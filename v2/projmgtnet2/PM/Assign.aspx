<%@ Page language="c#" Codebehind="Assign.aspx.cs" AutoEventWireup="false" Inherits="PMT.PM.Assign" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../Controls/PageNameControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="StyleControl" src="../Controls/StyleControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../Controls/XmlNavBar.ascx" %>
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
                    <td id="Main" valign="top">
                        <P><pmt:PageNameControl PageTitle="Developer Assignments" runat="server" id="PageNameControl1" /></P>
                        <asp:Panel id="AvailableDevPanel" runat="server">
      <H4>
<asp:Label id=AvailDevLabel runat="server">Available Developers</asp:Label></H4>
      <P>Select Assignment Threshold(Enter -1 to view all Developers:</P>
      <P>
<asp:TextBox id=ThresholdTextBox runat="server"></asp:TextBox>
<asp:RegularExpressionValidator id=ThreshholdTextBoxRegularExpressionValidator runat="server" ErrorMessage="Please Enter a Number" Display="None" ControlToValidate="ThresholdTextBox"></asp:RegularExpressionValidator></P>
<asp:Label id=ErrorLabel runat="server" ForeColor="Red"></asp:Label>
<asp:DataGrid id=dgAvailableDevs runat="server" CssClass="dg" HeaderStyle-CssClass="dgHeader" AlternatingItemStyle-CssClass="dgAltItem" AutoGenerateColumns="False">
<AlternatingItemStyle CssClass="dgAltItem">
</AlternatingItemStyle>

<HeaderStyle CssClass="dgHeader">
</HeaderStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
<asp:BoundColumn DataField="lastName" HeaderText="Last Name"></asp:BoundColumn>
<asp:BoundColumn DataField="firstName" HeaderText="First Name"></asp:BoundColumn>
<asp:ButtonColumn DataTextField="username" HeaderText="Username" CommandName="Select"></asp:ButtonColumn>
<asp:BoundColumn DataField="taskCount" HeaderText="Tasks Assigned"></asp:BoundColumn>
<asp:BoundColumn DataField="competence" HeaderText="Competency"></asp:BoundColumn>
</Columns>
</asp:DataGrid>
                        </asp:Panel>
                        <asp:Panel id="AssignmentsPanel" runat="server">
      <H4>Assignments</H4>
<asp:DataGrid id=dgAssignments runat="server" CssClass="dg" HeaderStyle-CssClass="dgHeader" AlternatingItemStyle-CssClass="dgAltItem" AutoGenerateColumns="True">
<AlternatingItemStyle CssClass="dgAltItem">
</AlternatingItemStyle>

<HeaderStyle CssClass="dgHeader">
</HeaderStyle>
<%--
<Columns>
<asp:BoundColumn Visible="False" DataField="devID" ReadOnly="True" HeaderText="devID"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="taskID" HeaderText="taskID"></asp:BoundColumn>
<asp:BoundColumn DataField="username" HeaderText="Developer"></asp:BoundColumn>
<asp:BoundColumn DataField="taskName" HeaderText="Task"></asp:BoundColumn>
<asp:BoundColumn DataField="moduleName" HeaderText="Module "></asp:BoundColumn>
<asp:BoundColumn DataField="projectName" HeaderText="Project"></asp:BoundColumn>
<asp:BoundColumn DataField="date" HeaderText="Date Assigned"></asp:BoundColumn>
<asp:BoundColumn DataField="complete" HeaderText="Complete"></asp:BoundColumn>
<asp:TemplateColumn Visible="False" HeaderText="Approved?">
<ItemTemplate>
                                            <asp:CheckBox ID="ApproveCheckBox" Runat="server" />
                                        
</ItemTemplate>
</asp:TemplateColumn>
</Columns>
--%>
</asp:DataGrid>
<asp:button id=UpdateButton runat="server" Text="Update Status"></asp:button>&nbsp; 
<asp:button id=CommitButton runat="server" Text="Commit Changes" Enabled="False"></asp:button>
<asp:Button id=CancelButton runat="server" Text="Cancel" Enabled="False"></asp:Button>
					</asp:Panel></td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
