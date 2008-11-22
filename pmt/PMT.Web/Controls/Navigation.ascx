<%@ Control Language="c#" Inherits="PMT.Web.Controls.Navigation" CodeBehind="Navigation.ascx.cs"
    EnableViewState="false" %>
<div id="divClient" runat="server" visible="false">
    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Client/">Client Home</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Client/Projects.aspx">Projects</asp:HyperLink>
    <br />
</div>
<div id="divDevloper" runat="server" visible="false">
    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Dev/">Developer Home</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Dev/Tasks.aspx">Tasks</asp:HyperLink>
    <br />
</div>
<div id="divManager" runat="server" visible="false">
    <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/PM/">Manager Home</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/PM/Projects.aspx">Projects</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/PM/Developers.aspx">Developers</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/PM/Assign.aspx">Task Assignments</asp:HyperLink>
    <br />
</div>
<div id="divAdministrator" runat="server" visible="false">
    <asp:HyperLink ID="HyperLink0" runat="server" NavigateUrl="~/Admin/">Administrator Home</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/NewUsers.aspx">New Users</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/Users.aspx">User Administration</asp:HyperLink>
    <br />
    <asp:HyperLink ID="hlElmah" runat="server" Target="_blank">Error Log</asp:HyperLink>
    <br />
</div>
<asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/AllUsers/Reports.aspx">Reports</asp:HyperLink>
<br />
