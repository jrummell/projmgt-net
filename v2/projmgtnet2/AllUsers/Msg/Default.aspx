<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="PMT.AllUsers.Msg.Messages" %>
<%@ Import Namespace="PMT" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../../Controls/PageNameControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../../Controls/XmlNavBar.ascx" %>
<%@ Register TagPrefix="pmt" TagName="StyleControl" Src="../../Controls/StyleControl.ascx" %>
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
                    <td id="Header" colSpan="2"><pmt:headercontrol id="HeaderControl1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td id="Navigation" vAlign="top"><pmt:navcontrol id="NavControl1" runat="server" /></td>
                    <td id="Main" vAlign="top">
                        <pmt:pagenamecontrol id="PageNameControl1" PageTitle="Messaging" runat="server" />
                        <P>
                            <a href="newMessage.aspx">Compose message</a>
                            <a href="default.aspx">Check for new messages</a>
                        </P>
                        <asp:panel id="MessagesPanel" runat="server">
                            <H4>Inbox</H4>
                            <asp:DataGrid id=MessagesDataGrid runat="server" CssClass="<%# Global.DataGridStyle %>" HeaderStyle-CssClass="<%# Global.DataGridHeaderStyle %>" AlternatingItemStyle-CssClass="<%# Global.DataGridAltItemStyle %>" ItemStyle-CssClass="<%# Global.DataGridItemStyle %>" PagerStyle-Mode="NumericPages" AllowPaging="True" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundColumn HeaderText="From" DataField="senderName" />
                                    <asp:HyperLinkColumn HeaderText="Subject" 
                                        DataNavigateUrlField="messageID" 
                                        DataNavigateUrlFormatString="viewMessage.aspx?id={0}" 
                                        DataTextField="subject" />
                                    <asp:BoundColumn HeaderText="Date" 
                                        DataField="date" />
                                    <asp:ButtonColumn HeaderText="Delete" 
                                        Text="Delete" 
                                        ButtonType="LinkButton" 
                                        CommandName="Delete" />
                                </Columns>
                            </asp:DataGrid>
                        </asp:panel>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
