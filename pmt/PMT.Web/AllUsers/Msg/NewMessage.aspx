<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.AllUsers.Msg.NewMessage" Codebehind="NewMessage.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>Messaging</h3>
    <p>
        <b>Compose Message</b> | 
        <a href="Default.aspx">Return to Inbox</a>
    </p>
    <asp:Label ID="lblResult" runat="server" />
    <table id="Table1" cellspacing="1" cellpadding="1" border="0">
        <tr>
            <td>
            </td>
            <td colspan="2">
                <asp:ValidationSummary ID="ComposeValidationSummary" runat="server"></asp:ValidationSummary>
            </td>
        </tr>
        <tr>
            <td>
                To:</td>
            <td style="width:150px">
                <br/>
                <asp:ListBox ID="ToListBox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ToListBox_SelectedIndexChanged">
                </asp:ListBox></td>
            <td>
                Contacts:<br/>
                <asp:ListBox ID="ContactsListBox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ContactsListBox_SelectedIndexChanged">
                </asp:ListBox>
                <asp:CustomValidator ID="ToCustomValidator" runat="server" ErrorMessage="Please select a recipient."
                    Display="None"></asp:CustomValidator></td>
        </tr>
        <tr>
            <td>
                Subject:</td>
            <td colspan="2">
                <asp:TextBox ID="SubjectTextBox" runat="server" Width="100%"></asp:TextBox><br/>
                <asp:CheckBox ID="cbSaveCopy" Text="Save a copy in sent folder" runat="server" />
                <asp:RequiredFieldValidator ID="SubjectRequiredFieldValidator" runat="server" ErrorMessage="Please enter a subject."
                    Display="None" ControlToValidate="SubjectTextBox"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td valign="top">
                Message:</td>
            <td colspan="2">
                <textarea id="MessageTextBox" class="Message" cols="50" rows="18" runat="server"
                    name="MessageTextBox"></textarea><asp:RequiredFieldValidator ID="MessageRequiredFieldValidator" runat="server" ErrorMessage="Please enter a message."
                    Display="None" ControlToValidate="MessageTextBox"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2">
                <asp:Button ID="SendButton" runat="server" Text="Send" OnClick="SendButton_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
