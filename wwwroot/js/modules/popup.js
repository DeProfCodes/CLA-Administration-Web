var currentSurveyTab = 1;
var totalSurveyTabs = 9;

var backBtnId = "PopupPrevTabBtn"
var nextBtnId = "PopupNextTabBtn";
var submitBtnId = "AddPopupSubmitBtn";

function ValidatePopupTabs(currentTab)
{
    if(currentTab == 1) return IsLinksTypeTabValid("Popup");
    if(currentTab == 2) return IsSkinsTabValid();
    if(currentTab == 3) return IsPopupTextsTabValid();
    if(currentTab == 6) return IsPopupRepeatTabValid();

    return true;
}

function PreviousPopupTab()
{
    if (currentSurveyTab > 1)
    {
        currentSurveyTab = PreviousModuleTab("popup", currentSurveyTab, totalSurveyTabs, backBtnId, nextBtnId, submitBtnId);
    }
}

function NextPopupTab()
{
    if (currentSurveyTab < totalSurveyTabs)
    {
        if (!ValidatePopupTabs(currentSurveyTab))
            return;
        
        currentSurveyTab = NextModuleTab("popup", currentSurveyTab, totalSurveyTabs, backBtnId, nextBtnId, submitBtnId);
    }
}

function NavigateToPopupTab(navLinkId, tabLinkNumber)
{
     currentSurveyTab = NavigateToModuleTab("popup", navLinkId, tabLinkNumber, currentSurveyTab, backBtnId, nextBtnId, submitBtnId);
}

/*==================================================================================================================================*/

function IntilizeSkinsPreview()
{
    HideShowElementVisibity("#PopupSkinPreview", HideShow.HIDE);

    HideShowElementVisibity("#PopupFeedbackContents", HideShow.HIDE);
    HideShowElementVisibity("#PopupFeedbackWindow", HideShow.HIDE);
}

function LoadDefaultSkinPreview()
{
    
    var popupDefaultSkin = `${APP_BASE_ADDRESS}/images/others/modules/skins/Popup_Skin_Default.png`;
    
    $("#PopupBodyPreview").css("background", `url(${popupDefaultSkin})`);
    $("#SkinFileName").text("Popup_Skin_Default.png");
    $("#PopupBodyPreviewFeedback").css("background", `url(${popupDefaultSkin})`);
}

function HideAllPopupTabs()
{
    HideShowElement(".popup-wizard-tabs", HideShow.HIDE);
    HideShowElement("#LinkTypeTab-1", HideShow.SHOW);
}

