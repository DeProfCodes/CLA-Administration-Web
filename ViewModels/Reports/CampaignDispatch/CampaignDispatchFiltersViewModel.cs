namespace CLA_Administration_Web.ViewModels.Reports.CampaignDispatch
{
    public class CampaignDispatchFiltersViewModel
    {
        public bool LockscreenReport { get; set; }

        public bool DesktopReport { get; set; }

        public bool ScreensaverReport { get; set; }

        public bool PopupReport { get; set; }

        public bool SurveyReport { get; set; }

        public bool TickerReport { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public DateTime EffectiveFrom { get; set; }

        public DateTime EffectiveTo { get; set; }

        public string ViewType { get; set; }

        public int IsAutomated { get; set; }
    }
}
