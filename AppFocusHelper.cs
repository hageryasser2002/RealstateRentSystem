// AppFocusHelper.cs
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

public static class AppFocusHelper
{
    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    public static bool IsAppActive()
    {
        IntPtr foregroundWindow = GetForegroundWindow();
        if (foregroundWindow == IntPtr.Zero)
            return false;

        GetWindowThreadProcessId(foregroundWindow, out uint processId);
        return processId == (uint)Process.GetCurrentProcess().Id;
    }
}
