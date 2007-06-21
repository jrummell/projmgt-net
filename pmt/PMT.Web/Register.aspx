<%@ Page Language="c#" Inherits="PMT.Web.Register" MasterPageFile="~/Master/Default.master" Codebehind="Register.aspx.cs" %>

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
