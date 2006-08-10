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
                        <a href="newMessage.aspx">Compose message</a>
                        <a href="default.aspx">Check for new messages</a><BR>
                        <asp:panel id="ComposePanel" runat="server" Visible="False">
                            
                        </asp:panel>
                        <P></P>
                        <asp:panel id="MessagesPanel" runat="server">
                            <H4>Inbox</H4>
                            <asp:DataGrid id="MessagesDataGrid" runat="server" AllowPaging="True" AutoGenerateColumns="True"
                                PagerStyle-Mode="NumericPages" AlternatingItemStyle-CssClass="dgAltItem" HeaderStyle-CssClass="dgHeader"
                                CssClass="dg" CellPadding="2">
                                <AlternatingItemStyle CssClass="dgAltItem"></AlternatingItemStyle>
                                <HeaderStyle CssClass="dgHeader"></HeaderStyle>
                                <%--
                                <Columns>
                                    <asp:BoundColumn Visible="False" DataField="messID"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="sender" HeaderText="From">
                                    </asp:BoundColumn>
                                    <asp:HyperLinkColumn DataNavigateUrlField="id" DataNavigateUrlFormatString="viewMessage.aspx?id={0}"
                                        DataTextField="subject" HeaderText="Subject"></asp:HyperLinkColumn>
                                    <asp:BoundColumn DataField="date" HeaderText="Date">
                                    </asp:BoundColumn>
                                    <asp:ButtonColumn Text="Delete" ButtonType="PushButton" HeaderText="Delete?" CommandName="Delete"></asp:ButtonColumn>
                                </Columns>
                                --%>
                            </asp:DataGrid>
                        </asp:panel></td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
