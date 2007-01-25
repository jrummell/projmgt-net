<%@ Control Language="c#" Inherits="PMT.Controls.Header" Codebehind="Header.ascx.cs" %>
<%@ Import Namespace="PMT.Configuration" %>

<h2>Project Management .Net</h2>
<div style="float: left">
    <asp:Label id="lblRole" Runat="server" />
</div>
<div style="float: right">
    <asp:Panel ID="pnlLoggedIn" runat="server">
        <a href="<%= Config.ApplicationPath %>allusers/profile.aspx"><asp:Label ID="lblUsername" Runat="server" /></a> |
        <a href="<%= Config.ApplicationPath %>allusers/msg">Messages</a> |
        <a href="<%= Config.ApplicationPath %>logout.aspx">Logout</a>
    </asp:Panel>
    <asp:Panel ID="pnlLoggedOut" runat="server">
        <a href="<%= Config.ApplicationPath %>register.aspx">Register</a> |
        <a href="<%= Config.ApplicationPath %>login.aspx">Login</a>
    </asp:Panel>
</div>
