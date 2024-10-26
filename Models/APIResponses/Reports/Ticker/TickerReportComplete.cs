using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Ticker
{
    public class TickerReportComplete
    {
        [JsonProperty("eff_from")]
        public DateTime EffectiveFrom { get; set; }

        [JsonProperty("eff_to")]
        public DateTime EffectiveTo { get; set; }

        [JsonProperty("DomainID")]
        public string DomainId { get; set; }

        [JsonProperty("userID")]
        public string UserId { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("machineID")]
        public string MachineId { get; set; }

        [JsonProperty("machineName")]
        public string MachineName { get; set; }

        [JsonProperty("ticker_text")]
        public string TickerText { get; set; }

        [JsonProperty("max_last_update_DT")]
        public DateTime MaxLastUpdateDate { get; set; }

        [JsonProperty("TickerPB_Click_DT")]
        public DateTime TickerPbClickDate { get; set; }
    }
}
