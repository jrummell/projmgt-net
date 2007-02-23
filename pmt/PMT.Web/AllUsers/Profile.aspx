<%@ Page Language="c#" Inherits="PMT.AllUsers.UserProfile" MasterPageFile="~/Master/Default.master" Codebehind="Profile.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <p><asp:Label ID="StatusLabel" runat="server" EnableViewState="false" /></p>
    <pmt:Profile id="ProfileControl1" runat="server" />
    <p><asp:Button ID="SubmitButton" runat="server" Text="Update" OnClick="SubmitButton_Click" /></p>
</asp:Content>
