<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" CodeFile="~/Admin/Default.aspx.cs"
    Inherits="PMT.Admin.Default" AutoEventWireup="false" %>
<%@ Import Namespace="PMTComponents" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>Admin</h3>
    <a href="NewUsers.aspx">New User Requests</a>: <asp:Label ID="lblNewUsers" runat="server"></asp:Label><br />
    <a href="Users.aspx">Total Users</a>: <asp:Label ID="lblTotalUsers" runat="server"></asp:Label>
    <table>
        <tr>
            <td><a href="Users.aspx?role=<%= (int)PMTUserRole.Administrator %>">Adminstrators</a>:</td>
            <td>
                <asp:Label ID="lblAdmins" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><a href="Users.aspx?role=<%= (int)PMTUserRole.Manager %>">Managers</a>:</td>
            <td>
                <asp:Label ID="lblManagers" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><a href="Users.aspx?role=<%= (int)PMTUserRole.Developer %>">Developers</a>:</td>
            <td>
                <asp:Label ID="lblDevelopers" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><a href="Users.aspx?role=<%= (int)PMTUserRole.Client %>">Clients</a>:</td>
            <td>
                <asp:Label ID="lblClients" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
