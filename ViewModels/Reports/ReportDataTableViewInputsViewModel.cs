namespace CLA_Administration_Web.ViewModels.Reports
{
    public class ReportDataTableViewInputsViewModel
    {
        public string ComponentId { get; set; }

        public string TableId {get; set; }

        public IEnumerable<object> DataSource { get; set; }

        public Type DefaultFallBackType { get; set; }

        public bool IsInitiallyHidden { get; set; }

        public string LastSyncDateColumnName { get; set; }

    }
}
