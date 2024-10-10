var currentSurveyTab = 1;
var totalSurveyTabs = 9;

var backBtnId = "SurveyPrevTabBtn"
var nextBtnId = "SurveyNextTabBtn";
var submitBtnId = "AddSurveySubmitBtn";

function ValidateSurveyTabs(currentTab)
{
    if (currentTab == 1) return IsValidSurveyTexts();
    if (currentTab == 2) return IsSurveySkinsTabValid();
    if (currentTab == 4) return IsValidSurveyResponseUrgency();
    if (currentTab == 6) return IsValidDeliveryMethod();
    /*
    
    if(currentTab == 3) return IsPopupTextsTabValid();
    if(currentTab == 6) return IsPopupRepeatTabValid();
    */
    return true;
}

function PreviousSurveyTab()
{
    if (currentSurveyTab > 1)
    {
        currentSurveyTab = PreviousModuleTab("survey", currentSurveyTab, totalSurveyTabs, backBtnId, nextBtnId, submitBtnId);
    }
}

function NextSurveyTab()
{
    if (currentSurveyTab < totalSurveyTabs)
    {
        if (!ValidateSurveyTabs(currentSurveyTab))
            return;

        currentSurveyTab = NextModuleTab("survey", currentSurveyTab, totalSurveyTabs, backBtnId, nextBtnId, submitBtnId);
    }
}

function NavigateToSurveyTab(navLinkId, tabLinkNumber)
{
    currentSurveyTab = NavigateToModuleTab("survey", navLinkId, tabLinkNumber, currentSurveyTab, backBtnId, nextBtnId, submitBtnId);
}

/*==================================================================================================================================*/

function LoadDefaultSurveySkinPreview()
{
    var surveyDefaultSkin = `${APP_BASE_ADDRESS}/images/others/modules/skins/SurveyBackground.bmp`;

    $("#SurveyPreviewSkin").css("background", `url(${surveyDefaultSkin})`);
    $("#SurveySkinTitleText").text("SurveyBackground.bmp");
}

function HideAllSurveyTabs()
{
    HideShowElement(".survey-wizard-tabs", HideShow.HIDE);
    HideShowElement("#TextsTab-1", HideShow.SHOW);
}

// Tab - 1
function SurveyTextShowHide(id)
{
    if (IsCheckboxChecked(id))
    {
        id = id.toLowerCase();
        if (id.includes("title"))
        {
            $("#SurveyTitleText").text("");
        }
        else if (id.includes("intro"))
        {
            $("#SurveyIntroductionText").text("");
        }
        else if (id.includes("conclusion"))
        {
            $("#SurveyConclusionText").text("");
        }
    }
}

function SurveyResponseUgencySelect(id)
{
    id = id.toLowerCase();
    if (id.includes("critical"))
    {
        HideShowElement("#SurveySnoozeSettingsContainer", HideShow.HIDE);
    }
    else
    {
        HideShowElement("#SurveySnoozeSettingsContainer", HideShow.SHOW);
    }
}

function InitialiseFlatPicker()
{
    $("#SurveyCriticalSnoozeDate").flatpickr({
        dateFormat: "Y-m-d", // Internal format (ISO 8601)
        altInput: true,      // Display formatted date
        altFormat: "l, d F Y, H:i", // Custom display format (e.g., Thursday, 03 October 2024, 17:00)
        minDate: "today",    // Disable past dates
        defaultDate: "today",  // Set initial date to today
        allowInput: true,
        enableTime: true,
    });
}

$("#SurveyTitleText").on('input', function ()
{
    CheckOrUncheckInput("ShowHideSurveyTitle", false);
});

$("#SurveyIntroductionText").on('input', function ()
{
    CheckOrUncheckInput("ShowHideSurveyIntro", false);
});

$("#SurveyConclusionText").on('input', function ()
{
    CheckOrUncheckInput("ShowHideSurveyConclusion", false);
});

function UpdateDisplayTimeDetails()
{
    var startDate = $("#DatePickerStartDate").val();
    var endDate = $("#DatePickerEndDate").val();
    var startTime = $("#TimePickerStartTime").val();
    var endTime = $("#TimePickerEndTime").val();

    if (IsNotEmptyString(startDate) && IsNotEmptyString(endDate) && IsNotEmptyString(startTime) && IsNotEmptyString(endTime))
    {
        $("#SurveyStartEffDate").text(startDate);
        $("#SurveyEndEffDate").text(endDate);
        $("#SurveyStartTimeSlot").text(startTime);
        $("#SurveyEndTimeSlot").text(endTime);
    }
}

$("#DatePickerStartDate").change(function ()
{
    UpdateDisplayTimeDetails();
});

$("#DatePickerEndDate").change(function ()
{
    UpdateDisplayTimeDetails();
});

$("#TimePickerStartTime").change(function ()
{
    UpdateDisplayTimeDetails();
});

$("#TimePickerEndTime").change(function ()
{
    UpdateDisplayTimeDetails();
});


