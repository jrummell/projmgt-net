<%@ Register TagPrefix="pmt" TagName="NavControl" src="../Controls/XmlNavBar.ascx" %>
<%@ Register TagPrefix="pmt" TagName="StyleControl" src="../Controls/StyleControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../Controls/PageNameControl.ascx" %>
<%@ Page language="c#" Inherits="PMT.Admin.Users" CodeFile="userList.aspx.cs" %>
<%@ Import Namespace="PMT" %>
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
                    <td id="Main" valign="top"><pmt:PageNameControl PageTitle="User Administration" runat="server" id="PageNameControl1" />
                        <asp:DataGrid id="UserDataGrid" runat="server" 
                            CssClass="<%# Global.DataGridStyle %>" 
                            HeaderStyle-CssClass="<%# Global.DataGridHeaderStyle %>" 
                            ItemStyle-CssClass="<%# Global.DataGridItemStyle %>"
                            AlternatingItemStyle-CssClass="<%# Global.DataGridAltItemStyle %>"
                            AutoGenerateColumns="False" AllowPaging="True">
                            <Columns>
                            <asp:HyperLinkColumn DataNavigateUrlField="id" DataNavigateUrlFormatString="changeUser.aspx?id={0}&amp;type=current" DataTextField="username" HeaderText="User"></asp:HyperLinkColumn>
                            <asp:BoundColumn DataField="firstName" HeaderText="First Name"></asp:BoundColumn>
                            <asp:BoundColumn DataField="lastName" HeaderText="Last Name"></asp:BoundColumn>
                            <asp:BoundColumn DataField="role" HeaderText="Role"></asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid></td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
