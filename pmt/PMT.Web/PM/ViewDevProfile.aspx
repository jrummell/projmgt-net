<%@ Page language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.PM.ViewDevProfile" Codebehind="ViewDevProfile.aspx.cs" %>
<%@ Register TagPrefix="pmt" TagName="Profile" Src="~/Controls/PMTProfile.ascx" %>
<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>Developer Profile</h3>
    Back to <a href="Assign.aspx">Developer Assignments</a>
    <pmt:Profile id="ProfileControl1" runat="server" />
    <br />
    Competency: <asp:DropDownList ID="ddlComp" runat="server" />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlComp"
        Display="Dynamic" ErrorMessage="Competency is required." />
</asp:Content>
