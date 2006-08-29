<%@ Register TagPrefix="pmt" TagName="StyleControl" src="../Controls/StyleControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../Controls/XmlNavBar.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../Controls/PageNameControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="ReportGridControl" src="../Controls/ReportGridControl.ascx" %>
<%@ Page language="c#" Codebehind="Reports.aspx.cs" AutoEventWireup="false" Inherits="PMT.AllUsers.Reports" %>
<%@ Register TagPrefix="pmt" TagName="Report" Src="../Controls/Report.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
        <title>Project Management Tool</title>
        <pmt:StyleControl runat="server" id=StyleControl1 />
  </HEAD>
    <body>
        <form id="Form1" method="post" runat="server">
            <table height="100%" width="100%">
                <tr>
                    <td id="Header" colSpan="2"><pmt:headercontrol id="HeaderControl1" runat="server" /></td>
                </tr>
                <tr>
                    <td id="Navigation" vAlign="top"><pmt:navcontrol id="NavControl1" runat="server" /></td>
                    <td id="Main" vAlign="top">
                        <P><pmt:pagenamecontrol id="PageNameControl1" runat="server" PageTitle="Reports" /></P>
                        <TABLE id="Table1" cellSpacing="1" cellPadding="1" border="0">
                            <TR>
                                <TD>Project:</TD>
                                <TD><asp:dropdownlist id="ProjectDropDownList" runat="server" AutoPostBack="True" /></TD>
                                <TD><asp:button id="ViewProjectButton" runat="server" Text="View Report" Enabled="False" /></TD>
                            </TR>
                            <TR>
                                <TD>Module:</TD>
                                <TD><asp:dropdownlist id="ModuleDropDownList" runat="server" AutoPostBack="True" /></TD>
                                <TD><asp:button id="ViewModuleButton" runat="server" Text="View Report" Enabled="False" /></TD>
                            </TR>
                            <TR>
                                <TD>Task:</TD>
                                <TD><asp:dropdownlist id="TaskDropDownList" runat="server" AutoPostBack="True" /></TD>
                                <TD><asp:button id="ViewTaskButton" runat="server" Text="View Report" Enabled="False" /></TD>
                            </TR>
                        </TABLE>
                        <br/>
                        <asp:panel id="ReportPanel" runat="server" Visible="False">
                            <blockquote>
                                <pmt:Report id="report" runat="server" />
                            </blockquote>
                        </asp:panel>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
