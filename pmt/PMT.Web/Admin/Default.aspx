<%@ Page Language="c#" MasterPageFile="~/Master/Default.master"
    Inherits="PMT.Admin.Default" AutoEventWireup="false" Codebehind="~/Admin/Default.aspx.cs" %>
<%@ Import Namespace="PMT.BLL" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>Admin</h3>
    <a href="NewUsers.aspx">New/Disabled Users</a>: <asp:Label ID="lblNewUsers" runat="server"></asp:Label>
    <br /><br />
    <a href="Users.aspx">Total Active Users</a>: <asp:Label ID="lblTotalUsers" runat="server"></asp:Label>
    <table>
        <tr>
            <td><a href="Users.aspx?role=<%= (int)UserRole.Administrator %>">Adminstrators</a>:</td>
            <td>
                <asp:Label ID="lblAdmins" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><a href="Users.aspx?role=<%= (int)UserRole.Manager %>">Managers</a>:</td>
            <td>
                <asp:Label ID="lblManagers" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><a href="Users.aspx?role=<%= (int)UserRole.Developer %>">Developers</a>:</td>
            <td>
                <asp:Label ID="lblDevelopers" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><a href="Users.aspx?role=<%= (int)UserRole.Client %>">Clients</a>:</td>
            <td>
                <asp:Label ID="lblClients" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
