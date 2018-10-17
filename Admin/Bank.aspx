<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Bank.aspx.cs" Inherits="Admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="my-table" width="500px">
        <tr>
            <td class="my-table-td">ID</td>
            <td class="my-table-td">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="my-textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="PL User Id" ControlToValidate="TextBox1" 
                ValidationGroup="aa">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="my-table-td">Amount</td>
            <td class="my-table-td">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="my-textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="PL Amount" ControlToValidate="TextBox2" 
                ValidationGroup="aa">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator 
                ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" 
                ErrorMessage="PL enter Only Numbric Value" ValidationExpression="^\d+$" 
                ValidationGroup="aa">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="my-table-td">Cheque</td>
            <td class="my-table-td"><asp:TextBox ID="TextBox3" runat="server" CssClass="my-textbox"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" align="center"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
        <td colspan="2" align="center">
            <asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click" ValidationGroup="aa" CssClass="my-button" />
            <br />
            <a href="payout1.aspx"> Click Here for Cheque Detail</a>
        </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="GridView1" runat="server" Width="1000px" DataKeyNames="ID" CssClass="my-grid"
        EnableModelValidation="True" onrowupdating="GridView1_RowUpdating">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update">Click</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <SelectedRowStyle BackColor="#6699FF" BorderColor="#FF33CC" 
            BorderStyle="Dotted" BorderWidth="1px" ForeColor="#33CC33" />
    </asp:GridView>
</asp:Content>

