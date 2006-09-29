<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Login"
    CodeFile="Login.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phMain" runat="Server">
    <table id="Table1" cellspacing="1" cellpadding="1" border="0">
        <tr>
            <td>
            </td>
            <td colspan="2">
                <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td>
                Username:</td>
            <td>
                <asp:TextBox ID="UserTextBox" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="UserRequiredFieldValidator" runat="server" ErrorMessage="Please enter your username."
                    ControlToValidate="UserTextBox" Display="Dynamic"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                Password:</td>
            <td>
                <asp:TextBox ID="PasswordTextBox" TextMode="Password" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ErrorMessage="Please enter your password."
                    ControlToValidate="PasswordTextBox" Display="Dynamic"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="SubmitButton" runat="server" Text="Login" OnClick="SubmitButton_Click">
                </asp:Button></td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
