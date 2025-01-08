namespace CLA_Administration_Web.ViewModels.Settings.DesktopInformation
{
    public class PositionViewModel
    {
        public List<string> Positions { get; set; }
        public string SelectedPosition { get; set; }
        public Dictionary<string, bool> Checkboxes { get; set; }
    }
}
