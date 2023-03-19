<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FanR.aspx.cs" Inherits="Web.Registration_Form.FanR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Fill the Blank<br />
            Name<br />
            <asp:TextBox ID="name" runat="server"></asp:TextBox>
            <br />
            Username<br />
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
            <br />
            Password<br />
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
            <br />
            National_ID<br />
            <asp:TextBox ID="national" runat="server"></asp:TextBox>
            <br />
            Phone</div>
        <asp:TextBox ID="phone" runat="server"></asp:TextBox>
        <br />
        BirtDate<br />
        <asp:Calendar ID="Calendar1" runat="server" AutoPostBack="True"></asp:Calendar>
        <br />
        Address<br />
        <asp:TextBox ID="address" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="SUB" Width="129px" />
        <br />
    </form>
</body>
</html>
