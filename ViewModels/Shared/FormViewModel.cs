namespace CLA_Administration_Web.ViewModels.Shared
{
    public class FormViewModel
    {

        public class DynamicFormViewModel
        {
            public string FormId { get; set; }
            public string SubmitAction { get; set; }
            public List<FormFieldViewModel> Fields { get; set; } = new List<FormFieldViewModel>();
        }

        public class FormFieldViewModel
        {
            public string FieldId { get; set; }
            public string Name { get; set; }
            public string Label { get; set; }
            public string Type { get; set; } // text, textarea, select, checkbox, radio
            public string Value { get; set; }
            public string Placeholder { get; set; }
            public bool IsRequired { get; set; } = false;
            public string ErrorMessage { get; set; }
            public int ColumnWidth { get; set; } = 12; // Grid column width for layout
            public List<SelectOptionViewModel> Options { get; set; } = new List<SelectOptionViewModel>();
        }

        public class SelectOptionViewModel
        {
            public string Value { get; set; }
            public string Text { get; set; }
        }
    }
}
