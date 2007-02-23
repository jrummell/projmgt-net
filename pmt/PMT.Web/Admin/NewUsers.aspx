<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Admin.NewUser" Codebehind="NewUsers.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>New User Requests</h3>
    <p>Check the enable box to approve a user. Click on the "Decline" button to decline
        a user.</p>
    <asp:DataGrid ID="NewUserDataGrid" runat="server" AutoGenerateColumns="False" AllowPaging="True">
        <Columns>
            <asp:BoundColumn DataField="ID" HeaderText="ID" SortExpression="ID"></asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Enable">
                <ItemTemplate>
                    <asp:CheckBox ID="cbEnabled" runat="server" AutoPostBack="True" Checked='<%# Eval("Enabled") %>'
                        OnCheckedChanged="cbEnabled_CheckedChanged" />
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:HyperLinkColumn DataNavigateUrlField="ID" DataNavigateUrlFormatString="EditUser.aspx?id={0}&amp;type=new"
                DataTextField="Username" HeaderText="Username"></asp:HyperLinkColumn>
            <asp:TemplateColumn HeaderText="Requested Role" SortExpression="Role">
                <ItemTemplate>
                    <asp:Label ID="lblRole" runat="server" Text='<%# (PMT.BLL.UserRole)Enum.Parse(typeof(PMT.BLL.UserRole), Eval("Role").ToString()) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:ButtonColumn Text="Decline" CommandName="Delete"></asp:ButtonColumn>
        </Columns>
    </asp:DataGrid>
</asp:Content>
