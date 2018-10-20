<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="products.aspx.cs" Inherits="Admin_products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    Add Products
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
		<td style="text-align:center;">DP :	</td>
        <td style="text-align:center;"><asp:TextBox ID="txtdp" runat="server" CssClass="my-textbox"></asp:TextBox></td>
		<td style="text-align:center;">PV : </td>
        <td style="text-align:center;"><asp:TextBox ID="txtpv" runat="server" CssClass="my-textbox"></asp:TextBox></td>
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
    <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="my-grid">
    </asp:GridView>
    </td>
    </tr>
    </table>

</asp:Content>

