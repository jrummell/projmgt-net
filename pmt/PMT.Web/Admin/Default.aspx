<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Web.Admin.Default"
    AutoEventWireup="false" CodeBehind="~/Admin/Default.aspx.cs" %>

<%@ Import Namespace="PMT.BLL" %>
<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>
        Admin</h3>
    <p>
        <a href="NewUsers.aspx">New/Disabled Users</a>:
        <asp:Label ID="lblNewUsers" runat="server"></asp:Label></p>
    <p>
        <a href="Users.aspx">Total Active Users</a>:
        <asp:Label ID="lblTotalUsers" runat="server"></asp:Label></p>
    <asp:Repeater ID="rptUsers" runat="server">
        <HeaderTemplate>
            <table>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <a href="Users.aspx?role=<%# Eval("Key") %>">
                        <%# Eval("Key") %>s</a>:
                </td>
                <td>
                    <%# Eval("Value") %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
