<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="DD.aspx.cs" Inherits="Admin_DD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    ADD DD
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <table style="width:900px;" class="my-table" id="pin-gen" align="center">
	<tr>
		<td style="height:10px" colspan="7">
		</td>
	</tr>
        <tr>
            <td style="text-align:center;">Name : </td>
            <td style="text-align:center;">
              <asp:TextBox ID="txtname" runat="server" CssClass="my-textbox"></asp:TextBox>
            </td>
		<td style="text-align:center;">Password :	</td>
        <td style="text-align:center;"><asp:TextBox ID="txtpass" runat="server" CssClass="my-textbox"></asp:TextBox></td>
	
		 <td style="text-align:center;">
            <asp:Button ID="buttonClick" runat="server" OnClick="buttonClick_Click" Width="200%" Text="Send" CssClass="lb-buttion" ></asp:Button>
         </td>

    </tr>
        <tr>
            <td colspan="7" style="text-align:center;"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
        </tr>
     <tr>
       
    </tr>
</table>
    <br />
<table style="width:900px;" class="my-table" id="pin-gen" align="center" >
	<tr>
		<td style="text-align:center;">    
    <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="my-grid" OnRowUpdating="GridView1_RowUpdating" EnableModelValidation="true">
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

