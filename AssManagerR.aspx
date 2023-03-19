<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssManagerR.aspx.cs" Inherits="Web.Registration_Form.AssManagerR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Fill the Blank"></asp:Label>
            <br />
            Name:<br />
            <asp:TextBox ID="Name" runat="server"></asp:TextBox>
            <br />
            Username:<br />
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
            <br />
            Password:
            <br />
            <asp:TextBox ID="Password"  runat="server"></asp:TextBox>
            <br />
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="SUB"  Width="126px" />
        </p>
    </form>
</body>
</html>
