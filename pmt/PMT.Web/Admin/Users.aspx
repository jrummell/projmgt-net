<%@ Page Language="c#" AutoEventWireup="False" MasterPageFile="~/Master/Default.master"
    Inherits="PMT.Web.Admin.Users" CodeBehind="Users.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">

    <script type="text/javascript">
        function changeRole(role)
        {
            window.location = "?role=" + role;
        }
    </script>

    <h3>
        User Administration</h3>
    <p>
        Filter by role:
        <select id="ddlRole" runat="server" onchange="changeRole(this.value);" />
    </p>
    <asp:GridView ID="gvUsers" runat="server" DataSourceID="odsUsers" AutoGenerateColumns="False"
        AllowPaging="True">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="EditUser.aspx?id={0}&amp;type=current"
                DataTextField="Username" HeaderText="User" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="Role" HeaderText="Role" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsUsers" runat="server" SelectMethod="GetByRole" TypeName="PMT.BLL.UserService"
        EnablePaging="true" StartRowIndexParameterName="startRowIndex" MaximumRowsParameterName="maximumRows"
        SelectCountMethod="GetCountByRole">
        <SelectParameters>
            <asp:QueryStringParameter Name="role" QueryStringField="role" Type="Object" ConvertEmptyStringToNull="true" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
