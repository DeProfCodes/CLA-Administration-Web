using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.Shared
{
    public enum ReportsNamesType
    {
        [Display(Name = "", ShortName = "")]
        None,

        [Display(Name = "Survey", Description = "Survey")]
        Survey,

        [Display(Name = "Popup", Description = "Popup")]
        Popup,

        [Display(Name = "Ticker", Description = "Ticker")]
        Ticker,

        [Display(Name = "Policy", Description = "Policy")]
        Policy,

        [Display(Name = "ActiveUsers", Description = "Active Users")]
        ActiveUsers,

        [Display(Name = "ActiveMachines", Description = "Active Machines")]
        ActiveMachines,

        [Display(Name = "CampaignDispatch", Description = "Campaign Dispatch")]
        CampaignDispatch,

        [Display(Name = "Troubleshoot", Description = "Troubleshoot")]
        Troubleshoot
    }
}
