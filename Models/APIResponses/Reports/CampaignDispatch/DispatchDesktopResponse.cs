using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.CampaignDispatch
{
    public class DispatchDesktopResponse
    {
        [JsonProperty("Environment")]
        public string? Environment { get; set; }

        [JsonProperty("Targeted")]
        public string? Targeted { get; set; }

        [JsonProperty("Desktop_User_Last_Modified")]
        public string? DesktopUserLastModified { get; set; }

        [JsonProperty("Desktop_Eff_From")]
        public DateTime? DesktopEffFrom { get; set; }

        [JsonProperty("Desktop_Eff_To")]
        public DateTime? DesktopEffTo { get; set; }

        [JsonProperty("Desktop_Timeslot_From")]
        public string? DesktopTimeslotFrom { get; set; }

        [JsonProperty("Desktop_Timeslot_To")]
        public string? DesktopTimeslotTo { get; set; }

        [JsonProperty("Desktop_Is_Automated")]
        public int? DesktopIsAutomated { get; set; }

        [JsonProperty("Desktop_Advert_Description")]
        public string? DesktopAdvertDescription { get; set; }

        [JsonProperty("Desktop_Advert_ID")]
        public int? DesktopAdvertId { get; set; }

        [JsonProperty("Desktop_Description")]
        public string? DesktopDescription { get; set; }

        [JsonProperty("Desktop_Desktop_Header_ID")]
        public int? DesktopHeaderId { get; set; }

        [JsonProperty("Desktop_Desktop_Position")]
        public int? DesktopPosition { get; set; }
    }
}
