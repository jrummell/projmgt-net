<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Web.AllUsers.Msg.Messages" Codebehind="Default.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>Messaging</h3>
    <p>
        <b>Inbox</b> | 
        <a href="default.aspx">Refresh</a> |
        <a href="newMessage.aspx">Compose message</a>
    </p>
    <asp:DataGrid ID="MessagesDataGrid" runat="server" AutoGenerateColumns="false"
        PagerStyle-Mode="NumericPages" AllowPaging="True">
        <Columns>
            <asp:BoundColumn
                HeaderText="ID"
                DataField="messageID"
                Visible="false" />
            <asp:BoundColumn 
                HeaderText="From" 
                DataField="senderName" />
            <asp:HyperLinkColumn 
                HeaderText="Subject" 
                DataNavigateUrlField="messageID" 
                DataNavigateUrlFormatString="viewMessage.aspx?id={0}"
                DataTextField="subject" />
            <asp:BoundColumn 
                HeaderText="Date" 
                DataField="date" />
            <asp:ButtonColumn 
                HeaderText="Delete" 
                Text="Delete" 
                ButtonType="LinkButton" 
                CommandName="Delete" />
        </Columns>
    </asp:DataGrid>
</asp:Content>
