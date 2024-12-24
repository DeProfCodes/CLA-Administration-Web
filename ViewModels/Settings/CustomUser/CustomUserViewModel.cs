namespace CLA_Administration_Web.ViewModels.Settings.CustomUser
{
    public class CustomUserViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ScreensaverTimeout { get; set; }
        public string PopupTimeout { get; set; }
        public string DeskTopTimeout { get; set; }
        public string TickerTimeout { get; set; }
        public string SyncTimeout { get; set; }
        public string Network { get; set; }
        public bool PolicyControlledScreenSaver { get; set; }
        public bool AllowTicker { get; set; }
        public bool UpdateFutureContent { get; set; }
        public bool ChangeScreenSaver { get; set; }
        public bool PasswordProtectScreensaver { get; set; }
        public bool OverrideDesktop { get; set; }
    }
}
