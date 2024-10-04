
function GetMonthStartAndEnd(dateString, val, val2)
{
    const date = new Date(dateString);
    
    const startOfMonth = new Date(date.getFullYear(), date.getMonth() + val, val2);
    const endOfMonth = new Date(date.getFullYear(), date.getMonth() + val, val2);
    
    const formatDate = (d) => `${d.getFullYear()}-${(d.getMonth() + 1).toString().padStart(2, '0')}-${d.getDate().toString().padStart(2, '0')}`;

    return formatDate(startOfMonth);
}

function FormatDate(dateStr, format) 
{
    let date = new Date(dateStr);

    const map = {
        DDDD: date.toLocaleString('default', { weekday: 'long' }),  // Full day of the week (e.g., Monday)
        DDD: date.toLocaleString('default', { weekday: 'short' }),  // Short day of the week (e.g., Mon)
        DD: ('0' + date.getDate()).slice(-2),  // Day of the month with leading zero
        MMM: date.toLocaleString('default', { month: 'short' }),    // Abbreviated month (e.g., Jan)
        MMMM: date.toLocaleString('default', { month: 'long' }),    // Full month name (e.g., January)
        MM: ('0' + (date.getMonth() + 1)).slice(-2),  // Month number with leading zero
        YYYY: date.getFullYear()  // Full year
    };

    return format.replace(/DDDD|DDD|DD|MMMM|MMM|MM|YYYY/g, matched => map[matched]);
}

function GetImageDimensions(imageURL)
{
    return new Promise((resolve, reject) =>
    {
        if (imageURL)
        {
            const reader = new FileReader();

            reader.readAsDataURL(imageURL);

            reader.onload = function (e)
            {
                const image = new Image();

                image.src = e.target.result;

                image.onload = function ()
                {
                    const width = image.width;
                    const height = image.height;

                    resolve(new DimensionType(width, height));
                };

                image.onerror = function ()
                {
                    reject(new DimensionType(-1, -1));
                };
            };

            reader.onerror = function ()
            {
                reject(new DimensionType(-1, -1));
            };
        } 
        else
        {
            reject(new DimensionType(-1, -1));
        }
    });
}