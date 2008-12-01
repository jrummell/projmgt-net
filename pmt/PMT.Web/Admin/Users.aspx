<%@ Page Language="c#" AutoEventWireup="False" MasterPageFile="~/Master/Default.master" Inherits="PMT.Web.Admin.Users" Codebehind="Users.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <script type="text/javascript">
        function changeRole(role)
        {
            window.location = "?role=" + role;
        }
    </script>
    <h3>User Administration</h3>
    <p>
        Filter by role: 
        <select ID="ddlRole" runat="server" onchange="changeRole(this.value);" />
    </p>
    <asp:DataGrid ID="UserDataGrid" runat="server" AutoGenerateColumns="False" AllowPaging="True">
        <Columns>
            <asp:HyperLinkColumn DataNavigateUrlField="id" DataNavigateUrlFormatString="EditUser.aspx?id={0}&amp;type=current"
                DataTextField="Username" HeaderText="User"></asp:HyperLinkColumn>
            <asp:BoundColumn DataField="FirstName" HeaderText="First Name"></asp:BoundColumn>
            <asp:BoundColumn DataField="LastName" HeaderText="Last Name"></asp:BoundColumn>
            <asp:BoundColumn DataField="Role" HeaderText="Role"></asp:BoundColumn>
        </Columns>
    </asp:DataGrid>
</asp:Content>
