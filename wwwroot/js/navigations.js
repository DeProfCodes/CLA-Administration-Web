
function ShowLoader(loaderType, message)
{
    var loaderType = loaderType.toLowerCase() == 'main' ? "Main" : "Secondary";

    var loaderId = `#${loaderType}Loader`;
    var loaderImgId = `${loaderId}Image`;
    var loaderMsgId = `${loaderId}Message`;
    
    $(loaderId).css("visibility", "visible");
    $(loaderImgId).css("visibility", "visible");
    $(loaderMsgId).text(message);
}

function HideLoader(loaderType)
{
    var loaderType = loaderType.toLowerCase() == 'main' ? "Main" : "Secondary";

    var loaderId = `#${loaderType}Loader`;
    var loaderImgId = `${loaderId}Image`;

    $(loaderId).css("visibility", "hidden");
    $(loaderImgId).css("visibility", "hidden");
}

function FinishedLoading(Destination, HTMLContent) 
{
   $(Destination).empty();
   $(Destination).html(HTMLContent);    
}

function LoadPartialView(url, destinationDiv)
{
    $.ajax({
        url: url,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        success: function (res)
        {
            FinishedLoading(destinationDiv, res);   
        },
        error: function (res)
        {
            toastr.error("Error");
        }
    });
}

function LoadPartialViewWithLoader(url, destinationDiv, loaderDiv)
{
    $.ajax({
        url: url,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        beforeSend: function()
        {
            $(destinationDiv).css("opacity", "0.3");
            $(loaderDiv).css("visibility", "visible");
        },
        success: function (res)
        {
            FinishedLoading(destinationDiv, res);   
            $(loaderDiv).css("visibility", "hidden");
            $(destinationDiv).css("opacity", "1");
        },
        error: function (res)
        {
            toastr.error("Error");
            $(loaderDiv).css("visibility", "hidden");
            $(destinationDiv).css("opacity", "1");
        }
    });
}

function OpenPage(page, id)
{
    LoadPageArea(page, id);

    var pageTitle = GetPageTitle(page);

    document.title = pageTitle;
}

function LoadPageArea(page, id)
{
    var url = GetPageUrl(page, id);
    
    var pageName = GetPageTitle(page);
    
    ShowLoader("Main", "Loading " + pageName);

    setTimeout(function ()
    {
        HideLoader("Main");
        LoadPartialView(url, "#DashboardMainArea");

    }, 0);
}


