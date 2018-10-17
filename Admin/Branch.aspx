<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Branch.aspx.cs" Inherits="Admin_Branch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Add Branch
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 900px;" class="my-table" id="pin-gen" align="center">
        <tr>
            <td style="height: 10px" colspan="7"></td>
        </tr>

        <tr>
            <td style="text-align: center;">DD Name : </td>
            <td style="text-align: center;">
                <asp:DropDownList ID="DropDownList1" CssClass="my-textbox" runat="server" Width="100px">

                </asp:DropDownList>
            </td>
            <td style="text-align: center;">Branch Name : </td>
            <td style="text-align: center;">
                <asp:TextBox ID="txtname" runat="server" CssClass="my-textbox"></asp:TextBox>
            </td>
            <td style="text-align: center;">Password :	</td>
            <td style="text-align: center;">
                <asp:TextBox ID="txtpass" runat="server" CssClass="my-textbox"></asp:TextBox></td>

            <td style="text-align: center;">
                <asp:Button ID="buttonClick" runat="server" OnClick="buttonClick_Click" Width="200%" Text="Send" CssClass="lb-buttion"></asp:Button>
            </td>

        </tr>
        <tr>
            <td colspan="7" style="text-align: center;">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
        </tr>
        </table>
    <br />
    <table style="width: 900px;" class="my-table" id="pin-gen" align="center">
        <tr>
            <td style="text-align: center;">
                <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="my-grid" onrowupdating="GridView1_RowUpdating" EnableModelValidation="True">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update">Click</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

