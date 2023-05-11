var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("inprocess") ){
        loadDataTable("inprocess");
    }
    else {
        if (url.includes("completed") ){
            loadDataTable("completed");
        }
        else {
            if (url.includes("pending") ){
                loadDataTable("pending");
            }
            else {
                if (url.includes("approved") ){
                    loadDataTable("approved");
                }
                else {
                    loadDataTable("all");
                }
            }
        }
    }

});

function loadDataTable(status) {
    dataTable = $('#myTable').DataTable({
        "ajax": {
            "url": "/Admin/Order/GetAll?status=" + status
        },
        "columns": [
            { "data": "id" },
            { "data": "name" },
            { "data": "phoneNumber" },
            { "data": "applicationUser.email" },
            { "data": "orderStatus" },
            { "data": "orderTotal" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <td class="d-flex">
                                <a href="/Admin/Order/Details?orderId=${data}" class="btn btn-primary mx-1 my-1 "><i class="bi bi-pencil-square"></i></a>
                            </td>
                            `
                }  
            }
        ]
    });
} 
