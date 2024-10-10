using CLA_Administration_Web.Helpers.Enums.Shared;

namespace CLA_Administration_Web.ViewModels.Modules.Rss
{
    public class AddNewRssFeed
    {
        public int CurrentCategoryId { get; set; }

        public List<RssCategoryOverviewViewModel> RssCategories { get; set; }

        public RssFeedOverviewViewModel RssFeedData { get; set; }

        public AddOrEditType AddOrEditType { get; set; }
    }
}
