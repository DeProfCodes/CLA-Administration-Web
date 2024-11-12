using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.AppPages
{
    public enum ReportsPages
    {
        [Display(Name = "", Description = "", ShortName = "")]
        None,

        [Display(Name = "AllReports", Description = "All Reports", ShortName = "All")]
        AllReports,

        [Display(Name = "ReportModulesListing", Description = "Report Modules Listing", ShortName = "ModuleReport")]
        ReportModulesListing,

        [Display(Name = "ExportFileToExcel", Description = "ExportFileToExcel", ShortName = "ModuleReport")]
        ExportFileToExcel,
        
        [Display(Name = "SurveyReport", Description = "Survey Report", ShortName = "Survey")]
        SurveyReport,

        [Display(Name = "SurveyReportForExport", Description = "Survey Report For Export", ShortName = "Survey")]
        SurveyReportForExport,

        [Display(Name = "SurveyReportOnly", Description = "Survey Report Only", ShortName = "Survey")]
        SurveyReportOnly,

        [Display(Name = "PopupReport", Description = "Popup Report", ShortName = "Popup")]
        PopupReport,

        [Display(Name = "PopupReportForExport", Description = "Popup Report For Export", ShortName = "Popup")]
        PopupReportForExport,

        [Display(Name = "PopupReportOnly", Description = "Popup Report Only", ShortName = "Popup")]
        PopupReportOnly,
        
        [Display(Name = "TickerReport", Description = "Ticker Report", ShortName = "Ticker")]
        TickerReport,

        [Display(Name = "TickerReportForExport", Description = "Ticker Report For Export", ShortName = "Ticker")]
        TickerReportForExport,

        [Display(Name = "TickerReportOnly", Description = "Ticker Report Only", ShortName = "Ticker")]
        TickerReportOnly,

        [Display(Name = "PolicyReport", Description = "Policy Report", ShortName = "Policy")]
        PolicyReport,

        [Display(Name = "PolicyReportForExport", Description = "Policy Report For Export", ShortName = "Policy")]
        PolicyReportForExport,

        [Display(Name = "PolicyReportOnly", Description = "Policy Report Only", ShortName = "Policy")]
        PolicyReportOnly,

        [Display(Name = "ActiveUsersReport", Description = "Active Users Report", ShortName = "Active Users")]
        ActiveUsersReport,

        [Display(Name = "ActiveMachinesReport", Description = "Active Machines Report", ShortName = "Active Machines")]
        ActiveMachinesReport,

        [Display(Name = "ActiveUsersMachinesReport", Description = "Active Users Machines Report", ShortName = "Active Users Machines")]
        ActiveUsersMachinesReport,

        [Display(Name = "CampaignDispatchReport", Description = "Campaign Dispatch Report", ShortName = "Campaign Dispatch")]
        CampaignDispatchReport,

        [Display(Name = "CampaignDispatchListReport", Description = "Campaign Dispatch List Report", ShortName = "Campaign Dispatch")]
        CampaignDispatchListReport,

        [Display(Name = "TroubleshootReport", Description = "Troubleshoot Report", ShortName = "Troubleshoot")]
        TroubleshootReport
    }
}