function PopupLinkTypeClick(linkBtnId)
{
    HideShowElement("#ContentUploadComponent", HideShow.HIDE);
    HideShowElement("#LinkTypeUrl", HideShow.HIDE);
    HideShowElement("#LinkTypeEmail", HideShow.HIDE);
    HideShowElement("#SurveyType", HideShow.HIDE);

    ClearFileUpload("PopupLinkType");

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
                $("#PopupLinkTypeUploadInput").attr("accept", "image/*");
            }
            else if (btnType.includes("audio"))
            {
                $("#UploadFileTitle").text("Audio");
                $("#PopupLinkTypeUploadInput").attr("accept", "audio/*");
            }
            else if (btnType.includes("video"))
            {
                $("#UploadFileTitle").text("Video");
                $("#PopupLinkTypeUploadInput").attr("accept", "video/*");
            }
            else if (btnType.includes("document"))
            {
                $("#UploadFileTitle").text("Document");
                $("#PopupLinkTypeUploadInput").attr("accept", ".xlsx,.xls,.doc, .docx,.ppt, .pptx,.txt,.pdf");
            }
            else if (btnType.includes("policy"))
            {
                $("#UploadFileTitle").text("Policy (PDF)");
                $("#PopupLinkTypeUploadInput").attr("accept", ".pdf");
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

function CheckAllEmailsListValid(emailList)
{
    var emails = emailList.split(";");
    for (let i = 0; i < emails.length; i++)
    {
        if (!CheckEmail(emails[i]))
            return false;
    }
    return true;
}

function PopupSkinTypeSelect(id)
{
    HideShowElementVisibity("#PopupSkinPreview", HideShow.SHOW);

    id = id.toLowerCase();
    if (id.includes("defaultskin"))
    {
        LoadDefaultSkinPreview();
        HideShowElement("#PopupSkinImage", HideShow.HIDE);
    }
    else
    {
        HideShowElement("#PopupSkinImage", HideShow.SHOW);
        UpdatePopupSkinPreview();
    }
}

function UpdatePopupSkinPreview()
{
    HideShowElementVisibity("#PopupSkinPreview", HideShow.SHOW);

    var skinImgSrc = $("#PopupSkinImage").val();

    if (skinImgSrc != "0")
    {
        $("#PopupBodyPreview").css("background", `url(${skinImgSrc})`);
        $("#PopupBodyPreviewFeedback").css("background", `url(${skinImgSrc})`);
        $("#SkinFileName").text($("#PopupSkinImage option:selected").text());
    }
}

function PopupIconOptionSelect(iconTypeId)
{
    HideShowElement("#PopupStandardIconsContainer", HideShow.HIDE);
    HideShowElement("#PopupCustomIconsContainer", HideShow.HIDE);
    HideShowElement("#PopupIconImg", HideShow.SHOW);
    HideShowElement("#PopupIconImgFeedback", HideShow.SHOW);

    iconTypeId = iconTypeId.toLowerCase();
    if (iconTypeId.includes("standard"))
    {
        HideShowElement("#PopupStandardIconsContainer", HideShow.SHOW);

        if ($('input:radio[name="PopupStandardIconOption"]:checked').length == 0)
        {
            $("#PopupStandardIconInfo").prop("checked", true);
            PopupStandardIconSelect("PopupStandardIconInfo");
        }
    }
    else if (iconTypeId.includes("custom"))
    {
        HideShowElement("#PopupCustomIconsContainer", HideShow.SHOW);
        $("#CustomIconInput").attr("accept", "image/*");

        var customIconUrl = $("#PopupCustomIconUploadFileURL").val();
        SetPopupIcon(customIconUrl);
    }
    else if (iconTypeId.includes("none"))
    {
        HideShowElement("#PopupIconImg", HideShow.HIDE);
        HideShowElement("#PopupIconImgFeedback", HideShow.HIDE);
    }
}

function SetPopupIcon(iconImgUrl)
{
    if (!StringNullOrEmpty(iconImgUrl))
    {
        $("#PopupIconImg").attr("src", iconImgUrl);
        $("#PopupIconImgFeedback").attr("src", iconImgUrl);
    }
}

function PopupStandardIconSelect(iconId)
{
    iconId = iconId.toLowerCase();

    var iconUrl = "";
    
    if (iconId.includes("info")) iconUrl = `${APP_BASE_ADDRESS}/images/icons/modules/popup/icon-info.png`;
    if (iconId.includes("warning")) iconUrl = `${APP_BASE_ADDRESS}/images/icons/modules/popup/icon-warning.png`;
    if (iconId.includes("error")) iconUrl = `${APP_BASE_ADDRESS}/images/icons/modules/popup/icon-error.png`;

    SetPopupIcon(iconUrl);
}

function UpdatePopupIconCustom(customImgUrl, fileData)
{
    GetImageDimensions(fileData).then(dimensions =>
    {
        if (dimensions.Width == 48 && dimensions.Width == 48)
        {
            SetPopupIcon(customImgUrl);
        }
        else
        {
            swal("Popup Icon Error", "Please upload image that is 48x48 pixels in dimension.", "error");
            ClearFileUpload("PopupCustomIcon");
        }
    })
    .catch(error =>
    {
        console.error('Error getting image dimensions:', error);
        ClearFileUpload("PopupCustomIcon");
    });
}


function ShowHidePopupText(sliderId, textType)
{
    var divPopupTextId = (textType == "title") ? "#PopupBodyPreviewTitleText" : "#PopupBodyPreviewTextBody";
    var htmlEditorId = (textType == "title") ? "PopupTextHeader" : "PopupTextBody";

    if ($(`#${sliderId}`).is(':checked'))
    {
        UpdatePreviews(htmlEditorId, "True", divPopupTextId);
    }
    else
    {
        $(divPopupTextId).html("");
        $(`${divPopupTextId}Feedback`).html("");
    }
}

function TogglePopupDisplaySettings()
{
    if (IsCheckboxChecked("DismissablePopupToggle"))
    {
        HideShowElement("#PopupDismissIcon", HideShow.SHOW);
        HideShowElement("#PopupDismissIconFeedback", HideShow.SHOW);
    }
    else
    {
        HideShowElement("#PopupDismissIcon", HideShow.HIDE);
        HideShowElement("#PopupDismissIconFeedback", HideShow.HIDE);
    }
    if (IsCheckboxChecked("SnoozePopupToggle"))
    {
        HideShowElement("#PopupSnoozeBtn", HideShow.SHOW);
        HideShowElement("#PopupSnoozeBtnFeedback", HideShow.SHOW);
    }
    else
    {
        HideShowElement("#PopupSnoozeBtn", HideShow.HIDE);
        HideShowElement("#PopupSnoozeBtnFeedback", HideShow.HIDE);
    }
}

function SetPopupPosition(popupPosId)
{
    $(".popup-pos").removeClass("active");
    $(`#${popupPosId}`).addClass("active");
}

function PopupRepeatInitailExpirationDate()
{
    $("#DailyRepeatExpiryDate").flatpickr({
        dateFormat: "Y-m-d", // Internal format (ISO 8601)
        altInput: true,      // Display formatted date
        altFormat: "l, d F Y", // Custom display format (e.g., Thursday, 03 October 2024)
        minDate: "today",    // Disable past dates
        defaultDate: "today",  // Set initial date to today
        allowInput: true
    });

    $("#WeeklyRepeatExpiryDate").flatpickr({
        dateFormat: "Y-m-d", // Internal format (ISO 8601)
        altInput: true,      // Display formatted date
        altFormat: "l, d F Y", // Custom display format (e.g., Thursday, 03 October 2024)
        minDate: "today",    // Disable past dates
        defaultDate: "today",  // Set initial date to today
        allowInput: true
    });
}

function PopupRepeatOptionSelect(id)
{
    HideShowElement("#PopupRepeatDailyContainer", HideShow.HIDE);
    HideShowElement("#PopupRepeatWeeklyContainer", HideShow.HIDE);

    id = id.toLowerCase();
    if (id.includes("daily"))
    {
        HideShowElement("#PopupRepeatDailyContainer", HideShow.SHOW);
    }
    else if (id.includes("weekly"))
    {
        HideShowElement("#PopupRepeatWeeklyContainer", HideShow.SHOW);
    }
}

function UpdatePopupFeedback()
{

    if (IsCheckboxChecked("FeedbackLikeDislikeToggle") || IsCheckboxChecked("FeedbackCommentToggle"))
    {
        HideShowElementVisibity("#PopupFeedbackContents", HideShow.SHOW);
        HideShowElementVisibity("#PopupFeedbackWindow", HideShow.SHOW);

        let hideShowDislike = IsCheckboxChecked("FeedbackLikeDislikeToggle") ? HideShow.SHOW : HideShow.HIDE;
        HideShowElementVisibity("#PopupFeedbackLikeDislikeIcons", hideShowDislike);
        HideShowElement("#FeedbackLikeDislikeTxt", hideShowDislike);

        let hideShowComment = IsCheckboxChecked("FeedbackCommentToggle") ? HideShow.SHOW : HideShow.HIDE;
        HideShowElementVisibity("#PopupFeedbackComment", hideShowComment);
        HideShowElement("#FeedbackCommentTxt", hideShowComment)
    }
    else
    {
        HideShowElementVisibity("#PopupFeedbackContents", HideShow.HIDE);
        HideShowElementVisibity("#PopupFeedbackWindow", HideShow.HIDE);
    }
}

//Validations
//#region Validations

function IsSkinsTabValid()
{
    var atLeastOneSkinOptionSelect = $('input:radio[name="PopupSkinOption"]:checked').length > 0;
    var atLeastOneIconOptionSelect = $('input:radio[name="PopupIconOption"]:checked').length > 0;
    if (!atLeastOneSkinOptionSelect || !atLeastOneIconOptionSelect)
    {
        if (!atLeastOneSkinOptionSelect && atLeastOneIconOptionSelect)
            swal("Popup Skins Error", "Please select default or custom skin option.", "error");

        else if (atLeastOneSkinOptionSelect && !atLeastOneIconOptionSelect)
            swal("Popup Icon Error", "Please select at least one icon option.", "error");

        else if (!atLeastOneSkinOptionSelect && !atLeastOneIconOptionSelect)
            swal("Popup Skin & Icon Error", "Please select popup skin and popup icon.", "error");

        return false;
    }
    else
    {
        var selectedSkinOptionId = $('input:radio[name="PopupSkinOption"]:checked').attr("id").toLowerCase();
        var selectedIconOptionId = $('input:radio[name="PopupIconOption"]:checked').attr("id").toLowerCase();

        var errorsCount = 0;
        var combinedErrorMessage = "";
        if (selectedSkinOptionId.includes("customskin"))
        {
            var selectedSkinValue = $("#PopupSkinImage option:selected").val();
            if (selectedSkinValue == 0)
            {
                combinedErrorMessage = "Please select custom skin.";
                errorsCount++;
            }
        }
        if (selectedIconOptionId.includes("custom"))
        {
            if (StringNullOrEmpty($("#PopupCustomIcon_UploadFileURL").val()))
            {
                combinedErrorMessage += "Please select custom Icon.";
                errorsCount++;
            }
        }
        if (errorsCount > 0)
        {
            swal("Popup Skin & Icon Error", combinedErrorMessage, "error");
            return false;
        }
    }
    return true;
}

function IsPopupTextsTabValid()
{
    $("#LinkTypeTextsTitleError").text("");
    $("#LinkTypeTextsBodyError").text("");

    var titleText = $("#PopupTextHeader").text();
    var bodyText = $("#PopupTextBody").text();

    var isValid = true;

    if (StringNullOrEmpty(titleText))
    {
        $("#LinkTypeTextsTitleError").text("enter popup title text");
        isValid = false;
    }
    if (StringNullOrEmpty(bodyText))
    {
        $("#LinkTypeTextsBodyError").text("enter popup title body");
        isValid = false;
    }

    if (!isValid)
    {
        swal("Popup Texts Error", "Enter Popup Texts", "error");
    }

    return isValid;
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
