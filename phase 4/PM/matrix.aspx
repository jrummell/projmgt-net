<%@ Register TagPrefix="pmt" TagName="StyleControl" src="../Controls/StyleControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../Controls/XmlNavBar.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../Controls/PageNameControl.ascx" %>
<%@ Page language="c#" Codebehind="Matrix.aspx.cs" AutoEventWireup="false" Inherits="PMT.PM.Matrix" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
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
                    <td id="Main" valign="top"><pmt:PageNameControl PageTitle="Competency/Complexity Matrix" runat="server" id="PageNameControl1" />
                        <asp:DataGrid id="compMatrixGrid" runat="server" 
                            CssClass="dg" 
                            HeaderStyle-CssClass="dgHeader" 
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn DataField="compLevel" ItemStyle-CssClass="dgHeader">
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="lowComplexity" HeaderText="Low Difficulty"></asp:BoundColumn>
                                <asp:BoundColumn DataField="medComplexity" HeaderText="Medium Difficulty"></asp:BoundColumn>
                                <asp:BoundColumn DataField="highComplexity" HeaderText="High Difficulty"></asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid></td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
