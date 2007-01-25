<%@ Page Language="c#" MasterPageFile="~/Master/Default.master" Inherits="PMT.PM.NewItem" Codebehind="NewItem.aspx.cs" %>

<asp:Content ContentPlaceHolderID="phMain" runat="server">
    <h3>New <asp:Label ID="lblItemType" runat="server" /></h3>
        <asp:Panel ID="ChooseItemPanel" runat="server" Visible="False">
            <asp:HyperLink ID="CreateProjectLink" runat="server" NavigateUrl="NewItem.aspx?item=Project">Project</asp:HyperLink>
            <br/>
            <asp:HyperLink ID="CreateModuleLink" runat="server" NavigateUrl="NewItem.aspx?item=Module">Module</asp:HyperLink>
            <br/>
            <asp:HyperLink ID="CreateTaskLink" runat="server" NavigateUrl="NewItem.aspx?item=Task">Task</asp:HyperLink>
        </asp:Panel>
        <asp:Panel ID="CreateItemPanel" runat="server" Visible="False">
            <table id="Table1" cellspacing="1" cellpadding="1" border="0">
                <tr>
                    <td style="width: 125px">
                        <asp:Label ID="InProjectLabel" runat="server">In project:</asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ProjectDropDownList" runat="server" OnSelectedIndexChanged="ProjectDropDownList_SelectedIndexChanged">
                        </asp:DropDownList></td>
                    <td>
                        <asp:RequiredFieldValidator ID="ProjectDropDownListRequiredFieldValidator" runat="server"
                            ErrorMessage="Please select a project." Display="Dynamic" ControlToValidate="ProjectDropDownList"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        <asp:Label ID="InModuleLabel" runat="server">In module:</asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ModuleDropDownList" runat="server">
                        </asp:DropDownList></td>
                    <td>
                        <asp:RequiredFieldValidator ID="ModuleDropDownListRequiredFieldValidator" runat="server"
                            ErrorMessage="Please select a module." Display="Dynamic" ControlToValidate="ModuleDropDownList"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        Name:
                    </td>
                    <td>
                        <p>
                            <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox></p>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="NameRequiredFieldValidator" runat="server" ErrorMessage="Please enter a name."
                            Display="Dynamic" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 125px">
                        Start Date:</td>
                    <td>
                        <asp:TextBox ID="StartTextBox" runat="server"></asp:TextBox>(mm/dd/yyyy)</td>
                    <td>
                        <asp:RegularExpressionValidator ID="StartRegularExpressionValidator" runat="server"
                            ErrorMessage="Please enter a valid date." Display="Dynamic" ControlToValidate="StartTextBox"
                            ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="StartRequiredFieldValidator" runat="server" ErrorMessage="Please enter the start date."
                            Display="Dynamic" ControlToValidate="StartTextBox"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="StartDateCustomValidator" runat="server" ErrorMessage="Start date must be after the parent item's start date."
                            Display="Dynamic"></asp:CustomValidator></td>
                </tr>
                <tr>
                    <td style="width: 125px; height: 46px">
                        <asp:Label ID="ComplexityLabel" runat="server">Complexity:</asp:Label></td>
                    <td style="height: 46px">
                        <asp:DropDownList ID="ComplexityDropDownList" runat="server">
                        </asp:DropDownList></td>
                    <td style="height: 46px">
                        <asp:RequiredFieldValidator ID="ComplexityDropDownListRequiredFieldValidator" runat="server"
                            ErrorMessage="Please Select a Complexity" ControlToValidate="ComplexityDropDownList"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 125px" valign="top">
                        Description:</td>
                    <td>
                        <textarea id="descriptionTextArea" rows="5" cols="30" runat="server"></textarea></td>
                    <td>
                        <asp:CustomValidator ID="DescriptionCustomValidator" runat="server" ErrorMessage="Description must be less than 256 characters."
                            Display="Dynamic" ControlToValidate="descriptionTextArea"></asp:CustomValidator></td>
                </tr>
                <tr>
                    <td style="width: 125px">
                    </td>
                    <td>
                        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click">
                        </asp:Button></td>
                    <td>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="creationSuccessPanel" runat="server" Visible="False">
            <p>
                <asp:Label ID="statusLabel" runat="server"></asp:Label></p>
            <p>
                <asp:HyperLink ID="AddItemToParentHyperLink" runat="server" NavigateUrl="NewItem.aspx">Add another </asp:HyperLink><br/>
                <asp:HyperLink ID="addAnotherItemLink" runat="server" NavigateUrl="NewItem.aspx"> Add an item to</asp:HyperLink></p>
        </asp:Panel>
</asp:Content>
