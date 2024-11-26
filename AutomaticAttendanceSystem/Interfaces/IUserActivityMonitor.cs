namespace AutomaticAttendanceSystem.Interfaces
{
    /// <summary>
    /// 提供使用者活動監控相關功能的服務介面。
    /// </summary>
    public interface IUserActivityMonitor
    {
        /// <summary>
        /// 獲取使用者活動狀態訊息，包括是否正在使用電腦以及當前前景程式名稱。
        /// </summary>
        /// <returns>使用者活動狀態訊息 <see cref="IUserActivityMonitor.UserActivityStatus"/>。</returns>
        public UserActivityStatus GetUserActivityStatus();

        /// <summary>
        /// 使用者活動狀態的資料結構
        /// </summary>
        public class UserActivityStatus
        {
            /// <summary>
            /// 使用者是否正在使用電腦。
            /// </summary>
            public bool IsActive { get; set; }

            /// <summary>
            /// 當前前景程式的名稱。
            /// </summary>
            public string ActiveProcessName { get; set; }
        }
    }
}
