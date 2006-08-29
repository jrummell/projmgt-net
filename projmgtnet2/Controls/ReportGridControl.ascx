<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ReportGridControl.ascx.cs" Inherits="PMT.Controls.ReportGridControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<asp:datagrid id="DataGrid1" AutoGenerateColumns="False" runat="server">
    <AlternatingItemStyle BackColor="#3399FF"></AlternatingItemStyle>
    <ItemStyle BackColor="White"></ItemStyle>
    <HeaderStyle Font-Bold="True"></HeaderStyle>
    <Columns>
        <asp:BoundColumn DataField="name" HeaderText="Module Name"></asp:BoundColumn>
        <asp:BoundColumn DataField="description" HeaderText="Description"></asp:BoundColumn>
        <asp:BoundColumn DataField="startDate" HeaderText="Start Date"></asp:BoundColumn>
        <asp:BoundColumn DataField="expEndDate" HeaderText="Expected End Date"></asp:BoundColumn>
        <asp:BoundColumn DataField="actEndDate" HeaderText="Actual End Date"></asp:BoundColumn>
    </Columns>
</asp:datagrid>
