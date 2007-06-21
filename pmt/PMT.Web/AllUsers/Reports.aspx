<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Web.AllUsers.Reports" Codebehind="Reports.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>
        Reports</h3>
    <table id="Table1" cellspacing="1" cellpadding="1" border="0">
        <tr>
            <td>
                Project:</td>
            <td>
                <asp:DropDownList ID="ProjectDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ProjectDropDownList_SelectedIndexChanged" /></td>
            <td>
                <asp:Button ID="ViewProjectButton" runat="server" Text="View Report" Enabled="False"
                    OnClick="ViewReportButton_Click" /></td>
        </tr>
        <tr>
            <td>
                Module:</td>
            <td>
                <asp:DropDownList ID="ModuleDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ModuleDropDownList_SelectedIndexChanged" /></td>
            <td>
                <asp:Button ID="ViewModuleButton" runat="server" Text="View Report" Enabled="False"
                    OnClick="ViewReportButton_Click" /></td>
        </tr>
        <tr>
            <td>
                Task:</td>
            <td>
                <asp:DropDownList ID="TaskDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="TaskDropDownList_SelectedIndexChanged" /></td>
            <td>
                <asp:Button ID="ViewTaskButton" runat="server" Text="View Report" Enabled="False"
                    OnClick="ViewReportButton_Click" /></td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="ReportPanel" runat="server" Visible="False">
        <blockquote>
            <pmt:Report ID="report" runat="server" />
        </blockquote>
    </asp:Panel>
</asp:Content>
