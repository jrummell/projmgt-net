<%@ Control Language="c#" AutoEventWireup="false" Codebehind="HeaderControl.ascx.cs" Inherits="PMT.Controls.HeaderControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<h1>Project Management .Net</h1>
<div style="FLOAT: left">
    <asp:Label id="lblRole" Runat="server" />
</div>
<div style="FLOAT: right">
    <asp:Panel ID="pnlLoggedIn" Runat="server">
        Logged in as: <asp:Label ID="lblUsername" Runat="server" /> - 
        <asp:HyperLink id="hlProfile" CssClass="nav" runat="server">Profile</asp:HyperLink> - 
        <asp:HyperLink id="hlMessages" CssClass="nav" runat="server">Messages</asp:HyperLink> -
        <asp:HyperLink id="hlLogout" CssClass="nav" runat="server">Logout</asp:HyperLink>
    </asp:Panel>
    <asp:Panel ID="pnlLoggedOut" Runat="server">
        <asp:HyperLink ID="hlRegister" CssClass="nav" Runat="server">Register</asp:HyperLink> - 
        <asp:HyperLink ID="hlLogin" CssClass="nav" Runat="server">Login</asp:HyperLink>
    </asp:Panel>
</div>