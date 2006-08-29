<%@ Page language="c#" AutoEventWireup="false" %>
<%@ Import Namespace="PMT" %>
<%@ Register TagPrefix="pmt" TagName="StyleControl" src="../Controls/StyleControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../Controls/PageNameControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../Controls/XmlNavBar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Project Management Tool</title>
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
					<td id="Main" valign="top"><pmt:PageNameControl PageTitle="[Page Title]" runat="server" id="PageNameControl1" /></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
