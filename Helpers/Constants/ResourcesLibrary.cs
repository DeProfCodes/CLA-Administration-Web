namespace CLA_Administration_Web.Helpers.Constants
{
    public class ResourcesLibrary
    {
        public class ModulesLibrary
        {
            public class Icons
            {
                public readonly static string PopupBaseAddress = $"{LaunchSettingsHelper.GetBaseAddressForImages()}/images/icons/modules/popup";
            }

            public class Skins
            {
                public readonly static string PopupDefaultSkin = $"{LaunchSettingsHelper.GetBaseAddressForImages()}/images/others/modules/skins/Popup_Skin_default.png";

                public readonly static string SurveyDefaultSkin = $"{LaunchSettingsHelper.GetBaseAddressForImages()}/images/others/modules/skins/SurveyBackground.bmp";
            }
        }
    }
}
