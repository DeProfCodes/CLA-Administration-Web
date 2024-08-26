
function FinishedLoading(Destination, HTMLContent) 
{
   $(Destination).empty();
   $(Destination).html(HTMLContent);    
}

function LoadPartialWithSpinner(url, destinationDiv)
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

