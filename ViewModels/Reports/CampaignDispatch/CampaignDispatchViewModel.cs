using CLA_Administration_Web.Models.APIResponses.Reports.CampaignDispatch;

namespace CLA_Administration_Web.ViewModels.Reports.CampaignDispatch
{
    public class CampaignDispatchViewModel
    {
        public CampaignDispatchFiltersViewModel Filters { get; set; }

        public List<DispatchLockedDesktopResponse> LockedDesktops { get; set; }

        public List<DispatchDesktopResponse> Desktops { get; set; }

        public List<DispatchScreensaverResponse> Screensaver { get; set; }

        public List<DispatchPopupResponse> Popups { get; set; }

        public List<DispatchSurveyResponse> Surveys { get; set; }

        public List<DispatchTickerResponse> Tickers { get; set; }
    }
}
