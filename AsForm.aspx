<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsForm.aspx.cs" Inherits="Web.View_Form.AsForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        HostCLub:<br />
        <asp:TextBox ID="HostA" runat="server"></asp:TextBox>
        <br />
        GuestClub:<br />
        <asp:TextBox ID="GuestA" runat="server"></asp:TextBox>
&nbsp;
        <br />
        StartTime:<br />
        <asp:TextBox ID="StA" runat="server"></asp:TextBox>
        <br />
        EndTime:<br />
        <asp:TextBox ID="EtA" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="AddMatch" OnClick="AddM" Width="129px"/>
        <br />
        <br />
          HostCLub:<br />
        <asp:TextBox ID="HostD" runat="server"></asp:TextBox>
        <br />
        GuestClub:<br />
        <asp:TextBox ID="GuestD" runat="server"></asp:TextBox>
&nbsp;
        <br />
        StartTime:<br />
        <asp:TextBox ID="StD" runat="server"></asp:TextBox>
        <br />
        EndTime:<br />
        <asp:TextBox ID="EtD" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button2" runat="server" Text="DeleteMatch" OnClick="DelM" Width="129px"/>
        <br />
        <br />
        NeverPlayedClubs<br />
        <asp:GridView ID="GridView5" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
        <br />
        <br />
        All upcoming matches 
        <asp:GridView ID="GridView7" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
        <asp:Button ID="Button3" runat="server" Text="Load Data" OnClick="Click" />
        <br />
        <br />
        ViewAlreadyPlayed
        <asp:GridView ID="GridView6" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
        <asp:Button ID="Button4" runat="server" Text="LoadData" onClick="Click2"/>
        <br />

        <br />
        <asp:Button ID="Button5" runat="server" Text="LogOut" OnClick="LogOut" />

        <br />


    </form>
</body>
</html>
