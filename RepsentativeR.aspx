<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepsentativeR.aspx.cs" Inherits="Web.Registration_Form.RepsentativeR" %>

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
            <asp:TextBox ID="Name" runat="server"></asp:TextBox>
            <br />
            Username<br />
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
            <br />
            Password<br />
            <asp:TextBox ID="Password" runat="server"></asp:TextBox>
            <br />
            NameOfClub<br />
            <asp:TextBox ID="Club" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="SUB" Width="127px" />
            <br />
        </div>
    </form>
</body>
</html>
