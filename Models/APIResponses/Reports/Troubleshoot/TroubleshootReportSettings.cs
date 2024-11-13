using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Troubleshoot
{
    public class TroubleshootReportSettings
    {
        [JsonProperty("Screensaver_Timeout")]
        public int? ScreensaverTimeout { get; set; }

        [JsonProperty("PopUp_Timeout")]
        public int? PopUpTimeout { get; set; }

        [JsonProperty("Ticker_Timeout")]
        public int? TickerTimeout { get; set; }

        [JsonProperty("Desktop_Timeout")]
        public int? DesktopTimeout { get; set; }

        [JsonProperty("Sync_Timeout")]
        public int? SyncTimeout { get; set; }

        [JsonProperty("Sync_Timeslot_From")]
        public string? SyncTimeslotFrom { get; set; }

        [JsonProperty("Sync_Timeslot_To")]
        public string? SyncTimeslotTo { get; set; }

        [JsonProperty("PolicyControlledScreensaver")]
        public int? PolicyControlledScreensaver { get; set; }

        [JsonProperty("AllowTickerToLaunchAutomatically")]
        public int? AllowTickerToLaunchAutomatically { get; set; }

        [JsonProperty("UpdateFutureContent")]
        public int? UpdateFutureContent { get; set; }

        [JsonProperty("NoDispScrSavPage")]
        public int? NoDispScrSavPage { get; set; }

        [JsonProperty("ScreenSaverIsSecure")]
        public int? ScreenSaverIsSecure { get; set; }

        [JsonProperty("ImpressionLogging")]
        public int? ImpressionLogging { get; set; }

        [JsonProperty("MaintainAspectRatio")]
        public int? MaintainAspectRatio { get; set; }

        [JsonProperty("ErrorLogging")]
        public int? ErrorLogging { get; set; }

        [JsonProperty("AD_Targeting")]
        public int? ADTargeting { get; set; }

        [JsonProperty("ScreensaverUpdateInterval")]
        public string? ScreensaverUpdateInterval { get; set; }

        [JsonProperty("SurveyFont")]
        public string? SurveyFont { get; set; }

        [JsonProperty("Network")]
        public string? Network { get; set; }

        [JsonProperty("MaximumAllowedConnections")]
        public int? MaximumAllowedConnections { get; set; }

        [JsonProperty("ScreensaverBackgroundColor")]
        public int? ScreensaverBackgroundColor { get; set; }

        [JsonProperty("DesktopBackgroundColor")]
        public int? DesktopBackgroundColor { get; set; }

        [JsonProperty("UseMachineID")]
        public int? UseMachineID { get; set; }

        [JsonProperty("Use_Audio")]
        public string? UseAudio { get; set; }

        [JsonProperty("DesktopIsSecure")]
        public int? DesktopIsSecure { get; set; }

        [JsonProperty("Process_Exclusions")]
        public string? ProcessExclusions { get; set; }

        [JsonProperty("ClientComponents")]
        public string? ClientComponents { get; set; }

        [JsonProperty("Popup_Position")]
        public int? PopupPosition { get; set; }

        [JsonProperty("Enable_Desktop_Info")]
        public int? EnableDesktopInfo { get; set; }

        [JsonProperty("Info_Position")]
        public int? InfoPosition { get; set; }

        [JsonProperty("Show_CPU")]
        public int? ShowCPU { get; set; }

        [JsonProperty("Show_Domain")]
        public int? ShowDomain { get; set; }

        [JsonProperty("Show_Domain_Controller")]
        public int? ShowDomainController { get; set; }

        [JsonProperty("Show_HDD")]
        public int? ShowHDD { get; set; }

        [JsonProperty("Show_IP")]
        public int? ShowIP { get; set; }

        [JsonProperty("Show_Last_Boot_Time")]
        public int? ShowLastBootTime { get; set; }

        [JsonProperty("Show_Machine")]
        public int? ShowMachine { get; set; }

        [JsonProperty("Show_Network")]
        public int? ShowNetwork { get; set; }

        [JsonProperty("Show_OS")]
        public int? ShowOS { get; set; }

        [JsonProperty("Show_Ram")]
        public int? ShowRam { get; set; }

        [JsonProperty("Show_Serial_Number")]
        public int? ShowSerialNumber { get; set; }

        [JsonProperty("Show_User")]
        public int? ShowUser { get; set; }

        [JsonProperty("Targeted_For_Desktop_Info")]
        public int? TargetedForDesktopInfo { get; set; }
    }
}
