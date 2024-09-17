
/// This class is responsible for converting given groupName and compute MenuItem DOM elements IDs for JQuery.
/// LinkId      -> Id of <a> element which is the whole menu item container
/// LeftIconId  -> Id of <img> which contains image icons
/// TitleId     -> Id of <span> which contains the text of the menu item
/// RightIconId -> Id of <i> which is an icon that contains the arrow to show menu opened/closed
/// DropDownId  -> Id of <ul> which is a list which is toggled to dropdown open/close
class LeftNavigationMenuItem
{
    LinkId;
    LeftIconId;
    TitleId;
    RightIconId;
    DropDownId;

    constructor(groupName)
    {
        this.LinkId = `#${groupName}Link`;
        this.LeftIconId = `#${groupName}LeftIcon`;
        this.TitleId = `#${groupName}Title`;
        this.RightIconId = `#${groupName}RightIcon`;
        this.DropDownId = `#${groupName}Dropdown`;
    }
}

/// <summary>  
/// Takes 2 inputs, the Id of image from DOM, and boolean param: isActive, retract src attribute of the image, then modify path name between white and blue depending on 
/// on :isActive variable
/// 
/// -> e.g DOM element: <img id='DesktopOverviewLink' src='~/images/icons/white/modules/desktop.png' />     leftIconId:'DesktopOverviewLink',   isActive:true
/// -> then change src='~/images/icons/white/modules/desktop.png' to src='~/images/icons/blue/modules/desktop.png', and vice versa
/// </summary>  
function ToggleIconImageActive(leftIconId, isActive)
{
    var iconImgUrl = $(leftIconId).attr("src");

    var newUrl = isActive ? iconImgUrl.replace('white', 'blue') : iconImgUrl.replace('blue', 'white');

    $(leftIconId).attr("src", newUrl);
}

/// Expand Left Navigation Menu, animate Slide down, make clicked menu active (set background and color), change drowdown arrow from right to down
function ExpandOpenLeftNavMenu(linkId, leftIconId, titleId, rightIconId, dropDownId, activeNavCss, isImageIcon)
{
    if (isImageIcon)
        ToggleIconImageActive(leftIconId, true);
    else
        $(leftIconId).addClass(activeNavCss);

    $(titleId).addClass(activeNavCss);
    $(rightIconId).addClass(activeNavCss);
    $(rightIconId).removeClass('bi-chevron-right');
    $(rightIconId).addClass('bi-chevron-down');

    $(linkId).addClass(activeNavCss);


    $(dropDownId).addClass("menu-active");
    $(dropDownId).slideDown();
}

/// Opposite of ExpandOpenLeftNavMenu
function ExpandCloseLeftNavMenu(linkId, leftIconId, titleId, rightIconId, dropDownId, activeNavCss, isImageIcon)
{
    if (isImageIcon)
        ToggleIconImageActive(leftIconId, false);
    else
        $(leftIconId).removeClass(activeNavCss);

    $(titleId).removeClass(activeNavCss);
    $(rightIconId).removeClass(activeNavCss);
    $(rightIconId).addClass('bi-chevron-right');
    $(rightIconId).removeClass('bi-chevron-down');

    $(linkId).removeClass(activeNavCss);
    $(dropDownId).removeClass("menu-active");
    $(dropDownId).slideUp();
}

// Close all main menus except for the one provided as parameter
function ExpandCloseAllMainMenuDropdowns(excludeDropDownId)
{
    const leftMenus = ["Dashboard", "Admin", "Modules", "Settings", "Reports", "Support", "Account"];

    for (let i = 0; i < leftMenus.length; i++)
    {
        var groupName = leftMenus[i];
        let navMenu = new LeftNavigationMenuItem(groupName);

        if(excludeDropDownId != null && excludeDropDownId == navMenu.DropDownId)
        {
            continue;
        }
        ExpandCloseLeftNavMenu(navMenu.LinkId, navMenu.LeftIconId, navMenu.TitleId, navMenu.RightIconId, navMenu.DropDownId, 'left-nav-menu-active', false);
    }
}

// Close all main menus except for the one provided as parameter
function ExpandCloseAllSubMenuDropdowns(excludeDropDownId)
{
    const leftMenus = ["ContentLibrary", "LockedDesktop", "Desktop", "Screensaver", "Popup", "Survey", "Ticker", "RSS"];

    for (let i = 0; i < leftMenus.length; i++)
    {
        var groupName = leftMenus[i];
        let navMenu = new LeftNavigationMenuItem(groupName);
       
        if(excludeDropDownId != null && excludeDropDownId == navMenu.DropDownId)
        {
            continue;
        }
        ExpandCloseLeftNavMenu(navMenu.LinkId, navMenu.LeftIconId, navMenu.TitleId, navMenu.RightIconId, navMenu.DropDownId, 'left-sub-nav-menu-active', true);
    }
}

