var dataTable;

$(document).ready(function () { loadDataTable(); });

function loadDataTable() {
    dataTable = $('#AutoList').dataTable({
        ajax: {
            //auto Controller / AutoList method
            url: "/auto/autolist",
            type: "GET",
            datatype: "json"
        },
        columns: [
            { data: 'autoName', width: '8%' },
            { data: 'year', width: '8%' },
            { data: 'autoType', width: '8%' },
            { data: 'brandName', width: '8%' },
            { data: 'autoDescr', width: '8%' },
            { data: 'color', width: '10%' },
            { data: 'price', width: '8%' },
            { data: 'trim', width: '8%' },
            { data: 'releasedDate', width: '10%' },
            {
                data: 'autoId',
                render: function (data) {
                    return `<div class="text-center">
                                <a href="/Auto/Details?autoId=${data}" class="btn btn-success" style="cursor:pointer; width:100px;">
                                    <i class="far fa-edit"></i> Edit
                                </a> &nbsp;
                                <a class="btn btn-danger text-white" style="cursor:pointer; width:100px;"
                                    onclick=Delete('/Auto/Delete?autoId='+${data})>
                                    <i class="far fa-trash-alt"></i> Delete
                                </a>
                            </div>`;
                }, width: "24%"
            }
        ],
        "language": {
            "emptyTable": "No data found."
        }, width: '100%'
    });
}


function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover it.",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.api().ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }

                }
            });
        }
    });
}