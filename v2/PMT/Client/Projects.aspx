<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../Controls/PageNameControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="StyleControl" src="../Controls/StyleControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../Controls/XmlNavBar.ascx" %>
<%@ Page language="c#" Inherits="PMT.Client.Projects" CodeFile="Projects.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD runat="server">
        <title>Project Management Tool</title>
        <pmt:StyleControl runat="server" id="StyleControl1" />
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="C#" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    </HEAD>
    <BODY>
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
                        <P><pmt:PageNameControl PageTitle="Projects" runat="server" id="PageNameControl1" /></P>
                        <asp:DataGrid id="DataGrid1" runat="server" 
                            CssClass="dg" 
                            HeaderStyle-CssClass="dgHeader" 
                            AlternatingItemStyle-CssClass="dgAltItem"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn Visible="False" DataField="projectID" HeaderText="Project ID"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="managerID" HeaderText="Manager ID"></asp:BoundColumn>
                                <asp:BoundColumn DataField="projectName" HeaderText="Project Name"></asp:BoundColumn>
                                <asp:BoundColumn DataField="managerName" HeaderText="Manager Name"></asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                    </td>
                </tr>
            </table>
        </form>
    </BODY>
</HTML>
