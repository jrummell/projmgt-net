<%@ Register TagPrefix="pmt" TagName="NavControl" src="../../Controls/XmlNavBar.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../../Controls/PageNameControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="StyleControl" src="../../Controls/StyleControl.ascx" %>
<%@ Import Namespace="PMT" %>
<%@ Page language="c#" Codebehind="NewMessage.aspx.cs" AutoEventWireup="false" Inherits="PMT.AllUsers.Msg.NewMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Project Management Tool</title>
		<pmt:StyleControl runat="server" ID="Stylecontrol1" NAME="Stylecontrol1"/>
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
					    <pmt:PageNameControl PageTitle="[Page Title]" runat="server" id="PageNameControl1" />
					    <H4>Compose Message</H4>
					    <asp:Label ID="lblResult" Runat="server" />
                        <TABLE id="Table1" cellSpacing="1" cellPadding="1" border="0">
                            <TR>
                                <TD></TD>
                                <TD colSpan="2">
                                    <asp:ValidationSummary id="ComposeValidationSummary" runat="server"></asp:ValidationSummary></TD>
                                <TD></TD>
                            </TR>
                            <TR>
                                <TD>To:</TD>
                                <TD width="150"><BR>
                                    <asp:ListBox id="ToListBox" runat="server" AutoPostBack="True"></asp:ListBox></TD>
                                <TD>Contacts:<BR>
                                    <asp:ListBox id="ContactsListBox" runat="server" AutoPostBack="True"></asp:ListBox></TD>
                                <TD>
                                    <asp:CustomValidator id="ToCustomValidator" runat="server" ErrorMessage="Please select a recipient."
                                        Display="None"></asp:CustomValidator></TD>
                            </TR>
                            <TR>
                                <TD>Subject:</TD>
                                <TD colSpan="2">
                                    <asp:TextBox id="SubjectTextBox" runat="server" Width="100%" Columns="50"></asp:TextBox><br>
                                    <asp:CheckBox id="cbSaveCopy" Text="Save a copy in sent folder" runat="server" /></TD>
                                <TD>
                                    <asp:RequiredFieldValidator id="SubjectRequiredFieldValidator" runat="server" ErrorMessage="Please enter a subject."
                                        Display="None" ControlToValidate="SubjectTextBox"></asp:RequiredFieldValidator></TD>
                            </TR>
                            <TR>
                                <TD vAlign="top">Message:</TD>
                                <TD colSpan="2"><TEXTAREA id="MessageTextBox" rows="15" cols="45" runat="server" NAME="MessageTextBox"></TEXTAREA></TD>
                                <TD vAlign="top">
                                    <asp:RequiredFieldValidator id="MessageRequiredFieldValidator" runat="server" ErrorMessage="Please enter a message."
                                        Display="None" ControlToValidate="MessageTextBox"></asp:RequiredFieldValidator></TD>
                            </TR>
                            <TR>
                                <TD></TD>
                                <TD colSpan="2">
                                        <asp:Button id="SendButton" runat="server" Text="Send" />
                                </TD>
                                <TD></TD>
                            </TR>
                        </TABLE>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
