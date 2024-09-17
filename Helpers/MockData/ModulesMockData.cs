using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.ViewModels.Modules;

namespace CLA_Administration_Web.Helpers.MockData
{
    public class ModulesMockData
    {
        public static List<PopupViewModel> AllPopupsData { get; set; } = GeneratePopupsData();

        private static List<PopupViewModel> GeneratePopupsData()
        {
            var popupsData = new List<PopupViewModel>()
            {
                new PopupViewModel
                {
                    Id = 1,
                    HeaderText = "Image Popup",
                    BodyText = "Click this popup to open, the popup itself is a url that will force lauch your machine default application for viewing images.",
                    EffectiveFrom = "2024/07/01",
                    EffectiveTo = "2024/08/30",
                    TimeslotFrom = "08:00",
                    TimeslotTo = "17:30",
                    LastModifiedDate = "2024/09/16 16:42",
                    UserIdLastModified = "NdhuvaziM",
                },
                new PopupViewModel
                {
                    Id = 2,
                    HeaderText = "WIP Status",
                    BodyText = "The current monthly stats have been shown a positve change, and some text some text some text.",
                    EffectiveFrom = "2024/09/05",
                    EffectiveTo = "2024/09/26",
                    TimeslotFrom = "11:00",
                    TimeslotTo = "13:30",
                    LastModifiedDate = "2024/09/16 16:42",
                    UserIdLastModified = "NdhuvaziM"
                },
                new PopupViewModel
                {
                    Id = 3,
                    HeaderText = "Special Announcement - Future",
                    BodyText = "There is an urgent announcement that needs you attention and you have to click this popup to start a survey.",
                    EffectiveFrom = "2024/11/05",
                    EffectiveTo = "2024/11/26",
                    TimeslotFrom = "11:00",
                    TimeslotTo = "13:30",
                    LastModifiedDate = "2024/09/16 16:42",
                    UserIdLastModified = "BertusB"
                },
                new PopupViewModel
                {
                    Id = 4,
                    HeaderText = "Special Announcement",
                    BodyText = "There is an urgent announcement that needs you attention and you have to click this popup to start a survey.",
                    EffectiveFrom = "2024/09/05",
                    EffectiveTo = "2024/09/26",
                    TimeslotFrom = "11:00",
                    TimeslotTo = "13:30",
                    LastModifiedDate = "2024/09/16 16:42",
                    UserIdLastModified = "LeboC"
                },
                new PopupViewModel
                {
                    Id = 5,
                    HeaderText = "Time Travel - Future",
                    BodyText = "There is an urgent announcement that needs you attention and you have to click this popup to start a survey.",
                    EffectiveFrom = "2024/11/05",
                    EffectiveTo = "2024/11/26",
                    TimeslotFrom = "11:00",
                    TimeslotTo = "13:30",
                    LastModifiedDate = "2024/09/16 16:42",
                    UserIdLastModified = "BertusB"
                },
                new PopupViewModel
                {
                    Id = 6,
                    HeaderText = "Some Header LO",
                    BodyText = "Random Texting 101.",
                    EffectiveFrom = "2014/09/05",
                    EffectiveTo = "2014/12/26",
                    TimeslotFrom = "11:00",
                    TimeslotTo = "13:30",
                    LastModifiedDate = "2024/09/16 16:42",
                    UserIdLastModified = "LeboC"
                },
                new PopupViewModel
                {
                    Id = 7,
                    HeaderText = "Because it is Title",
                    BodyText = "The normal popup body text is meant to be in html format okay?.",
                    EffectiveFrom = "2014/09/05",
                    EffectiveTo = "2014/12/26",
                    TimeslotFrom = "11:00",
                    TimeslotTo = "13:30",
                    LastModifiedDate = "2024/09/16 16:42",
                    UserIdLastModified = "Administrator"
                },
            };
            
            popupsData.AddRange(popupsData);
            popupsData.AddRange(popupsData);
            popupsData.AddRange(popupsData);

            return popupsData;
        }
    }
}
