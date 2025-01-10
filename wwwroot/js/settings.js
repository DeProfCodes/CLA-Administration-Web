
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

function ValidateImage(file, module) {
    return new Promise((resolve, reject) => {
        const reader = new FileReader();

        reader.onload = function (e) {
            const image = new Image();
            image.src = e.target.result;

            image.onload = function () {
                const width = image.width;
                const height = image.height;
                const fileType = file.type.split("/")[1].toUpperCase();

                const validationRules = {
                    "Offline": { formats: ["JPG", "PNG"], width: null, height: null },
                    "Popups": { formats: ["BMP"], width: [314, 414], height: [188, 288] },
                    "Surveys": { formats: ["BMP"], width: [485], height: [600] },
                    "SingleTicker": { formats: ["BMP"], width: [80], height: [40] },
                    "DoubleTicker": { formats: ["BMP"], width: [80], height: [80] }
                };

                const rules = validationRules[module];
                if (!rules.formats.includes(fileType)) {
                    reject(`Invalid file type. Allowed: ${rules.formats.join(", ")}`);
                    return;
                }

                if (rules.width && (!Array.isArray(rules.width) || !rules.width.includes(width))) {
                    reject(`Invalid width. Expected: ${rules.width.join(", ")}`);
                    return;
                }

                if (rules.height && (!Array.isArray(rules.height) || !rules.height.includes(height))) {
                    reject(`Invalid height. Expected: ${rules.height.join(", ")}`);
                    return;
                }

                resolve(true);
            };

            image.onerror = function () {
                reject("Invalid image file.");
            };
        };

        reader.onerror = function () {
            reject("File read error.");
        };

        reader.readAsDataURL(file);
    });
}


// Function to filter tree view based on input
/*
function filterTreeView(inputId, treeContainerSelector) {
    const filter = document.getElementById(inputId).value.toLowerCase();
    const treeViewItems = document.querySelectorAll(`${treeContainerSelector} li`);

    treeViewItems.forEach(item => {
        const label = item.querySelector('label');
        const labelText = label ? label.textContent.toLowerCase() : '';
        const shouldHide = labelText.indexOf(filter) === -1;
        item.style.display = shouldHide ? 'none' : '';
    });
}

// Function to save selected items from the tree view and populate a form
function saveSelections(treeViewSelector, userCheckboxClass, groupPrefix, machinePrefix, ipRangePrefix, outputFields) {
    let selectedUsers = [];
    let selectedGroups = [];
    let selectedMachines = [];
    let selectedIpRanges = [];

    // Get selected users
    document.querySelectorAll(`${treeViewSelector} .${userCheckboxClass}:checked`).forEach(item => {
        selectedUsers.push(item.parentNode.textContent.trim());
    });

    // Get selected groups, machines, and IP ranges
    document.querySelectorAll(`${treeViewSelector} input[type="checkbox"]:checked`).forEach(item => {
        const parentText = item.parentNode.textContent.trim();
        if (item.id.includes(groupPrefix)) {
            selectedGroups.push(parentText);
        } else if (item.id.includes(machinePrefix)) {
            selectedMachines.push(parentText);
        } else if (item.id.includes(ipRangePrefix)) {
            selectedIpRanges.push(parentText);
        }
    });

    // Populate fields with selected data (if specified)
    if (outputFields) {
        if (outputFields.users) document.getElementById(outputFields.users).value = selectedUsers.join(', ');
        if (outputFields.groups) document.getElementById(outputFields.groups).value = selectedGroups.join(', ');
        if (outputFields.machines) document.getElementById(outputFields.machines).value = selectedMachines.join(', ');
        if (outputFields.ipRanges) document.getElementById(outputFields.ipRanges).value = selectedIpRanges.join(', ');
    }

    // Optionally log the selections (for debugging or further processing)
    console.log("Selected Users: ", selectedUsers);
    console.log("Selected Groups: ", selectedGroups);
    console.log("Selected Machines: ", selectedMachines);
    console.log("Selected IP Ranges: ", selectedIpRanges);
}

// Function to open a modal by its ID
function openModal(modalId) {
    const modal = new bootstrap.Modal(document.getElementById(modalId));
    modal.show();
}


// Function to close a modal by its ID
function closeModal(modalId) {
    const modal = new bootstrap.Modal(document.getElementById(modalId));
    modal.hide();
}


*/


