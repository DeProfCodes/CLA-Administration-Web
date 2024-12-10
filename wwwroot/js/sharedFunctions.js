
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

function GenerateTimeOptions(id)
{
    const select = document.getElementById(id);
    const startTime = 0; // 00:00 in hours
    const endTime = 23; // 23:00 in hours
    const stepMinutes = 30; // Step in minutes (30 mins)

    // Loop through each hour and minute
    for (let hour = startTime; hour <= endTime; hour++)
    {
        for (let minutes = 0; minutes < 60; minutes += stepMinutes)
        {
            const option = document.createElement("option");

            // Pad hours and minutes to ensure two digits (e.g., "08:00", "14:30")
            const hourString = String(hour).padStart(2, '0');
            const minuteString = String(minutes).padStart(2, '0');

            option.value = `${hourString}:${minuteString}`;
            option.text = `${hourString}:${minuteString}`;
            select.appendChild(option);
        }
    }
}

// Create a script element
const script = document.createElement('script');

// Set attributes
script.type = 'text/javascript';
script.charset = 'utf8';
script.src = 'https://cdn.datatables.net/1.13.4/js/jquery.dataTables.js';

// Append the script to the document head or body
document.head.appendChild(script);

function MakeStandardDataTable(tableId)
{
    $(`#${tableId}`).DataTable();
}

function MakeSimpleDataTable(tableId)
{
    $(`#${tableId}`).DataTable({
        dom: 'rtip',
        pageLength: 10,
        responsive: true  // Helps with layout when hidden
    }).columns.adjust().draw(); // Adjust column layout and redraw to ensure it initializes fully
}