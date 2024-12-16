using CLA_Administration_Web.Helpers.Enums.Module;
using CLA_Administration_Web.ViewModels.Shared;
using CLAModulesLibrary.Helpers.Enums.Modules.Popup;
using CLAModulesLibrary.Models.Popup.SubModels;

namespace CLA_Administration_Web.ViewModels.Modules.PST
{
    /// <summary>
    /// Module View Model for the modules: Popup, Survey, Ticker (PST)
    /// </summary>
    public class ModulePSTDataViewModel
    {
        public int Id { get; set; }

        public string HeaderText { get; set; }

        public string BodyText { get; set; }

        public string ConclusionText { get; set; }

        public bool DisplayHeaderText { get; set; }

        public bool DisplayBodyText { get; set; }

        public bool DisplayConclusionText { get; set; }

        public string ModuleSkinUrl { get; set; }

        //Popup only
        public PopupIconType PopupIcon { get; set; }

        public PopupDisplayTypes PopupDisplayType { get; set; }

        public int PopupAutoHideSeconds { get; set; }

        public int PopupPosition { get; set; }

        public FeedbackSettings PopupFeedback { get; set; }

        public string EffectiveFrom { get; set; }

        public string EffectiveTo { get; set; }

        public DateTime EffectiveFromDate { get; set; }

        public DateTime EffectiveToDate { get; set; }

        public string TimeslotFrom { get; set; }

        public string TimeslotTo { get; set; }

        public StatusViewModel Status { get; set; }

        public string LastModifiedDate { get; set; }

        public string UserIdLastModified { get; set; }

        public string MachineLastModified { get; set; }
    }
}
