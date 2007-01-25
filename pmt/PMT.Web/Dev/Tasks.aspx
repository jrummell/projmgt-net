<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.Dev.Tasks" Codebehind="Tasks.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>Tasks</h3>
    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundColumn Visible="False" DataField="taskID" ReadOnly="True" HeaderText="TaskID">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="name" ReadOnly="True" HeaderText="Name"></asp:BoundColumn>
            <asp:BoundColumn DataField="moduleName" HeaderText="Module"></asp:BoundColumn>
            <asp:BoundColumn DataField="projectName" HeaderText="Project"></asp:BoundColumn>
            <asp:BoundColumn DataField="dateAss" ReadOnly="True" HeaderText="Date Assigned"></asp:BoundColumn>
            <asp:BoundColumn DataField="actEndDate" ReadOnly="True" HeaderText="Date Completed">
            </asp:BoundColumn>
            <asp:TemplateColumn Visible="False" HeaderText="Completed?">
                <ItemTemplate>
                    <asp:CheckBox ID="completeCheckBox" runat="server" />
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="complete" ReadOnly="True" HeaderText="Status"></asp:BoundColumn>
        </Columns>
    </asp:DataGrid><asp:Button ID="UpdateButton" runat="server" Text="Update Status"
        OnClick="UpdateButton_Click"></asp:Button>&nbsp;<asp:Button ID="CommitButton" runat="server"
            Text="Commit Changes" Enabled="False" OnClick="CommitButton_Click"></asp:Button>
    <asp:Button ID="CancelButton" runat="server" Text="Cancel" Enabled="False" OnClick="CancelButton_Click">
    </asp:Button>
</asp:Content>
