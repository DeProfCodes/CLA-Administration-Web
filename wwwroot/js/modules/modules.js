

function GetStatusFromButtonId(buttonId)
{
    var id = buttonId.toLowerCase();
    
    if(id.includes('all')) return AllStatusTypes.All;
    if(id.includes('active')) return AllStatusTypes.Active;
    if(id.includes('expired')) return AllStatusTypes.Expired;
    if(id.includes('pending')) return AllStatusTypes.Pending;

    return null;
}

function ModuleFilterButtonClick(filterBtnId, moduleType, status, username, startDate, endDate, stagingLiveFilter, viewType)
{
    $('.filter-status-btn').removeClass('btn-group-active');
    $(`#${filterBtnId}`).addClass('btn-group-active');
    
    ReloadFilteredModuleOverview(moduleType, status, username, startDate, endDate, stagingLiveFilter, viewType);
}

function ModuleFilterUsersFilterChange(moduleName, selectListId)
{
    var statusBtn = $(`.filter-status-btn.btn-group-active.${moduleName}`); 
    var status = statusBtn.text();
    var btnId = statusBtn.attr("id");

    FilterModuleDataOverviewByStatus(moduleName, btnId, status);
}

function ModuleFilterDatesFilterChange(moduleName)
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

function ReloadFilteredModuleOverview(moduleType, status, username, startDate, endDate, stagingLiveFilter, viewType)
{
    ModuleOverviewLoader(moduleType, status);

    var isPSTModules = (moduleType == AllModuleTypes.Popup || moduleType == AllModuleTypes.Survey || moduleType == AllModuleTypes.Ticker);
    var isLDSModules = (moduleType == AllModuleTypes.LockedDesktop || moduleType == AllModuleTypes.Desktop || moduleType == AllModuleTypes.Screensaver);

    var url = "";
    var pageName = 'ModuleLDSTableOverview';
    
    viewType = viewType.trim().toLowerCase();
    
    if(isLDSModules)
    {
        if(viewType == "tabular") pageName = "ModuleLDSTableOverview";
        if(viewType == "calendar") pageName = "ModuleLDSCalendarOverview";
        if(viewType == "gantt") pageName = "ModuleLDSGanttOverview";
    }
    
    if(isPSTModules)
        url = GetPageUrl('ModulePSTTableOverview') + `?moduleNameType=${moduleType}&status=${status}&userType=${username}&startDate=${startDate}&endDate=${endDate}`;

    if(isLDSModules)
        url = GetPageUrl(pageName) + `?moduleNameType=${moduleType}&status=${status}&stagingLive=${stagingLiveFilter}&startDate=${startDate}&endDate=${endDate}`;
    
    LoadPartialViewWithLoader(url, "#ModuleOverviewTableContainer","#SecondaryLoader");
}

function FilterModuleDataOverviewByStatus(moduleName, buttonId, status)
{
    var username = $(`#${moduleName}UsersFilter`).val();
    var startDate = $(`#${moduleName}DateFromFilter`).val();
    var endDate = $(`#${moduleName}DateToFilter`).val();
    var stagingLiveFilter = $(`.filter-type-btn.btn-group-active.${moduleName}`).text(); 
    var viewType = $(`.filter-view-btn.btn-group-active.${moduleName}`).text();

    ModuleFilterButtonClick(buttonId, moduleName, status, username, startDate, endDate, stagingLiveFilter, viewType);
}

function FilterModuleDataOverviewByStagingLive(moduleType, buttonId, stagingOrLive)
{
    $('.filter-type-btn').removeClass('btn-group-active');
    $(`#${buttonId}`).addClass('btn-group-active');

    var statusBtn = $(`.filter-status-btn.btn-group-active.${moduleType}`); 
    var status = statusBtn.text();
    var btnId = statusBtn.attr("id");

    FilterModuleDataOverviewByStatus(moduleType, btnId, status);
}

function FilterModuleDataOverviewByViewType(moduleType, buttonId)
{
    $('.filter-view-btn').removeClass('btn-group-active');
    $(`#${buttonId}`).addClass('btn-group-active');

    var statusBtn = $(`.filter-status-btn.btn-group-active.${moduleType}`); 
    var status = statusBtn.text();
    var btnId = statusBtn.attr("id");
    
    FilterModuleDataOverviewByStatus(moduleType, btnId, status);
}

function LoadContentPreviewer(containerDivId)
{
    var url = GetPageUrl("ModuleContentPreviewer");
    LoadPartialView(url, containerDivId);
}

function PreviewImage()
{
    OpenImagePreviewModal();
}