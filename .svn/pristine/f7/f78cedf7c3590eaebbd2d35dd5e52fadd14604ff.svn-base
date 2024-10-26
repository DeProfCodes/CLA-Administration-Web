using CLA_Administration_Web.ViewModels.Reports;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CLA_Administration_Web.Helpers.Reporting
{
    public class ReportDataToJsonConvertor
    {
        public static string ConvertPopupResponseBreakdown(List<PopupResponseBreakDown> list)
        {
            var result = new List<object>();
            foreach (var item in list)
            {
                var jsonObject = new
                {
                    Eff_From = item.EffectiveFrom, 
                    Eff_To = item.EffectiveTo,
                    user_Name = item.Username,
                    machine_Name = item.MachineName,
                    Bubble_Show_DT = item.BubbleShowDT?.ToString("o"),
                    Bubble_Click_DT = item.BubbleClickDT?.ToString("o"),
                    Bubble_Dismiss_DT = item.BubbleDismissDT?.ToString("o"),
                    Bubble_Snooze_DT = item.BubbleSnoozeDT?.ToString("o"),
                    Bubble_AutoHide_DT = item.BubbleAutoHideDT?.ToString("o"),
                    Snooze_Count = item.SnoozeCount,
                    Feedback_LikeDislike = item.FeedbackLikeDislike,
                    Feedback_Comment = item.FeedbackComment,
                    Domain_ID = item.Domain,
                    user_ID = item.UserId,
                    machine_ID = item.MachineId,
                    Max_last_Update_DT = item.LastSyncDT?.ToString("o")
                };
                result.Add(jsonObject);
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            return JsonSerializer.Serialize(result, options);
        }

        public static string ConvertPopupSummary(PopupReportStatsMockViewModel model)
        {
            var result = new
            {
                Eff_From = model.EffectiveFrom,
                Eff_To = model.EffectiveTo,
                STM_ID = model.PopupId,
                STM_Title = model.PopupTitle,
                STM_Text = model.PopupText, // Example text
                Targeted = model.Targeted,
                Show = model.Show,
                Completed = model.Completed,
                Outstanding = model.Outstanding
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return JsonSerializer.Serialize(new[] { result }, options); // Serialize as an array
        }

        public static string ConvertToSecondJsonFormat(PopupReportStatsMockViewModel model)
        {
            var result = new
            {
                Eff_From = model.EffectiveFrom,
                Eff_To = model.EffectiveTo,
                STM_ID = model.PopupId,
                STM_Title = model.PopupTitle,
                STM_Text = model.PopupText, 
                Num_Targeted = model.Targeted,
                Perc_Show = model.Show,
                Click = model.Click,
                Perc_Click = model.Click,
                Dismiss = model.Dismiss,
                Perc_Dismiss = model.Dismiss,
                Snooze = model.Snooze,
                Perc_Snooze = model.Snooze,
                ReShow = model.Show, 
                Perc_ReShow = model.Show,
                Autohide = model.AutoHide,
                Perc_Autohide = model.AutoHide,
                No_Action = model.Outstanding, 
                Perc_No_Action = model.Outstanding
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return JsonSerializer.Serialize(new[] { result }, options); // Serialize as an array
        }
    }
}
