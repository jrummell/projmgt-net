<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.AllUsers.Msg.viewMessage"
    CodeFile="viewMessage.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>Messaging</h3>
    <p>
        <a href="default.aspx">Return to Inbox</a> | <a href="newMessage.aspx?action=reply&amp;id=<%= MessageID %>">
            Reply</a> | <a href="newMessage.aspx?action=forward&amp;id=<%= MessageID %>">Forward</a></p>
    <h4>View Message</h4>
    <table>
        <tr>
            <td>
                Subject:</td>
            <td>
                <asp:Label ID="subjectLabel" runat="server" ForeColor="Black" /></td>
        </tr>
        <tr>
            <td>
                From:</td>
            <td>
                <asp:Label ID="senderLabel" runat="server" /></td>
        </tr>
        <tr>
            <td>
                To:</td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Date:</td>
            <td>
                <asp:Label ID="dateLabel" runat="server" /></td>
        </tr>
        <tr>
            <td valign="top">
                Message:</td>
            <td class="Message">
                <asp:Label ID="lblMessage" runat="server" /></td>
        </tr>
    </table>
</asp:Content>
