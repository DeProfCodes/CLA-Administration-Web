using Newtonsoft.Json;
using System.ComponentModel;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Ticker
{
    public class TickerReportAllData
    {
        [DisplayName("DOMAIN ID")]
        [JsonProperty("DomainID")]
        public string? DomainId { get; set; }

        [DisplayName("PROVIDER ID")]
        [JsonProperty("Provider_ID")]
        public int? ProviderId { get; set; }

        [DisplayName("TICKER ID")]
        [JsonProperty("Ticker_ID")]
        public int? TickerId { get; set; }

        [DisplayName("TICKER TEXT")]
        [JsonProperty("ticker_text")]
        public string? TickerText { get; set; }

        [DisplayName("EFF FROM")]
        [JsonProperty("Eff_From")]
        public DateTime? EffectiveFrom { get; set; }

        [DisplayName("EFF TO")]
        [JsonProperty("Eff_To")]
        public DateTime? EffectiveTo { get; set; }

        [DisplayName("TIMESLOT FROM")]
        public string? TimeslotFrom { get; set; }

        [DisplayName("TIMESLOT TO")]
        public string? TimeslotTo { get; set; }

        [DisplayName("USER ID")]
        [JsonProperty("userID")]
        public string? UserId { get; set; }

        [DisplayName("USER NAME")]
        [JsonProperty("userName")]
        public string? UserName { get; set; }

        [DisplayName("MACHINE ID")]
        [JsonProperty("machineID")]
        public string? MachineId { get; set; }

        [DisplayName("MACHINE NAME")]
        [JsonProperty("machineName")]
        public string? MachineName { get; set; }

        [DisplayName("MAX LAST UPDATE DATE")]
        [JsonProperty("max_last_update_DT")]
        public DateTime? MaxLastUpdateDate { get; set; }

        [DisplayName("TICKER CLICK DATE")]
        [JsonProperty("TickerPB_Click_DT")]
        public DateTime? TickerPbClickDate { get; set; }
    }
}
