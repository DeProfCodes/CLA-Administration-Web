

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



//popup module js
let currentPopup = 1;
let totalPopups = 9;


function showPopup(popupNumber)
{
    for (let i = 1; i <= totalPopups; i++)
    {
        const popupElement = document.getElementById(`popup${i}`);
        if (popupElement)
        {
            popupElement.style.display = i === popupNumber ? 'block' : 'none';
        } else {
            console.warn(`Popup ${i} not found`);
        }
    }

    const pageNumberElement = document.getElementById('pageNumber');
    if (pageNumberElement)
    {
        pageNumberElement.textContent = `Page ${popupNumber}`;
    }

    const backBtn = document.getElementById('backBtn');
    const nextBtn = document.getElementById('nextBtn');
    const submitBtn = document.getElementById('submitBtn');
    const previewBox = document.getElementById('preview-box');

    if (backBtn && nextBtn && submitBtn && previewBox)
    {
        backBtn.style.display = popupNumber === 1 ? 'none' : 'inline-block';
        previewBox.style.display = popupNumber <= 1 ? 'none' : 'inline-block';
        nextBtn.style.display = popupNumber === totalPopups ? 'none' : 'inline-block';
        submitBtn.style.display = popupNumber === totalPopups ? 'inline-block' : 'none';
    }

    // Show or hide the preview based on the page number
   
    updatePopupSidebar(popupNumber);
}

// Go to the next popup
function nextPopup()
{
    if (currentPopup < totalPopups)
    {
        currentPopup++;
        showPopup(currentPopup);
    }
}

// Go to the previous popup
function prevPopup()
{
    if (currentPopup > 1)
    {
        currentPopup--;
        showPopup(currentPopup);
    }
}

// Sidebar update logic
function updatePopupSidebar(step)
{
    const sidebarLinks = document.querySelectorAll('.sidebar a');
    sidebarLinks.forEach(link => link.classList.remove('active'));

    const sidebarMap =
    {
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

    const currentSidebarLink = document.getElementById(sidebarMap[step]);
    if (currentSidebarLink)
    {
        currentSidebarLink.classList.add('active');
    }
}


document.addEventListener('DOMContentLoaded', () =>
{
    showPopup(currentPopup);
    const previewBox = document.getElementById('preview-box');
    if (currentPopup <= 1)
    {

        previewBox.style.display = 'none';
    }
    const backBtn = document.getElementById('backBtn');


    if (backBtn)
    {
        backBtn.style.display = 'none';
        previewBox.style.display = 'none';

    }
});

    LoadPartialViewWithLoader(url, "#PopupOverviewTableContainer","#SecondaryLoader");
}