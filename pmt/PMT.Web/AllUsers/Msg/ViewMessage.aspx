<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Web.AllUsers.Msg.ViewMessage" Codebehind="ViewMessage.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>Messaging</h3>
    <p>
        <b>View Message</b> | 
        <a href="newMessage.aspx?action=reply&id=<%= MessageID %>">Reply</a> | 
        <a href="newMessage.aspx?action=forward&id=<%= MessageID %>">Forward</a> |
        <a href="default.aspx">Return to Inbox</a>
    </p>
    <table>
        <tr>
            <td>Subject:</td>
            <td><b><asp:Label ID="subjectLabel" runat="server" /></b></td>
        </tr>
        <tr>
            <td>From:</td>
            <td><asp:Label ID="senderLabel" runat="server" /></td>
        </tr>
        <tr>
            <td valign="top">To:</td>
            <td>
                <asp:DataList ID="dlRecipients" runat="server">
                    <ItemTemplate>
                        <%# Eval("LastName") %>, <%# Eval("FirstName") %> (<%# Eval("Username") %>)
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td>Sent:</td>
            <td><asp:Label ID="dateLabel" runat="server" /></td>
        </tr>
        <tr>
            <td valign="top">Message:</td>
            <td class="Message"><asp:Label ID="lblMessage" runat="server" /></td>
        </tr>
    </table>
</asp:Content>
