namespace CLA_Administration_Web.ViewModels.Components.Form
{
    public class DataTableViewModel
    {
        public string ComponentId { get; set; }

        public string TableId { get; set; }

        public IEnumerable<object> DataSource { get; set; }

        public Type DefaultFallBackType { get; set; }

        public bool IsInitiallyHidden { get; set; }

        List<DataTableActionButton> ActionButtons { get; set; }
    }

    public class DataTableActionButton
    {
        public string ButtonName { get; set; }

        public string ButtonCss { get; set; }

        public string ButtonIconCss { get; set; }

        public string CallBackFunction { get; set; }

        public string CallBackFunctionParameters { get; set; }

    }
}
