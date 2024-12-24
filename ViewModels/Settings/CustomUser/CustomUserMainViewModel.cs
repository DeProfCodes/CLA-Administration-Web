using CLA_Administration_Web.Models.APIResponses.Reports.Troubleshoot;
using System.Collections.Generic;

namespace CLA_Administration_Web.ViewModels.Settings.CustomUser
{
    public class CustomUserMainViewModel
    {
        public List<CustomUserViewModel> CustomUsersSettings { get; set; }

        public bool ConnectedToLive { get; set; }

        public bool IsBlank { get; set; }

        public TroubleshootReportLastSyncDetails LastSyncDetails { get; set; }

    
        public List<TroubleshootReportUserGroup> UserGroups { get; set; }

  
        public List<TroubleshootReportTargeting> Targeting { get; set; }


        public TroubleshootReportSettings Settings { get; set; }

        public CustomUserMainViewModel()
        {
            CustomUsersSettings = new List<CustomUserViewModel>();
            UserGroups = new List<TroubleshootReportUserGroup>();
            Targeting = new List<TroubleshootReportTargeting>();
        }
    }
}
