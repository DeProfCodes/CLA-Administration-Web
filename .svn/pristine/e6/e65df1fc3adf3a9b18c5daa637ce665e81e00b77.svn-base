
var currentTickerTab = 1;
var totalTickerTabs = 5;

var backBtnId = "TickerPrevTabBtn"
var nextBtnId = "TickerNextTabBtn";
var submitBtnId = "AddTickerSubmitBtn";

function ValidateTickerTab(currentTab)
{
    if (currentTab == 1) return IsLinksTypeTabValid("Ticker");
    if (currentTab == 2) return IsTickerTextsTabValid();

    return true;
}

function NextTickerTab()
{
    if (currentTickerTab < totalTickerTabs)
    {
        if (!ValidateTickerTab(currentTickerTab))
            return;

        currentTickerTab = NextModuleTab("ticker", currentTickerTab, totalTickerTabs, backBtnId, nextBtnId, submitBtnId);
    }
}

function PreviousTickerTab()
{
    if (currentTickerTab > 1)
    {
        currentTickerTab = PreviousModuleTab("ticker", currentTickerTab, totalTickerTabs, backBtnId, nextBtnId, submitBtnId);
    }
}

function NavigateToTickerTab(navLinkId, tabLinkNumber)
{
    currentTickerTab = NavigateToModuleTab("ticker", navLinkId, tabLinkNumber, currentTickerTab, backBtnId, nextBtnId, submitBtnId);
}

/*============================================================================*/



function HideAllTickerTabs()
{
    HideShowElement(".ticker-wizard-tabs", HideShow.HIDE);
    HideShowElement("#LinkTypeTab-1", HideShow.SHOW);
}

function TickerLinkTypeClick(linkBtnId)
{
    HideShowElement("#ContentUploadComponent", HideShow.HIDE);
    HideShowElement("#LinkTypeUrl", HideShow.HIDE);
    HideShowElement("#LinkTypeEmail", HideShow.HIDE);
    HideShowElement("#SurveyType", HideShow.HIDE);

    ClearFileUpload("TickerLinkType");

    $(".link-type-btn").removeClass("btn-group-active");
    $(`#${linkBtnId}`).addClass("btn-group-active");

    var btnType = linkBtnId.toLowerCase();

    if (btnType == "nolink" || btnType.includes("ticker"))
    {
        HideShowElement("#LinkTypeAttachment", HideShow.HIDE);
    }
    else
    {
        HideShowElement("#LinkTypeAttachment", HideShow.SHOW);
        $("#UploadFileTitle").removeClass("align-content-center");

        var isAttachmentType = btnType.includes("image") || btnType.includes("audio") || btnType.includes("video") || btnType.includes("document") || btnType.includes("policy");
        var isUrlType = btnType.includes("website") || btnType.includes("email");

        if (isAttachmentType)
        {
            HideShowElement("#ContentUploadComponent", HideShow.SHOW);
            $("#UploadFileTitle").removeClass("align-content-center");

            if (btnType.includes("image"))
            {
                $("#UploadFileTitle").text("Image");
                $("#TickerLinkTypeUploadInput").attr("accept", "image/*");
            }
            else if (btnType.includes("audio"))
            {
                $("#UploadFileTitle").text("Audio");
                $("#TickerLinkTypeUploadInput").attr("accept", "audio/*");
            }
            else if (btnType.includes("video"))
            {
                $("#UploadFileTitle").text("Video");
                $("#TickerLinkTypeUploadInput").attr("accept", "video/*");
            }
            else if (btnType.includes("document"))
            {
                $("#UploadFileTitle").text("Document");
                $("#TickerLinkTypeUploadInput").attr("accept", ".xlsx,.xls,.doc, .docx,.ppt, .pptx,.txt,.pdf");
            }
            else if (btnType.includes("policy"))
            {
                $("#UploadFileTitle").text("Policy (PDF)");
                $("#TickerLinkTypeUploadInput").attr("accept", ".pdf");
            }
        }
        else if (btnType.includes("website"))
        {
            HideShowElement("#LinkTypeUrl", HideShow.SHOW);
            $("#UploadFileTitle").text("Website")
            $("#UploadFileTitle").addClass("align-content-center");

        }
        else if (btnType.includes("email"))
        {
            HideShowElement("#LinkTypeEmail", HideShow.SHOW);
            $("#UploadFileTitle").text("Email")
        }
        else if (btnType.includes("survey"))
        {
            HideShowElement("#SurveyType", HideShow.SHOW);
            $("#UploadFileTitle").text("Survey");
        }
    }
}

function UpdateTickerDisplayTimeDetails()
{
    var startDate = $("#DatePickerStartDate").val();
    var endDate = $("#DatePickerEndDate").val();
    var startTime = $("#TimePickerStartTime").val();
    var endTime = $("#TimePickerEndTime").val();

    if (IsNotEmptyString(startDate) && IsNotEmptyString(endDate) && IsNotEmptyString(startTime) && IsNotEmptyString(endTime))
    {
        $("#TickerStartEffDate").text(startDate);
        $("#TickerEndEffDate").text(endDate);
        $("#TickerStartTimeSlot").text(startTime);
        $("#TickerEndTimeSlot").text(endTime);
    }
}

$("#DatePickerStartDate").change(function ()
{
    UpdateTickerDisplayTimeDetails();
});

$("#DatePickerEndDate").change(function ()
{
    UpdateTickerDisplayTimeDetails();
});

$("#TimePickerStartTime").change(function ()
{
    UpdateTickerDisplayTimeDetails();
});

$("#TimePickerEndTime").change(function ()
{
    UpdateTickerDisplayTimeDetails();
});

function SurveyLinkTypeClick(btnId)
{
    $(".module-link-type").removeClass("btn-group-active");
    $(`#${btnId}`).addClass("btn-group-active");

    btnId = btnId.toLowerCase();

    if (btnId.includes("active"))
    {
        HideShowElement("#SelectSurveyLinkType1", HideShow.SHOW);
        HideShowElement("#SelectSurveyLinkType2", HideShow.HIDE);
    }
    else if (btnId.includes("pending"))
    {
        HideShowElement("#SelectSurveyLinkType1", HideShow.HIDE);
        HideShowElement("#SelectSurveyLinkType2", HideShow.SHOW);
    }
}

//Validations
//#region Validations

function IsTickerTextsTabValid()
{
    $("#TickerTextError").text("");

    var tickerText = $("#TickerText").text();

    if (StringNullOrEmpty(tickerText))
    {
        $("#TickerTextError").text("enter ticker title text");
        swal("Ticker Texts Error", "Enter Ticker text", "error");
        return false;
    }
    return true;
}

//#endregion