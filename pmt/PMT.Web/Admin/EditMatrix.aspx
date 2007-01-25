<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Admin.EditMatrix" Codebehind="EditMatrix.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phHead" runat="server">
<style type="text/css">
    tr.txtEdit input {width:5em;}
</style>
</asp:Content>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>Competency Matrix Editor</h3>
    <p><asp:Label ID="ResultLabel" runat="server" /></p>
    <asp:DataGrid ID="compMatrixGrid" runat="server" AutoGenerateColumns="False" 
        EditItemStyle-CssClass="txtEdit">
        <Columns>
            <asp:BoundColumn DataField="compLevel" ReadOnly="True" />
            <asp:BoundColumn DataField="lowComplexity" HeaderText="Low Difficulty" />
            <asp:BoundColumn DataField="medComplexity" HeaderText="Medium Difficulty" />
            <asp:BoundColumn DataField="highComplexity" HeaderText="High Difficulty" />
            <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" HeaderText="Change?"
                CancelText="Cancel" EditText="Edit" />
        </Columns>
    </asp:DataGrid>
</asp:Content>
