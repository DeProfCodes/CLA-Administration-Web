

function ModuleFilterButtonClick(moduleName, filterBtnId)
{
    $('.module-filter-btn-group').removeClass('btn-group-active');
    $(`#${filterBtnId}`).addClass('btn-group-active');
}

function ModuleFilterUsersFilterChange(moduleName, selectListId)
{
    var name = $(`#${selectListId}`).val();
    alert('Hello ' + name);
}

function ModuleFilterDatesFilterChange(moduleName, dateInputId)
{
    var newDate = $(`#${dateInputId}`).val();
    alert('Date = ' + newDate);
}