
function markAsRead(id) {
    $.ajax({
        url: 'ContactUsMessage/MarkAsRead',
        type: 'POST',
        data: { id: id },
        success: function (response) {
            $('#status-' + id).removeClass('bg-label-danger').addClass('bg-label-primary').text('خوانده شده');
        },
        error: function (xhr, status, error) {
            console.error('پیام پیدا نشد. ', error);
        }
    });
}

function confirmDelete(formId, fullname) {
    Swal.fire({
        title: "توجه",
        text: "آیا از حذف " + fullname + " مطمئن هستید؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "بله، حذف کن",
        cancelButtonText: "لغو"
    }).then((result) => {
        if (result.isConfirmed) {
            document.getElementById(formId).submit();
        }
    });
}