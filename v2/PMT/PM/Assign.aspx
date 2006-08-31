<%@ Page language="c#" Codebehind="Assign.aspx.cs" AutoEventWireup="false" Inherits="PMT.PM.Assign" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../Controls/PageNameControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="StyleControl" src="../Controls/StyleControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../Controls/XmlNavBar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>Project Management Tool</title>
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
                        <P><pmt:PageNameControl PageTitle="Developer Assignments" runat="server" id="PageNameControl1" /></P>
                        <asp:Panel id="AvailableDevPanel" runat="server">
                            <H4><asp:Label id="AvailDevLabel" runat="server">Available Developers</asp:Label></H4>
                            <P>Assignment Threshold: <asp:DropDownList ID="ddlTaskThreshold" AutoPostBack="True" Runat="server" /></P>
                            <asp:Label id="ErrorLabel" runat="server" ForeColor="Red" />
                            <asp:DataGrid id="dgAvailableDevs" runat="server" AutoGenerateColumns="False" 
                                ItemStyle-CssClass="<%= Global.DataGridItemStyle %>"
                                AlternatingItemStyle-CssClass="dgAltItem"
                                HeaderStyle-CssClass="dgHeader" 
                                CssClass="dg">
                                <Columns>
                                    <asp:BoundColumn  DataField="userID" HeaderText="User ID" />
                                    <%--
                                    <asp:BoundColumn DataField="lastName" HeaderText="Last Name" />
                                    <asp:BoundColumn DataField="firstName" HeaderText="First Name" />
                                    --%>
                                    <asp:ButtonColumn DataTextField="userName" HeaderText="Username" CommandName="Select" />
                                    <asp:BoundColumn DataField="numTasks" HeaderText="Tasks Assigned" />
                                    <asp:BoundColumn DataField="competence" HeaderText="Competency" />
                                </Columns>
                            </asp:DataGrid>
                        </asp:Panel>
                        
                        <asp:Panel id="AssignmentsPanel" runat="server">
                            <H4>Assignments</H4>
                            <asp:DataGrid id="dgAssignments" runat="server" AutoGenerateColumns="false" 
                                ItemStyle-CssClass="<%= Global.DataGridItemStyle %>"
                                AlternatingItemStyle-CssClass="dgAltItem"
                                HeaderStyle-CssClass="dgHeader" 
                                CssClass="dg">
                                <Columns>
                                    <%--
                                    <asp:BoundColumn Visible="False" DataField="devID" ReadOnly="True" HeaderText="devID" />
                                    <asp:BoundColumn Visible="False" DataField="taskID" HeaderText="taskID" />
                                    --%>
                                    <asp:BoundColumn DataField="username" HeaderText="Developer" />
                                    <asp:BoundColumn DataField="taskID" HeaderText="Task ID" />
                                    <asp:BoundColumn DataField="taskName" HeaderText="Task" />
                                    <asp:BoundColumn DataField="moduleName" HeaderText="Module" />
                                    <asp:BoundColumn DataField="projectName" HeaderText="Project" />
                                    <asp:BoundColumn DataField="taskStatus" HeaderText="Status" />
                                    <asp:BoundColumn DataField="assignDate" HeaderText="Assigned" />
                                    <asp:BoundColumn DataField="finishDate" HeaderText="Approved" />
                                    <asp:TemplateColumn Visible="False" HeaderText="Approve">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ApproveCheckBox" Runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </asp:DataGrid>
                            <asp:button id="UpdateButton" runat="server" Text="Update Status" />
                            <asp:button id="CommitButton" runat="server" Text="Commit Changes" Enabled="False" />
                            <asp:Button id="CancelButton" runat="server" Text="Cancel" Enabled="False" />
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
