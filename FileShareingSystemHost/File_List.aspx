<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="File_List.aspx.cs" Inherits="FileShareingSystemHost.File_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="85px" style="margin-right: 0px" Width="704px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="File Name">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%# Eval("File Name") %>' CommandName="Download" Text='<%# Eval("File Name") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Date" HeaderText="Date" />
                    <asp:BoundField DataField="user id" HeaderText="user id" />
                </Columns>
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
