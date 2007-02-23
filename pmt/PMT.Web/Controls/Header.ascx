<%@ Control Language="c#" Inherits="PMT.Web.Controls.Header" Codebehind="Header.ascx.cs" %>
<%@ Import Namespace="PMT.Configuration" %>

<h2>Project Management .Net</h2>
<div style="float: left">
    <asp:Literal id="litRole" Runat="server" />
</div>
<div style="float: right">
    <span id="spanLoggedIn" runat="server">
        <asp:HyperLink ID="hlProfile" runat="server" NavigateUrl="~/allusers/profile.aspx"></asp:HyperLink> |
        <asp:HyperLink ID="hlMessages" runat="server" NavigateUrl="~/allusers/msg/default.aspx">Messages</asp:HyperLink> |
        <asp:HyperLink ID="hlLogout" runat="server" NavigateUrl="~/logout.aspx">Logout</asp:HyperLink>
    </span>
    <span id="spanLoggedOut" runat="server">
        <asp:HyperLink ID="hlRegister" runat="server" NavigateUrl="~/register.aspx">Register</asp:HyperLink> |
        <asp:HyperLink ID="hlLogin" runat="server" NavigateUrl="~/login.aspx">Login</asp:HyperLink>
    </span>
</div>
