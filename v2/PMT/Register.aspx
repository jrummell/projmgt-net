<%@ Page language="c#" Codebehind="Register.aspx.cs" AutoEventWireup="false" Inherits="PMT.Register" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="Controls/PageNameControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="Controls/XmlNavBar.ascx" %><%@ Register TagPrefix="pmt" TagName="StyleControl" src="Controls/StyleControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="ProfileControl" src="Controls/ProfileControl.ascx" %>
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
                    <td id="Header" colSpan="2"><pmt:headercontrol id="HeaderControl1" runat="server" /></td>
                </tr>
                <tr>
                    <td id="Navigation" vAlign="top"><pmt:navcontrol id="NavControl1" runat="server"></pmt:navcontrol></td>
                    <td id="Main" vAlign="top"><pmt:pagenamecontrol id="PageNameControl1" runat="server" PageTitle="Register"></pmt:pagenamecontrol><asp:panel id="RegisterPanel" runat="server">
                            <pmt:ProfileControl id="ProfileControl1" runat="server"></pmt:ProfileControl>
                            <BR>
                            <asp:Button id="SubmitButton" runat="server" Text="Submit"></asp:Button>
                        </asp:panel>
                        <P>&nbsp;</P>
                        <asp:panel id="StatusPanel" runat="server" Visible="False">
                            <asp:Label id="StatusLabel" runat="server" ForeColor="Red"></asp:Label>
                        </asp:panel></td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
