<%@ Page Language="C#" MasterPageFile="~/Master/Default.master" AutoEventWireup="true" Inherits="PMT.PM.ChooseDevelopers" Codebehind="ChooseDevelopers.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phMain" Runat="Server">
    <h3>Choose Developers</h3>
    <asp:Label ID="lblResult" ForeColor="red" runat="server" EnableViewState="false" />
    <asp:ObjectDataSource ID="dsDevelopers" runat="server" SelectMethod="GetDevelopers" />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataSourceID="dsDevelopers" AllowPaging="True" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField
                HeaderText="ID"
                DataField="ID"
                SortExpression="ID" />
            <asp:HyperLinkField 
                HeaderText="Username"
                DataTextField="UserName"
                DataNavigateUrlFields="ID"
                DataNavigateUrlFormatString="ViewDevProfile.aspx?devID={0}"
                SortExpression="Username" />
            <asp:BoundField
                HeaderText="Last Name" 
                DataField="LastName" 
                SortExpression="LastName" />
            <asp:BoundField 
                HeaderText="First Name" 
                DataField="FirstName"
                SortExpression="FirstName" />
            <asp:BoundField
                HeaderText="Competence"
                DataField="Competence"
                SortExpression="Competence" />
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="cbSelected" AutoPostBack="true" OnCheckedChanged="cbSelected_CheckedChanged" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>

