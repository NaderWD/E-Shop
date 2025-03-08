
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



function confirmDelete(url) {
    Swal.fire({
        title: 'آیا مطمئن هستید؟',
        text: "این عملیات قابل بازگشت نیست!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'بله، حذف شود!',
        cancelButtonText: 'لغو'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = url;
        }
    })
}


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





