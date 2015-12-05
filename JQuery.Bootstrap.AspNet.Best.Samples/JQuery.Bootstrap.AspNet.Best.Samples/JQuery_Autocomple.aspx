<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JQuery_Autocomple.aspx.cs" Inherits="JQuery.Bootstrap.AspNet.Best.Samples.JQuery_Autocomple" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-2.1.4.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#TextBox_Autocomplete").on("input", function (evt) {
                var options = {};
                // options.url = "JQuery_Autocomple.aspx/GetTitles"; 
                options.url = "http://localhost:61625/api/AutoComplete/GetTitles";
                options.data = JSON.stringify({ title: $(evt.target).val() });
                options.type = "POST";
                options.dataType = "json";
                options.contentType = "application/json";
                options.success = function (result) {
                    $("#titles").empty();
                    for (var i = 0; i < result.d.length; i++) {
                        $("#titles").append("<option>" + result.d[i] + "</option>");
                    }
                };
                options.error = function (xhr, status, err) { alert(err); };
                $.ajax(options);
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Label ID="Label_Autocomplete" runat="server" Text="Enter Title :"></asp:Label>
     <br />
     <asp:TextBox ID="TextBox_Autocomplete" runat="server" list="titles"></asp:TextBox>
     <datalist id="titles"></datalist>

    </div>
    </form>
</body>
</html>
