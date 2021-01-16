var dataTable;

$(document).ready(function () { loadDataTable(); });

function loadDataTable() {
    dataTable = $('#BrandList').dataTable({
        ajax: {
            // BrandController/ BrandList method
            url: "/brand/brandlist",
            //[HttpGet]
            type: "GET",
            //return type
            datatype: "json"
        },
        columns: [
            {
                data: { brandName: 'brandName', brandId: 'brandId'}, width: "15%",
                render: function (data) {
                    return `<a href="/Brand/Details?brandId=${data.brandId}">${data.brandName}</a>`
                }
            },
            { data: 'brandDescr', width: "15%" },
            { data: 'establishmentDate', width: "20%" },
            { data: 'brandCodeDescr', width: "10%" },
            { data: 'headquarters', width: "15%" },
            {
                data: 'brandId',
                render: function (data) {
                    return `<div class="text-center">
                                <a href="/Brand/Details?brandId=${data}" class="btn btn-success" style="cursor:pointer; width:100px;">
                                    <i class="far fa-edit"></i> Edit
                                </a> &nbsp;
                                <a class="btn btn-danger text-white" style="cursor:pointer; width:100px;"
                                    onclick=Delete('/Brand/Delete?brandId='+${data})>
                                    <i class="far fa-trash-alt"></i> Delete
                                </a>
                            </div>`;

                   
                }, width: "25%"
            }
        ],
        "language": {
            "emptyTable": "No data found."
        },
        width: "100%"
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

