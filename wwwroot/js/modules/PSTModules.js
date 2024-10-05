
function IsLinksTypeTabValid(moduleName)
{
    var linkTypeBtn = $(".link-type-btn.btn-group-active");

    var btnId = linkTypeBtn.attr("id").toLowerCase();
    var btnText = $(linkTypeBtn).text();

    var isAttachmentType = btnId.includes("image") || btnId.includes("audio") || btnId.includes("video") || btnId.includes("document") || btnId.includes("policy");

    if (btnId.includes("nolink") || btnId.includes("ticker"))
    {
        return true;
    }
    else if (isAttachmentType)
    {
        var uploadFileUrl = $(`#${moduleName}LinkType_UploadFileURL`).val();
        if (StringNullOrEmpty(uploadFileUrl))
        {
            swal(`${moduleName} Link Error`, `Please upload ${btnText} file`, "error");
            return false;
        }
        return true;
    }
    else if (btnId.includes("website"))
    {
        if (IsEmptyInput("#LinkTypeUrlInput"))
        {
            swal(`${moduleName} Link Error`, `Please upload enter website URL`, "error");
            return false;
        }
    }
    else if (btnId.includes("email"))
    {
        $("#LinkTypeEmailValid").text("");
        $("#LinkTypeCCEmailValid").text("");
        $("#LinkTypeEmailSubjectValid").text("");
        $("#LinkTypeEmailMessageValid").text("");

        var emails = $("#LinkTypeEmailInput").val();
        var ccEmails = $("#LinkTypeCCEmailInput").val();
        var emailsValid = true;

        if (IsEmptyInput("#LinkTypeEmailInput") || !CheckAllEmailsListValid(emails))
        {
            $("#LinkTypeEmailValid").text("please enter valid emails!");
            emailsValid = false;
        }
        if (!IsEmptyInput("#LinkTypeCCEmailInput") && !CheckAllEmailsListValid(ccEmails))
        {
            $("#LinkTypeCCEmailValid").text("please enter valid emails!");
            emailsValid = false;
        }
        if (IsEmptyInput("#LinkTypeEmailSubjectInput"))
        {
            $("#LinkTypeEmailSubjectValid").text("please enter subject!");
            emailsValid = false;
        }
        if (IsEmptyInput("#LinkTypeEmailMessageInput"))
        {
            $("#LinkTypeEmailMessageValid").text("please enter email message!");
            emailsValid = false;
        }

        if (!emailsValid)
        {
            swal(`${moduleName} Link Error`, `Please enter valid emails information.`, "error");
            return false;
        }
        return true;
    }
    else if (btnId.includes("survey"))
    {
        var surveyTypeTxt = $(".module-link-type.btn-group-active").text().toLowerCase();

        var invalidSurvey = (surveyTypeTxt.includes("active")) ? ($("#SelectSurveyLinkType1").val() == null || $("#SelectSurveyLinkType1").val() == 0) :
            ($("#SelectSurveyLinkType2").val() == null || $("#SelectSurveyLinkType2").val() == 0);

        if (invalidSurvey)
        {
            swal(`${moduleName} Link Error`, `Please select an existing survey to link this ${moduleName} to.`, "error");
            return false;
        }
        return true;
    }
    return false;
}

function EnableModuleTabForNavigating(moduleName, tabNo)
{
    moduleName = moduleName.toLowerCase();

    var moduleTabs = $(`.${moduleName}-wizard-tabs`);
    HideShowElement(`.${moduleName}-wizard-tabs`, HideShow.HIDE);

    for (let i = 0; i < moduleTabs.length; i++)
    {
        var tabElementId = `#${moduleTabs[i].getAttribute("id")}`;
        var data = tabElementId.split("-");

        if (data != null && data.length >= 2)
        {
            var tabNumber = data[1];
            if (tabNumber == tabNo)
            {
                var linkTab = `.module-left-nav-link.T-${tabNumber}`;
                var dotOnTabLink = `.module-nav-link-dot.T-${tabNumber}`;

                $(linkTab).addClass("visited-nav-link");
                $(dotOnTabLink).removeClass("hidden");

                HideShowElement(tabElementId, HideShow.SHOW);

                break;
            }
        }
    }
}

