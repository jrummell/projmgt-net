<%@ Page language="c#" Codebehind="Projects.aspx.cs" AutoEventWireup="false" Inherits="PMT.PM.Projects" %>
<%@ Register TagPrefix="pmt" TagName="DisplayGridControl" src="../Controls/DisplayGridControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../Controls/XmlNavBar.ascx" %><%@ Register TagPrefix="pmt" TagName="StyleControl" src="../Controls/StyleControl.ascx" %>
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
                    <td id="Main" vAlign="top">
                        <P><pmt:pagenamecontrol id="PageNameControl1" runat="server" PageTitle="Projects"></pmt:pagenamecontrol></P>
                        <asp:Label ID="lblResult" Runat="server" />
                        <asp:panel id="projectPanel" runat="server">
                            <H4>
                                <asp:Label id="ItemLabel" runat="server"></asp:Label></H4>
                            <asp:datagrid id="DataGrid1" runat="server" 
                                CssClass="dg" 
                                HeaderStyle-CssClass="dgHeader" 
                                AlternatingItemStyle-CssClass="dgAltItem"
                                AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
                                    <asp:HyperLinkColumn DataNavigateUrlField="id" DataTextField="name" HeaderText="Name"></asp:HyperLinkColumn>
                                    <asp:BoundColumn DataField="description" HeaderText="Description"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="startDate" HeaderText="Start Date"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="expEndDate" ReadOnly="True" HeaderText="Exp End Date"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="actEndDate" ReadOnly="True" HeaderText="Act End Date"></asp:BoundColumn>
                                    <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" HeaderText="Change?" CancelText="Cancel"
                                        EditText="Edit"></asp:EditCommandColumn>
                                    <asp:ButtonColumn Text="Delete" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
                                </Columns>
                            </asp:datagrid>
                            <BR>
                            <asp:HyperLink id="AddItemHyperLink" runat="server" NavigateUrl="NewItem.aspx?item=Module&amp;parentID="></asp:HyperLink>
                        </asp:panel></td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
