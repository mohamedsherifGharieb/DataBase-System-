<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stadium_Manager.aspx.cs" Inherits="Web.View_Form.Stadium_Manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
  <Columns>
    <asp:TemplateField HeaderText="Status">
      <ItemTemplate>
       <asp:Label runat="server" Text='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "Status")) == true ? "Available" : "UnAvailable" %>' />
      </ItemTemplate>
    </asp:TemplateField>
     <asp:BoundField DataField="Name" HeaderText="Name" />
    <asp:BoundField DataField="Capacity" HeaderText="Capacity" />
    <asp:BoundField DataField="location" HeaderText="location" />
  </Columns>
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:M4ConnectionString %>" SelectCommand="SELECT [Name], [Capacity], [Status], [location] FROM [ManStad] WHERE ([Username] = @Username)">
                <SelectParameters>
                    <asp:SessionParameter Name="Username" SessionField="USER" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            Requests<asp:GridView ID="GridView2" runat="server"  DataKeyNames="Host,Guest,StartTime" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnAction1" runat="server" Text="Accept" OnClick="Accept_Click" />
                <asp:Button ID="btnAction2" runat="server" Text="Reject" OnClick="Reject_Click" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
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
             <asp:Button ID="Button1" runat="server" Text="ViewRequests" OnClick="View" />
            <br />
            <br />

            <asp:Button ID="Button5" runat="server" Text="LogOut" OnClick="LogOut" />
        </div>
    </form>
</body> 
</html>
