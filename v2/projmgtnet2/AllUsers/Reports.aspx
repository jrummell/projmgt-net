<%@ Page language="c#" Codebehind="Reports.aspx.cs" AutoEventWireup="false" Inherits="PMT.AllUsers.Reports" %>
<%@ Register TagPrefix="pmt" TagName="ReportGridControl" src="../Controls/ReportGridControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../Controls/PageNameControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../Controls/XmlNavBar.ascx" %><%@ Register TagPrefix="pmt" TagName="StyleControl" src="../Controls/StyleControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>Project Management Tool</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="C#" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <pmt:StyleControl runat="server" />
    </HEAD>
    <body>
        <form id="Form1" method="post" runat="server">
            <table height="100%" width="100%">
                <tr>
                    <td id="Header" colSpan="2"><pmt:headercontrol id="HeaderControl1" runat="server"></pmt:headercontrol></td>
                </tr>
                <tr>
                    <td id="Navigation" vAlign="top"><pmt:navcontrol id="NavControl1" runat="server"></pmt:navcontrol></td>
                    <td id="Main" vAlign="top">
                        <P><pmt:pagenamecontrol id="PageNameControl1" runat="server" PageTitle="Reports"></pmt:pagenamecontrol></P>
                        <TABLE id="Table1" cellSpacing="1" cellPadding="1" border="0">
                            <TR>
                                <TD style="HEIGHT: 23px">Project:</TD>
                                <TD style="HEIGHT: 23px"><asp:dropdownlist id="ProjectDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
                                <TD style="HEIGHT: 23px"><asp:button id="ViewProjectButton" runat="server" Text="View Report" Enabled="False"></asp:button></TD>
                            </TR>
                            <TR>
                                <TD>Module:</TD>
                                <TD><asp:dropdownlist id="ModuleDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
                                <TD><asp:button id="ViewModuleButton" runat="server" Text="View Report" Enabled="False"></asp:button></TD>
                            </TR>
                            <TR>
                                <TD>Task:</TD>
                                <TD><asp:dropdownlist id="TaskDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
                                <TD><asp:button id="ViewTaskButton" runat="server" Text="View Report" Enabled="False"></asp:button></TD>
                            </TR>
                        </TABLE>
                        <P>&nbsp;</P>
                        <asp:panel id="ReportPanel" runat="server" Visible="False">
                            <P>
                                <asp:Label id="ProjectLabel" runat="server"></asp:Label><BR>
                                <asp:Label id="ModuleLabel" runat="server"></asp:Label><BR>
                                <asp:Label id="TaskLabel" runat="server"></asp:Label></P>
                            <asp:DataGrid id="DisplayGrid" runat="server" Visible="False" 
                                CssClass="dg" 
                                HeaderStyle-CssClass="dgHeader" 
                                AlternatingItemStyle-CssClass="dgAltItem"
                                AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundColumn Visible="False" DataField="id" HeaderText="ID"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="name" HeaderText="Name"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="description" HeaderText="Description"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="startDate" HeaderText="Start Date"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="expEndDate" HeaderText="Expected End Date"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="actEndDate" HeaderText="Actual End Date"></asp:BoundColumn>
                                    <asp:BoundColumn Visible="False" HeaderText="Status"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Complete (%)"></asp:BoundColumn>
                                </Columns>
                            </asp:DataGrid>
                        </asp:panel>
                        <H5></H5>
                        <H4></H4>
                        <H3></H3>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
