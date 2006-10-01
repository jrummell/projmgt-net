<%@ Page language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.PM.ViewDevProfile" CodeFile="ViewDevProfile.aspx.cs" %>
<%@ Register TagPrefix="pmt" TagName="Profile" Src="~/Controls/PMTProfile.ascx" %>
<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>Developer Profile</h3>
    <asp:HyperLink id="BackHyperLink" runat="server" NavigateUrl="Assign.aspx">Back to Developer Assignments</asp:HyperLink>
    <pmt:Profile id="ProfileControl1" runat="server" />
</asp:Content>
