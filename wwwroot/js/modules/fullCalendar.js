

function CreateModuleCalendarView(calendarDivId,eventsData)
{
    var calendarEl = document.getElementById(calendarDivId); 

    var calendar = new FullCalendar.Calendar(calendarEl, 
    {
        initialView: 'timeGridWeek',
        initialDate: '2024-08-07',
        headerToolbar: {
          left: 'prev,next today',
          center: 'title',
          right: 'timeGridWeek,timeGridDay'
        },
        events: eventsData
    });

    calendar.render();
}