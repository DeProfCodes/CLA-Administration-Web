namespace CLA_Administration_Web.ViewModels.Settings.Shared
{
    public class SettingsModalView
    {
        public string ModalId { get; set; }
        public string ModalTitle { get; set; }
        public List<FormField> FormFields { get; set; }
        public string ActionButtonText { get; set; }
        public string ActionButtonCallbackFunction { get; set; }
        public string EntityType { get; set; }
    }

    public class FormField
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
    }
}
