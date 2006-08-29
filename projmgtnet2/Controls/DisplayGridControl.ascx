<%@ Control Language="c#" AutoEventWireup="false" Codebehind="DisplayGridControl.ascx.cs" Inherits="PMT.Controls.DisplayGridControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<asp:datagrid id="DataGrid1" AutoGenerateColumns="False" runat="server">
    <AlternatingItemStyle BackColor="#3399FF"></AlternatingItemStyle>
    <ItemStyle BackColor="White"></ItemStyle>
    <HeaderStyle Font-Bold="True"></HeaderStyle>
    <Columns>
        <asp:BoundColumn DataField="name" HeaderText="Name"></asp:BoundColumn>
        <asp:BoundColumn DataField="description" HeaderText="Description"></asp:BoundColumn>
        <asp:ButtonColumn Text="Delete" ButtonType="PushButton" HeaderText="not impl" CommandName="Delete"></asp:ButtonColumn>
    </Columns>
</asp:datagrid>
