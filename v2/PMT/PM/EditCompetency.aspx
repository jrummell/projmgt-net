<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.PM.EditCompetency"
    CodeFile="EditCompetency.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>Developer Competency</h3>
    <p>
        Developer ID:
        <asp:DropDownList ID="DeveloperDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DeveloperDropDownList_SelectedIndexChanged" /></p>
    <asp:Panel ID="DeveloperPanel" runat="server" Visible="False">
        <p>
            First Name:
            <asp:Label ID="devFirstLabel" runat="server" /></p>
        <p>
            Last Name:
            <asp:Label ID="devLastLabel" runat="server"/></p>
        <p>
            Competence:
            <asp:DropDownList ID="CompetenceDropDownList" runat="server"/></p>
        <p>
            <asp:Button ID="SaveButton" runat="server" Visible="False" Text="Save" OnClick="Button_Click"/>
            <asp:Button ID="CancelButton" runat="server" Visible="False" Text="Cancel" OnClick="Button_Click"/>
        </p>
    </asp:Panel>
</asp:Content>
