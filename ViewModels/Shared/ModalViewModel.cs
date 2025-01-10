using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.ViewModels.Targeting;

namespace CLA_Administration_Web.ViewModels.Shared
{
    public class ModalViewModel
    {

        public string ModalId { get; set; }
        public string ModalLabelId { get; set; }
        public string ModalTitle { get; set; }
        public string ModalContainerId { get; set; }
        public string SaveButtonAction { get; set; }
        public string SaveButtonText { get; set; } = "Save";
        public string CancelButtonText { get; set; } = "Cancel";
        public string ModalSize { get; set; } = "modal-lg"; // e.g., modal-sm, modal-md, modal-lg ,
        public bool ShowSaveButton { get; set; } = true;
        public bool ShowCancelButton { get; set; } = true;
        public List<TargetedEntityTree> TargetedEntities { get; set; }
        public string CallbackFunction { get; set; }
        public ModuleNamesType ModuleName { get; set; }
        public List<TargetedEntityTree> TargetedAccepted { get; set; }

        public List<TargetedEntityTree> TargetedGroups { get; set; }

        public bool IsReadonly { get; set; }


    }
}
