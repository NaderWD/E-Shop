
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
