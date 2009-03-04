<%@ Page Language="C#" MasterPageFile="~/Master/Default.master" AutoEventWireup="false"
    Inherits="PMT.Web.PM.Developers" CodeBehind="Developers.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phMain" runat="Server">
    <h3>
        Your Developers</h3>
    <p>
        <a href="ChooseDevelopers.aspx">Choose Developers</a></p>
    <asp:GridView ID="dvDevs" runat="server" AutoGenerateColumns="False" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" SortExpression="ID" />
            <asp:HyperLinkField HeaderText="Username" DataTextField="UserName" DataNavigateUrlFields="ID"
                DataNavigateUrlFormatString="ViewDevProfile.aspx?devID={0}" SortExpression="Username" />
            <asp:BoundField HeaderText="Last Name" DataField="LastName" SortExpression="LastName" />
            <asp:BoundField HeaderText="First Name" DataField="FirstName" SortExpression="FirstName" />
        </Columns>
    </asp:GridView>
</asp:Content>
