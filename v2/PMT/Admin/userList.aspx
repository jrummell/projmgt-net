<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Admin.Users"
    CodeFile="userList.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>User Administration</h3>
    <asp:DataGrid ID="UserDataGrid" runat="server" AutoGenerateColumns="False" AllowPaging="True">
        <Columns>
            <asp:HyperLinkColumn DataNavigateUrlField="id" DataNavigateUrlFormatString="changeUser.aspx?id={0}&amp;type=current"
                DataTextField="username" HeaderText="User"></asp:HyperLinkColumn>
            <asp:BoundColumn DataField="firstName" HeaderText="First Name"></asp:BoundColumn>
            <asp:BoundColumn DataField="lastName" HeaderText="Last Name"></asp:BoundColumn>
            <asp:BoundColumn DataField="role" HeaderText="Role"></asp:BoundColumn>
        </Columns>
    </asp:DataGrid>
</asp:Content>
