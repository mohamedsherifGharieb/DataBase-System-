<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Web.View_Form.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp; NameOfClub
            <br />
            <asp:TextBox ID="Add" runat="server"></asp:TextBox>
            &nbsp;
            <br />
            Location<br />
            <asp:TextBox ID="LocationAdd" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="AddClub" OnClick="AddC" Height="28px" />
            <br />
            <br />
            NameOfClub<br />
            <asp:TextBox ID="Delete" runat="server"></asp:TextBox>
            &nbsp;
            <asp:Button ID="Button2" runat="server" Text="DeleteClub" OnClick="DeleteC" Height="33px" Width="91px"/>
            <br />
            <br />
            NameOfStadium<br />
            <asp:TextBox ID="ADD1" runat="server"></asp:TextBox>
&nbsp;
            <br />
            LocationOfStadium<br />
            <asp:TextBox ID="location" runat="server"></asp:TextBox>
            <br />
            Capcity<br />
            <asp:TextBox ID="Cap" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="AddStadium" OnClick="AddS"/>
            <br />
            <br />
            NameOfStadium<br />
            <asp:TextBox ID="Delete1" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="Button4" runat="server" Text="DeleteStadium" OnClick="DeleteS" />
            <br />
            <br />
            FanID<br />
            <asp:TextBox ID="Block" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="Sherif" runat="server" Text="BlockFan" OnClick="BlockFan"/>
            <br />
            <br />
            FanID<br />
            <asp:TextBox ID="UnBlock" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="Button6" runat="server" Text="UnBlockFan" OnClick="UnBlockFan" />
            <br />
            <br />
            <asp:Button ID="Button7" runat="server" Text="LogOut" OnClick="LogOut" />
            <br />
        </div>
    </form>
</body>
</html>
