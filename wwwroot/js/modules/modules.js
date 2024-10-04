

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

function LoadContentPreviewer(containerDivId, moduleContentType)
{
    var url = GetPageUrl("ModuleContentPreviewer", moduleContentType);
    LoadPartialView(url, containerDivId);
}

function PreviewImage()
{
    OpenImagePreviewModal();
}

function PreviewImage2(imgSrc)
{
    OpenImagePreviewModal2(imgSrc);
}

function EnablePopupTabForNavigating(popupTabNo)
{
    var popupTabs = $(".add-new-popup");
    HideShowElement(".add-new-popup", HideShow.HIDE);

    for (let i = 0; i < popupTabs.length; i++)
    {
        var tabElementId = `#${popupTabs[i].getAttribute("id")}`;
        var data = tabElementId.split("-");
        
        if(data != null && data.length >= 2)
        {
            var tabNumber = data[1];
            if (tabNumber == popupTabNo)
            {
                var linkTab = `.module-left-nav-link.T-${tabNumber}`;
                var dotOnTabLink = `.popup-nav-link-dot.T-${tabNumber}`;
                
                $(linkTab).addClass("visited-nav-link");
                $(dotOnTabLink).removeClass("hidden");

                HideShowElement(tabElementId, HideShow.SHOW);

                break;
            }
        }
    }
}

function SwitchPopupTab(popupTabNo)
{
    var popupTabs = $(".add-new-popup");
    HideShowElement(".add-new-popup", HideShow.HIDE);

    for (let i = 0; i < popupTabs.length; i++)
    {
        var tabElementId = `#${popupTabs[i].getAttribute("id")}`;
        var data = tabElementId.split("-");
        
        if(data != null && data.length >= 2)
        {
            var tabNumber = data[1];
            if (tabNumber == popupTabNo)
            {
                var linkTab = `.module-left-nav-link.T-${tabNumber}`;
                var dotOnTabLink = `.popup-nav-link-dot.T-${tabNumber}`;
                
                $(linkTab).removeClass("visited-nav-link");
                $(dotOnTabLink).addClass("hidden");

                HideShowElement(tabElementId, HideShow.SHOW);

                break;
            }
        }
    }
}

function UpdatePopupTabsNavigation(popupTabNo)
{
    var popupLinkTabsNav = $(".module-left-nav-link");
    $(".module-left-nav-link").removeClass("active");

    for (let i = 0; i < popupLinkTabsNav.length; i++)
    {
        var tabLinkElementId = `#${popupLinkTabsNav[i].getAttribute("id")}`;
        var data = tabLinkElementId.split("-");
        
        if(data != null && data.length >= 2)
        {
            var tabNumber = data[1];
            if (tabNumber == popupTabNo)
            {
                $(tabLinkElementId).addClass("active");
                break;
            }
        }
    }
}

function UpdatePopupTabButtons(popupTabNo)
{
    var tabsCount = $(".module-left-nav-link").length;
    if(popupTabNo == 1)
    {
        HideShowElement("#PopupPrevTabBtn", HideShow.HIDE);
    }
    if(popupTabNo > 1 && popupTabNo < tabsCount)
    {
        HideShowElement("#PopupPrevTabBtn", HideShow.SHOW);
    }
    if(popupTabNo == tabsCount)
    {
         HideShowElement("#PopupNextTabBtn", HideShow.HIDE);
         HideShowElement("#AddPopupSubmitBtn", HideShow.SHOW);
    }
}

function ValidateTab(currentTab)
{
    if(currentTab == 1) return IsLinksTabValid();
    if(currentTab == 2) return IsSkinsTabValid();
    if(currentTab == 3) return IsPopupTextsTabValid();
    if(currentTab == 6) return IsPopupRepeatTabValid();

    return true;
}

function CustomNavigateToTab(popupTabNo)
{
    EnablePopupTabForNavigating(currentPopupTab);
    SwitchPopupTab(popupTabNo);
    UpdatePopupTabsNavigation(popupTabNo);
    UpdatePopupTabButtons(popupTabNo);
}

function NextPopupTab()
{
    if (currentPopupTab < totalPopupTabs)
    {
        if(!ValidateTab(currentPopupTab))
            return;

        EnablePopupTabForNavigating(currentPopupTab);

        currentPopupTab++;

        SwitchPopupTab(currentPopupTab);
        UpdatePopupTabsNavigation(currentPopupTab);
        UpdatePopupTabButtons(currentPopupTab);
    }
}

function PreviousPopupTab()
{
    if (currentPopupTab > 1)
    {
        EnablePopupTabForNavigating(currentPopupTab);

        currentPopupTab--;

        SwitchPopupTab(currentPopupTab);
        UpdatePopupTabsNavigation(currentPopupTab);
        UpdatePopupTabButtons(currentPopupTab);
    }
}
