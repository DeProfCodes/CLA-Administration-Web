
/*=============== Data Table Variables =========*/

let usersDT = null;
let machinesDT = null;



function ToggleStaginUserMachines(id) {
    $(".filter-type-btn").removeClass("btn-group-active");
    $(`#${id}`).addClass("btn-group-active");

    if (id.includes("User")) {
        $("#BreadcrumSettingsBtnText").text("Add New Target Group User");
        $("#StagingUserMachineTitle").text("Users");
        HideShowElement("#StagingUsersSettings", HideShow.SHOW);
        HideShowElement("#StagingMachinesSettings", HideShow.HIDE);
        SwitchDomainsSelectDataSource(usersDomains);
    }
    else if (id.includes("Machine")) {
        $("#BreadcrumSettingsBtnText").text("Add New Target Group Machine");
        $("#StagingUserMachineTitle").text("Machines");
        HideShowElement("#StagingUsersSettings", HideShow.HIDE);
        HideShowElement("#StagingMachinesSettings", HideShow.SHOW);
        SwitchDomainsSelectDataSource(machinesDomains);
    }
    else if (id.includes("Group")) {
        $("#BreadcrumSettingsBtnText").text("Add New Target Group Machine");
        $("#StagingUserMachineTitle").text("Machines");
        HideShowElement("#StagingUsersSettings", HideShow.HIDE);
        HideShowElement("#StagingMachinesSettings", HideShow.SHOW);
        SwitchDomainsSelectDataSource(machinesDomains);
    }
}

function SwitchDomainsSelectDataSource(dataSource) {
    const selectList = document.getElementById("ReportModuleSelect");

    selectList.innerHTML = "";

    const defaultOption = document.createElement("option");
    defaultOption.value = "0";
    defaultOption.textContent = "Please select Domain Name";
    selectList.appendChild(defaultOption);

    dataSource.forEach(domain => {
        const option = document.createElement("option");
        option.value = domain;
        option.textContent = domain;
        selectList.appendChild(option);
    });
}

function FilterByDomain() {
    const selectedDomain = $("#ReportModuleSelect").val();

    var userActive = $("#StagingUserBtn").hasClass("btn-group-active");

    if (selectedDomain === "0") {
        if (userActive)
            usersDT.column(0).search("").draw();
        else
            machinesDT.column(0).search("").draw();
    }
    else {
        if (userActive)
            usersDT.column(0).search(selectedDomain).draw();

        else
            machinesDT.column(0).search(selectedDomain).draw();
    }
}

function AddNewStagingEntity() {
    const buttonText = document.getElementById("BreadcrumSettingsBtnText").innerText;

    if (buttonText.includes("User")) {
        const userModal = new bootstrap.Modal(document.getElementById('CreateStagingUserModal'));
        userModal.show();
    }
    else if (buttonText.includes("Machine")) {
        const machineModal = new bootstrap.Modal(document.getElementById('CreateStagingMachineModal'));
        machineModal.show();
    }
}

function EditNewStagingEnting(machineId, entityType) {
    // LoadEditModal(formData, '@Url.Action("EditStagingMachine", "Settings")', 'POST', editMachineForm, edit-machine-btn)
    $.ajax({
        url: '@Url.Action("EditStagingMachine", "Settings")',
        type: 'GET',
        data: { machineId: machineId, entityType: entityType },
        success: function (response) {

            $('#EditModalContainer').html(response);
            const editModal = new bootstrap.Modal(document.getElementById('EditModal'));
            editModal.show();

        },
        error: function (error) {
            console.log('Error fetching machine data:', error);
        }
    });
}

function SaveEditNewStagingEnting(formdata) {

    LoadEditModal(formData, '@Url.Action("SaveStagingData", "Settings")', 'POST', editMachineForm, edit - machine - btn)
}

function closeModal(modalId) {
    $('#' + modalId).modal('hide');
}

function applyRealTimeStyles(previewTextId, fontFamilyDropdownId, fontWeightDropdownId, fontStyleDropdownId)
{

    var $previewText = $("#" + previewTextId);
    var $fontFamilyDropdown = $("#" + fontFamilyDropdownId);
    var $fontWeightDropdown = $("#" + fontWeightDropdownId);
    var $fontStyleDropdown = $("#" + fontStyleDropdownId);


    if ($previewText.length)
    {
        $previewText.css("font-family", $fontFamilyDropdown.length ? $fontFamilyDropdown.val() : "Arial");
        $previewText.css("font-weight", $fontWeightDropdown.length ? $fontWeightDropdown.val() : "normal");
        $previewText.css("font-style", $fontStyleDropdown.length ? $fontStyleDropdown.val() : "normal");
    }

    if ($fontFamilyDropdown.length)
    {
        $fontFamilyDropdown.on("change", function ()
        {
            if ($previewText.length)
            {
                $previewText.css("font-family", $(this).val());
            }
        });
    }

    if ($fontWeightDropdown.length)
    {
        $fontWeightDropdown.on("change", function ()
        {
            if ($previewText.length)
            {
                $previewText.css("font-weight", $(this).val());
            }
        });
    }

    if ($fontStyleDropdown.length)
    {
        $fontStyleDropdown.on("change", function ()
        {
            if ($previewText.length)
            {
                $previewText.css("font-style", $(this).val());
            }
        });
    }
}
