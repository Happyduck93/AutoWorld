var dataTable;

$(document).ready(function () { loadDataTable(); });

function loadDataTable() {
    dataTable = $('#CodeList').dataTable({
        ajax: {
            //CodeList in CodeController
            url: "/Code/CodeList",
            //parameter of CodeList method
            data: {},
            //HttpGet
            type: "GET",
            // return json type
            datatype: "json" 
        },
        columns: [
            {
                data: { categoryId: 'categoryId', codeId: 'codeId'}, width: '20%',
                render: function (data) {
                    return `<a href="/Code/Details?codeId=${data.codeId}&categoryId=${data.categoryId}">${data.categoryId}</a>`


                }

            },
            { data: 'codeId', width: "20%" },
            { data: 'activeYn', with: "20%" },
            { data: 'codeDescr', width: "20%" },
            { data: 'createDt', width: "20%" }
        ],
        "language": {
            "emptyTable": "No data found..."
        },
        width: "100%"

    });
}


