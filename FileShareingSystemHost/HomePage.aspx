<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="FileShareingSystemHost.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server">[HyperLink1]</asp:HyperLink>
            <br />
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" />
        </div>
    </form>
</body>
</html>
