<%@ Page Language="c#" AutoEventWireup="False" MasterPageFile="~/Master/Default.master" Inherits="PMT.Admin.Users" Codebehind="Users.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>User Administration</h3>
    <p>
        Filter by role: 
        <asp:DropDownList ID="ddlRoles" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRoles_SelectedIndexChanged" />
    </p>
    <asp:DataGrid ID="UserDataGrid" runat="server" AutoGenerateColumns="False" AllowPaging="True">
        <Columns>
            <asp:HyperLinkColumn DataNavigateUrlField="id" DataNavigateUrlFormatString="EditUser.aspx?id={0}&amp;type=current"
                DataTextField="username" HeaderText="User"></asp:HyperLinkColumn>
            <asp:BoundColumn DataField="firstName" HeaderText="First Name"></asp:BoundColumn>
            <asp:BoundColumn DataField="lastName" HeaderText="Last Name"></asp:BoundColumn>
            <asp:BoundColumn DataField="role" HeaderText="Role"></asp:BoundColumn>
        </Columns>
    </asp:DataGrid>
</asp:Content>
