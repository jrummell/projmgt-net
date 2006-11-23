<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Admin.Settings"
    CodeFile="Settings.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>Configuration Settings</h3>
    <p>Warning: Any changes made on this page will restart the ASP .Net Application.</p>
    <asp:ValidationSummary ID="vs" runat="server" />
    <h3>Database</h3>
    <table>
        <tr>
            <td>Database Provider</td>
            <td>
                <asp:RadioButtonList ID="rblDbType" AutoPostBack="True" RepeatDirection="Horizontal"
                    runat="server" />
                <asp:RequiredFieldValidator ID="rfvDbType" ControlToValidate="rblDbType" Text="*"
                    ErrorMessage="Database Provider is required." Display="Dynamic" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Server</td>
            <td>
                <asp:TextBox ID="txtServer" runat="server" />
                <asp:RequiredFieldValidator ID="rfvServer" ControlToValidate="txtServer" Text="*"
                    ErrorMessage="Server is required." Display="Dynamic" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Database</td>
            <td>
                <asp:TextBox ID="txtDatabase" runat="server" />
                <asp:RequiredFieldValidator ID="rfvDatabase" ControlToValidate="txtDatabase" Text="*"
                    ErrorMessage="Database is required." Display="Dynamic" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">Trusted Connection
                <asp:CheckBox ID="cbTrusted" Enabled="False" AutoPostBack="True" runat="server" /></td>
        </tr>
        <tr>
            <td>Username</td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server" />
                <asp:RequiredFieldValidator Enabled="False" ID="rfvUsername" ControlToValidate="txtUsername"
                    Text="*" ErrorMessage="Username is required." Display="Dynamic" runat="server" />
            </td>
        </tr>
        <tr valign="top">
            <td>Password<br />Confirm Password</td>
            <td>
                <asp:TextBox ID="txtPassword1" TextMode="Password" runat="server" />
                <asp:RequiredFieldValidator Enabled="False" ID="rfvPassword1" ControlToValidate="txtPassword1"
                    Text="*" ErrorMessage="Password is required." Display="Dynamic" runat="server" /><br />
                <asp:TextBox ID="txtPassword2" TextMode="Password" runat="server" />
                <asp:RequiredFieldValidator Enabled="False" ID="rfvPassword2" ControlToValidate="txtPassword2"
                    Text="*" ErrorMessage="Password is required." Display="Dynamic" runat="server" />
                <asp:CompareValidator Enabled="False" ID="cvPassword" ControlToValidate="txtPassword1"
                    ControlToCompare="txtPassword2" Operator="Equal" ErrorMessage="Passwords do not match."
                    Display="Dynamic" Text="*" runat="server" />
            </td>
        </tr>
    </table>
    <asp:Button ID="btnUpdate" Text="Update" runat="server" />
</asp:Content>
