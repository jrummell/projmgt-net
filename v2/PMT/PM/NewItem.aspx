<%@ Register TagPrefix="pmt" TagName="PageNameControl" src="../Controls/PageNameControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="HeaderControl" src="../Controls/HeaderControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="StyleControl" src="../Controls/StyleControl.ascx" %>
<%@ Register TagPrefix="pmt" TagName="NavControl" src="../Controls/XmlNavBar.ascx" %>
<%@ Page language="c#" Inherits="PMT.PM.NewItem" CodeFile="NewItem.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD runat="server">
        <title>Project Management Tool</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="C#" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <pmt:StyleControl runat="server" id="StyleControl1" />
    </HEAD>
    <body>
        <form id="Form1" method="post" runat="server">
            <table height="100%" width="100%">
                <tr>
                    <td id="Header" colSpan="2"><pmt:headercontrol id="HeaderControl1" runat="server" /></td>
                </tr>
                <tr>
                    <td id="Navigation" vAlign="top"><pmt:navcontrol id="NavControl1" runat="server"></pmt:navcontrol></td>
                    <td id="Main" vAlign="top">
                        <P><pmt:pagenamecontrol id="pageNameControl" runat="server" PageTitle="New Item"></pmt:pagenamecontrol></P>
                        <P><asp:panel id="ChooseItemPanel" runat="server" Visible="False">
                                <asp:HyperLink id="CreateProjectLink" runat="server" NavigateUrl="NewItem.aspx?item=Project">Project</asp:HyperLink>
                                <BR>
                                <asp:HyperLink id="CreateModuleLink" runat="server" NavigateUrl="NewItem.aspx?item=Module">Module</asp:HyperLink>
                                <BR>
                                <asp:HyperLink id="CreateTaskLink" runat="server" NavigateUrl="NewItem.aspx?item=Task">Task</asp:HyperLink>
                            </asp:panel>
                        <P></P>
                        <asp:panel id="CreateItemPanel" runat="server" Visible="False">
                            <TABLE id="Table1" cellSpacing="1" cellPadding="1" border="0">
                                <TR>
                                    <TD style="WIDTH: 125px">
                                        <asp:Label id="InProjectLabel" runat="server">In project:</asp:Label></TD>
                                    <TD>
                                        <asp:DropDownList id="ProjectDropDownList" runat="server" onselectedindexchanged="ProjectDropDownList_SelectedIndexChanged"></asp:DropDownList></TD>
                                    <TD>
                                        <asp:RequiredFieldValidator id="ProjectDropDownListRequiredFieldValidator" runat="server" ErrorMessage="Please select a project."
                                            Display="Dynamic" ControlToValidate="ProjectDropDownList"></asp:RequiredFieldValidator></TD>
                                </TR>
                                <TR>
                                    <TD style="WIDTH: 125px">
                                        <asp:Label id="InModuleLabel" runat="server">In module:</asp:Label></TD>
                                    <TD>
                                        <asp:DropDownList id="ModuleDropDownList" runat="server"></asp:DropDownList></TD>
                                    <TD>
                                        <asp:RequiredFieldValidator id="ModuleDropDownListRequiredFieldValidator" runat="server" ErrorMessage="Please select a module."
                                            Display="Dynamic" ControlToValidate="ModuleDropDownList"></asp:RequiredFieldValidator></TD>
                                </TR>
                                <TR>
                                    <TD style="WIDTH: 125px">Name:
                                    </TD>
                                    <TD>
                                        <P>
                                            <asp:textbox id="NameTextBox" runat="server"></asp:textbox></P>
                                    </TD>
                                    <TD>
                                        <asp:requiredfieldvalidator id="NameRequiredFieldValidator" runat="server" ErrorMessage="Please enter a name."
                                            Display="Dynamic" ControlToValidate="NameTextBox"></asp:requiredfieldvalidator></TD>
                                </TR>
                                <TR>
                                    <TD style="WIDTH: 125px">Start Date:</TD>
                                    <TD>
                                        <asp:textbox id="StartTextBox" runat="server"></asp:textbox>(mm/dd/yyyy)</TD>
                                    <TD>
                                        <asp:regularexpressionvalidator id="StartRegularExpressionValidator" runat="server" ErrorMessage="Please enter a valid date."
                                            Display="Dynamic" ControlToValidate="StartTextBox" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"></asp:regularexpressionvalidator>
                                        <asp:requiredfieldvalidator id="StartRequiredFieldValidator" runat="server" ErrorMessage="Please enter the start date."
                                            Display="Dynamic" ControlToValidate="StartTextBox"></asp:requiredfieldvalidator>
                                        <asp:CustomValidator id="StartDateCustomValidator" runat="server" ErrorMessage="Start date must be after the parent item's start date."
                                            Display="Dynamic"></asp:CustomValidator></TD>
                                </TR>
                                <TR>
                                    <TD style="WIDTH: 125px; HEIGHT: 46px">
                                        <asp:Label id="ComplexityLabel" runat="server">Complexity:</asp:Label></TD>
                                    <TD style="HEIGHT: 46px">
                                        <asp:DropDownList id="ComplexityDropDownList" runat="server"></asp:DropDownList></TD>
                                    <TD style="HEIGHT: 46px">
                                        <asp:RequiredFieldValidator id="ComplexityDropDownListRequiredFieldValidator" runat="server" ErrorMessage="Please Select a Complexity"
                                            ControlToValidate="ComplexityDropDownList"></asp:RequiredFieldValidator></TD>
                                </TR>
                                <TR>
                                    <TD style="WIDTH: 125px" vAlign="top">Description:</TD>
                                    <TD><TEXTAREA id="descriptionTextArea" rows="5" cols="30" runat="server"></TEXTAREA></TD>
                                    <TD>
                                        <asp:CustomValidator id="DescriptionCustomValidator" runat="server" ErrorMessage="Description must be less than 256 characters."
                                            Display="Dynamic" ControlToValidate="descriptionTextArea"></asp:CustomValidator></TD>
                                </TR>
                                <TR>
                                    <TD style="WIDTH: 125px"></TD>
                                    <TD>
                                        <asp:button id="SubmitButton" runat="server" Text="Submit" onclick="SubmitButton_Click"></asp:button></TD>
                                    <TD></TD>
                                </TR>
                            </TABLE>
                        </asp:panel><asp:panel id="creationSuccessPanel" runat="server" Visible="False">
                            <P>
                                <asp:Label id="statusLabel" runat="server"></asp:Label></P>
                            <P>
                                <asp:HyperLink id="AddItemToParentHyperLink" runat="server" NavigateUrl="NewItem.aspx">Add another </asp:HyperLink><BR>
                                <asp:HyperLink id="addAnotherItemLink" runat="server" NavigateUrl="NewItem.aspx"> Add an item to</asp:HyperLink></P>
                        </asp:panel></td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
