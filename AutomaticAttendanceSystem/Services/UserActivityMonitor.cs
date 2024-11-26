using AutomaticAttendanceSystem.Interfaces;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AutomaticAttendanceSystem.Services
{
    public class UserActivityMonitor : IUserActivityMonitor
    {
        /// <summary>
        /// 獲取使用者活動狀態訊息，包括是否正在使用電腦以及當前前景程式名稱。
        /// </summary>
        /// <returns>使用者活動狀態訊息 <see cref="IUserActivityMonitor.UserActivityStatus"/>。</returns>
        public IUserActivityMonitor.UserActivityStatus GetUserActivityStatus()
        {
            return new IUserActivityMonitor.UserActivityStatus
            {
                IsActive = IsUsingComputer(),
                ActiveProcessName = GetActiveProcessName()
            };
        }

        /// <summary>
        /// 根據閒置時間判斷使用者是否正在使用電腦。
        /// </summary>
        /// <param name="idleTimeThreshold">判斷是否使用電腦的閒置時間閾值（單位：毫秒，預設為1000毫秒）。</param>
        /// <returns>如果使用者在指定閒置時間內有操作則返回 true，否則返回 false。</returns>
        private static bool IsUsingComputer(uint idleTimeThreshold = 1000)
        {
            try
            {
                var lastInputInfo = new LASTINPUTINFO();
                lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
                if (GetLastInputInfo(ref lastInputInfo))
                {
                    var idleTime = (uint)Environment.TickCount - lastInputInfo.dwTime;
                    return idleTime < idleTimeThreshold;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 獲取當前處於前景視窗的程式名稱。
        /// </summary>
        /// <returns>目前前景程式的名稱，若無法獲取則返回 null。</returns>
        private static string GetActiveProcessName()
        {
            try
            {
                var foregroundWindowHandle = GetForegroundWindow();
                if (foregroundWindowHandle != IntPtr.Zero)
                {
                    _ = GetWindowThreadProcessId(foregroundWindowHandle, out var processId);
                    var activeProcess = Process.GetProcessById(processId);
                    return activeProcess.ProcessName;
                }
                else
                {
                    return default;
                }
            }
            catch (Exception)
            {
                return default;
            }
        }

        #region user32.dll

        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [StructLayout(LayoutKind.Sequential)]
        private struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        #endregion
    }
}
