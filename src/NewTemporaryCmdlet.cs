using System.IO;
using System.Management.Automation;

namespace aquanjsw.PowerShell.Utility
{
  [Cmdlet(VerbsCommon.New, "Temporary")]
  [Alias("nt")]
  [OutputType(typeof(string))]
  public class NewTemporaryCmdlet : PSCmdlet
  {
    [Parameter(Mandatory = false)]
    public SwitchParameter Directory { get; set; } = false;

    [Parameter(Mandatory = false, HelpMessage = "The suffix to use for the temporary file or directory.")]
    public string Suffix { get; set; } = "";

    [Parameter(Mandatory = false)]
    public SwitchParameter DryRun { get; set; }


    // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
    protected override void BeginProcessing()
    {
      WriteVerbose("Begin!");
    }

    // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
    protected override void ProcessRecord()
    {
      var rootTempDir = Path.GetTempPath();
      var basename = Path.GetRandomFileName() + Suffix;
      var path = Path.Combine(rootTempDir, basename);

      if (!DryRun && Directory)
      {
        System.IO.Directory.CreateDirectory(path);
      }

      WriteObject(path);
    }

    // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
    protected override void EndProcessing()
    {
      WriteVerbose("End!");
    }
  }
}

