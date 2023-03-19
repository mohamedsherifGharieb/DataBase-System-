<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Web.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;<asp:Button ID="Button5" runat="server" Text="Register As Sports Association Manager " OnClick="AssManager" Width="266px" />
            <asp:Button ID="Button6" runat="server" Text="Register As Club Representative" OnClick="Repsentative" Width="225px" />
            <asp:Button ID="Button7" runat="server" Text="Register As Stadium Manager" Onclick="Stadium" Width="214px" />
            <asp:Button ID="Button8" runat="server" Text="Register As Fan" OnClick="Fan" Width="130px"/>
        </div>
    </form>
</body>
</html>
