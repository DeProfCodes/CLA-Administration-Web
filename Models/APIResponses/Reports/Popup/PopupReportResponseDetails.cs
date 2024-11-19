using CLA_Administration_Web.Helpers.Reporting;
using Newtonsoft.Json;
using System.ComponentModel;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Popup
{
    public class PopupReportResponseDetails
    {
        [DisplayName("Domain")]
        [JsonProperty("Domain_ID")]
        public string? Domain { get; set; }

        [DisplayName("UserID")]
        [JsonProperty("user_ID")]
        public string? UserId { get; set; }

        [DisplayName("UserName")]
        [JsonProperty("user_Name")]
        public string? UserName { get; set; }

        [DisplayName("MachineID")]
        [JsonProperty("machine_ID")]
        public string? MachineId { get; set; }

        [DisplayName("MachineName")]
        [JsonProperty("machine_Name")]
        public string? MachineName { get; set; }

        [DisplayName("Bubble Show DT")]
        [JsonProperty("Bubble_Show_DT")]
        public DateTime? BubbleShowDate { get; set; }

        [DisplayName("Bubble Dismiss DT")]
        [JsonProperty("Bubble_Dismiss_DT")]
        public DateTime? BubbleDismissDate { get; set; }

        [DisplayName("Bubble Click DT")]
        [JsonProperty("Bubble_Click_DT")]
        public DateTime? BubbleClickDate { get; set; }

        [DisplayName("Bubble Snooze DT")]
        [JsonProperty("Bubble_Snooze_DT")]
        public DateTime? BubbleSnoozeDate { get; set; }

        [DisplayName("Bubble AutoHide DT")]
        [JsonProperty("Bubble_AutoHide_DT")]
        public DateTime? BubbleAutoHideDate { get; set; }

        [DisplayName("Feedback: Like/Dislike")]
        [JsonProperty("Feedback_LikeDislike")]
        public string? FeedbackLikeDislike { get; set; }

        [DisplayName("Feedback: Comment")]
        [JsonProperty("Feedback_Comment")]
        public string? FeedbackComment { get; set; }

        [DisplayName("LastSyncDT")]
        [JsonProperty("Max_last_Update_DT")]
        public DateTime? MaxLastUpdateDate { get; set; }

        [DisplayName("")]
        [SkipProperty]
        [JsonProperty("Snooze_Count")]
        public int? SnoozeCount { get; set; }

        [DisplayName("")]
        [SkipProperty]
        [JsonProperty("Eff_From")]
        public DateTime? EffectiveFrom { get; set; }

        [DisplayName("")]
        [SkipProperty]
        [JsonProperty("Eff_To")]
        public DateTime? EffectiveTo { get; set; }
    }
}
