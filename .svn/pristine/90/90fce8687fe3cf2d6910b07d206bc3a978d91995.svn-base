var popupReportTab = 1;
var totalPopupReportTabs = 8;

var backBtnId = "#ReportNavBackBtn";
var nextBtnId = "#ReportNavNextBtn";

function NavigateToPopupReportTab(tabNo)
{
    popupReportTab = tabNo;
    SwitchReportTab("popup", tabNo);
    UpdateReportNavigationBtns(popupReportTab, totalPopupReportTabs);
}

function NextReportTab()
{
    if(popupReportTab < totalPopupReportTabs)
    {
        popupReportTab++;

        NavigateToPopupReportTab(popupReportTab);
    }
}

function PreviousReportTab()
{
    if(popupReportTab > 1)
    {
        popupReportTab--;

        NavigateToPopupReportTab(popupReportTab);
    }
}

function UpdateReportNavigationBtns(tabNo, maxTabs)
{
    if(tabNo == 1)
    {
        HideShowElement(backBtnId, HideShow.HIDE);
        HideShowElement(nextBtnId, HideShow.SHOW);
    }
    else if(tabNo > 1 && tabNo < maxTabs)
    {
        HideShowElement(backBtnId, HideShow.SHOW);
        HideShowElement(nextBtnId, HideShow.SHOW);
    }
    else if(tabNo == maxTabs)
    {
        HideShowElement(backBtnId, HideShow.SHOW);
        HideShowElement(nextBtnId, HideShow.HIDE);
    }
}

function SwitchReportTab(moduleReportName, tabNo)
{
    moduleReportName = moduleReportName.toLowerCase();

    var reportModuleTabs = $(`.report-module-tabs-${moduleReportName}`);
    HideShowElement(`.report-module-tabs-${moduleReportName}`, HideShow.HIDE);

    for (let i = 0; i < reportModuleTabs.length; i++)
    {
        var tabElementId = `#${reportModuleTabs[i].getAttribute("id")}`;
        var data = tabElementId.split("-");
        
        if (data != null && data.length >= 2)
        {
            var tabNumber = data[1];
            if (tabNumber == tabNo)
            {
                var linkTab = `.popup-report-type-nav.T-${tabNumber}`;

                $(".popup-report-type-nav").removeClass("btn-group-active");
                $(linkTab).addClass("btn-group-active");
                
                HideShowElement(tabElementId, HideShow.SHOW);

                break;
            }
        }
    }
}

function ReportDataLoader(reportType)
{
    var width = $(".report-data-area").css("width");
    var height = $(".report-data-area").css("height");

    const element = document.getElementById("report-data-area");
    const rect = element.getBoundingClientRect();
    const left = rect.left + window.scrollX;
    const top = rect.top + window.scrollY;

    $("#SecondaryLoader").css("top", top);
    $("#SecondaryLoader").css("left", left);
    $("#SecondaryLoader").css("width", width);
    $("#SecondaryLoader").css("height", height);

    $("#SecondaryLoaderMessage").text(`Loading ${GetReportNameType(reportType)} reports`);

}

function ReloadFilteredReport(reportModuleType, reportDataType, reportModuleId)
{
    ReportDataLoader(reportModuleType);

    var url = "";
    var pageName = '';
    
    if(reportDataType == ReportDataTypes.EXPORT_ONLY)
    {
        if(reportModuleType == ReportModuleTypes.POPUP) pageName = "PopupReportForExport";
        if(reportModuleType == ReportModuleTypes.TICKER) pageName = "TickerReportForExport";
        if(reportModuleType == ReportModuleTypes.SURVEY) pageName = "SurveyReportForExport";
        if(reportModuleType == ReportModuleTypes.POLICY) pageName = "PolicyReportForExport";
    }

    url = GetPageUrl(pageName, reportModuleId);

    LoadPartialViewWithLoader(url, "#ReportModuleData","#SecondaryLoader");
}
