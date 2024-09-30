using CLA_Administration_Web.ViewModels.Shared;

namespace CLA_Administration_Web.ViewModels.Modules.ContentLibrary
{
    public class ContentLibraryContentModel
    {
        public int ContentId { get; set; }

        public int CategoryId { get; set; }

        public int AdvertId { get; set; }

        public int ProductId { get; set; }

        public string CategoryName { get; set; }

        public string AdvertDescription { get; set; }

        public int Duration { get; set; }

        public string ContentType { get; set; }

        public string ContentPath { get; set; }

        public string TargetedModules { get; set; }

        public string TargetedModulesFullName { get; set; }

        public string EffectiveFrom { get; set; }

        public DateTime EffectiveFromDate { get; set; }

        public string EffectiveTo { get; set; }

        public DateTime EffectiveToDate { get; set; }

        public StatusViewModel Status { get; set; }

        public string Archive { get; set; }

        public string DateLastModified { get; set; }

        public string UserIdLastModified { get; set; }

        public string MachineIdLastModified { get; set; }

    }
}
