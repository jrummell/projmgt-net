<%@ Page language="c#" Inherits="PMT.Admin.NewUser" CodeFile="newUser.aspx.cs" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../Controls/PageNameControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../Controls/XmlNavBar.ascx" %>
<%@ Register TagPrefix="pmt" TagName="StyleControl" src="../Controls/StyleControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD runat="server">
        <title>Project Management Tool</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="C#" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <pmt:StyleControl runat="server" id="StyleControl1" />
  </HEAD>
    <body>
        <form id="Form1" method="post" runat="server">
            <table width="100%" height="100%">
                <tr>
                    <td id="Header" colspan="2">
                        <pmt:HeaderControl id="HeaderControl1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td id="Navigation" valign="top">
                        <pmt:NavControl xmlSource="AdminNavLinks.xml" runat="server" id="NavControl1" /></td>
                    <td id="Main" valign="top"><pmt:PageNameControl PageTitle="New User Requests" runat="server" id="PageNameControl1" />
                        <asp:DataGrid id="NewUserDataGrid" runat="server" CssClass="dg" HeaderStyle-CssClass="dgHeader"
                            AlternatingItemStyle-CssClass="dgAltItem" AutoGenerateColumns="False" AllowPaging="True">
                            <AlternatingItemStyle CssClass="dgAltItem"></AlternatingItemStyle>
                            <HeaderStyle CssClass="dgHeader"></HeaderStyle>
                            <Columns>
                            <asp:BoundColumn Visible="False" DataField="id" HeaderText="ID"></asp:BoundColumn>
                            <asp:BoundColumn DataField="firstName" HeaderText="First Name"></asp:BoundColumn>
                            <asp:BoundColumn DataField="lastName" HeaderText="Last Name"></asp:BoundColumn>
                            <asp:HyperLinkColumn DataNavigateUrlField="id" DataNavigateUrlFormatString="changeUser.aspx?id={0}&amp;type=new" DataTextField="userName" HeaderText="User Name"></asp:HyperLinkColumn>
                            <asp:BoundColumn DataField="email" HeaderText="E-Mail"></asp:BoundColumn>
                            <asp:BoundColumn DataField="role" HeaderText="Requested Role"></asp:BoundColumn>
                            <asp:ButtonColumn Text="Decline" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
                            </Columns>
                        </asp:DataGrid>
                        <asp:Label id="Label1" runat="server">Click on a username to approve a user. Click on the "Decline" button to decline a user.</asp:Label>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
