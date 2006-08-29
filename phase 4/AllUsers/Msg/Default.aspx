<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="PMT.AllUsers.Msg.Messages" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../../Controls/XmlNavBar.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../../Controls/PageNameControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>Project Management Tool</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="C#" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../StyleSheet.css" type="text/css" rel="stylesheet">
    </HEAD>
    <body>
        <form id="Form1" method="post" runat="server">
            <table height="100%" width="100%">
                <tr>
                    <td id="Header" colSpan="2"><pmt:headercontrol id="HeaderControl1" runat="server"></pmt:headercontrol>
                    </td>
                </tr>
                <tr>
                    <td id="Navigation" vAlign="top"><pmt:navcontrol id="NavControl1" runat="server"></pmt:navcontrol></td>
                    <td id="Main" vAlign="top">
                        <pmt:pagenamecontrol id="PageNameControl1" PageTitle="Messaging" runat="server"></pmt:pagenamecontrol>
                        <P></P>
                        <asp:linkbutton id="ComposeLinkButton" runat="server">Compose message</asp:linkbutton>
                        <asp:LinkButton id="UpdateLinkButton" runat="server">Check for new messages</asp:LinkButton><BR>
                        <asp:panel id="ComposePanel" runat="server" Visible="False">
                            <H4>Compose Message</H4>
                            <TABLE id="Table1" cellSpacing="1" cellPadding="1" border="0">
                                <TR>
                                    <TD></TD>
                                    <TD colSpan="2">
                                        <asp:ValidationSummary id="ComposeValidationSummary" runat="server"></asp:ValidationSummary></TD>
                                    <TD></TD>
                                </TR>
                                <TR>
                                    <TD>To:</TD>
                                    <TD width="150"><BR>
                                        <asp:ListBox id="ToListBox" runat="server" AutoPostBack="True"></asp:ListBox></TD>
                                    <TD>Contacts:<BR>
                                        <asp:ListBox id="ContactsListBox" runat="server" AutoPostBack="True"></asp:ListBox></TD>
                                    <TD>
                                        <asp:CustomValidator id="ToCustomValidator" runat="server" ErrorMessage="Please select a recipient."
                                            Display="None"></asp:CustomValidator></TD>
                                </TR>
                                <TR>
                                    <TD>Subject:</TD>
                                    <TD colSpan="2">
                                        <asp:TextBox id="SubjectTextBox" runat="server" Width="100%" Columns="50"></asp:TextBox></TD>
                                    <TD>
                                        <asp:RequiredFieldValidator id="SubjectRequiredFieldValidator" runat="server" ErrorMessage="Please enter a subject."
                                            Display="None" ControlToValidate="SubjectTextBox"></asp:RequiredFieldValidator></TD>
                                </TR>
                                <TR>
                                    <TD vAlign="top">Message:</TD>
                                    <TD colSpan="2"><TEXTAREA id="MessageTextBox" rows="15" cols="45" runat="server"></TEXTAREA></TD>
                                    <TD vAlign="top">
                                        <asp:RequiredFieldValidator id="MessageRequiredFieldValidator" runat="server" ErrorMessage="Please enter a message."
                                            Display="None" ControlToValidate="MessageTextBox"></asp:RequiredFieldValidator></TD>
                                </TR>
                                <TR>
                                    <TD></TD>
                                    <TD colSpan="2">
                                        <asp:Button id="SendButton" runat="server" Text="Send"></asp:Button></TD>
                                    <TD></TD>
                                </TR>
                            </TABLE>
                        </asp:panel>
                        <P></P>
                        <asp:panel id="MessagesPanel" runat="server">
                            <H4>Inbox</H4>
                            <asp:DataGrid id="MessagesDataGrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                PagerStyle-Mode="NumericPages" AlternatingItemStyle-CssClass="dgAltItem" HeaderStyle-CssClass="dgHeader"
                                CssClass="dg" CellPadding="2">
                                <AlternatingItemStyle CssClass="dgAltItem"></AlternatingItemStyle>
                                <HeaderStyle CssClass="dgHeader"></HeaderStyle>
                                <Columns>
                                    <asp:BoundColumn Visible="False" DataField="messID"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="sender" HeaderText="From">
                                        <HeaderStyle Width="20%"></HeaderStyle>
                                    </asp:BoundColumn>
                                    <asp:HyperLinkColumn DataNavigateUrlField="id" DataNavigateUrlFormatString="viewMessage.aspx?id={0}"
                                        DataTextField="subject" HeaderText="Subject"></asp:HyperLinkColumn>
                                    <asp:BoundColumn DataField="date" HeaderText="Date">
                                        <HeaderStyle Width="20%"></HeaderStyle>
                                    </asp:BoundColumn>
                                    <asp:ButtonColumn Text="Delete" ButtonType="PushButton" HeaderText="Delete?" CommandName="Delete"></asp:ButtonColumn>
                                </Columns>
                                <PagerStyle Mode="NumericPages"></PagerStyle>
                            </asp:DataGrid>
                        </asp:panel></td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
