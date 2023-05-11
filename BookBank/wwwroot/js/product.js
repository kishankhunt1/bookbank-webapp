var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#myTable').DataTable({
        "ajax": {
            "url":"/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "product_Title" },
            { "data": "product_Description" },
            { "data": "product_ISBN" },
            { "data": "product_Author" },
            { "data": "product_Price" },
            { "data": "category.name" },
            { "data":"coverType.name"},
            {
                "data": "product_id",
                "render": function (data) {
                    return `
                            <td class="d-flex">
                                <a href="/Admin/Product/Upsert?id=${data}" class="btn btn-primary mx-1 my-1 "><i class="bi bi-pencil-square"></i> &nbsp; Edit</a>
                                <a onClick=Delete('/Admin/Product/Delete/${data}') class="btn btn-primary mx-1 my-1 "><i class="bi bi-trash-fill"></i> &nbsp; Delete</a>
                            </td>
                            `
                }  
            }
        ]
    });
} 

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}
