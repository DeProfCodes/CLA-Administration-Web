using Newtonsoft.Json;
using System.ComponentModel;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Popup
{
    public class PopupReportAllData
    {
        [DisplayName("DOMAIN_ID")]
        [JsonProperty("domain_id")]
        public int? DomainId { get; set; }

        [DisplayName("POPUP ID")]
        [JsonProperty("STM_ID")]
        public int PopupId { get; set; }

        [DisplayName("POPUP HEADER")]
        [JsonProperty("STM_Title")]
        public string Title { get; set; }

        [DisplayName("POPUP TEXT")]
        [JsonProperty("STM_Text")]
        public string Text { get; set; }

        [DisplayName("USER_ID")]
        [JsonProperty("User_ID")]
        public string UserId { get; set; }

        [DisplayName("USER_NAME")]
        [JsonProperty("user_Name")]
        public string UserName { get; set; }

        [DisplayName("MACHINE_ID")]
        [JsonProperty("Machine_ID")]
        public string MachineId { get; set; }

        [DisplayName("MACHINE_NAME")]
        [JsonProperty("machine_Name")]
        public string MachineName { get; set; }

        [DisplayName("BUBBLE_SHOW_DATE")]
        [JsonProperty("Bubble_Show_DT")]
        public DateTime? BubbleShowDate { get; set; }

        [DisplayName("BUBBLE_CLICK_DATE")]
        [JsonProperty("Bubble_Click_DT")]
        public DateTime? BubbleClickDate { get; set; }

        [DisplayName("BUBBLE_DISMISS_DATE")]
        [JsonProperty("Bubble_Dismiss_DT")]
        public DateTime? BubbleDismissDate { get; set; }

        [DisplayName("BUBBLE_SNOOZE_DATE")]
        [JsonProperty("Bubble_Snooze_DT")]
        public DateTime? BubbleSnoozeDate { get; set; }

        [DisplayName("BUBBLE_RESHOW_DATE")]
        [JsonProperty("Bubble_ReShow_DT")]
        public DateTime? BubbleReShowDate { get; set; }

        [DisplayName("BUBBLE_AUTOHIDE_DATE")]
        [JsonProperty("Bubble_AutoHide_DT")]
        public DateTime? BubbleAutoHideDate { get; set; }

        [DisplayName("SNOOZE_COUNT")]
        [JsonProperty("Snooze_Count")]
        public int? SnoozeCount { get; set; }

        [DisplayName("FEEDBACK_LIKEDISLIKE")]
        [JsonProperty("Feedback_LikeDislike")]
        public string FeedbackLikeDislike { get; set; }

        [DisplayName("FEEDBACK_COMMENT")]
        [JsonProperty("Feedback_Comment")]
        public string FeedbackComment { get; set; }

        [DisplayName("EFF_FROM")]
        [JsonProperty("Eff_From")]
        public DateTime EffectiveFrom { get; set; }

        [DisplayName("EFF_TO")]
        [JsonProperty("Eff_To")]
        public DateTime EffectiveTo { get; set; }

        [DisplayName("TIMESLOT_FROM")]
        [JsonProperty("Timeslot_From")]
        public string TimeslotFrom { get; set; }

        [DisplayName("TIMESLOT_TO")]
        [JsonProperty("Timeslot_To")]
        public string TimeslotTo { get; set; }

        [DisplayName("LAST_UPDATE_DATE")]
        public string LastUpdateDate { get; set; }
    }
}
