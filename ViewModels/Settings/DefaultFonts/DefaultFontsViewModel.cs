namespace CLA_Administration_Web.ViewModels.Settings.DefaultFonts
{
    public class SubHeadingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
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
