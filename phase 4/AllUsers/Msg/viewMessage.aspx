<%@ Page language="c#" Codebehind="viewMessage.aspx.cs" AutoEventWireup="false" Inherits="PMT.AllUsers.Msg.viewMessage" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../../Controls/PageNameControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../../Controls/XmlNavBar.ascx" %>
<%@ Register TagPrefix="pmt" TagName="StyleControl" src="../../Controls/StyleControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>Message View</title>
        <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
        <meta name="CODE_LANGUAGE" Content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <pmt:StyleControl runat="server" id="StyleControl1" />
    </HEAD>
    <body MS_POSITIONING="GridLayout">
        <form id="Form1" method="post" runat="server">
            <table width="100%" height="100%">
                <tr>
                    <td id="Header" colspan="2">
                        <pmt:HeaderControl id="HeaderControl1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td id="Navigation" valign="top">
                        <pmt:NavControl xmlSource="MessagingNavLinks.xml" runat="server" id="NavControl1" /></td>
                    <td id="Main" valign="top">
                        <P><pmt:PageNameControl PageTitle="Messaging" runat="server" id="PageNameControl1" /></P>
                        <P>
                            <asp:HyperLink id="ReturnHyperLink" runat="server" NavigateUrl="default.aspx">Return to Inbox</asp:HyperLink></P>
                        <H4>View Message</H4>
                        <TABLE id="Table1" cellSpacing="1" cellPadding="1" border="0">
                            <TR>
                                <td>Subject:</td>
                                <TD>
                                    <asp:Label id="subjectLabel" runat="server" ForeColor="Black"></asp:Label></TD>
                            </TR>
                            <TR>
                                <TD>Sender:</TD>
                                <TD>
                                    <asp:Label id="senderLabel" runat="server"></asp:Label></TD>
                            </TR>
                            <TR>
                                <TD>Date:</TD>
                                <TD>
                                    <asp:Label id="dateLabel" runat="server"></asp:Label></TD>
                            </TR>
                            <TR>
                                <TD valign="top">Message:</TD>
                                <TD>
                                    <asp:Label id="messageLabel" runat="server" Width="424px" Height="96px"></asp:Label></TD>
                            </TR>
                        </TABLE>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
