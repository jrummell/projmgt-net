<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ProfileControl.ascx.cs" Inherits="PMT.Controls.ProfileControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" border="0">
    <TR>
        <TD></TD>
        <TD colSpan="2">
            <asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD>
    </TR>
    <TR>
        <TD>First Name:</TD>
        <TD>
            <asp:TextBox id="FirstNameTextBox" runat="server"></asp:TextBox>
            <asp:Label id="FirstNameLabel" runat="server" Visible="False"></asp:Label></TD>
        <TD>
            <asp:RequiredFieldValidator id="FirstNameRequiredFieldValidator" runat="server" ControlToValidate="FirstNameTextBox"
                Display="None" ErrorMessage="Please enter your first name."></asp:RequiredFieldValidator></TD>
    </TR>
    <TR>
        <TD>Last Name:</TD>
        <TD>
            <asp:TextBox id="LastNameTextBox" runat="server"></asp:TextBox>
            <asp:Label id="LastNameLabel" runat="server" Visible="False"></asp:Label></TD>
        <TD>
            <asp:RequiredFieldValidator id="LastNameRequiredFieldValidator" runat="server" ControlToValidate="LastNameTextBox"
                Display="None" ErrorMessage="Please enter your last name."></asp:RequiredFieldValidator></TD>
    </TR>
    <TR>
        <TD>
            <asp:Label id="UsernamePromptLabel" runat="server">Username:</asp:Label></TD>
        <TD>
            <asp:TextBox id="UsernameTextBox" runat="server"></asp:TextBox>
            <asp:Label id="UsernameLabel" runat="server" Visible="False"></asp:Label></TD>
        <TD>
            <asp:RequiredFieldValidator id="UsernameRequiredFieldValidator" runat="server" ControlToValidate="UserNameTextBox"
                Display="None" ErrorMessage="Please enter a username."></asp:RequiredFieldValidator></TD>
    </TR>
    <TR>
        <TD>
            <asp:CheckBox id="ChangePasswordCheckBox" runat="server" Text="Change Password" AutoPostBack="True"></asp:CheckBox></TD>
        <TD></TD>
        <TD></TD>
    </TR>
    <TR>
        <TD>
            <asp:Label id="OldPasswordLabel" runat="server">Old Password:</asp:Label></TD>
        <TD>
            <asp:TextBox id="OldPasswordTextBox" runat="server" TextMode="Password"></asp:TextBox></TD>
        <TD>
            <asp:RequiredFieldValidator id="OldPasswordRequiredFieldValidator" runat="server" ControlToValidate="OldPasswordTextBox"
                Display="None" ErrorMessage="Please verify your old password"></asp:RequiredFieldValidator></TD>
    </TR>
    <TR>
        <TD>
            <asp:Label id="NewPassword1Label" runat="server">New Password:</asp:Label></TD>
        <TD>
            <asp:TextBox id="NewPassword1TextBox" runat="server" TextMode="Password"></asp:TextBox></TD>
        <TD>
            <asp:RequiredFieldValidator id="Password1RequiredFieldValidator" runat="server" ControlToValidate="NewPassword1TextBox"
                Display="None" ErrorMessage="Please enter a password."></asp:RequiredFieldValidator></TD>
    </TR>
    <TR>
        <TD>
            <asp:Label id="NewPassword2Label" runat="server">Re-enter New Password:</asp:Label></TD>
        <TD>
            <asp:TextBox id="NewPassword2TextBox" runat="server" TextMode="Password"></asp:TextBox></TD>
        <TD>
            <asp:RequiredFieldValidator id="Password2RequiredFieldValidator" runat="server" ControlToValidate="NewPassword2TextBox"
                Display="None" ErrorMessage="Please re-enter your password."></asp:RequiredFieldValidator>
            <asp:CompareValidator id="PasswordCompareValidator" runat="server" ControlToValidate="NewPassword2TextBox"
                Display="None" ErrorMessage="Your passwords do not match." ControlToCompare="NewPassword1TextBox"></asp:CompareValidator></TD>
    </TR>
    <TR>
        <TD>Address:</TD>
        <TD>
            <asp:TextBox id="AddressTextBox" runat="server"></asp:TextBox>
            <asp:Label id="AddressLabel" runat="server" Visible="False"></asp:Label></TD>
        <TD>
            <asp:RequiredFieldValidator id="AddressRequiredFieldValidator" runat="server" ControlToValidate="AddressTextBox"
                Display="None" ErrorMessage="Please enter your address."></asp:RequiredFieldValidator></TD>
    </TR>
    <TR>
        <TD>City:</TD>
        <TD>
            <asp:TextBox id="CityTextBox" runat="server"></asp:TextBox>
            <asp:Label id="CityLabel" runat="server" Visible="False"></asp:Label></TD>
        <TD>
            <asp:RequiredFieldValidator id="CityRequiredFieldValidator" runat="server" ControlToValidate="CityTextBox" Display="None"
                ErrorMessage="Please enter your city."></asp:RequiredFieldValidator></TD>
    </TR>
    <TR>
        <TD>State:</TD>
        <TD>
            <asp:TextBox id="StateTextBox" runat="server"></asp:TextBox>
            <asp:Label id="StateLabel" runat="server" Visible="False"></asp:Label></TD>
        <TD>
            <asp:RequiredFieldValidator id="StateRequiredFieldValidator" runat="server" ControlToValidate="StateTextBox"
                Display="None" ErrorMessage="Please enter your state."></asp:RequiredFieldValidator></TD>
    </TR>
    <TR>
        <TD>Zip:</TD>
        <TD>
            <asp:TextBox id="ZipTextBox" runat="server"></asp:TextBox>
            <asp:Label id="ZipLabel" runat="server" Visible="False"></asp:Label></TD>
        <TD>
            <asp:RequiredFieldValidator id="ZipRequiredFieldValidator" runat="server" ControlToValidate="ZipTextBox" Display="None"
                ErrorMessage="Please enter your zip code."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="ZipRegularExpressionValidator" runat="server" ControlToValidate="ZipTextBox"
                Display="None" ErrorMessage="Please enter a valid zip code (ex. 12345 or 12345-1234)." ValidationExpression="\d{5}"></asp:RegularExpressionValidator></TD>
    </TR>
    <TR>
        <TD>Phone Number (123-456-7890):</TD>
        <TD>
            <asp:TextBox id="PhoneTextBox" runat="server"></asp:TextBox>
            <asp:Label id="PhoneLabel" runat="server" Visible="False"></asp:Label></TD>
        <TD>
            <asp:RequiredFieldValidator id="PhoneRequiredFieldValidator" runat="server" ControlToValidate="PhoneTextBox"
                Display="None" ErrorMessage="Please enter your phone number."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="PhoneRegularExpressionValidator" runat="server" ControlToValidate="PhoneTextBox"
                Display="None" ErrorMessage="Please enter a valid phone number." ValidationExpression="\d{3}-\d{3}-\d{4}"></asp:RegularExpressionValidator></TD>
    </TR>
    <TR>
        <TD>Email:</TD>
        <TD>
            <asp:TextBox id="EmailTextBox" runat="server"></asp:TextBox>
            <asp:Label id="EmailLabel" runat="server" Visible="False"></asp:Label></TD>
        <TD>
            <asp:RequiredFieldValidator id="EmailRequiredFieldValidator" runat="server" ControlToValidate="EmailTextBox"
                Display="None" ErrorMessage="Please enter your email address."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="EmailRegularExpressionValidator" runat="server" ControlToValidate="EmailTextBox"
                Display="None" ErrorMessage="Please enter a valid email address." ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></TD>
    </TR>
    <TR>
        <TD>
            <asp:Label id="SecurityPromptLabel" runat="server">Security:</asp:Label></TD>
        <TD>
            <asp:DropDownList id="SecurityDropDownList" runat="server">
                <asp:ListItem Value=" "></asp:ListItem>
                <asp:ListItem Value="Project Manager">Project Manager</asp:ListItem>
                <asp:ListItem Value="Developer">Developer</asp:ListItem>
                <asp:ListItem Value="Client">Client</asp:ListItem>
            </asp:DropDownList>
            <asp:Label id="SecurityLabel" runat="server" Visible="False"></asp:Label></TD>
        <TD>
            <asp:RequiredFieldValidator id="SecurityRequiredFieldValidator" runat="server" ControlToValidate="SecurityDropDownList"
                Display="None" ErrorMessage="Please select a security level from the list."></asp:RequiredFieldValidator></TD>
    </TR>
</TABLE>
