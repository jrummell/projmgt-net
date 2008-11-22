<%@ Control Language="c#" Inherits="PMT.Web.Controls.Header" Codebehind="Header.ascx.cs" %>

<h2>Project Management .Net</h2>
<div style="float: right">
    <asp:LoginView ID="LoginView1" runat="server">
        <LoggedInTemplate>
            <asp:HyperLink ID="hlProfile" runat="server" NavigateUrl="~/allusers/profile.aspx">
                <asp:LoginName ID="LoginName1" runat="server" />
            </asp:HyperLink> |
        <asp:HyperLink ID="hlLogout" runat="server" NavigateUrl="~/logout.aspx">Logout</asp:HyperLink>
        </LoggedInTemplate>
        <AnonymousTemplate>
            <asp:HyperLink ID="hlRegister" runat="server" NavigateUrl="~/register.aspx">Register</asp:HyperLink> |
        <asp:HyperLink ID="hlLogin" runat="server" NavigateUrl="~/login.aspx">Login</asp:HyperLink>
        </AnonymousTemplate>
    </asp:LoginView>
</div>
<br style="clear:both;" />
