<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Web.Admin.EditUser"
    CodeBehind="EditUser.aspx.cs" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>
        Edit User</h3>
    <pmt:Profile ID="ProfileControl1" runat="server" />
    <p>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="Submit_Click" />
        <input type="button" value="Cancel" onclick="window.location='Users.aspx';" /></p>
</asp:Content>
