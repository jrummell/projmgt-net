<%@ Register TagPrefix="pmt" TagName="NavControl" src="Controls/XmlNavBar.ascx" %><%@ Register TagPrefix="pmt" TagName="StyleControl" src="Controls/StyleControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="Controls/PageNameControl.ascx" %>
<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="PMT.Login" %>
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
						<P><pmt:PageNameControl PageTitle="Login" runat="server" id="PageNameControl1" /></P>
						<P>
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" border="0">
								<TR>
									<td></td>
									<TD colSpan="2">
										<asp:Label id="ErrorLabel" runat="server" ForeColor="Red"></asp:Label></TD>
								</TR>
								<TR>
									<TD>Username:</TD>
									<TD>
										<asp:TextBox id="UserTextBox" runat="server"></asp:TextBox></TD>
									<TD>
										<asp:RequiredFieldValidator id="UserRequiredFieldValidator" runat="server" ErrorMessage="Please enter your username."
											ControlToValidate="UserTextBox" Display="Dynamic"></asp:RequiredFieldValidator></TD>
								</TR>
								<TR>
									<TD>Password:</TD>
									<TD>
										<asp:TextBox id="PasswordTextBox" TextMode="Password" runat="server"></asp:TextBox></TD>
									<TD>
										<asp:RequiredFieldValidator id="PasswordRequiredFieldValidator" runat="server" ErrorMessage="Please enter your password."
											ControlToValidate="PasswordTextBox" Display="Dynamic"></asp:RequiredFieldValidator></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD>
										<asp:Button id="SubmitButton" runat="server" Text="Login"></asp:Button></TD>
									<TD></TD>
								</TR>
							</TABLE>
						</P>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
