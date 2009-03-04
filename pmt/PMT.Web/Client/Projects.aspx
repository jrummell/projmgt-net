<%@ Page CodeBehind="Projects.aspx.cs" Inherits="PMT.Web.Client.Projects" Language="c#"
    MasterPageFile="~/Master/Default.master" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>
        Projects</h3>
    <asp:DataGrid ID="dgProjects" runat="server" AutoGenerateColumns="False" EnableViewState="false">
        <Columns>
            <asp:BoundColumn DataField="ProjectID" HeaderText="Project ID"></asp:BoundColumn>
            <asp:BoundColumn DataField="ProjectName" HeaderText="Project Name"></asp:BoundColumn>
        </Columns>
    </asp:DataGrid>
</asp:Content>
