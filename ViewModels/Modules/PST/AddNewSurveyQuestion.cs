using CLA_Administration_Web.Helpers.Enums.Shared;

namespace CLA_Administration_Web.ViewModels.Modules.PST
{
    public class AddNewSurveyQuestion
    {
        public int SurveyId { get; set; }

        public int SurveyQuestionId { get; set; }

        public AddOrEditType AddOrEditType { get; set; }
    }
}
