<%@ Register TagPrefix="pmt" TagName="StyleControl" src="../Controls/StyleControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../Controls/XmlNavBar.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../Controls/PageNameControl.ascx" %>
<%@ Page language="c#" Codebehind="editMatrix.aspx.cs" AutoEventWireup="false" Inherits="PMT.Admin.EditMatrix" %>
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
            <table height="100%" width="100%">
                <tr>
                    <td id="Header" colSpan="2"><pmt:headercontrol id="HeaderControl1" runat="server"></pmt:headercontrol></td>
                </tr>
                <tr>
                    <td id="Navigation" vAlign="top"><pmt:navcontrol id="NavControl1" runat="server"></pmt:navcontrol></td>
                    <td id="Main" vAlign="top">
                        <P><pmt:pagenamecontrol id="PageNameControl1" runat="server" PageTitle="Competency Matrix Editor"></pmt:pagenamecontrol></P>
                        <asp:datagrid id="compMatrixGrid" runat="server" CssClass="dg" HeaderStyle-CssClass="dgHeader" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn DataField="compLevel" ReadOnly="True" ItemStyle-CssClass="dgHeader"></asp:BoundColumn>
                                <asp:BoundColumn DataField="lowComplexity" HeaderText="Low Difficulty"></asp:BoundColumn>
                                <asp:BoundColumn DataField="medComplexity" HeaderText="Medium Difficulty"></asp:BoundColumn>
                                <asp:BoundColumn DataField="highComplexity" HeaderText="High Difficulty"></asp:BoundColumn>
                                <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" HeaderText="Change?" CancelText="Cancel"
                                    EditText="Edit"></asp:EditCommandColumn>
                            </Columns>
                        </asp:datagrid>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
