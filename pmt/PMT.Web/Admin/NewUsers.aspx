<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Web.Admin.NewUser"
    CodeBehind="NewUsers.aspx.cs" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>
        New User Requests</h3>
    <p>
        Check the enable box to approve a user. Click on the "Decline" button to decline
        a user.</p>
    <asp:DataGrid ID="NewUserDataGrid" runat="server" AutoGenerateColumns="False" AllowPaging="True"
        OnDeleteCommand="NewUserDataGrid_DeleteCommand">
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
            <asp:BoundColumn DataField="Role" HeaderText="Requested Role" SortExpression="Role">
            </asp:BoundColumn>
            <asp:ButtonColumn Text="Decline" CommandName="Delete"></asp:ButtonColumn>
        </Columns>
    </asp:DataGrid>
</asp:Content>
