<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JQuery_Animation_FadingEffect.aspx.cs" Inherits="JQuery.Bootstrap.AspNet.Best.Samples.JQuery_Animation_FadingEffect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="Scripts/jquery-2.1.4.min.js"></script>
    <script type="text/javascript">
        var handle;
        $(document).ready(function () {
            $("#Panel_FadingEffect").hide();
            $("#Button_FadingEffect").click(function (evt) {
                $("input:submit").prop("disabled", true);
                handle=setTimeout(Wait, 1000);
                var xhr = new XMLHttpRequest();
                xhr.open("POST", "FileUploadHandler.ashx");
                $(xhr).on("load", function (evt) {
                    clearTimeout(handle);
                    $("#Panel_FadingEffect").hide();
                    $("input:submit").prop("disabled", false);
                    alert(evt.target.responseText);
                });
                xhr.send();
                evt.preventDefault();
            });
        });
        function Wait() {
            $("#Panel_FadingEffect").fadeToggle("slow");
            handle = setTimeout(Wait, 1000);
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button runat="server" Text="start processing file" ID="Button_FadingEffect"  ClientIDMode="Static"/>
        <asp:Panel runat="server" ID="Panel_FadingEffect" ClientIDMode="Static">
            <asp:Label runat="server" ID="Label_FadingEffect" ForeColor="Red" Text="Wait... our server is processing your request" ClientIDMode="Static"></asp:Label>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
