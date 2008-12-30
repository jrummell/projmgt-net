<%@ Page Language="c#" Inherits="PMT.Web.Register" MasterPageFile="~/Master/Default.master"
    CodeBehind="Register.aspx.cs" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <asp:Panel ID="RegisterPanel" runat="server">
        <pmt:Profile ID="ProfileControl1" runat="server" AllowChangePassword="false" AllowNewPassword="true"
            AllowChangeSecurity="true" AllowChangeUsername="true" />
        <asp:CustomValidator ID="cvUsernameExists" runat="server" ErrorMessage="Username Not Available."
            OnServerValidate="cvUsernameExists_ServerValidate" Text="" />
        <br />
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    </asp:Panel>
    <asp:Panel ID="StatusPanel" runat="server" EnableViewState="false">
        <asp:Label ID="StatusLabel" runat="server" />
    </asp:Panel>
</asp:Content>
