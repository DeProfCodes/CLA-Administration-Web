// Your ToggleStaginUserMachines function to show and hide relevant settings
function ToggleStaginUserMachines(id) {
    $(".filter-type-btn").removeClass("btn-group-active");
    $(`#${id}`).addClass("btn-group-active");

    if (id.includes("User")) {
        // Update breadcrumb text and table title
        $("#BreadcrumSettingsBtnText").text("Add New Staging User");
        $("#StagingUserMachineTitle").text("Users");

        // Show the appropriate settings and hide others
        HideShowElement("#StagingUsersSettings", HideShow.SHOW);
        HideShowElement("#StagingMachinesSettings", HideShow.HIDE);

        // Switch domain data source for users
        SwitchDomainsSelectDataSource(usersDomains);

        // Open the modal for adding a new user
        openTargetGroupModal("User");
    }
    else if (id.includes("Machine")) {
        // Update breadcrumb text and table title
        $("#BreadcrumSettingsBtnText").text("Add New Staging Machine");
        $("#StagingUserMachineTitle").text("Machines");

        // Show the appropriate settings and hide others
        HideShowElement("#StagingUsersSettings", HideShow.HIDE);
        HideShowElement("#StagingMachinesSettings", HideShow.SHOW);

        // Switch domain data source for machines
        SwitchDomainsSelectDataSource(machinesDomains);

        // Open the modal for adding a new machine
        openTargetGroupModal("Machine");
    }
    else if (id.includes("IPRanges")) {
        // Update breadcrumb text and table title
        $("#BreadcrumSettingsBtnText").text("Add New IP Range");
        $("#StagingUserMachineTitle").text("IP Ranges");

        // Show the appropriate settings and hide others
        HideShowElement("#StagingUsersSettings", HideShow.HIDE);
        HideShowElement("#StagingMachinesSettings", HideShow.HIDE);

        // Open the modal for adding a new IP range
        openTargetGroupModal("IPRange");
    }
    else if (id.includes("Group")) {
        // Update breadcrumb text and table title
        $("#BreadcrumSettingsBtnText").text("Add New Target Group");
        $("#StagingUserMachineTitle").text("Groups");

        // Show the appropriate settings and hide others
        HideShowElement("#StagingUsersSettings", HideShow.HIDE);
        HideShowElement("#StagingMachinesSettings", HideShow.HIDE);

        // Open the modal for adding a new group
        openTargetGroupModal("Group");
    }
}

// Function to open the appropriate modal based on the type
function openTargetGroupModal(type) {
    let modalId = "";
    let formFields = "";

    switch (type) {
        case "User":
            modalId = "CreateStagingUserModal";
            formFields = `
                <div class="mb-3">
                    <label for="StagingUserDomain" class="form-label">Domain</label>
                    <select class="form-select" id="StagingUserDomain" required>
                        <option value="">Please select a domain</option>
                        @foreach (var domain in usersDomains) {
                            <option value="@domain">@domain</option>
                        }
                    </select>
                </div>
                <div class="mb-3">
                    <label for="StagingUserUsername" class="form-label">Username</label>
                    <input type="text" class="form-control" id="StagingUserUsername" required>
                </div>
                <div class="mb-3">
                    <label for="StagingUserFirstname" class="form-label">First Name</label>
                    <input type="text" class="form-control" id="StagingUserFirstname" required>
                </div>
                <div class="mb-3">
                    <label for="StagingUserLastname" class="form-label">Last Name</label>
                    <input type="text" class="form-control" id="StagingUserLastname" required>
                </div>`;
            break;

        case "Machine":
            modalId = "CreateStagingMachineModal";
            formFields = `
                <div class="mb-3">
                    <label for="StagingMachinename" class="form-label">Machine Name</label>
                    <input type="text" class="form-control" id="StagingMachinename" required>
                </div>
                <div class="mb-3">
                    <label for="StagingMachineDescription" class="form-label">Machine Description</label>
                    <input type="text" class="form-control" id="StagingMachineDescription" required>
                </div>`;
            break;

        case "IPRange":
            modalId = "CreateIPRangeModal";
            formFields = `
                <div class="mb-3">
                    <label for="RangeID" class="form-label">Range ID</label>
                    <input type="text" class="form-control" id="RangeID" required>
                </div>
                <div class="mb-3">
                    <label for="StartIP" class="form-label">Start IP</label>
                    <input type="text" class="form-control" id="StartIP" required>
                </div>
                <div class="mb-3">
                    <label for="EndIP" class="form-label">End IP</label>
                    <input type="text" class="form-control" id="EndIP" required>
                </div>
                <div class="mb-3">
                    <label for="IPDescription" class="form-label">Description</label>
                    <input type="text" class="form-control" id="IPDescription" required>
                </div>
                <div class="mb-3">
                    <label for="IPRangeAction" class="form-label">Action</label>
                    <select class="form-select" id="IPRangeAction" required>
                        <option value="">Please select an action</option>
                        <option value="Create">Create</option>
                        <option value="Delete">Delete</option>
                        <option value="Update">Update</option>
                    </select>
                </div>`;
            break;

        case "Group":
            modalId = "CreateTargetGroupModal";
            formFields = `
                <div class="mb-3">
                    <label for="GroupName" class="form-label">Group Name</label>
                    <input type="text" class="form-control" id="GroupName" required>
                </div>
                <div class="mb-3">
                    <label for="GroupDescription" class="form-label">Description</label>
                    <input type="text" class="form-control" id="GroupDescription" required>
                </div>`;
            break;

        default:
            console.error("No modal found for type:", type);
            return;
    }

    // Dynamically update modal content
    const modalContainer = document.querySelector(`#${modalId} .modal-body`);
    if (modalContainer) {
        modalContainer.innerHTML = formFields;
    }

    // Show the modal
    const modal = new bootstrap.Modal(document.getElementById(modalId));
    modal.show();
}
