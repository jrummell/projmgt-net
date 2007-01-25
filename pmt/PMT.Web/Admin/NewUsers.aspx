<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Admin.NewUser" Codebehind="NewUsers.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>New User Requests</h3>
    <asp:DataGrid ID="NewUserDataGrid" runat="server" AutoGenerateColumns="False" AllowPaging="True">
        <Columns>
            <asp:BoundColumn Visible="False" DataField="id" HeaderText="ID"></asp:BoundColumn>
            <asp:BoundColumn DataField="firstName" HeaderText="First Name"></asp:BoundColumn>
            <asp:BoundColumn DataField="lastName" HeaderText="Last Name"></asp:BoundColumn>
            <asp:HyperLinkColumn DataNavigateUrlField="id" DataNavigateUrlFormatString="EditUser.aspx?id={0}&amp;type=new"
                DataTextField="userName" HeaderText="User Name"></asp:HyperLinkColumn>
            <asp:BoundColumn DataField="email" HeaderText="E-Mail"></asp:BoundColumn>
            <asp:BoundColumn DataField="role" HeaderText="Requested Role"></asp:BoundColumn>
            <asp:ButtonColumn Text="Decline" ButtonType="LinkButton" CommandName="Delete"></asp:ButtonColumn>
        </Columns>
    </asp:DataGrid>
    <p>Click on a username to approve a user. Click on the "Decline" button to decline a user.</p>
</asp:Content>
