

function GetStatusFromButtonId(buttonId)
{
    var id = buttonId.toLowerCase();
    
    if(id.includes('all')) return AllStatusTypes.All;
    if(id.includes('active')) return AllStatusTypes.Active;
    if(id.includes('expired')) return AllStatusTypes.Expired;
    if(id.includes('pending')) return AllStatusTypes.Pending;

    return null;
}

function ModuleFilterButtonClick(filterBtnId, moduleType, status, username, startDate, endDate)
{
    $('.module-filter-btn-group').removeClass('btn-group-active');
    $(`#${filterBtnId}`).addClass('btn-group-active');
    
    if(moduleType == AllModuleTypes.Popup)
    {
        ReloadFilteredModuleOverview(moduleType, status, username, startDate, endDate);
    }
}

function ModuleFilterUsersFilterChange(moduleName, selectListId)
{
    var statusBtn = $(`.module-filter-btn-group.btn-group-active.${moduleName}`); 
    var status = statusBtn.text();
    var btnId = statusBtn.attr("id");

    FilterModuleDataOverviewByStatus(moduleName, btnId, status);
}

function ModuleFilterDatesFilterChange(moduleName, dateInputId)
{
    var statusBtn = $(`.module-filter-btn-group.btn-group-active.${moduleName}`); 
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

function ReloadFilteredModuleOverview(moduleType, status, username, startDate, endDate)
{
    if(popupsDataTable != null)
        popupsDataTable.clear().draw();

    ModuleOverviewLoader(moduleType, status);

    var url = GetPageUrl('PopupOverviewFilter') + `?status=${status}&userType=${username}&startDate=${startDate}&endDate=${endDate}`;

    LoadPartialViewWithLoader(url, "#PopupOverviewTableContainer","#SecondaryLoader");
}

function FilterModuleDataOverviewByStatus(moduleName, buttonId, status)
{
    var username = $(`#${moduleName}UsersFilter`).val();
    var startDate = $(`#${moduleName}DateFromFilter`).val();
    var endDate = $(`#${moduleName}DateToFilter`).val();

    ModuleFilterButtonClick(buttonId, moduleName, status, username, startDate, endDate);
}