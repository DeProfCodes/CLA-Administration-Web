using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.ViewModels.Shared;

namespace CLA_Administration_Web.ViewModels.Modules.PSTR
{
    /// <summary>
    /// Module View Model for the modules: Popup, Survey, Ticker, RSS (PSTR)
    /// </summary>
    public class ModulePSTRDataViewModel
    {
        public int Id { get; set; }

        public string HeaderText { get; set; }

        public string BodyText { get; set; }

        public string EffectiveFrom { get; set; }

        public string EffectiveTo { get; set; }

        public DateTime EffectiveFromDate { get; set; }

        public DateTime EffectiveToDate { get; set; }

        public string TimeslotFrom { get; set; }

        public string TimeslotTo { get; set; }

        public StatusViewModel Status { get; set; }

        public string LastModifiedDate { get; set; }

        public string UserIdLastModified { get; set; }

        public string MachineLastModified { get; set; }
    }
}
