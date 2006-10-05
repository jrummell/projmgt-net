<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.PM.Assign"
    CodeFile="Assign.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>Developer Assignments</h3>
    <asp:Panel ID="AvailableDevPanel" runat="server">
        <h4>Available Developers</h4>
        <%--<asp:Label ID="AvailDevLabel" runat="server">Available Developers</asp:Label>--%>
        Assignment Threshold: <asp:DropDownList ID="ddlTaskThreshold" AutoPostBack="True" runat="server" />
        <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" />
        <asp:DataGrid ID="dgAvailableDevs" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundColumn 
                    HeaderText="User ID" 
                    DataField="userID"
                    ReadOnly="true" />
                <asp:HyperLinkColumn 
                    HeaderText="Username/Profile"
                    DataTextField="userName"
                    DataNavigateUrlField="userID"
                    DataNavigateUrlFormatString="ViewDevProfile.aspx?devID={0}" />
                <asp:BoundColumn
                    HeaderText="Tasks Assigned" 
                    DataField="numTasks"
                    ReadOnly="true" />
                <asp:BoundColumn 
                    HeaderText="Competency" 
                    DataField="competence"
                    ReadOnly="true" />
                <asp:TemplateColumn
                    HeaderText="Tasks"
                    Visible="false">
                    <ItemTemplate></ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlTasks" runat="server" />
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:EditCommandColumn
                    HeaderText="Assign"
                    EditText="Assign Task ..."
                    CancelText="Cancel"
                    UpdateText="Assign" />
            </Columns>
        </asp:DataGrid>
    </asp:Panel>
    <asp:Panel ID="AssignmentsPanel" runat="server">
        <h4>Assignments</h4>
        <asp:DataGrid ID="dgAssignments" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundColumn DataField="username" HeaderText="Developer" />
                <asp:BoundColumn DataField="taskID" HeaderText="Task ID" />
                <asp:BoundColumn DataField="taskName" HeaderText="Task" />
                <asp:BoundColumn DataField="moduleName" HeaderText="Module" />
                <asp:BoundColumn DataField="projectName" HeaderText="Project" />
                <asp:BoundColumn DataField="taskStatus" HeaderText="Status" />
                <asp:BoundColumn DataField="assignDate" HeaderText="Assigned" />
                <asp:BoundColumn DataField="finishDate" HeaderText="Approved" />
                <asp:TemplateColumn Visible="False" HeaderText="Approve">
                    <ItemTemplate>
                        <asp:CheckBox ID="ApproveCheckBox" runat="server" />
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
        </asp:DataGrid>
        <asp:Button ID="UpdateButton" runat="server" Text="Update Status" />
        <asp:Button ID="CommitButton" runat="server" Text="Commit Changes" Enabled="False" />
        <asp:Button ID="CancelButton" runat="server" Text="Cancel" Enabled="False" />
    </asp:Panel>
</asp:Content>
