using CLA_Administration_Web.ViewModels.Modules.ContentLibrary;
using CLA_Administration_Web.ViewModels.Modules.PST;
using CLA_Administration_Web.ViewModels.Settings.SkinAndOfflineImage;

namespace CLA_Administration_Web.ViewModels.Settings.SkinAndOfflineImage
{
    public class SkinsAndOfflineImageMainViewModel
    {
        public List<SkinsAndOfflineModel> SkinAndOfflineImage { get; set; }
        

        public List<SkinOfflineCategortyTree> SkinOfflineCategortyTrees { get; set; }
    }
}
