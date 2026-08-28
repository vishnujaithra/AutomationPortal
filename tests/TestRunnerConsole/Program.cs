using System;
using System.Diagnostics;

public partial class Program
{
    static void Main(string[] args)
    {
        var testRunnerPath = "C:\\Users\\CA_OHPNM_DEV_11\\source\\repos\\p3\\ohpnm-automation\\AutomationAPI\\NUnit.Console-3.18.3\\bin\\net8.0\\nunit3-console.exe";
        var testAssemblyPath = "C:\\Users\\CA_OHPNM_DEV_11\\source\\repos\\p3\\ohpnm-automation\\OhpnmAutomation\\bin\\Debug\\net8.0\\OhpnmAutomation.dll";

        var processInfo = new ProcessStartInfo
        {
            FileName = testRunnerPath,
            Arguments = $"--params:TestParameters=Test {testAssemblyPath}",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
        };
        using (var process = Process.Start(processInfo))
        {
            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();
            process.WaitForExit();
            process.Kill();
        }
    }
}




