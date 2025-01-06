
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

function triggerDelete(customID, confirmMessage, successMessage, deleteCallback) {
    
    Swal.fire({
        title: `Are you sure you want to delete ${customID}?`,
        text: confirmMessage || "This action cannot be undone!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!'
    }).then((result) => {
        if (result.isConfirmed) {
            if (deleteCallback && typeof deleteCallback === 'function') {
                deleteCallback(customID);
            }
            Swal.fire(
                'Deleted!',
                successMessage || `${customID} has been successfully deleted.`,
                'success'
            );
        } else {
            Swal.fire(
                'Cancelled',
                `${customID} has not been deleted.`,
                'info'
            );
        }
    });
}



function closeModal(modalId)
{

    if (typeof modalId === 'string') {
        const modalElement = document.getElementById(modalId);
        if (modalElement) {
            const bootstrapModal = bootstrap.Modal.getInstance(modalElement) || new bootstrap.Modal(modalElement);
            bootstrapModal.hide();
        } else {
            console.error(`Modal with ID "${modalId}" not found.`);
        }
    } else {
        console.error("closeModal expects a string ID.");
    }
}

function SaveModal(modalId, successMessage)
{
    closeModal(modalId);
    setTimeout(() => {
        Swal.fire({
            position: "top-end",
            icon: "success",
            title: successMessage,
            showConfirmButton: false,
            timer: 1500
        });
    }, 300);
}
