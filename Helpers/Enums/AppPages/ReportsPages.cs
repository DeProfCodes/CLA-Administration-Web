using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.AppPages
{
    public enum ReportsPages
    {
        [Display(Name = "")]
        None,

        [Display(Name = "Survey")]
        Survey,

        [Display(Name = "Popup")]
        Popup,

        [Display(Name = "Ticker")]
        Ticker,

        [Display(Name = "Policy")]
        Policy,

        [Display(Name = "ActiveUsers")]
        ActiveUsers,

        [Display(Name = "ActiveMachines")]
        ActiveMachines,

        [Display(Name = "CampaignDispatch")]
        CampaignDispatch,

        [Display(Name = "Troubleshoot")]
        Troubleshoot
    }
}
