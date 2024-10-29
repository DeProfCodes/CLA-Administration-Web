using CLA_Administration_Web.Helpers.Reporting;
using Newtonsoft.Json;
using System.ComponentModel;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Popup
{
    public class PopupReportOutstanding
    {
        [DisplayName("Domain")]
        [JsonProperty("DomainID")]
        public string DomainId { get; set; }

        [DisplayName("User ID")]
        [JsonProperty("userID")]
        public string UserId { get; set; }

        [DisplayName("User Name")]
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [DisplayName("Machine ID")]
        [JsonProperty("machineID")]
        public string MachineId { get; set; }

        [DisplayName("Machine Name")]
        [JsonProperty("machineName")]
        public string MachineName { get; set; }

        [SkipProperty]
        [JsonProperty("stm_header")]
        public string PopupHeader { get; set; }

        [DisplayName("Last Sync DT")]
        [JsonProperty("max_last_update_DT")]
        public DateTime? MaxLastUpdateDate { get; set; }

        [SkipProperty]
        [JsonProperty("eff_from")]
        public DateTime EffectiveFrom { get; set; }

        [SkipProperty]
        [JsonProperty("eff_to")]
        public DateTime EffectiveTo { get; set; }

        [SkipProperty]
        [JsonProperty("Bubble_Click_DT")]
        public DateTime? BubbleClickDate { get; set; }
    }
}
