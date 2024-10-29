using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Popup
{
    public class PopupReportOutstanding
    {
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

        [JsonProperty("stm_header")]
        public string PopupHeader { get; set; }

        [JsonProperty("max_last_update_DT")]
        public DateTime? MaxLastUpdateDate { get; set; }

        [JsonProperty("eff_from")]
        public DateTime EffectiveFrom { get; set; }

        [JsonProperty("eff_to")]
        public DateTime EffectiveTo { get; set; }

        [JsonProperty("Bubble_Click_DT")]
        public DateTime? BubbleClickDate { get; set; }
    }
}
