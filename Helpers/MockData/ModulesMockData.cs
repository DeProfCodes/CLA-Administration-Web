using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.ViewModels.Modules;

namespace CLA_Administration_Web.Helpers.MockData
{
    public class ModulesMockData
    {
        public static List<PopupViewModule> AllPopupsData { get; set; } = GeneratePopupsData();

        private static List<PopupViewModule> GeneratePopupsData()
        {
            var popupsData = new List<PopupViewModule>()
            {
                new PopupViewModule
                {
                    Id = 1,
                    HeaderText = "Image Popup",
                    BodyText = "Click this popup to open, the popup itself is a url that will force lauch your machine default application for viewing images.",
                    EffectiveFrom = "2024/07/01",
                    EffectiveTo = "2024/08/30",
                    TimeslotFrom = "08:00",
                    TimeslotTo = "17:30",
                    LastModifiedDate = "2024/09/16 16:42"
                },
                new PopupViewModule
                {
                    Id = 2,
                    HeaderText = "WIP Status",
                    BodyText = "The current monthly stats have been shown a positve change, and some text some text some text.",
                    EffectiveFrom = "2024/09/05",
                    EffectiveTo = "2024/09/26",
                    TimeslotFrom = "11:00",
                    TimeslotTo = "13:30",
                    LastModifiedDate = "2024/09/16 16:42"
                },
                new PopupViewModule
                {
                    Id = 3,
                    HeaderText = "Special Announcement - Future",
                    BodyText = "There is an urgent announcement that needs you attention and you have to click this popup to start a survey.",
                    EffectiveFrom = "2024/11/05",
                    EffectiveTo = "2024/11/26",
                    TimeslotFrom = "11:00",
                    TimeslotTo = "13:30",
                    LastModifiedDate = "2024/09/16 16:42"
                },
                new PopupViewModule
                {
                    Id = 4,
                    HeaderText = "Special Announcement",
                    BodyText = "There is an urgent announcement that needs you attention and you have to click this popup to start a survey.",
                    EffectiveFrom = "2024/09/05",
                    EffectiveTo = "2024/09/26",
                    TimeslotFrom = "11:00",
                    TimeslotTo = "13:30",
                    LastModifiedDate = "2024/09/16 16:42"
                },
            };
            
            popupsData.AddRange(popupsData);
            popupsData.AddRange(popupsData);
            popupsData.AddRange(popupsData);

            return popupsData;
        }
    }
}
