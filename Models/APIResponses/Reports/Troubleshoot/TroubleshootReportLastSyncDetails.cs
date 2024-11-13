using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Troubleshoot
{
    public class TroubleshootReportLastSyncDetails
    {
        [JsonProperty("Last_Update_DT")]
        public DateTime? LastUpdateDT { get; set; }

        [JsonProperty("User_ID")]
        public string? UserID { get; set; }

        [JsonProperty("Machine_ID")]
        public string? MachineID { get; set; }

        [JsonProperty("IP_Address")]
        public string? IPAddress { get; set; }

        [JsonProperty("Last_STM_ID")]
        public int? LastSTMID { get; set; }

        [JsonProperty("Popup_Title")]
        public string? PopupTitle { get; set; }

        [JsonProperty("Last_STM_DT")]
        public DateTime? LastSTMDT { get; set; }

        [JsonProperty("Last_Survey_ID")]
        public int? LastSurveyID { get; set; }

        [JsonProperty("Survey_Title")]
        public string? SurveyTitle { get; set; }

        [JsonProperty("Last_Survey_DT")]
        public DateTime? LastSurveyDT { get; set; }

        [JsonProperty("MSDIM_Version")]
        public DateTime? MSDIMVersion { get; set; }

        [JsonProperty("MSDIMSVC_Version")]
        public DateTime? MSDIMSVCVersion { get; set; }

        [JsonProperty("MSDIMSYNC_Version")]
        public DateTime? MSDIMSYNCVersion { get; set; }

        [JsonProperty("MSDIM_Version_SF")]
        public string? MSDIMVersionSF { get; set; }

        [JsonProperty("MSDIMSVC_Version_SF")]
        public string? MSDIMSVCVersionSF { get; set; }

        [JsonProperty("MSDIMSYNC_Version_SF")]
        public string? MSDIMSYNCVersionSF { get; set; }

        [JsonProperty("InPresentationFullScreenMode")]
        public bool? InPresentationFullScreenMode { get; set; }

        [JsonProperty("InPresentationFullScreenModeReasons")]
        public string? InPresentationFullScreenModeReasons { get; set; }
    }
}
