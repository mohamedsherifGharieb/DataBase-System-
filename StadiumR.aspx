<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StadiumR.aspx.cs" Inherits="Web.Registration_Form.StadiumR" %>

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
            <asp:TextBox ID="name" runat="server" ></asp:TextBox>
            <br />
            Username<br />
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
            <br />
            Password<br />
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
            <br />
            StadiumName<br />
            <asp:TextBox ID="Stadium" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="GET"/>
            <br />
        </div>
    </form>
</body>
</html>
