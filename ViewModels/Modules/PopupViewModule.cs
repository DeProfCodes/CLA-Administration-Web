using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.ViewModels.Shared;

namespace CLA_Administration_Web.ViewModels.Modules
{
    public class PopupViewModule
    {
        public int Id { get; set; }

        public string HeaderText { get; set; }

        public string BodyText { get; set; }

        public string EffectiveFrom { get; set; }

        public string EffectiveTo { get; set; }

        public string TimeslotFrom { get; set; }

        public string TimeslotTo { get; set; }

        public StatusViewModel Status { get; set; }

        public string LastModifiedDate { get; set; }
    }
}
