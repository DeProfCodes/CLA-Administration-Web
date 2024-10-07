namespace CLA_Administration_Web.ViewModels.Modules.Components.Form
{
    public class HtmlEditorModel
    {
        public string EditorId { get; set; }

        public string WidthPx {get; set; }

        public string Css { get; set; }

        public int MaxCharacterCount { get; set; }

        public string HeightPx { get; set; }

        public bool WriteToDesitnationOnInput { get; set; }

        public string DestinationTextDivId { get; set; }

    }
}
