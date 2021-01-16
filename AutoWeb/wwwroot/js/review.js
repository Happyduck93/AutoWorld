var dataTable;
var aId= document.currentScript.getAttribute('aId');

$(document).ready(function() { loadDataTable(); });

function loadDataTable() {
    dataTable = $('#ReviewList').dataTable({
        ajax: {
            //review Controller // ReviewList method
            url: "/Review/ReviewList",
            data: { autoId: aId },
            type: "GET",
            datatype: "json"
        },
        columns: [
            { data: 'userId', width: '20%' },
            { data: 'reviewDescr', width: '60%' },
            { data: 'reviewDate', width: '20' }
        ],
        "language": {
            "emptyTable": "No data found."
        },
        width: '100%'
    });
}
