<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Web.PM.Matrix" Codebehind="Matrix.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>Competency/Complexity Matrix</h3>
    <asp:DataGrid ID="dgCompMatrix" runat="server" AutoGenerateColumns="False" OnItemDataBound="dgCompMatrix_ItemDataBound">
        <Columns>
            <asp:BoundColumn DataField="compLevel" ItemStyle-CssClass="dgHeader"></asp:BoundColumn>
            <asp:BoundColumn DataField="lowComplexity" HeaderText="Low Difficulty"></asp:BoundColumn>
            <asp:BoundColumn DataField="medComplexity" HeaderText="Medium Difficulty"></asp:BoundColumn>
            <asp:BoundColumn DataField="highComplexity" HeaderText="High Difficulty"></asp:BoundColumn>
        </Columns>
    </asp:DataGrid>
</asp:Content>