function SwitchModuleTab(moduleName, tabNo)
{
    moduleName = moduleName.toLowerCase();

    var moduleTabs = $(`.${moduleName}-wizard-tabs`);
    HideShowElement(`.${moduleName}-wizard-tabs`, HideShow.HIDE);

    for (let i = 0; i < moduleTabs.length; i++)
    {
        var tabElementId = `#${moduleTabs[i].getAttribute("id")}`;
        var data = tabElementId.split("-");

        if (data != null && data.length >= 2)
        {
            var tabNumber = data[1];
            if (tabNumber == tabNo)
            {
                var linkTab = `.module-left-nav-link.T-${tabNumber}`;
                var dotOnTabLink = `.module-nav-link-dot.T-${tabNumber}`;

                $(linkTab).removeClass("visited-nav-link");
                $(dotOnTabLink).addClass("hidden");

                HideShowElement(tabElementId, HideShow.SHOW);

                break;
            }
        }
    }
}

function UpdateModuleTabsNavigation(tabNo)
{
    var moduleLinkTabsNav = $(".module-left-nav-link");
    $(".module-left-nav-link").removeClass("active");

    for (let i = 0; i < moduleLinkTabsNav.length; i++)
    {
        var tabLinkElementId = `#${moduleLinkTabsNav[i].getAttribute("id")}`;
        var data = tabLinkElementId.split("-");

        if (data != null && data.length >= 2)
        {
            var tabNumber = data[1];
            if (tabNumber == tabNo)
            {
                $(tabLinkElementId).addClass("active");
                break;
            }
        }
    }
}

function UpdateModuleTabButtons(tabNo, backBtnId, nextBtnId, submitBtnId)
{
    backBtnId = EnsureJQueryId(backBtnId);
    nextBtnId = EnsureJQueryId(nextBtnId);
    submitBtnId = EnsureJQueryId(submitBtnId);

    HideShowElement(submitBtnId, HideShow.HIDE);

    var tabsCount = $(".module-left-nav-link").length;
    if (tabNo == 1)
    {
        HideShowElement(backBtnId, HideShow.HIDE);
        HideShowElement(backBtnId, HideShow.SHOW);
    }
    if (tabNo > 1 && tabNo < tabsCount)
    {
        HideShowElement(backBtnId, HideShow.SHOW);
        HideShowElement(nextBtnId, HideShow.SHOW);
    }
    if (tabNo == tabsCount)
    {
        HideShowElement(backBtnId, HideShow.SHOW);
        HideShowElement(nextBtnId, HideShow.HIDE);
        HideShowElement(submitBtnId, HideShow.SHOW);
    }
}

function CustomNavigateToModuleTab(moduleName, currentTabNumber, tabNo, backBtnId, nextBtnId, submitBtnId)
{
    EnableModuleTabForNavigating(moduleName, currentTabNumber);
    SwitchModuleTab(moduleName, tabNo);
    UpdateModuleTabsNavigation(tabNo);
    UpdateModuleTabButtons(tabNo, backBtnId, nextBtnId, submitBtnId);
}

function NavigateToModuleTab(moduleName, navLinkId, tabLinkNumber, currentTabNumber, backBtnId, nextBtnId, submitBtnId)
{
    var canNavigate = !$(`#${navLinkId}`).hasClass("active") && $(`#${navLinkId}`).hasClass("visited-nav-link");
    if (canNavigate)
    {
        CustomNavigateToModuleTab(moduleName, currentTabNumber, tabLinkNumber, backBtnId, nextBtnId, submitBtnId);
        return tabLinkNumber;
    }
    return currentTabNumber;
}

function NextModuleTab(moduleName, tabNumber, maxTabs, backBtnId, nextBtnId, submitBtnId)
{
    if (tabNumber < maxTabs)
    {
        EnableModuleTabForNavigating(moduleName, tabNumber);

        tabNumber++;

        SwitchModuleTab(moduleName, tabNumber);
        UpdateModuleTabsNavigation(tabNumber);
        UpdateModuleTabButtons(tabNumber, backBtnId, nextBtnId, submitBtnId);
    }
    return tabNumber;
}

function PreviousModuleTab(moduleName, tabNumber, maxTabs, backBtnId, nextBtnId, submitBtnId)
{
    if (tabNumber < maxTabs)
    {
        EnableModuleTabForNavigating(moduleName, tabNumber);

        tabNumber--;

        SwitchModuleTab(moduleName, tabNumber);
        UpdateModuleTabsNavigation(tabNumber);
        UpdateModuleTabButtons(tabNumber, backBtnId, nextBtnId, submitBtnId);
    }
    return tabNumber;
}
