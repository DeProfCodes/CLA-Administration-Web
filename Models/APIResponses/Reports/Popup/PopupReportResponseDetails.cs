using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Popup
{
    public class PopupReportResponseDetails
    {
        [JsonProperty("user_Name")]
        public string UserName { get; set; }

        [JsonProperty("machine_Name")]
        public string MachineName { get; set; }

        [JsonProperty("Bubble_Show_DT")]
        public DateTime? BubbleShowDate { get; set; }

        [JsonProperty("Bubble_Click_DT")]
        public DateTime? BubbleClickDate { get; set; }

        [JsonProperty("Bubble_Dismiss_DT")]
        public DateTime? BubbleDismissDate { get; set; }

        [JsonProperty("Bubble_Snooze_DT")]
        public DateTime? BubbleSnoozeDate { get; set; }

        [JsonProperty("Bubble_AutoHide_DT")]
        public DateTime? BubbleAutoHideDate { get; set; }

        [JsonProperty("Snooze_Count")]
        public int? SnoozeCount { get; set; }

        [JsonProperty("Feedback_LikeDislike")]
        public string FeedbackLikeDislike { get; set; }

        [JsonProperty("Feedback_Comment")]
        public string FeedbackComment { get; set; }

        [JsonProperty("Domain_ID")]
        public string DomainId { get; set; }

        [JsonProperty("user_ID")]
        public string UserId { get; set; }

        [JsonProperty("machine_ID")]
        public string MachineId { get; set; }

        [JsonProperty("Max_last_Update_DT")]
        public DateTime? MaxLastUpdateDate { get; set; }

        [JsonProperty("Eff_From")]
        public DateTime EffectiveFrom { get; set; }

        [JsonProperty("Eff_To")]
        public DateTime EffectiveTo { get; set; }
    }
}
