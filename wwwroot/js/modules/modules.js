

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


//popup module js
let currentPopup = 1;
let totalPopups = 9;

function showPopup(popupNumber) {
    for (let i = 1; i <= totalPopups; i++) {
        var popupElement = document.getElementById(`popup${i}`);
        if (popupElement) {
            popupElement.style.display = i === popupNumber ? 'block' : 'none';
        }
    }

    var pageNumberElement = document.getElementById('pageNumber');
    if (pageNumberElement) {
        pageNumberElement.textContent = `Page ${popupNumber}`;
    }

    var backBtn = document.getElementById('backBtn');
    var nextBtn = document.getElementById('nextBtn');
    var submitBtn = document.getElementById('submitBtn');
    var previewBox = document.getElementById('preview-box');

    if (backBtn && nextBtn && submitBtn && previewBox) {
        backBtn.style.display = popupNumber === 1 ? 'none' : 'inline-block';
        previewBox.style.display = popupNumber === 1 ? 'none' : 'inline-block';
        nextBtn.style.display = popupNumber === totalPopups ? 'none' : 'inline-block';
        submitBtn.style.display = popupNumber === totalPopups ? 'inline-block' : 'none';
    }

    updatePopupSidebar(popupNumber);
}

function nextPopup() {
    if (currentPopup < totalPopups) {
        currentPopup++;
        showPopup(currentPopup);
    }
}

function prevPopup() {
    if (currentPopup > 1) {
        currentPopup--;
        showPopup(currentPopup);
    }
}

function updatePopupSidebar(step) {
    var sidebarLinks = document.querySelectorAll('.module-leftsidebar-link a');
    sidebarLinks.forEach(link => link.classList.remove('active'));

    var sidebarMap = {
        1: 'sidebar-link-type',
        2: 'sidebar-skin',
        3: 'sidebar-texts',
        4: 'sidebar-times',
        5: 'sidebar-displays',
        6: 'sidebar-repeat',
        7: 'sidebar-feedback',
        8: 'sidebar-target-users',
        9: 'sidebar-exposure-summary'
    };

    var currentSidebarLink = document.getElementById(sidebarMap[step]);
    if (currentSidebarLink) {
        currentSidebarLink.classList.add('active');
    }
}

document.addEventListener('DOMContentLoaded', () => {
    showPopup(currentPopup); // Show the current popup

 
   
    var previewBox = document.getElementById('preview-box');
    if (previewBox) {
        previewBox.style.display = 'none'; // Hide back button if on the first page
    }
    const backBtn = document.getElementById('backBtn');
    if (backBtn) {
        backBtn.style.display = 'none'; // Hide back button if on the first page
    }
});


