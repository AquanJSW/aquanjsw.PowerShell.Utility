# My PowerShell Utilities

## Steps to add new functions

1. Implement new class library under `src` folder like `NewTemporaryCmdlet.cs`
2. Modify the `.psd1` file under `aquanjsw.PowerShell.Utility` folder to reflect
   your changes (mainly the `NestedModules` and `FunctionsToExport` sections)
   like:

   ```powershell
   NestedModules = @('bin\NewTemporaryCmdlet.dll', 'bin\GetSomethingCmdlet.dll')
   FunctionsToExport = @('New-Temporary', 'Get-Something')
   ```

3. Build the project using `.\build.ps1` script, you can test on the current
   shell session.
4. Publish to PS Gallery using `.\publish.ps1`, which assuming you have already
   set the `PSGALLERY_KEY` environment variable.

## References

- [How to create a Standard Library binary module](https://learn.microsoft.com/en-us/powershell/scripting/dev-cross-plat/create-standard-library-binary-module?view=powershell-7.4)