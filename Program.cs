using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

class Program
{
    [DllImport("user32.dll")]
    static extern int GetSystemMetrics(int index);

    const int SM_CXSCREEN = 0;

    static void Main()
    {
        int width = GetSystemMetrics(SM_CXSCREEN);
        // using https://nircmd.nirsoft.net/setdisplay.html library to change resolution
        string exePath = @"C:\Tools\nircmd\nircmd.exe";
        string args = width > 3000
            ? "setdisplay 2560 1440 32 120"
            : "setdisplay 3440 1440 32 100";

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = args,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            }
        };

        process.Start();
    }
}