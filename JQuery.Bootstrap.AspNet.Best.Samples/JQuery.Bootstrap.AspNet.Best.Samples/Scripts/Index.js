var pageSize = 3;
var pageCount = 0;
$(document).ready(function () {
   // alert('Jquery');
    var options = {};
    options.url = "http://localhost:61625/Home/GetTotalRows";
    options.type = "POST";
    options.dataType = "json";
    options.contentType = "application/json";
    options.success = function (count) {
        //alert(count);
        pageCount = count / pageSize;
        renderPager(0);
        getPageData(0);
    };
    options.error = function (xhr, status, err) { alert(err); };
    $.ajax(options);
});


function renderPager(currentPageIndex) {
    var html = '';
    for (var i = 0; i < pageCount; i++) {
        if (i == currentPageIndex) {
            html += "<span>" + (i + 1) + "</span>&nbsp;";
        }
        else {
            html += "<a href='#' data-page-index='" + i + "'>" +
            (i + 1) + "</a>&nbsp;";
        }
    }
    $("#tblGrid tr:last td").html(html);
    $("a").click(function (evt) {
        var pageIndex = $(this).data("pageIndex");
        getPageData(pageIndex);
        evt.preventDefault();
    });
}


function getPageData(index) {
    var options = {};
    options.url = "http://localhost:61625/Home/GetPageData";
    options.type = "POST";
    options.data = JSON.stringify(
    { pageIndex: index, pageSize: this.pageSize }
    );
    options.dataType = "json";
    options.contentType = "application/json";
    options.success = function (employees) {
        $("#tblGrid").find("tr:gt(0)").remove("tr:not(:last)");
        for (var i = 0; i < employees.length; i++) {
            var html = "<tr>";
            html += "<td>" + employees[i].EmployeeID + "</td>";
            html += "<td>" + employees[i].FirstName + "</td>";
            html += "<td>" + employees[i].LastName + "</td>";
            html += "<td>" + employees[i].Title + "</td>";
            html += "<td>" + employees[i].Country + "</td>";
            html += "</tr>";
            $("#tblGrid tr").eq(i).after(html);
        }
        renderPager(index);
    };
    options.error = function (xhr, status, err) { alert(err); };
    $.ajax(options);
}
