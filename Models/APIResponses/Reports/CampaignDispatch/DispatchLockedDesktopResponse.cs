using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.CampaignDispatch
{
    public class DispatchLockedDesktopResponse
    {
        [JsonProperty("Environment")]
        public string? Environment { get; set; }

        [JsonProperty("Targeted")]
        public string? Targeted { get; set; }

        [JsonProperty("Locked_Desktop_User_Last_Modified")]
        public string? LockedDesktopUserLastModified { get; set; }

        [JsonProperty("Locked_Desktop_Eff_From")]
        public DateTime? LockedDesktopEffFrom { get; set; }

        [JsonProperty("Locked_Desktop_Eff_To")]
        public DateTime? LockedDesktopEffTo { get; set; }

        [JsonProperty("Locked_Desktop_Timeslot_From")]
        public string? LockedDesktopTimeslotFrom { get; set; }

        [JsonProperty("Locked_Desktop_Timeslot_To")]
        public string? LockedDesktopTimeslotTo { get; set; }

        [JsonProperty("Locked_Desktop_Is_Automated")]
        public int? LockedDesktopIsAutomated { get; set; }

        [JsonProperty("Locked_Desktop_Advert_Description")]
        public string? LockedDesktopAdvertDescription { get; set; }

        [JsonProperty("Locked_Desktop_Advert_ID")]
        public int? LockedDesktopAdvertId { get; set; }

        [JsonProperty("Locked_Desktop_Description")]
        public string? LockedDesktopDescription { get; set; }

        [JsonProperty("Locked_Desktop_Header_ID")]
        public int? LockedDesktopHeaderId { get; set; }

        [JsonProperty("Locked_Desktop_Position")]
        public int? LockedDesktopPosition { get; set; }
    }
}
