<%@ Register TagPrefix="pmt" TagName="StyleControl" src="../Controls/StyleControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../Controls/XmlNavBar.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../Controls/PageNameControl.ascx" %>
<%@ Page language="c#" Inherits="PMT.Admin.EditMatrix" CodeFile="editMatrix.aspx.cs" %>
<%@ Import Namespace="PMT" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD runat="server">
        <title>Project Management Tool</title>
        <pmt:StyleControl runat="server" id="StyleControl1" />
    </HEAD>
    <body>
        <form id="Form1" method="post" runat="server">
            <table height="100%" width="100%">
                <tr>
                    <td id="Header" colSpan="2"><pmt:headercontrol id="HeaderControl1" runat="server" /></td>
                </tr>
                <tr>
                    <td id="Navigation" vAlign="top"><pmt:navcontrol id="NavControl1" runat="server" /></td>
                    <td id="Main" vAlign="top">
                        <P><pmt:pagenamecontrol id="PageNameControl1" runat="server" PageTitle="Competency Matrix Editor" /></P>
                        <p><asp:Label ID="ResultLabel" Runat="server" /></p>
                        <asp:datagrid id="compMatrixGrid" runat="server" AutoGenerateColumns="False"
                            CssClass="<%# Global.DataGridStyle %>" 
                            HeaderStyle-CssClass="<%# Global.DataGridHeaderStyle %>" 
                            ItemStyle-CssClass="<%# Global.DataGridItemStyle %>"
                            AlternatingItemStyle-CssClass="<%# Global.DataGridAltItemStyle %>">
                            <Columns>
                                <asp:BoundColumn DataField="compLevel" ReadOnly="True" ItemStyle-CssClass="dgHeader" />
                                <asp:BoundColumn DataField="lowComplexity" HeaderText="Low Difficulty" />
                                <asp:BoundColumn DataField="medComplexity" HeaderText="Medium Difficulty" />
                                <asp:BoundColumn DataField="highComplexity" HeaderText="High Difficulty" />
                                <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" HeaderText="Change?" CancelText="Cancel"
                                    EditText="Edit" />
                            </Columns>
                        </asp:datagrid>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
