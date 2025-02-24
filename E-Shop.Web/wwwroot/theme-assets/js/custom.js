
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


// Update auto-refresh to maintain scroll position
setInterval(function () {
    if (@Model.SelectedUserId.HasValue.ToString().ToLower()) {
        const container = $('.chat-history-body');
        const scrollPos = container.scrollTop();

        $.get('@Url.Action("Chat", new { userId = Model.SelectedUserId })',
            function (data) {
                const newContent = $(data).find('.chat-history-wrapper').html();
                container.html(newContent);
                container.scrollTop(scrollPos);
            });
    }
}, 5000);


// Handle message submission via AJAX
$('form').submit(function (e) {
    e.preventDefault();
    var formData = new FormData(this);

    $.ajax({
        url: $(this).attr('action'),
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            $('.chat-history-wrapper').html($(data).find('.chat-history-wrapper').html());
            $('input[name="NewMessage.Text"]').val('');
        }
    });
});