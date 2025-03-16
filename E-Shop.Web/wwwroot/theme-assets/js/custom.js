
(function ($) {
    "use strict";
    let THEME = {};

    /*====== Example ======*/
    THEME.Example = function () {
        // Write your code here
    };
    /*====== end Example ======*/

    $(window).on("load", function () { });
    $(document).ready(function () {
        THEME.Example();
    });
})(jQuery);



function confirmDelete(formId, Title) {
    Swal.fire({
        title: 'آیا از حذف' + Title + 'مطمئن هستید؟',
        text: "این عملیات قابل بازگشت نیست!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله، حذف شود!',
        cancelButtonText: 'لغو'
    }).then((result) => {
        if (result.isConfirmed) {
            document.getElementById(formId).submit();
        }
    })
}


// Set timer duration in seconds
let duration = 120;

const timerElement = document.getElementById('timer');
const resendLink = document.getElementById('resendLink');

function updateTimer() {
    if (duration > 0) {
        timerElement.textContent = `مدت زمان اعتبار کد: ${duration--} ثانیه`;
        setTimeout(updateTimer, 1000);
    } else {
        timerElement.classList.add('hidden');
        resendLink.classList.remove('hidden');
    }
}

updateTimer();



function readfile(input) {
    const files = input.files;
    const filelist = $("#files");
    const invalidError = $("#InvalidFile");
    filelist.empty();
    invalidError.empty();

    for (var i = 0; i < files.length; i++) {
        var file = files[i];
        var name = file.name;

        var div = "<div>" + name + "</div>";
        filelist.append(div);
    }
}



function updateRatingValue(value, elementId) {
    document.getElementById(elementId).textContent = value;
}


// Rating
function calculateOverallRating() {
    // Get slider values and convert to numbers
    var buildQuality = parseFloat(document.getElementById('buildQuality').value);
    var valueForMoney = parseFloat(document.getElementById('valueForMoney').value);
    var innovation = parseFloat(document.getElementById('innovation').value);
    var features = parseFloat(document.getElementById('features').value);
    var easeOfUse = parseFloat(document.getElementById('easeOfUse').value);
    var design = parseFloat(document.getElementById('design').value);

    // Calculate average
    var sum = buildQuality + valueForMoney + innovation + features + easeOfUse + design;
    var average = sum / 6;

    // Update display (rounded to 1 decimal place)
    document.getElementById('overallRating').textContent = average.toFixed(1);

    // Update hidden input with precise value
    var overallRatingInput = document.getElementById('overallRatingInput');
    if (overallRatingInput) {
        overallRatingInput.value = average;
    }
}

// Initial calculation on page load
calculateOverallRating();



// Evaluations
function addPositiveEvaluation() {
    var index = $('#positive-evaluations input').length;
    $('#positive-evaluations').append('<input type="text" name="PositiveEvaluations[' + index + '].Text" class="form-control evaluation-input mb-2" placeholder="نقطه قوت ' + (index + 1) + '" />');
}


function addNegativeEvaluation() {
    var index = $('#negative-evaluations input').length;
    $('#negative-evaluations').append('<input type="text" name="NegativeEvaluations[' + index + '].Text" class="form-control evaluation-input mb-2" placeholder="نقطه ضعف ' + (index + 1) + '" />');
}



// Permission CheckBoxes
function toggleChildren(parentCheckbox, parentId) {
    // Select or deselect all children based on the parent checkbox
    var childCheckboxes = document.getElementsByClassName('child-checkbox-' + parentId);
    for (var i = 0; i < childCheckboxes.length; i++) {
        childCheckboxes[i].checked = parentCheckbox.checked;
    }
}

function toggleParent(childCheckbox, parentId) {
    // Get the parent checkbox element
    var parentCheckbox = document.getElementById('permission_' + parentId);

    // Check if any child is checked
    var childCheckboxes = document.getElementsByClassName('child-checkbox-' + parentId);
    var anyChecked = false;
    for (var i = 0; i < childCheckboxes.length; i++) {
        if (childCheckboxes[i].checked) {
            anyChecked = true;
            break;
        }
    }

    // Select the parent checkbox if any child is checked
    parentCheckbox.checked = anyChecked;
}


//Add Roles To User
document.addEventListener("DOMContentLoaded", function () {
    const selectedRoles = [];

    function updateHiddenInput() {
        document.getElementById("selectedRoles").value = JSON.stringify(selectedRoles);
    }

    function addRoleDropdown(dropdown) {
        const selectedValue = dropdown.value;

        if (selectedValue && !selectedRoles.includes(selectedValue)) {
            selectedRoles.push(selectedValue);
            updateHiddenInput();

            // Remove selected option from all existing dropdowns
            removeSelectedOption(selectedValue);

            // Create a new dropdown
            const container = document.getElementById("roles-container");
            const newDropdownDiv = document.createElement("div");
            newDropdownDiv.className = "role-selection mb-3";
            const newDropdown = document.createElement("select");
            newDropdown.className = "form-select role-dropdown";
            newDropdown.onchange = function () {
                addRoleDropdown(newDropdown);
            };

            // Default option
            const defaultOption = document.createElement("option");
            defaultOption.value = "";
            defaultOption.textContent = "یک نقش را انتخاب کنید";
            newDropdown.appendChild(defaultOption);

            // Add options from available roles
            const availableRoles = JSON.parse(document.getElementById("roles-data").textContent);
            availableRoles.forEach((role) => {
                if (!selectedRoles.includes(role.RoleId)) {
                    const option = document.createElement("option");
                    option.value = role.RoleId;
                    option.textContent = role.RoleName;
                    newDropdown.appendChild(option);
                }
            });

            newDropdownDiv.appendChild(newDropdown);
            container.appendChild(newDropdownDiv);
        }
    }

    function removeSelectedOption(value) {
        const dropdowns = document.querySelectorAll(".role-dropdown");
        dropdowns.forEach((dropdown) => {
            const option = dropdown.querySelector(`option[value="${value}"]`);
            if (option) {
                option.remove();
            }
        });
    }
});


//Address Creation
$(document).ready(function () {
    $('#StateId').change(function () {
        var stateId = $(this).val();
        var cityDropdown = $('#CityId');

        if (stateId) {
            $.ajax({
                url: '@Url.Action("GetCitiesByStateId", "Address")',
                type: 'GET',
                data: { stateId: stateId },
                success: function (data) {
                    cityDropdown.empty();
                    cityDropdown.append('<option value="">-- انتخاب شهر --</option>');
                    $.each(data, function (index, city) {
                        cityDropdown.append('<option value="' + city.cityId + '">' + city.cityName + '</option>');
                    });
                },
                error: function () {
                    alert('خطا در بارگذاری شهرها');
                }
            });
        } else {
            cityDropdown.empty().append('<option value="">-- ابتدا استان را انتخاب کنید --</option>');
        }
    });
});


