

function ToggleIconImageActive(leftIconId, isActive)
{
    var iconImgUrl = $(leftIconId).attr("src");

    var newUrl = isActive ? iconImgUrl.replace('white', 'blue') : iconImgUrl.replace('blue', 'white');

    $(leftIconId).attr("src", newUrl);
}

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

function ExpandCloseAllMainMenuDropdowns(excludeDropDownId)
{
    const leftMenus = ["Dashboard", "Admin", "Modules", "Settings", "Reports", "Support", "Account"];

    for (let i = 0; i < leftMenus.length; i++)
    {
        var groupName = leftMenus[i];
        var linkId = `#${groupName}Link`;
        var leftIconId = `#${groupName}LeftIcon`;
        var titleId = `#${groupName}Title`;
        var rightIconId = `#${groupName}RightIcon`;
        var dropDownId = `#${groupName}Dropdown`;

        if(excludeDropDownId != null && excludeDropDownId == dropDownId)
        {
            continue;
        }
        ExpandCloseLeftNavMenu(linkId, leftIconId, titleId, rightIconId, dropDownId, 'left-nav-menu-active', false);
    }
}

function ExpandCloseAllSubMenuDropdowns(excludeDropDownId)
{
    const leftMenus = ["ContentLibrary", "LockedDesktop", "Desktop", "Screensaver", "Popup", "Survey", "Ticker", "RSS"];

    for (let i = 0; i < leftMenus.length; i++)
    {
        var groupName = leftMenus[i];
        var linkId = `#${groupName}Link`;
        var leftIconId = `#${groupName}LeftIcon`;
        var titleId = `#${groupName}Title`;
        var rightIconId = `#${groupName}RightIcon`;
        var dropDownId = `#${groupName}Dropdown`;

        if(excludeDropDownId != null && excludeDropDownId == dropDownId)
        {
            continue;
        }
        ExpandCloseLeftNavMenu(linkId, leftIconId, titleId, rightIconId, dropDownId, 'left-sub-nav-menu-active', true);
    }
}

function ExpandToggleLeftMainNavMenu(groupName)
{
    var linkId = `#${groupName}Link`;
    var leftIconId = `#${groupName}LeftIcon`;
    var titleId = `#${groupName}Title`;
    var rightIconId = `#${groupName}RightIcon`;
    var dropDownId = `#${groupName}Dropdown`;

    var isOpening = $(dropDownId).hasClass('menu-active') == false;

    if (isOpening)
    {
        ExpandCloseAllMainMenuDropdowns();
        ExpandOpenLeftNavMenu(linkId, leftIconId, titleId, rightIconId, dropDownId, 'left-nav-menu-active', false);
    }
    else
    {
        ExpandCloseLeftNavMenu(linkId, leftIconId, titleId, rightIconId, dropDownId, 'left-nav-menu-active', false);
    }
}

function ExpandOpenLeftMainNavMenu(groupName)
{
    var linkId = `#${groupName}Link`;
    var leftIconId = `#${groupName}LeftIcon`;
    var titleId = `#${groupName}Title`;
    var rightIconId = `#${groupName}RightIcon`;
    var dropDownId = `#${groupName}Dropdown`;

    ExpandCloseAllMainMenuDropdowns(dropDownId);
    ExpandOpenLeftNavMenu(linkId, leftIconId, titleId, rightIconId, dropDownId, 'left-nav-menu-active', false);
}

function ExpandCloseLeftMainNavMenu(groupName)
{
    var linkId = `#${groupName}Link`;
    var leftIconId = `#${groupName}LeftIcon`;
    var titleId = `#${groupName}Title`;
    var rightIconId = `#${groupName}RightIcon`;
    var dropDownId = `#${groupName}Dropdown`;

    ExpandCloseLeftNavMenu(linkId, leftIconId, titleId, rightIconId, dropDownId, 'left-nav-menu-active', false);
}

function ExpandOpenLeftSubNavMenu(groupName)
{
    var linkId = `#${groupName}Link`;
    var leftIconId = `#${groupName}LeftIcon`;
    var titleId = `#${groupName}Title`;
    var rightIconId = `#${groupName}RightIcon`;
    var dropDownId = `#${groupName}Dropdown`;

    ExpandCloseAllSubMenuDropdowns(dropDownId);
    ExpandOpenLeftNavMenu(linkId, leftIconId, titleId, rightIconId, dropDownId, 'left-sub-nav-menu-active', true);
}

function ExpandCloseLeftSubNavMenu(groupName)
{
    var linkId = `#${groupName}Link`;
    var leftIconId = `#${groupName}LeftIcon`;
    var titleId = `#${groupName}Title`;
    var rightIconId = `#${groupName}RightIcon`;
    var dropDownId = `#${groupName}Dropdown`;

    ExpandCloseLeftNavMenu(linkId, leftIconId, titleId, rightIconId, dropDownId, 'left-sub-nav-menu-active', true);
}

function ExpandToggleLeftSubNavMenu(groupName)
{
    var linkId = `#${groupName}Link`;
    var leftIconId = `#${groupName}LeftIcon`;
    var titleId = `#${groupName}Title`;
    var rightIconId = `#${groupName}RightIcon`;
    var dropDownId = `#${groupName}Dropdown`;

    var isOpening = $(dropDownId).hasClass('menu-active') == false;

    if (isOpening)
    {
        ExpandCloseAllSubMenuDropdowns();
        ExpandOpenLeftNavMenu(linkId, leftIconId, titleId, rightIconId, dropDownId, 'left-sub-nav-menu-active', true);
    }
    else
    {
        ExpandCloseLeftNavMenu(linkId, leftIconId, titleId, rightIconId, dropDownId, 'left-sub-nav-menu-active', true);
    }
}

function SetLinkActive(linkId)
{
    $('.left-sub-nav-link').removeClass("active-sub-nav-link");
    $(linkId).addClass("active-sub-nav-link");
}

function OpenLeftNavigationPage(page, linkId)
{
    SetLinkActive(`#${linkId}`);
    OpenPage(page);

    if (IsTrayClosedByScreenSize())
    {
        CloseMenuTray();
    }
}

function OpenLeftNavigationPageAll(page, linkId)
{
    ExpandCloseAllSubMenuDropdowns();
    OpenLeftNavigationPage(page, linkId);
}

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
