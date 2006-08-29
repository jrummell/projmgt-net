<%@ Page language="c#" Codebehind="viewMessage.aspx.cs" AutoEventWireup="false" Inherits="PMT.AllUsers.Msg.viewMessage" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../../Controls/PageNameControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../../Controls/XmlNavBar.ascx" %>
<%@ Register TagPrefix="pmt" TagName="StyleControl" src="../../Controls/StyleControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>Messaging</title>
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
                        <pmt:NavControl xmlSource="MessagingNavLinks.xml" runat="server" id="NavControl1" /></td>
                    <td id="Main" valign="top">
                        <P><pmt:PageNameControl PageTitle="Messaging" runat="server" id="PageNameControl1" /></P>
                        <P>
                            <a href="default.aspx">Return to Inbox</a> | 
                            <a href="newMessage.aspx?action=reply&amp;id=<%= MessageID %>">Reply</a> | 
                            <a href="newMessage.aspx?action=forward&amp;id=<%= MessageID %>">Forward</a></P>
                        <H4>View Message</H4>
                        <TABLE>
                            <TR>
                                <td>Subject:</td>
                                <TD>
                                    <asp:Label id="subjectLabel" runat="server" ForeColor="Black" /></TD>
                            </TR>
                            <TR>
                                <TD>From:</TD>
                                <TD>
                                    <asp:Label id="senderLabel" runat="server" /></TD>
                            </TR>
                            <tr>
                                <td>To:</td>
                                <td></td>
                            </tr>
                            <TR>
                                <TD>Date:</TD>
                                <TD>
                                    <asp:Label id="dateLabel" runat="server" /></TD>
                            </TR>
                            <TR>
                                <TD valign="top">Message:</TD>
                                <TD class="Message">
                                    <asp:Label ID="lblMessage" Runat="server" /></TD>
                            </TR>
                        </TABLE>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
