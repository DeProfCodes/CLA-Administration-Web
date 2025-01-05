namespace CLA_Administration_Web.ViewModels.Settings.DefaultFonts
{
    public class SubHeadingViewModel
    {
        public int SubId { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
        public string HeadingFontFamily { get; set; } = "Arial";
        public int FontSize { get; set; } = 16;
        public string FontWeight { get; set; } = "normal";
        public string FontStyle { get; set; } = "normal";
        public string TextColor { get; set; } = "#000000";
        public string BackgroundColor { get; set; } = "#FFFFFF";
    }
    public class DefaultFontsViewModel
    {
        public int Id { get; set; }
        public string DefaultHeading { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }

       
        public List<SubHeadingViewModel> SubHeadings { get; set; }
    }



}
