<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Web.Login" Codebehind="Login.aspx.cs" %>
<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <asp:Label id="lblResult" runat="server" EnableViewState="false" />
    <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" />
</asp:Content>
