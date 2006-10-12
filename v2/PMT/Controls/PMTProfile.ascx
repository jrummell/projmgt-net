<%@ Control Language="c#" Inherits="PMT.Controls.PMTProfile" CodeFile="PMTProfile.ascx.cs" %>
<table id="Table1" cellspacing="1" cellpadding="1" border="0">
    <tr>
        <td>
        </td>
        <td colspan="2">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server"></asp:ValidationSummary>
        </td>
    </tr>
    <tr>
        <td>
            First Name:</td>
        <td>
            <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="FirstNameLabel" runat="server" Visible="False"></asp:Label></td>
        <td>
            <asp:RequiredFieldValidator ID="FirstNameRequiredFieldValidator" runat="server" ControlToValidate="FirstNameTextBox"
                Display="None" ErrorMessage="Please enter your first name."></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
            Last Name:</td>
        <td>
            <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="LastNameLabel" runat="server" Visible="False"></asp:Label></td>
        <td>
            <asp:RequiredFieldValidator ID="LastNameRequiredFieldValidator" runat="server" ControlToValidate="LastNameTextBox"
                Display="None" ErrorMessage="Please enter your last name."></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="UsernamePromptLabel" runat="server">Username:</asp:Label></td>
        <td>
            <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="UsernameLabel" runat="server" Visible="False"></asp:Label></td>
        <td>
            <asp:RequiredFieldValidator ID="UsernameRequiredFieldValidator" runat="server" ControlToValidate="UserNameTextBox"
                Display="None" ErrorMessage="Please enter a username."></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
            <asp:CheckBox ID="ChangePasswordCheckBox" runat="server" Text="Change Password" AutoPostBack="True"
                OnCheckedChanged="ChangePasswordCheckBox_CheckedChanged"></asp:CheckBox></td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="OldPasswordLabel" runat="server">Old Password:</asp:Label></td>
        <td>
            <asp:TextBox ID="OldPasswordTextBox" runat="server" TextMode="Password"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="OldPasswordRequiredFieldValidator" runat="server"
                ControlToValidate="OldPasswordTextBox" Display="None" ErrorMessage="Please verify your old password"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="NewPassword1Label" runat="server">New Password:</asp:Label></td>
        <td>
            <asp:TextBox ID="NewPassword1TextBox" runat="server" TextMode="Password"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="Password1RequiredFieldValidator" runat="server" ControlToValidate="NewPassword1TextBox"
                Display="None" ErrorMessage="Please enter a password."></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="NewPassword2Label" runat="server">Re-enter New Password:</asp:Label></td>
        <td>
            <asp:TextBox ID="NewPassword2TextBox" runat="server" TextMode="Password"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="Password2RequiredFieldValidator" runat="server" ControlToValidate="NewPassword2TextBox"
                Display="None" ErrorMessage="Please re-enter your password."></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="PasswordCompareValidator" runat="server" ControlToValidate="NewPassword2TextBox"
                Display="None" ErrorMessage="Your passwords do not match." ControlToCompare="NewPassword1TextBox"></asp:CompareValidator></td>
    </tr>
    <tr>
        <td>
            Address:</td>
        <td>
            <asp:TextBox ID="AddressTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="AddressLabel" runat="server" Visible="False"></asp:Label></td>
        <td>
            <asp:RequiredFieldValidator ID="AddressRequiredFieldValidator" runat="server" ControlToValidate="AddressTextBox"
                Display="None" ErrorMessage="Please enter your address."></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
            City:</td>
        <td>
            <asp:TextBox ID="CityTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="CityLabel" runat="server" Visible="False"></asp:Label></td>
        <td>
            <asp:RequiredFieldValidator ID="CityRequiredFieldValidator" runat="server" ControlToValidate="CityTextBox"
                Display="None" ErrorMessage="Please enter your city."></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
            State:</td>
        <td>
            <asp:TextBox ID="StateTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="StateLabel" runat="server" Visible="False"></asp:Label></td>
        <td>
            <asp:RequiredFieldValidator ID="StateRequiredFieldValidator" runat="server" ControlToValidate="StateTextBox"
                Display="None" ErrorMessage="Please enter your state."></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
            Zip:</td>
        <td>
            <asp:TextBox ID="ZipTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="ZipLabel" runat="server" Visible="False"></asp:Label></td>
        <td>
            <asp:RequiredFieldValidator ID="ZipRequiredFieldValidator" runat="server" ControlToValidate="ZipTextBox"
                Display="None" ErrorMessage="Please enter your zip code."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="ZipRegularExpressionValidator" runat="server"
                ControlToValidate="ZipTextBox" Display="None" ErrorMessage="Please enter a valid zip code (ex. 12345 or 12345-1234)."
                ValidationExpression="\d{5}"></asp:RegularExpressionValidator></td>
    </tr>
    <tr>
        <td>
            Phone Number (123-456-7890):</td>
        <td>
            <asp:TextBox ID="PhoneTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="PhoneLabel" runat="server" Visible="False"></asp:Label></td>
        <td>
            <asp:RequiredFieldValidator ID="PhoneRequiredFieldValidator" runat="server" ControlToValidate="PhoneTextBox"
                Display="None" ErrorMessage="Please enter your phone number."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="PhoneRegularExpressionValidator" runat="server"
                ControlToValidate="PhoneTextBox" Display="None" ErrorMessage="Please enter a valid phone number."
                ValidationExpression="\d{3}-\d{3}-\d{4}"></asp:RegularExpressionValidator></td>
    </tr>
    <tr>
        <td>
            Email:</td>
        <td>
            <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="EmailLabel" runat="server" Visible="False"></asp:Label></td>
        <td>
            <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ControlToValidate="EmailTextBox"
                Display="None" ErrorMessage="Please enter your email address."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" runat="server"
                ControlToValidate="EmailTextBox" Display="None" ErrorMessage="Please enter a valid email address."
                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="SecurityPromptLabel" runat="server">Security:</asp:Label></td>
        <td>
            <asp:DropDownList ID="SecurityDropDownList" runat="server" />
            <asp:Label ID="SecurityLabel" runat="server" Visible="False"></asp:Label></td>
        <td>
            <asp:RequiredFieldValidator ID="SecurityRequiredFieldValidator" runat="server" ControlToValidate="SecurityDropDownList"
                Display="None" ErrorMessage="Please select a security level from the list."></asp:RequiredFieldValidator></td>
    </tr>
</table>
