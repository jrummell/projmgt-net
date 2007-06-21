<%@ Page Language="C#" MasterPageFile="~/Master/Default.master" AutoEventWireup="true" Inherits="PMT.Web.PM.Developers" Codebehind="Developers.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phMain" Runat="Server">
    <h3>Your Developers</h3>
    <p><a href="ChooseDevelopers.aspx">Choose Developers</a></p>
    <asp:GridView ID="dvDevs" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" AllowSorting="True" DataSourceID="dsDevelopers" 
        OnRowDataBound="dvDevs_RowDataBound">
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
                SortExpression="LastName"/>
            <asp:BoundField 
                HeaderText="First Name" 
                DataField="FirstName"
                SortExpression="FirstName" />
            <asp:BoundField
                HeaderText="Competence"
                DataField="Competence"
                SortExpression="Competence" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="dsDevelopers" runat="server" />
</asp:Content>

