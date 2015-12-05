$(document).ready(function () {
    $("th").click(function () {
        var columnIndex = $(this).index();
        var tdArray = $(this).closest("table")
        .find("tr td:nth-child(" + (columnIndex + 1) + ")");
        tdArray.sort(function (p, n) {
            var pData = $(p).text();
            var nData = $(n).text();
            return pData < nData ? -1 : 1;
        });
        tdArray.each(function () {
            var row = $(this).parent();
            $("#tblGridSort").append(row);
        });
    });
});
