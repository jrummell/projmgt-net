<%@ Page language="c#" Codebehind="Tasks.aspx.cs" AutoEventWireup="false" Inherits="PMT.Dev.Tasks" %>
<%@ Register TagPrefix="pmt" TagName="DisplayGridControl" src="../Controls/DisplayGridControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="StyleControl" src="../Controls/StyleControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../Controls/XmlNavBar.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../Controls/PageNameControl.ascx" %>
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
                    <td id="Header" colSpan="2"><pmt:headercontrol id="HeaderControl1" runat="server" /></td>
                </tr>
                <tr>
                    <td id="Navigation" vAlign="top"><pmt:navcontrol id="NavControl1" runat="server" /></td>
                    <td id="Main" vAlign="top">
                        <P><pmt:pagenamecontrol id="PageNameControl1" runat="server" PageTitle="Tasks" /></P>
                        <asp:datagrid id="DataGrid1" runat="server" 
                            CssClass="dg" 
                            HeaderStyle-CssClass="dgHeader" 
                            AlternatingItemStyle-CssClass="dgAltItem"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn Visible="False" DataField="taskID" ReadOnly="True" HeaderText="TaskID"></asp:BoundColumn>
                                <asp:BoundColumn DataField="name" ReadOnly="True" HeaderText="Name"></asp:BoundColumn>
                                <asp:BoundColumn DataField="moduleName" HeaderText="Module"></asp:BoundColumn>
                                <asp:BoundColumn DataField="projectName" HeaderText="Project"></asp:BoundColumn>
                                <asp:BoundColumn DataField="dateAss" ReadOnly="True" HeaderText="Date Assigned"></asp:BoundColumn>
                                <asp:BoundColumn DataField="actEndDate" ReadOnly="True" HeaderText="Date Completed"></asp:BoundColumn>
                                <asp:TemplateColumn Visible="False" HeaderText="Completed?">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="completeCheckBox" Runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="complete" ReadOnly="True" HeaderText="Status"></asp:BoundColumn>
                            </Columns>
                        </asp:datagrid><asp:button id="UpdateButton" runat="server" Text="Update Status"></asp:button>&nbsp;<asp:button id="CommitButton" runat="server" Text="Commit Changes" Enabled="False"></asp:button>
                        <asp:Button id="CancelButton" runat="server" Text="Cancel" Enabled="False"></asp:Button></td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
