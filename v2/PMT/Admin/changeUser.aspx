<%@ Page language="c#" Inherits="PMT.Admin.ChangeUser" CodeFile="changeUser.aspx.cs" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../Controls/PageNameControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../Controls/XmlNavBar.ascx" %><%@ Register TagPrefix="pmt" TagName="StyleControl" src="../Controls/StyleControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="ProfileControl" src="../Controls/ProfileControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD runat="server">
    <title>Project Management Tool</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <pmt:StyleControl runat="server" />
  </HEAD>
  <body>
    <form id="Form1" method="post" runat="server">
      <table width="100%" height="100%">
        <tr>
          <td id="Header" colspan="2">
            <pmt:HeaderControl  id="HeaderControl1" runat="server" />
          </td>
        </tr>
        <tr>
          <td id="Navigation" valign="top">
            <pmt:NavControl xmlSource="AdminNavLinks.xml" runat="server" id="NavControl1" /></td>
          <td id="Main" valign="top">
            <P><pmt:PageNameControl PageTitle="Edit User" runat="server" id="PageNameControl1" /></P>
            <P>
              <pmt:ProfileControl id="ProfileControl1" runat="server"></pmt:ProfileControl></P>
            <P>
              <asp:Button id="Submit" runat="server" Text="Submit" onclick="Submit_Click"></asp:Button>
              <asp:Button id="Cancel" runat="server" Text="Cancel" onclick="Cancel_Click"></asp:Button></P>
          </td>
        </tr>
      </table>
    </form>
  </body>
</HTML>
