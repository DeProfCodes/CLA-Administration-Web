namespace CLA_Administration_Web.ViewModels.Settings.ManageAdminAccess
{
    public class AdminAccessItem
    {
        public int AdminID { get; set; }
        public string Domain { get; set; }
        public string Username { get; set; }

        // Desktop Permissions
        public string DesktopEnvironment { get; set; }
        public bool DesktopRead { get; set; }
        public bool DesktopWrite { get; set; }
        public bool DesktopReport { get; set; }

        // Tickers Permissions
        public string TickersEnvironment { get; set; }
        public bool TickersRead { get; set; }
        public bool TickersWrite { get; set; }
        public bool TickersReport { get; set; }

        // RSS Permissions
        public string RSS_Environment { get; set; }
        public bool RSS_Read { get; set; }
        public bool RSS_Write { get; set; }
        public bool RSS_Report { get; set; }

        // Lockscreen Permissions
        public string LockscreenEnvironment { get; set; }
        public bool LockscreenRead { get; set; }
        public bool LockscreenWrite { get; set; }
        public bool LockscreenReport { get; set; }

        public string UserLastModified { get; set; }
        public string MachineLastModified { get; set; }
    }
}
