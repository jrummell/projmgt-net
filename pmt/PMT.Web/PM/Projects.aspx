<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.PM.Projects" Codebehind="Projects.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>
        Projects</h3>
    <asp:Label ID="lblResult" EnableViewState="false" runat="server" />
    <asp:Panel ID="projectPanel" runat="server">
        <h4>
            <asp:Label ID="ItemLabel" runat="server"></asp:Label></h4>
        <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundColumn DataField="ID" ReadOnly="True" HeaderText="ID" />
                <asp:HyperLinkColumn HeaderText="Name" DataTextField="name" />
                <asp:BoundColumn DataField="description" HeaderText="Description" />
                <asp:BoundColumn DataField="startDate" HeaderText="Start Date" />
                <asp:BoundColumn DataField="expEndDate" ReadOnly="True" HeaderText="Exp End Date" />
                <asp:BoundColumn DataField="actEndDate" ReadOnly="True" HeaderText="Act End Date" />
                <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" HeaderText=""
                    CancelText="Cancel" EditText="Edit" />
                <asp:ButtonColumn Text="Delete" ButtonType="PushButton" CommandName="Delete" />
            </Columns>
        </asp:DataGrid>
        <asp:HyperLink ID="AddItemHyperLink" runat="server" NavigateUrl="NewItem.aspx?item=Module&amp;parentID=" />
    </asp:Panel>
</asp:Content>
