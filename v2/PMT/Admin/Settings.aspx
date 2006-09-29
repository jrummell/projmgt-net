<%@ Page language="c#" Inherits="PMT.Admin.Settings" CodeFile="Settings.aspx.cs" %>
<%@ Import Namespace="PMT" %>
<%@ Register TagPrefix="pmt" TagName="StyleControl" src="../Controls/StyleControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../Controls/PageNameControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../Controls/XmlNavBar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD runat="server">
		<title>Project Management .Net</title>
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
					    <pmt:PageNameControl PageTitle="Configuration Settings" runat="server" id="PageNameControl1" />
					    <p>Warning:  Any changes made on this page will restart the ASP .Net Application.</p>
					    <asp:ValidationSummary Runat="server" id=ValidationSummary1 />
					    <h3>Database</h3>
					    <table>
					        <tr>
					            <td>Database Provider</td>
					            <td>
					                <asp:RadioButtonList ID="rblDbType" AutoPostBack="True" RepeatDirection="Horizontal" Runat="server" />
					                <asp:RequiredFieldValidator ID="rfvDbType" ControlToValidate="rblDbType" Text="*" ErrorMessage="Database Provider is required." Display="Dynamic" Runat="server" />
					            </td>
					        </tr>
					        <tr>
					            <td>Server</td>
					            <td>
					                <asp:TextBox id="txtServer" Runat="server" />
					                <asp:RequiredFieldValidator ID="rfvServer" ControlToValidate="txtServer" Text="*" ErrorMessage="Server is required." Display="Dynamic" Runat="server" />
					            </td>
					        </tr>
					        <tr>
					            <td>Database</td>
					            <td>
					                <asp:TextBox id="txtDatabase" Runat="server" />
					                <asp:RequiredFieldValidator ID="rfvDatabase" ControlToValidate="txtDatabase" Text="*" ErrorMessage="Database is required." Display="Dynamic" Runat="server" />
					            </td>
					        </tr>
					        <tr>
					            <td colspan="2">Trusted Connection <asp:CheckBox ID="cbTrusted" Enabled="False" AutoPostBack="True" Runat="server" /></td>
					        </tr>
					        <tr>
					            <td>Username</td>
					            <td>
					                <asp:TextBox id="txtUsername" Runat="server" />
					                <asp:RequiredFieldValidator Enabled="False" ID="rfvUsername" ControlToValidate="txtUsername" Text="*" ErrorMessage="Username is required." Display="Dynamic" Runat="server" />
					            </td>
					        </tr>
					        <tr>
					            <td>Password</td>
					            <td>
					                <asp:TextBox id="txtPassword1" TextMode="Password" Runat="server" />
					                <asp:RequiredFieldValidator Enabled="False" ID="rfvPassword1" ControlToValidate="txtPassword1" Text="*" ErrorMessage="Password is required." Display="Dynamic" Runat="server" /><br>
					                <asp:TextBox id="txtPassword2" TextMode="Password" Runat="server" />
					                <asp:RequiredFieldValidator Enabled="False" ID="rfvPassword2" ControlToValidate="txtPassword2" Text="*" ErrorMessage="Password is required." Display="Dynamic" Runat="server" />
					                <asp:CompareValidator Enabled="False" ID="cvPassword" ControlToValidate="txtPassword1" ControlToCompare="txtPassword2" Operator="Equal" ErrorMessage="Passwords do not match." Display="Dynamic" Text="*" Runat="server" />
					            </td>
					        </tr>
					    </table>
					    <asp:Button ID="btnUpdate" Text="Update" Runat="server" />
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
