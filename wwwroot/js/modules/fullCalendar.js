

function CreateModuleCalendarView(calendarDivId,eventsData)
{
    var calendarEl = document.getElementById(calendarDivId); 

    var calendar = new FullCalendar.Calendar(calendarEl, 
    {
        initialView: 'timeGridWeek',
        initialDate: TodayDate(),
        headerToolbar: {
          left: 'prev,next today',
          center: 'title',
          right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
        events: eventsData
    });

    calendar.render();
}