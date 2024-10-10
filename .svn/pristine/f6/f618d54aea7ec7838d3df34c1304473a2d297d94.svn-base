

//capitalize only the first letter of the string. 
function CapitalizeFirstLetter(string) 
{
    return string.charAt(0).toUpperCase() + string.slice(1);
}

//Get Today String
function TodayDate(seperator = '-')
{
    var today = new Date();
    var month = (today.getMonth()+1).toString();
    var todayDate = today.getFullYear() + seperator + (month.length < 2 ? "0" + month : month) + seperator + today.getDate();

    return todayDate;
}

function HideShowElement(selector, hideShow)
{
    if(hideShow == HideShow.HIDE)
    {
        $(selector).addClass("hidden");
    }
    else if(hideShow == HideShow.SHOW)
    {
        $(selector).removeClass("hidden");
    }
}

function HideShowElementVisibity(selector, hideShow)
{
    if(hideShow == HideShow.HIDE)
    {
        $(selector).addClass("invisble");
    }
    else if(hideShow == HideShow.SHOW)
    {
        $(selector).removeClass("invisble");
    }
}

function StringNullOrEmpty(value)
{
    return value == null || value.trim().length == 0;
}

function IsNotEmptyString(value)
{
    return value != null && value.length > 0;
}

function EnsureJQueryId(Id)
{
    if(IsNotEmptyString(Id) && Id[0] == "#")
        return Id;

    Id = (IsNotEmptyString(Id) && Id[0] != "#") ? `#${Id}` : "invalid";

    return Id;
}

function IsEmptyInput(textBoxId)
{
    textBoxId = EnsureJQueryId(textBoxId);

    var value = $(textBoxId).val();

    return StringNullOrEmpty(value);  
}

function IsEmptyText(textBoxId)
{
    textBoxId = EnsureJQueryId(textBoxId);

    var value = $(textBoxId).text();

    return StringNullOrEmpty(value);  
}

function CheckEmail(email)
{
    if (email == null || email == "")
        return false;

    var emailRegex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

    return email.match(emailRegex);
}

function CheckInputEmail(emailInputId)
{
    emailInputId = EnsureJQueryId(emailInputId);

    var email = $(emailInputId).val();

    return CheckEmail(emailRegex);
}

function IsCheckboxChecked(checkboxId)
{
    checkboxId = EnsureJQueryId(checkboxId);

    return $(checkboxId).is(':checked');
}

function CheckOrUncheckInput(checkboxId, check)
{
    checkboxId = EnsureJQueryId(checkboxId);
    $(checkboxId).prop( "checked", check);
}