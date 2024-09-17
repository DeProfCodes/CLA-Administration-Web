

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
    var name = $(`#${selectListId}`).val();
    alert('Hello ' + name);
}

function ModuleFilterDatesFilterChange(moduleName, dateInputId)
{
    var newDate = $(`#${dateInputId}`).val();
    alert('Date = ' + newDate);
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
        //ShowLoader("Secondary", `Loading ${status} Popups...`);
    }
}

function ReloadFilteredModuleOverview(moduleType, status, username, startDate, endDate)
{
    ModuleOverviewLoader(moduleType, status);

    var url = GetPageUrl('PopupOverviewFilter') + `?status=${status}&userType=${username}&startDate=${startDate}&endDate=${endDate}`;

    LoadPartialViewWithLoader(url, "#PopupOverviewTableContainer","#SecondaryLoader");
}