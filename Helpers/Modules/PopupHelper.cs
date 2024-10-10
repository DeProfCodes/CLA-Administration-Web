using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.ViewModels.Modules.PST;
using CLACommonFunctionsLibrary_NET.Helpers.Enums;
using CLAModulesLibrary.Helpers.Enums.Modules.Popup;
using CLAModulesLibrary.Models.Popup.SubModels;

namespace CLA_Administration_Web.Helpers.Modules
{
    public class PopupHelper
    {
        public static List<ModuleSkinViewModel> GetPopupAvailableSkins()
        {
            return new List<ModuleSkinViewModel>
            {
                new ModuleSkinViewModel
                {
                    Filename = "Default",
                    FileURL = $"{LaunchSettingsHelper.GetBaseAddressForImages()}/images/others/modules/skins/Popup_Skin_Default.png"
                },
                new ModuleSkinViewModel
                {
                    Filename = "Popup_Skin_90_456_654",
                    FileURL = $"{LaunchSettingsHelper.GetBaseAddressForImages()}/images/others/modules/skins/Popup_Skin_Test_1.BMP"
                },
                new ModuleSkinViewModel
                {
                    Filename = "Pick_N_Pay_June_Skin",
                    FileURL = $"{LaunchSettingsHelper.GetBaseAddressForImages()}/images/others/modules/skins/Popup_Skin_Test_2.BMP"
                },
                new ModuleSkinViewModel
                {
                    Filename = "INC_Default_Skin",
                    FileURL = $"{LaunchSettingsHelper.GetBaseAddressForImages()}/images/others/modules/skins/Popup_Skin_Test_3.BMP"
                },
            };
        }

        public static string GetPopupDisplayTypeString(PopupDisplayTypes displayType)
        {
            var displayTypeStr = displayType.GetDisplayName().Split(";");

            return string.Join(" | ", displayTypeStr);
        }

        public static string GetPopupPositionString(int popupPosition)
        {
            switch (popupPosition)
            {
                case 0: return "Top Left";
                case 1: return "Top Center";
                case 2: return "Top Right";
                case 3: return "Middle Left";
                case 4: return "Middle Center";
                case 5: return "Middle Right";
                case 6: return "Bottom Left";
                case 7: return "Bottom Center";
                case 8: return "Bottom Right";

                default: return "Bottom Right";
            }
        }

        public static string GetPopupFeedbackTypeString(FeedbackSettings feedback)
        {
            var feedbackOptions = new List<string>();

            if (feedback.RequireFeedbackLikeDislike) feedbackOptions.Add("Like/Dislike");
            if (feedback.RequireFeedbackComment) feedbackOptions.Add("Comment");

            var feedbackStr = feedbackOptions.Count > 0 ? string.Join(" | ", feedbackOptions) : "No Feedback";
            
            return feedbackStr;
        }

    }
}
