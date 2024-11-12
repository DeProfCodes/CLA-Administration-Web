using CLA_Administration_Web.Helpers.Reporting;
using Newtonsoft.Json;
using System.ComponentModel;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Policy
{
    public class PolicyReportOutstanding
    {
        [DisplayName("Domain")]
        [JsonProperty("Domain")]
        public string Domain { get; set; }

        [DisplayName("User ID")]
        [JsonProperty("User_ID")]
        public string UserId { get; set; }

        [DisplayName("User Name")]
        [JsonProperty("User_Name")]
        public string UserName { get; set; }

        [DisplayName("Machine ID")]
        [JsonProperty("Machine_ID")]
        public string MachineId { get; set; }

        [DisplayName("Machine Name")]
        [JsonProperty("Machine_Name")]
        public string MachineName { get; set; }

        [DisplayName("Last Sync DT User")]
        [JsonProperty("Last_Sync_DT_User")]
        public DateTime? LastSyncDTUser { get; set; }

        [DisplayName("Last Sync DT Machine")]
        [JsonProperty("Last_Sync_DT_Machine")]
        public DateTime? LastSyncDTMachine { get; set; }

        [DisplayName("")]
        [SkipProperty]
        [JsonProperty("")]
        public DateTime? LastSyncDate { get; set; }

        [DisplayName("")]
        [SkipProperty]
        [JsonProperty("TargetedType")]
        public string TargetedType { get; set; }
    }
}
