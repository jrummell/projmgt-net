<%@ Page Language="c#" Inherits="PMT.Register" MasterPageFile="~/Master/Default.master"
    CodeFile="Register.aspx.cs" %>
<%@ Register TagPrefix="pmt" TagName="Profile" Src="~/Controls/PMTProfile.ascx" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <asp:Panel ID="RegisterPanel" runat="server">
        <pmt:Profile id="ProfileControl1" runat="server" />
        <br/>
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    </asp:Panel>
    <asp:Panel ID="StatusPanel" runat="server" Visible="False">
        <asp:Label ID="StatusLabel" EnableViewState="false" runat="server" ForeColor="Red" />
    </asp:Panel>
</asp:Content>