function SurveySnoozeSettingsSelect(id)
{
    id = id.toLowerCase();

    if (id.includes("criticalcount"))
    {
        var hideOrShow = IsCheckboxChecked("SnoozeCriticalCountCheck") ? HideShow.SHOW : HideShow.HIDE;
        HideShowElement("#SurveyCriticalSnoozeCount", hideOrShow);
    }
    else if (id.includes("snoozedate"))
    {
        var hideOrShow = IsCheckboxChecked("SurveyCriticalSnoozeDateCheck") ? HideShow.SHOW : HideShow.HIDE;
        HideShowElement("#SurveyCriticalSnoozeDateContainer", hideOrShow);
    }
}

function SurveySkinTypeSelect(id)
{
    id = id.toLowerCase();
    if (id.includes("defaultskin"))
    {
        LoadDefaultSurveySkinPreview();
        HideShowElement("#SurveySkinPreview", HideShow.SHOW);
        HideShowElement("#SurveySkinImageSelect", HideShow.HIDE);
    }
    else
    {
        HideShowElement("#SurveySkinImageSelect", HideShow.SHOW);
        UpdateSurveySkinPreview();
    }
}

function UpdateSurveySkinPreview()
{
    var skinImgSrc = $("#SurveySkinImageSelect").val();

    if (skinImgSrc != "0")
    {
        $("#SurveyPreviewSkin").css("background", `url(${skinImgSrc})`);
        $("#SurveySkinTitleText").text($("#SurveySkinImageSelect option:selected").text());
    }
    else
    {
        HideShowElement("#SurveySkinPreview", HideShow.HIDE);
    }

    if (skinImgSrc != "0" && $("#SurveyPreviewSkin").css("background").includes("url"))
        HideShowElement("#SurveySkinPreview", HideShow.SHOW);
}

function DisplaySurveyAddOnDetails(id)
{
    var imageId = "#SurveyAddOnDetailsImage";
    var outputId = "#AddOnDetailsTextOnlyText";

    HideShowElement(imageId, HideShow.HIDE);
    $(imageId).removeClass("survey-addon-info-img-btn");
    $(imageId).removeClass("survey-addon-info-img-scored");
    $(imageId).removeClass("survey-addon-info-img-summary");

    id = id.toLowerCase();

    if (id.includes("recall"))
    {
        $(outputId).text("Select this option if you wish to allow the user to recall a completed survey from the CLA Widget");
    }
    else if (id.includes("randomize"))
    {
        $(outputId).text("Select this option if you wish to randomize questions. This will result in targeted users receiving the same " +
            "questions but in different order to prevent cheating or working together on scored assessments.");
    }
    else if (id.includes("usercred"))
    {
        $(outputId).text("Select this option if you wish to Enable Credential Verification on the Standalone Survey module. This allow a central " +
            "administrator to capture survey responses on behalf of staff members or a user can capture their own responses on a " +
            "shared machine by entering their credentials.");
    }
    else if (id.includes("acceptablescore"))
    {
        $(outputId).text("This specify the Overall Acceptable Score for a survey that may contain questions that are scored. ");
    }
    else if (id.includes("prevbtn"))
    {
        HideShowElement(imageId, HideShow.SHOW);
        $(outputId).text("Select this option if you wish to show the survey Previous Button. This allow the user to navigate to previous questions to view " +
            "and/or modify answers (provided the previous questions are not scored). Scored answers will be locked and cannot be changed.");

        $(imageId).addClass("survey-addon-info-img-btn");
        $("#AddOnDetailsTextOnly").addClass("d-flex");

        $(imageId).attr("src", `${APP_BASE_ADDRESS}/images/others/modules/survey/survey_previous_button.png`);
    }
    else if (id.includes("exportbtn"))
    {
        HideShowElement(imageId, HideShow.SHOW);
        $(outputId).text("Select this option if you wish to show the Export Button on the conclusion screen. This allows the user to Export their " +
            "individual results for future reference.");

        $(imageId).addClass("survey-addon-info-img-btn");
        $("#AddOnDetailsTextOnly").addClass("d-flex");

        $(imageId).attr("src", `${APP_BASE_ADDRESS}/images/others/modules/survey/survey_export_button.png`);
    }
    else if (id.includes("correctanswer"))
    {
        HideShowElement(imageId, HideShow.SHOW);
        $(outputId).text("Select this option if you wish to show the correct/incorrect answer to the user on scored questions");

        $(imageId).addClass("survey-addon-info-img-scored");
        $("#AddOnDetailsTextOnly").removeClass("d-flex");

        $(imageId).attr("src", `${APP_BASE_ADDRESS}/images/others/modules/survey/survey_scored_question.jpg`);
    }
    else if (id.includes("scoredsummary"))
    {
        HideShowElement(imageId, HideShow.SHOW);
        $(outputId).text("Select this option if you wish to show the summart of the scored questions on the conclusion screen of the survey.");

        $(imageId).addClass("survey-addon-info-img-summary");
        $("#AddOnDetailsTextOnly").removeClass("d-flex");

        $(imageId).attr("src", `${APP_BASE_ADDRESS}/images/others/modules/survey/survey_score_summary.png`);
    }
}

