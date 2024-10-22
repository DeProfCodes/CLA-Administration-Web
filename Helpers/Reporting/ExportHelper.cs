using CLA_Administration_Web.ViewModels.Reports;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using System.Text;

namespace CLA_Administration_Web.Helpers.Reporting
{
    public class ExportHelper
    {
        public static byte[] RenderReport(ReportRDLC reportData)
        {
            LocalReport localReport = new LocalReport();
            string reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", reportData.ReportRDLCPath);

            using (var fs = new FileStream(reportPath, FileMode.Open, FileAccess.Read))
            {
                localReport.LoadReportDefinition(fs);
            }

            localReport.DataSources.Add(new ReportDataSource(reportData.RDLCName, reportData.DataSet.Tables[0]));

            string mimeType, encoding, fileNameExtension;
            Warning[] warnings;
            string[] streams;

            return localReport.Render("EXCELOPENXML", null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
        }

        public static byte[] GetReportExcelBytes(List<ReportRDLC> reportsRDLCs, string reportRDLCPath, string parameterValue = "")
        {
            try
            {
                var localReport = new LocalReport();

                using (FileStream fs = new FileStream(reportRDLCPath, FileMode.Open, FileAccess.Read))
                {
                    localReport.LoadReportDefinition(fs);
                }

                foreach (var report in reportsRDLCs)
                {
                    localReport.DataSources.Add(new ReportDataSource(report.RDLCName, report.DataSet.Tables[0]));
                }

                if (!string.IsNullOrEmpty(parameterValue))
                {
                    ReportParameter[] reportParameters =
                    [
                        new ReportParameter("pFilterColumn", parameterValue)
                    ];
                    localReport.SetParameters(reportParameters);
                }

                byte[] renderedBytes = localReport.Render("EXCELOPENXML", null, out _, out _, out _, out _, out _);

                var htmlOutput = Encoding.UTF8.GetString(renderedBytes);

                return renderedBytes;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public static void AddSheetToExcel(XLWorkbook workbook, byte[] reportBytes, string sheetName)
        {
            // Create a new temporary workbook to hold the rendered report bytes
            using (var tempWorkbookStream = new MemoryStream(reportBytes))
            {
                using (var tempWorkbook = new XLWorkbook(tempWorkbookStream))
                {
                    // Loop through all sheets in the rendered report and add them to the main workbook
                    foreach (var worksheet in tempWorkbook.Worksheets)
                    {
                        // Copy the sheet to the main workbook
                        worksheet.CopyTo(workbook, sheetName);
                    }
                }
            }
        }
        //public static void AddSheetToExcel(XLWorkbook workbook, byte[] reportBytes, string sheetName)
        //{
        //    using (var stream = new MemoryStream(reportBytes))
        //    {
        //        workbook.Worksheets.Add(stream, sheetName);
        //    }
        //}
    }
}