// Derive DOM elements Ids from group name provided, then Expand Left Main Left Menu Open
function ExpandOpenLeftMainNavMenu(groupName)
{
    let navMenu = new LeftNavigationMenuItem(groupName);
    
    ExpandCloseAllMainMenuDropdowns(navMenu.DropDownId);
    ExpandOpenLeftNavMenu(navMenu.LinkId, navMenu.LeftIconId, navMenu.TitleId, navMenu.RightIconId, navMenu.DropDownId, 'left-nav-menu-active', false);
}

// Derive DOM elements Ids from group name provided, then Expand Left Main Left Menu Close
function ExpandCloseLeftMainNavMenu(groupName)
{
    let navMenu = new LeftNavigationMenuItem(groupName);
    
    ExpandCloseLeftNavMenu(navMenu.LinkId, navMenu.LeftIconId, navMenu.TitleId, navMenu.RightIconId, navMenu.DropDownId, 'left-nav-menu-active', false);
}

// Derive DOM elements Ids from group name provided, then Expand Left Main Left Menu Toggle: Open when closed, close when opened
function ExpandToggleLeftMainNavMenu(groupName)
{
    let navMenu = new LeftNavigationMenuItem(groupName);
    var isOpening = $(navMenu.DropDownId).hasClass('menu-active') == false;

    if (isOpening)
    {
        ExpandOpenLeftMainNavMenu(groupName);
    }
    else
    {
        ExpandCloseLeftMainNavMenu(groupName);
    }
}

// Derive DOM elements Ids from group name provided, then Expand Left Sub Left Menu Open
function ExpandOpenLeftSubNavMenu(groupName)
{
    let navMenu = new LeftNavigationMenuItem(groupName);

    ExpandCloseAllSubMenuDropdowns(navMenu.DropDownId);
    ExpandOpenLeftNavMenu(navMenu.LinkId, navMenu.LeftIconId, navMenu.TitleId, navMenu.RightIconId, navMenu.DropDownId, 'left-sub-nav-menu-active', true);
}

// Derive DOM elements Ids from group name provided, then Expand Left Sub Left Menu Close
function ExpandCloseLeftSubNavMenu(groupName)
{
    let navMenu = new LeftNavigationMenuItem(groupName);

    ExpandCloseLeftNavMenu(navMenu.LinkId, navMenu.LeftIconId, navMenu.TitleId, navMenu.RightIconId, navMenu.DropDownId, 'left-sub-nav-menu-active', true);
}

// Derive DOM elements Ids from group name provided, then Expand Left Sub Left Menu Toggle: Open when closed, close when opened
function ExpandToggleLeftSubNavMenu(groupName)
{
    let navMenu = new LeftNavigationMenuItem(groupName);

    var isOpening = $(navMenu.DropDownId).hasClass('menu-active') == false;

    if (isOpening)
    {
        ExpandOpenLeftSubNavMenu(groupName);
    }
    else
    {
        ExpandCloseLeftSubNavMenu(groupName);
    }
}

// Apply background color and animations to mark navigation menu active
function SetLinkActive(linkId)
{
    $('.left-sub-nav-link').removeClass("active-sub-nav-link");
    $(linkId).addClass("active-sub-nav-link");
}

// Open page and apply all desired animations
function OpenLeftNavigationPage(page, linkId)
{
    SetLinkActive(`#${linkId}`);
    OpenPage(page);

    if (IsTrayClosedByScreenSize())
    {
        CloseMenuTray();
    }
}

// Open a page for grouped sections e.g All Modules, All Settings etc
function OpenLeftNavigationPageAll(page, linkId)
{
    ExpandCloseAllSubMenuDropdowns();
    OpenLeftNavigationPage(page, linkId);
}

// Open page and perform all animations of collapsing other menus close and open required as well as setting active page.
function OpenPageWithAnimations(menuGroup, subGroup, page, navPageId, isAllItemsPage = false)
{
    if(menuGroup != null)
    {
        ExpandOpenLeftMainNavMenu(menuGroup);
    }
    if (subGroup != null)
    {
        ExpandOpenLeftSubNavMenu(subGroup);
    }
    if(!isAllItemsPage)
    {
        OpenLeftNavigationPage(page, navPageId);
    }
    else
    {
        OpenLeftNavigationPageAll(page, navPageId);
    }
}
