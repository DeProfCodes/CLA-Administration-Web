using Newtonsoft.Json;
using System.ComponentModel;

namespace CLA_Administration_Web.ViewModels.Reports.Survey
{
    public class SurveyOutstandingViewModel
    {
        [DisplayName("Domain")]
        public string DomainId { get; set; }

        [DisplayName("User ID")]
        public string UserId { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("Machine ID")]
        public string MachineId { get; set; }

        [DisplayName("Machine Name")]
        public string MachineName { get; set; }

        [DisplayName("Last Sync DT User")]
        public DateTime? LastSyncDTUser { get; set; }

        [DisplayName("Last Sync DT Machine")]
        public DateTime? LastSyncDTMachine { get; set; }
    }
}
