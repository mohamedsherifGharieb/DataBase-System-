<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            Sign In<br />
            Username<br />

            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
            <br />
            Password<br />
            <asp:TextBox ID="Password" runat="server" Type="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Height="27px" Text="Register" OnClick="Register" Width="127px" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Log" OnClick="login" Width="127px" Height="27px" />


        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