function ClearSurveyAddOnDetails()
{
    $("#AddOnDetailsTextOnlyText").text("Hold your mouse over an option to view more information.");
    HideShowElement("#SurveyAddOnDetailsImage", HideShow.HIDE);
}

function SurveyDeliveryViaModules(id)
{
    if (IsCheckboxChecked(id))
    {
        CheckOrUncheckInput("SurveyDeliveryViaWidget", false);
    }
}

function SurveyDeliveryViaWidget()
{
    if (IsCheckboxChecked("SurveyDeliveryViaWidget"))
    {
        CheckOrUncheckInput("SurveyDeliveryViaTicker", false);
        CheckOrUncheckInput("SurveyDeliveryViaPopup", false);
        CheckOrUncheckInput("SurveyDeveryViaScreensaver", false);
    }
}


//Validations
//#region Validations

function IsValidSurveyTexts()
{
    $("#NewSurveyTextsTitleError").text("");
    $("#NewSurveyTextsIntroError").text("");
    $("#NewSurveyTextsConclusionError").text("");

    var valid = true;
    if (IsEmptyText("SurveyTitleText") && !IsCheckboxChecked("ShowHideSurveyTitle"))
    {
        $("#NewSurveyTextsTitleError").text("please enter survey title");
        valid = false;
    }
    if (IsEmptyText("SurveyIntroductionText") && !IsCheckboxChecked("ShowHideSurveyIntro"))
    {
        $("#NewSurveyTextsIntroError").text("please enter survey introduction");
        valid = false;
    }
    if (IsEmptyText("SurveyConclusionText") && !IsCheckboxChecked("ShowHideSurveyConclusion"))
    {
        $("#NewSurveyTextsConclusionError").text("please enter survey conclusion");
        valid = false;
    }

    if (!valid)
    {
        swal("Survey Texts Error", "Please enter all required survey texts", "error");
    }
    return valid;
}

function IsSurveySkinsTabValid()
{
    var atLeastOneSkinOptionSelect = $('input:radio[name="SurveySkinOption"]:checked').length > 0;

    if (!atLeastOneSkinOptionSelect)
    {
        swal("Survey Skins Error", "Please select default or custom skin option.", "error");
        return false;
    }
    else
    {
        var selectedSkinOptionId = $('input:radio[name="SurveySkinOption"]:checked').attr("id").toLowerCase();

        if (selectedSkinOptionId.includes("customskin"))
        {
            var selectedSkinValue = $("#SurveySkinImageSelect option:selected").val();
            if (selectedSkinValue == 0)
            {
                swal("Survey Skins Error", "Please select custom skin.", "error");
                return false;
            }
        }
    }
    return true;
}

function IsValidSurveyResponseUrgency()
{
    var atLeastOneSelect = $('input:radio[name="SurveyResponseUrgency"]:checked').length > 0;

    if (!atLeastOneSelect)
    {
        swal("Survey Response Urgency Error", "Please choose a response urgency setting for this survey.", "error");
        return false;
    }
    return true;
}

function IsValidDeliveryMethod()
{
    var atLeastOneSelect = IsCheckboxChecked("SurveyDeveryViaScreensaver") || IsCheckboxChecked("SurveyDeliveryViaPopup") ||
        IsCheckboxChecked("SurveyDeliveryViaTicker") || IsCheckboxChecked("SurveyDeliveryViaWidget");

    if (!atLeastOneSelect)
    {
        swal("Survey Delivery Method Error", "Please choose a delivery method for this survey.", "error");
        return false;
    }
    return true;
}

function IsPopupRepeatTabValid()
{
    var atLeastOneSelected = $('input:radio[name="PopupRepeatOption"]:checked').length > 0;

    if (!atLeastOneSelected)
    {
        swal("Popup Repeat Error", "Please select at least one Popup repeat setting.", "error");
        return false;
    }
    else
    {
        var selectedRepeatOptionId = $('input:radio[name="PopupRepeatOption"]:checked').attr("id").toLowerCase();
        if (selectedRepeatOptionId.includes("daily") || selectedRepeatOptionId.includes("weekly"))
        {
            if (selectedRepeatOptionId.includes("daily") && StringNullOrEmpty($("#DailyRepeatExpiryDate").val()))
            {
                swal("Popup Repeat Error", "Please select enter expiration date.", "error");
                return false;
            }
            if (selectedRepeatOptionId.includes("weekly") && StringNullOrEmpty($("#WeeklyRepeatExpiryDate").val()))
            {
                swal("Popup Repeat Error", "Please select enter expiration date.", "error");
                return false;
            }
        }
    }
    return true;
}

//#endregion
