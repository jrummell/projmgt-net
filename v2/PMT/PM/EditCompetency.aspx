<%@ Register TagPrefix="pmt" TagName="NavControl" src="../Controls/XmlNavBar.ascx" %>
<%@ Register TagPrefix="pmt" TagName="StyleControl" src="../Controls/StyleControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../Controls/PageNameControl.ascx" %>
<%@ Page language="c#" Inherits="PMT.PM.EditCompetency" CodeFile="EditCompetency.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD runat="server">
        <title>Project Management Tool</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="C#" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
                        <pmt:NavControl runat="server" id="NavControl1" /></td>
                    <td id="Main" valign="top">
                        <pmt:PageNameControl PageTitle="Developer Competency" runat="server" id="PageNameControl1" />
                        <P>
                            <asp:Label id="IDLabel" runat="server">Developer ID</asp:Label>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            &nbsp;
                            <asp:DropDownList id="DeveloperDropDownList" runat="server" AutoPostBack="True" onselectedindexchanged="DeveloperDropDownList_SelectedIndexChanged"></asp:DropDownList></P>
                        <asp:Panel id="DeveloperPanel" runat="server" Visible="False">
                            <P>
                                <asp:Label id="FirstNameLabel" runat="server">First Name</asp:Label>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label id="devFirstLabel" runat="server">Label</asp:Label></P>
                            <P>
                                <asp:Label id="LastNameLabel" runat="server">Last Name</asp:Label>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label id="devLastLabel" runat="server">Label</asp:Label></P>
                            <P>
                                <asp:Label id="PresentCompetenceLabel" runat="server"> Competence:</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList id="CompetenceDropDownList" runat="server"></asp:DropDownList></P>
                            <P>&nbsp;
                                <asp:Button id="SaveButton" runat="server" Visible="False" Text="Save" onclick="Button_Click"></asp:Button>
                                <asp:Button id="CancelButton" runat="server" Visible="False" Text="Cancel" onclick="Button_Click"></asp:Button></P>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
