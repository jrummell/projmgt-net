<%@ Page language="c#" Codebehind="Profile.aspx.cs" AutoEventWireup="false" Inherits="PMT.AllUsers.Profile" %>
<%@ Register TagPrefix="pmt" TagName="ProfileControl" src="../Controls/ProfileControl.ascx" %>
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
                        <P><pmt:pagenamecontrol id="PageNameControl1" runat="server" PageTitle="Profile"></pmt:pagenamecontrol></P>
                        <P>
                            <asp:Label id="StatusLabel" runat="server" Font-Bold="True"></asp:Label><BR>
                            <br>
                            <pmt:profilecontrol id="ProfileControl1" runat="server"></pmt:profilecontrol></P>
                        <P>
                            <asp:Button id="SubmitButton" runat="server" Text="Update"></asp:Button></P>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
