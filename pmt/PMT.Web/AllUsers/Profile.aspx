<%@ Page Language="c#" Inherits="PMT.Web.AllUsers.Profile" MasterPageFile="~/Master/Default.master"
    CodeBehind="Profile.aspx.cs" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <p>
        <asp:Label ID="StatusLabel" runat="server" EnableViewState="false" /></p>
    <pmt:Profile ID="ProfileControl1" runat="server" AllowChangeUsername="false" AllowChangePassword="true"
        AllowChangeSecurity="false" />
    <p>
        <asp:Button ID="SubmitButton" runat="server" Text="Update" OnClick="SubmitButton_Click" /></p>
</asp:Content>
