

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