// Reusable function to render a tree view
function renderTreeView(containerId, data) {
    const container = document.getElementById(containerId);
    container.innerHTML = createTreeHTML(data);
}

// Helper function to generate tree HTML recursively
function createTreeHTML(data) {
    let html = "<ul>";
    for (const key in data) {
        const value = data[key];
        if (typeof value === "object" && !Array.isArray(value)) {
            html += `
                <li>
                    <input type="checkbox" id="node_${key}" class="tree-toggle">
                    <label for="node_${key}" class="tree-toggle-label">${key}</label>
                    ${createTreeHTML(value)}
                </li>
            `;
        } else {
            html += `
                <li>
                    <input type="checkbox" id="${key}" class="item-checkbox">
                    <label for="${key}" class="item-label">${key}</label>
                </li>
            `;
        }
    }
    html += "</ul>";
    return html;
}

// Function to filter tree view dynamically
function filterTree(containerId, inputId) {
    const filter = document.getElementById(inputId).value.toLowerCase();
    const container = document.getElementById(containerId);
    const items = container.querySelectorAll(".tree-view li");

    items.forEach(item => {
        const label = item.querySelector("label");
        const labelText = label ? label.textContent.toLowerCase() : "";
        item.style.display = labelText.indexOf(filter) === -1 ? "none" : "";
    });
}

// Function to collect selected items from the tree
function collectSelectedItems(containerId) {
    const container = document.getElementById(containerId);
    const selected = {
        users: [],
        groups: [],
        machines: [],
        ipRanges: []
    };

    container.querySelectorAll(".item-checkbox:checked").forEach(checkbox => {
        const label = checkbox.nextElementSibling.textContent.trim();
        if (checkbox.id.includes("user")) selected.users.push(label);
        else if (checkbox.id.includes("group")) selected.groups.push(label);
        else if (checkbox.id.includes("machine")) selected.machines.push(label);
        else if (checkbox.id.includes("iprange")) selected.ipRanges.push(label);
    });

    return selected;
}

// Function to populate the main modal with selected data
function populateModal(data, modalFields) {
    document.getElementById(modalFields.userId).value = data.users.join(", ");
    document.getElementById(modalFields.domain).value = data.groups.join(", ");
    document.getElementById(modalFields.ntUsername).value = data.machines.join(", ");
    document.getElementById(modalFields.firstName).value = data.ipRanges.join(", ");
}

// Example of rendering and handling filtering
document.addEventListener("DOMContentLoaded", () => {
    renderTreeView("directoryTree", usersData);

    document.getElementById("filterInputMember").addEventListener("input", () => {
        filterTree("directoryTree", "filterInputMember");
    });
});




To make your modal opening and closing functions reusable for any pair of modals, we can generalize the functionality into two functions: openTreeViewModal and closeTreeViewModal.These functions can accept modal IDs as parameters, making them reusable for different modals.

    Here’s the updated code:

Reusable openTreeViewModal Function
javascript
Copy code
function openTreeViewModal(triggerButton, modal1Id, modal2Id) {
    // Get modal elements by their IDs
    var modal1 = document.getElementById(modal1Id);  // The second modal (partial modal)
    var modal2 = document.getElementById(modal2Id);  // The main modal

    // Ensure modal1 (second modal) is fully visible
    modal1.style.display = 'block';
    modal1.style.opacity = '1';
    modal1.style.zIndex = '1055'; // Bring modal1 on top of modal2

    // Ensure modal2 (main modal) is beneath modal1
    modal2.style.zIndex = '0';

    // Remove or hide the backdrop of modal2
    var backdrop = document.querySelector('.modal-backdrop');
    if (backdrop) {
        backdrop.style.zIndex = '0';  // Move the backdrop behind modal1
        backdrop.style.opacity = '0'; // Make the backdrop invisible
    }

    // Retrieve the fields and callback dynamically from the trigger button
    const lastModifiedField = triggerButton.getAttribute('data-lastmodified-field');
    const callbackFunction = triggerButton.getAttribute('data-callback');

    // Store these globally or pass to the modal
    window.selectedFields = {
        lastModifiedField,
        callbackFunction,
    };
}