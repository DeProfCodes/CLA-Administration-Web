
/*=============== Data Table Variables =========*/





function SwitchDomainsSelectDataSource(dataSource, id)
{
    const selectList = document.getElementById(id);

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

function FilterByDomain()
{
    const selectedDomain = $("#ReportModuleSelect").val();

    var userActive = $("#StagingUserBtn").hasClass("btn-group-active");

    if (selectedDomain === "0")
    {
        if (userActive)
            usersDT.column(0).search("").draw();
        else
            machinesDT.column(0).search("").draw();
    }
    else
    {
        if (userActive)
            usersDT.column(0).search(selectedDomain).draw();

        else
            machinesDT.column(0).search(selectedDomain).draw();
    }
}


function closeModal(modalId)
{
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

function triggerDelete(customID, confirmMessage, successMessage, deleteCallback)
{
    
    Swal.fire({
        title: `Are you sure you want to delete ${customID}?`,
        text: confirmMessage || "This action cannot be undone!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!'
    }).then((result) =>
    {
        if (result.isConfirmed)
        {
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

function ValidateImage(file, module)
{
    return new Promise((resolve, reject) =>
    {
        const reader = new FileReader();

        reader.onload = function (e)
        {
            const image = new Image();
            image.src = e.target.result;

            image.onload = function ()
            {
                const width = image.width;
                const height = image.height;
                const fileType = file.type.split("/")[1].toUpperCase();

                const validationRules =
                {
                    "Offline": { formats: ["JPG", "PNG"], width: null, height: null },
                    "Popups": { formats: ["BMP"], width: [314, 414], height: [188, 288] },
                    "Surveys": { formats: ["BMP"], width: [485], height: [600] },
                    "SingleTicker": { formats: ["BMP"], width: [80], height: [40] },
                    "DoubleTicker": { formats: ["BMP"], width: [80], height: [80] }
                };

                const rules = validationRules[module];
                if (!rules.formats.includes(fileType))
                {
                    reject(`Invalid file type. Allowed: ${rules.formats.join(", ")}`);
                    return;
                }

                if (rules.width && (!Array.isArray(rules.width) || !rules.width.includes(width)))
                {
                    reject(`Invalid width. Expected: ${rules.width.join(", ")}`);
                    return;
                }

                if (rules.height && (!Array.isArray(rules.height) || !rules.height.includes(height)))
                {
                    reject(`Invalid height. Expected: ${rules.height.join(", ")}`);
                    return;
                }

                resolve(true);
            };

            image.onerror = function ()
            {
                reject("Invalid image file.");
            };
        };

        reader.onerror = function ()
        {
            reject("File read error.");
        };

        reader.readAsDataURL(file);
    });
}


// Reusable function to render a tree view
function renderTreeView(containerId, data)
{
    const container = document.getElementById(containerId);
    container.innerHTML = createTreeHTML(data);
}

// Helper function to generate tree HTML recursively
function createTreeHTML(model)
{
    let html = "<ul>";
    for (const key in model) {
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
function filterTree(containerId, inputId)
{
    const filter = document.getElementById(inputId).value.toLowerCase();
    const container = document.getElementById(containerId);
    const items = container.querySelectorAll(".tree-view li");

    items.forEach(item => {
        const label = item.querySelector("label");
        const labelText = label ? label.textContent.toLowerCase() : "";
        item.style.display = labelText.indexOf(filter) === -1 ? "none" : "";
    });
}


