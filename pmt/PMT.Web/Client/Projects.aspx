<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Client.Projects" Codebehind="Projects.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>Projects</h3>
    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundColumn Visible="False" DataField="projectID" HeaderText="Project ID"></asp:BoundColumn>
            <asp:BoundColumn Visible="False" DataField="managerID" HeaderText="Manager ID"></asp:BoundColumn>
            <asp:BoundColumn DataField="projectName" HeaderText="Project Name"></asp:BoundColumn>
            <asp:BoundColumn DataField="managerName" HeaderText="Manager Name"></asp:BoundColumn>
        </Columns>
    </asp:DataGrid>
</asp:Content>
