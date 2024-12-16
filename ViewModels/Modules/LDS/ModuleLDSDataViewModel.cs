using CLA_Administration_Web.ViewModels.Shared;

namespace CLA_Administration_Web.ViewModels.Modules.LDS
{
    /// <summary>
    /// Module View Model for the modules: Lockscreen, Desktop, Screensaver (LDS)
    /// </summary>
    public class ModuleLDSDataViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public string ContentType { get; set; }

        public string ContentDescription { get; set; }

        public int Duration { get; set; }

        public string EffectiveFrom { get; set; }

        public string EffectiveTo { get; set; }

        public DateTime EffectiveFromDate { get; set; }

        public DateTime EffectiveToDate { get; set; }

        public string TimeslotFrom { get; set; }

        public string TimeslotTo { get; set; }

        public StatusViewModel Status { get; set; }

        public string LastModifiedDate { get; set; }

        public string UserIdLastModified { get; set; }

        public string MachineIdLastModified { get; set; }
    }
}
