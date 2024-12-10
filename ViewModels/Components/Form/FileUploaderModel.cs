namespace CLA_Administration_Web.ViewModels.Components.Form
{
    public class FileUploaderModel
    {
        public string ComponentId { get; set; }

        public string InputId { get; set; }

        public bool ShowPreviewButton { get; set; }

        public bool InitialHidden { get; set; }

        public string WidthPx { get; set; }

        public string WidthCss { get; set; }

        public string OnFileUploadCallback { get; set; }
    }
}
