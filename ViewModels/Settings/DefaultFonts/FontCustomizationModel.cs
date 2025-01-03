namespace CLA_Administration_Web.ViewModels.Settings.DefaultFonts
{
    public class FontCustomizationModel
    {
        public int Id { get; set; }
        public string HeadingFontFamily { get; set; } = "Arial";
        public int FontSize { get; set; } = 16;
        public string FontWeight { get; set; } = "normal";
        public string FontStyle { get; set; } = "normal";
        public string TextColor { get; set; } = "#000000"; 
        public string BackgroundColor { get; set; } = "#FFFFFF";
    }
}
