<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.AllUsers.Msg.Messages"
    CodeFile="Default.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>Messaging</h3>
    <p>
        <a href="newMessage.aspx">Compose message</a> | <a href="default.aspx">Check for new messages</a>
    </p>
    <asp:Panel ID="MessagesPanel" runat="server">
        <h4>Inbox</h4>
        <asp:DataGrid ID="MessagesDataGrid" runat="server" AutoGenerateColumns="false"
            PagerStyle-Mode="NumericPages" AllowPaging="True">
            <Columns>
                <asp:BoundColumn HeaderText="From" DataField="senderName" />
                <asp:HyperLinkColumn HeaderText="Subject" DataNavigateUrlField="messageID" DataNavigateUrlFormatString="viewMessage.aspx?id={0}"
                    DataTextField="subject" />
                <asp:BoundColumn HeaderText="Date" DataField="date" />
                <asp:ButtonColumn HeaderText="Delete" Text="Delete" ButtonType="LinkButton" CommandName="Delete" />
            </Columns>
        </asp:DataGrid>
    </asp:Panel>
</asp:Content>
