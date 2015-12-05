<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JQuery_Convert_AspGridview_To_Csv.aspx.cs" Inherits="JQuery.Bootstrap.AspNet.Best.Samples.JQuery_Convert_AspGridview_To_Csv" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-2.1.4.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#TextBox_To_Csv").hide();
            $("#Button_To_Csv").click(function (evt) {
                var rows = [];
                var str = '';
                $("#GridView_To_CSV").find("tr").each(function () {
                    if ($(this).find("th").length) {
                        var headerArray = [];
                        $(this).find("th").each(function () {
                            str = $(this).text().replace(/"/g, '""');
                            headerArray.push('"' + str + '"');
                        });
                        rows.push(headerArray.join(','));
                    } else {
                        var dataArray = [];
                        $(this).find("td").each(function () {
                            str = $(this).text().replace(/"/g, '""');
                            dataArray.push('"' + str + '"');
                        });
                        rows.push(dataArray.join(','));
                    }
                });
                var csv = rows.join('\n');
                $("#TextBox_To_Csv").val(csv);
                $("#TextBox_To_Csv").slideDown("slow");
                evt.preventDefault();
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="row">
     <asp:Button ID="Button_To_Csv" runat="server" Text="Exporta in CSV" CssClass="col-lg-offset-2"  />
    </div>
        

         <div class="row">
             <asp:TextBox CssClass="col-lg-offset-2" ID="TextBox_To_Csv" TextMode="MultiLine" runat="server" Rows="10" Columns="50"></asp:TextBox>
    </div>
       
         <div class="row">
     <asp:GridView ID="GridView_To_CSV" CssClass="table table-hover  table-condensed col-lg-offset-2" runat="server" AutoGenerateColumns="false" DataKeyNames="EmployeeID" CellPadding="10" DataSourceID="SqlDataSource_To_CSV" Width="80%">
         <Columns>
        <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" InsertVisible="False" ReadOnly="True" />
        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
        <asp:BoundField DataField="LastName" HeaderText="LastName" />
        <asp:BoundField DataField="Title" HeaderText="Title" />
        <asp:BoundField DataField="Country" HeaderText="Country" />
        </Columns>

     </asp:GridView>
    </div>
    </div>

        <asp:SqlDataSource ID="SqlDataSource_To_CSV" runat="server" ConnectionString='<%$ ConnectionStrings:NORTHWNDConnectionString %>' SelectCommand="SELECT [EmployeeID], [FirstName], [LastName], [Title], [Country] FROM [Employees]"></asp:SqlDataSource>
    </form>
</body>
</html>
