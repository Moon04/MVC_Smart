function confirmDelete(id) {
    let res = confirm("Are you sure?");
    if (res) {
        $.ajax({
            url: "/Employee/Delete/" + id,
            type: "POST",
            success: function (response) {
                if (response) {
                    let tr = $("#" + id);
                    tr.remove();
                }
            },
            error: function (xhr, status, err) {
                console.log(err);
            }
        });
    }
}

function onSuccess(employee) {
    document.getElementById("form0").reset();
    $('#employee-modal').modal("hide");
}