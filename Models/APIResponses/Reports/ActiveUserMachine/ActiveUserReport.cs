using Newtonsoft.Json;
using System.ComponentModel;

namespace CLA_Administration_Web.Models.APIResponses.Reports.ActiveUserMachine
{
    public class ActiveUserReport
    {
        [DisplayName("Domain")]
        [JsonProperty("Domain_ID")]
        public int? DomainId { get; set; }

        [DisplayName("User ID")]
        [JsonProperty("User_ID")]
        public string? UserId { get; set; }

        [DisplayName("User Name")]
        [JsonProperty("User_Name")]
        public string? UserName { get; set; }

        [DisplayName("Last Machine Used")]
        [JsonProperty("Last_Machine")]
        public string? LastMachine { get; set; }

        [DisplayName("Last Sync DT")]
        [JsonProperty("Max_Update_DT")]
        public DateTime? MaxUpdateDt { get; set; }

        [DisplayName("Last Screensaver Pull")]
        [JsonProperty("Max_SCR_Pull")]
        public DateTime? MaxScrPull { get; set; }

        [DisplayName("Last Online Screen")]
        [JsonProperty("Max_Online_Screen")]
        public DateTime? MaxOnlineScreen { get; set; }

        [DisplayName("Last Offline Screen")]
        [JsonProperty("Max_Offline_Screen")]
        public DateTime? MaxOfflineScreen { get; set; }

        [DisplayName("Last Popup Pull")]
        [JsonProperty("Max_Pop_Pull")]
        public DateTime? MaxPopPull { get; set; }

        [DisplayName("Last Popup")]
        [JsonProperty("Max_Pop")]
        public DateTime? MaxPop { get; set; }

        [DisplayName("Last Survey Pull")]
        [JsonProperty("Max_Survey_Pull")]
        public DateTime? MaxSurveyPull { get; set; }

        [DisplayName("Last Survey")]
        [JsonProperty("Max_Survey")]
        public DateTime? MaxSurvey { get; set; }

        [DisplayName("Last Desktop Pull")]
        [JsonProperty("Max_Desk_Pull")]
        public DateTime? MaxDeskPull { get; set; }

        [DisplayName("Last Desktop")]
        [JsonProperty("Max_Desktop")]
        public DateTime? MaxDesktop { get; set; }

        [DisplayName("Last Offline Desktop")]
        [JsonProperty("Max_Offline_Desktop")]
        public DateTime? MaxOfflineDesktop { get; set; }

        [DisplayName("Last Ticker Pull")]
        [JsonProperty("Max_Ticker_Pull")]
        public DateTime? MaxTickerPull { get; set; }

        [DisplayName("Last Ticker")]
        [JsonProperty("Max_Ticker")]
        public DateTime? MaxTicker { get; set; }

        [DisplayName("Last Lockscreen Pull")]
        [JsonProperty("Max_Lockscreen_Pull")]
        public DateTime? MaxLockscreenPull { get; set; }

        [DisplayName("Last Lockscreen")]
        [JsonProperty("Max_Lockscreen")]
        public DateTime? MaxLockscreen { get; set; }

        [DisplayName("Last Offline Lockscreen")]
        [JsonProperty("Max_Offline_Lockscreen")]
        public DateTime? MaxOfflineLockscreen { get; set; }

        [DisplayName("Is In Presentation / Fullscreen Mode")]
        [JsonProperty("InPresentationFullscreenMode")]
        public int? InPresentationFullscreenMode { get; set; }

        [DisplayName("Is In Presentation / Fullscreen Mode Reason(s)")]
        [JsonProperty("InPresentationFullscreenModeReasons")]
        public string? InPresentationFullscreenModeReasons { get; set; }

    }
}
