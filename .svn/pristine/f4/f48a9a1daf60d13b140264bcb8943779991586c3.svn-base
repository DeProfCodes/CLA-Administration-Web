

function GetStatusFromButtonId(buttonId)
{
    var id = buttonId.toLowerCase();
    
    if(id.includes('all')) return AllStatusTypes.All;
    if(id.includes('active')) return AllStatusTypes.Active;
    if(id.includes('expired')) return AllStatusTypes.Expired;
    if(id.includes('pending')) return AllStatusTypes.Pending;

    return null;
}

function ModuleFilterButtonClick(filterBtnId, moduleType, status, username, startDate, endDate, stagingLiveFilter)
{
    $('.filter-status-btn').removeClass('btn-group-active');
    $(`#${filterBtnId}`).addClass('btn-group-active');
    
    ReloadFilteredModuleOverview(moduleType, status, username, startDate, endDate, stagingLiveFilter);
}

function ModuleFilterUsersFilterChange(moduleName, selectListId)
{
    var statusBtn = $(`.filter-status-btn.btn-group-active.${moduleName}`); 
    var status = statusBtn.text();
    var btnId = statusBtn.attr("id");

    FilterModuleDataOverviewByStatus(moduleName, btnId, status);
}

function ModuleFilterDatesFilterChange(moduleName, dateInputId)
{
    var statusBtn = $(`.filter-status-btn.btn-group-active.${moduleName}`); 
    var status = statusBtn.text();
    var btnId = statusBtn.attr("id");

    FilterModuleDataOverviewByStatus(moduleName, btnId, status);
}

function ModuleOverviewLoader(moduleType, status)
{
    if(moduleType == AllModuleTypes.Popup)
    {
        var width = $("#ModuleOverviewCard").css("width");
        var height = $("#ModuleOverviewCard").css("height");

        const element = document.getElementById("ModuleOverviewCard");
        const rect = element.getBoundingClientRect();
        const left = rect.left + window.scrollX;
        const top = rect.top + window.scrollY;
        
        $("#SecondaryLoader").css("top", top);
        $("#SecondaryLoader").css("left", left);
        $("#SecondaryLoader").css("width", width);
        $("#SecondaryLoader").css("height", height);
        
        $("#SecondaryLoaderMessage").text(`Loading ${status} Popups...`);
    }
}

function ReloadFilteredModuleOverview(moduleType, status, username, startDate, endDate, stagingLiveFilter)
{
    ModuleOverviewLoader(moduleType, status);

    var url = "";
    
    if(moduleType == AllModuleTypes.Popup || moduleType == AllModuleTypes.Survey || moduleType == AllModuleTypes.Ticker || moduleType == AllModuleTypes.RSS)
        url = GetPageUrl('ModulesOverviewFilterPSTR') + `?moduleNameType=${moduleType}&status=${status}&userType=${username}&startDate=${startDate}&endDate=${endDate}`;

    if(moduleType == AllModuleTypes.LockedDesktop || moduleType == AllModuleTypes.Desktop || moduleType == AllModuleTypes.Screensaver)
        url = GetPageUrl('ModulesOverviewFilterLDS') + `?moduleNameType=${moduleType}&status=${status}&stagingLive=${stagingLiveFilter}&startDate=${startDate}&endDate=${endDate}`;

    LoadPartialViewWithLoader(url, "#ModuleOverviewTableContainer","#SecondaryLoader");
}

function FilterModuleDataOverviewByStatus(moduleName, buttonId, status)
{
    var username = $(`#${moduleName}UsersFilter`).val();
    var startDate = $(`#${moduleName}DateFromFilter`).val();
    var endDate = $(`#${moduleName}DateToFilter`).val();
    var stagingLiveFilter = $(`.filter-type-btn.btn-group-active.${moduleName}`).text(); 

    ModuleFilterButtonClick(buttonId, moduleName, status, username, startDate, endDate, stagingLiveFilter);
}

function FilterModuleDataOverviewByStagingLive(moduleName, buttonId, stagingOrLive)
{
    $('.filter-type-btn').removeClass('btn-group-active');
    $(`#${buttonId}`).addClass('btn-group-active');
}

function FilterModuleDataOverviewByViewType(moduleName, buttonId, viewType)
{
    $('.filter-view-btn').removeClass('btn-group-active');
    $(`#${buttonId}`).addClass('btn-group-active');
}