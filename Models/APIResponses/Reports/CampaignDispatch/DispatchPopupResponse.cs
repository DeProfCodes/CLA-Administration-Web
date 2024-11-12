using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.CampaignDispatch
{
    public class DispatchPopupResponse
    {
        [JsonProperty("Environment")]
        public string? Environment { get; set; }

        [JsonProperty("Targeted")]
        public string? Targeted { get; set; }

        [JsonProperty("STM_User_Last_Modified")]
        public string? StmUserLastModified { get; set; }

        [JsonProperty("STM_Eff_From")]
        public DateTime? StmEffFrom { get; set; }

        [JsonProperty("STM_Eff_To")]
        public DateTime? StmEffTo { get; set; }

        [JsonProperty("STM_Timeslot_From")]
        public string? StmTimeslotFrom { get; set; }

        [JsonProperty("STM_Timeslot_To")]
        public string? StmTimeslotTo { get; set; }

        [JsonProperty("STM_Is_Automated")]
        public int? StmIsAutomated { get; set; }

        [JsonProperty("STM_Provider_ID")]
        public int? StmProviderId { get; set; }

        [JsonProperty("STM_Has_Linked_Blob")]
        public int? StmHasLinkedBlob { get; set; }

        [JsonProperty("STM_Linked_Blob_FileName")]
        public string? StmLinkedBlobFileName { get; set; }

        [JsonProperty("STM_Linked_Blob_Length")]
        public int? StmLinkedBlobLength { get; set; }

        [JsonProperty("STM_Has_Linked_URL")]
        public int? StmHasLinkedUrl { get; set; }

        [JsonProperty("STM_Linked_URL")]
        public string? StmLinkedUrl { get; set; }

        [JsonProperty("STM_Has_Linked_Survey")]
        public int? StmHasLinkedSurvey { get; set; }

        [JsonProperty("STM_Linked_Survey_ID")]
        public int? StmLinkedSurveyId { get; set; }

        [JsonProperty("STM_STM_ID")]
        public int? StmStmId { get; set; }

        [JsonProperty("STM_STM_Header")]
        public string? StmStmHeader { get; set; }

        [JsonProperty("STM_STM_Text")]
        public string? StmStmText { get; set; }

        [JsonProperty("STM_STM_IconType")]
        public int? StmStmIconType { get; set; }

        [JsonProperty("STM_STM_DisplayType")]
        public int? StmStmDisplayType { get; set; }

        [JsonProperty("STM_STM_LinkType")]
        public int? StmStmLinkType { get; set; }

        [JsonProperty("STM_STM_Icon_Length")]
        public int? StmStmIconLength { get; set; }

        [JsonProperty("STM_AutoHide")]
        public int? StmAutoHide { get; set; }

        [JsonProperty("STM_Snooze_Options")]
        public string? StmSnoozeOptions { get; set; }

        [JsonProperty("STM_Repeat_Frequency")]
        public int? StmRepeatFrequency { get; set; }

        [JsonProperty("STM_Repeat_Expiry")]
        public DateTime? StmRepeatExpiry { get; set; }

        [JsonProperty("STM_Repeat_Parent_Id")]
        public int? StmRepeatParentId { get; set; }

        [JsonProperty("STM_Critical_Snoozes")]
        public int? StmCriticalSnoozes { get; set; }

        [JsonProperty("STM_Critical_DateTime")]
        public DateTime? StmCriticalDateTime { get; set; }
    }
}
