using CLA_Administration_Web.Helpers.Reporting;
using Newtonsoft.Json;
using System.ComponentModel;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Ticker
{
    public class TickerReportComplete
    {
        [DisplayName("")]
        [SkipProperty]
        [JsonProperty("eff_from")]
        public DateTime EffectiveFrom { get; set; }

        [DisplayName("")]
        [SkipProperty]
        [JsonProperty("eff_to")]
        public DateTime EffectiveTo { get; set; }

        [DisplayName("Domain")]
        [JsonProperty("DomainID")]
        public string DomainId { get; set; }
           
        [DisplayName("User ID")]
        [JsonProperty("userID")]
        public string UserId { get; set; }

        [DisplayName("UserName")]
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [DisplayName("Machine ID")]
        [JsonProperty("machineID")]
        public string MachineId { get; set; }

        [DisplayName("Machine Name")]
        [JsonProperty("machineName")]
        public string MachineName { get; set; }

        [DisplayName("")]
        [SkipProperty]
        [JsonProperty("ticker_text")]
        public string TickerText { get; set; }

        [DisplayName("Last Sync Date")]
        [HideProperty]
        [JsonProperty("max_last_update_DT")]
        public DateTime MaxLastUpdateDate { get; set; }

        [DisplayName("TickerPB_Click_DT")]
        [JsonProperty("TickerPB_Click_DT")]
        public DateTime ClickDate { get; set; }
    }
}
