<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Admin.ChangeUser"
    CodeFile="ChangeUser.aspx.cs" %>
<%@ Register TagPrefix="pmt" TagName="Profile" Src="~/Controls/PMTProfile.ascx" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>Edit User</h3>
    <pmt:Profile id="ProfileControl1" runat="server" />
    <p>
        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
        <asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" /></p>
</asp:Content>