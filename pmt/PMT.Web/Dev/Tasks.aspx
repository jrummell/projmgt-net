<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Web.Dev.Tasks"
    CodeBehind="Tasks.aspx.cs" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>
        Tasks</h3>
    <asp:DataGrid ID="dgTasks" runat="server" AutoGenerateColumns="True">
        <Columns>
        </Columns>
    </asp:DataGrid>
    <asp:Button ID="btnUpdate" runat="server" Text="Update Status" OnClick="UpdateButton_Click" />
    <asp:Button ID="btnCommit" runat="server" Text="Commit Changes" Enabled="False" OnClick="CommitButton_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Enabled="False" OnClick="CancelButton_Click" />
</asp:Content>
