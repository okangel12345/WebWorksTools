using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WebWorks.Utilities
{
    internal class GameLaunchHelper
    {
        // Import necessary WinAPI functions
        //------------------------------------------------------------------------------------------
        #region Windows APIs functions

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        const int GWL_STYLE = -16;
        const int WS_CAPTION = 0x00C00000;
        const int WS_THICKFRAME = 0x00040000;

        #endregion

        // Load game and parent
        //------------------------------------------------------------------------------------------
        public static async Task LoadGameAsync(string executablePath, string Args, string targetProcessName, Panel panel1, Label Log)
        {
            try
            {
                if (!File.Exists(executablePath))
                {
                    Log.Text = $"The executable was not found at: {executablePath}";
                    return;
                }

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = executablePath,
                    Arguments = Args,
                    WindowStyle = ProcessWindowStyle.Minimized
                };

                Process launcherProcess = null;
                try
                {
                    launcherProcess = Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    Log.Text = $"Failed to start the program: {ex.Message}";
                    return;
                }

                if (launcherProcess == null)
                {
                    Log.Text = "Failed to start the program. Process object is null.";
                    return;
                }

                Thread.Sleep(2000);

                ParentToWindow(targetProcessName, panel1, Log);
            }
            catch (Exception ex)
            {
                Log.Text = $"Error loading game: {ex.Message}";
            }
        }

        // Simple parent
        //------------------------------------------------------------------------------------------
        public static async Task ParentProcessToPanelAsync(string targetProcessName, Panel panel1, Label Log)
        {
            try
            {
                ParentToWindow(targetProcessName, panel1, Log);
            }
            catch (Exception ex)
            {
                Log.Text = $"Error parenting process to panel: {ex.Message}";
            }
        }

        // Parent to window
        //------------------------------------------------------------------------------------------
        private static async void ParentToWindow(string targetProcessName, Panel panel1, Label Log)
        {
            Process targetProcess = null;
            int retryCount = 20;
            int delay = 1000;

            for (int i = 0; i < retryCount; i++)
            {
                targetProcess = Process.GetProcessesByName(targetProcessName).FirstOrDefault();
                if (targetProcess != null)
                {
                    break;
                }
                await Task.Delay(delay);
            }

            if (targetProcess == null)
            {
                Log.Text = ($"Failed to find the target process '{targetProcessName}' after multiple attempts.");
                return;
            }

            IntPtr targetHandle = targetProcess.MainWindowHandle;
            if (targetHandle == IntPtr.Zero)
            {
                Log.Text = $"Failed to retrieve the target window handle for '{targetProcessName}'.";
                return;
            }

            SetParent(targetHandle, panel1.Handle);

            int style = GetWindowLong(targetHandle, GWL_STYLE);
            style &= ~(WS_CAPTION | WS_THICKFRAME);
            SetWindowLong(targetHandle, GWL_STYLE, style);

            panel1.Resize += (sender, e) =>
            {
                MoveWindow(targetHandle, 0, 0, panel1.Width, panel1.Height, true);
            };
            MoveWindow(targetHandle, 0, 0, panel1.Width, panel1.Height, true);
        }
    }
}
