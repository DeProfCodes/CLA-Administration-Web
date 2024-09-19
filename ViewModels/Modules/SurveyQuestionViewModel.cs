using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.ViewModels.Shared;

namespace CLA_Administration_Web.ViewModels.Modules
{
    public class SurveyQuestionViewModel
    {
        public int Id { get; set; }

        public string QuestionNo { get; set; }

        public int SurveyId { get; set; }

        public string QuestionTitle { get; set; }

        public string QuestionText { get; set; }

        public string CorrectAnswer { get; set; }

        public string Dependencies { get; set; }

        public string IsAnnonymouse { get; set; }

        public string IsScored { get; set; }

        public string Randomize { get; set; }

        public string ResponseType { get; set; }

        public string TimeslotTo { get; set; }

        public StatusViewModel Status { get; set; }

        public string LastModifiedDate { get; set; }

        public string MachineLastModifiedDate { get; set; }

        public string UserIdLastModified { get; set; }
    }
}
