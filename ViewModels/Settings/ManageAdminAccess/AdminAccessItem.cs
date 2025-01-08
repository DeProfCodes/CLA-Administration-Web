namespace CLA_Administration_Web.ViewModels.Settings.ManageAdminAccess
{
    public class AdminAccessItem
    {
        public int AdminID { get; set; }
        public string Domain { get; set; }
        public string Username { get; set; }

        // Desktop Permissions
        public string DesktopEnvironment { get; set; }
        public string DesktopRead { get; set; }
        public string DesktopWrite { get; set; }
        public string DesktopReport { get; set; }

        // Tickers Permissions
        public string TickersEnvironment { get; set; }
        public string TickersRead { get; set; }
        public string TickersWrite { get; set; }
        public string TickersReport { get; set; }

        // RSS Permissions
        public string RSS_Environment { get; set; }
        public string RSS_Read { get; set; }
        public string RSS_Write { get; set; }
        public string RSS_Report { get; set; }

        // Lockscreen Permissions
        public string LockscreenEnvironment { get; set; }
        public string LockscreenRead { get; set; }
        public string LockscreenWrite { get; set; }
        public string LockscreenReport { get; set; }

        public string UserLastModified { get; set; }
        public string MachineLastModified { get; set; }
    }
}
