<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ReturnPin.aspx.cs" Inherits="Client_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table align="center" class="my-table" id="pin-gen" width="900px">
 <tr>
		<td height="10px" colspan="7">
		</td>
	</tr>
    <tr>
        <td class="my-table-header" colspan="7"  align="center" style="font-size:20px">
          Return Pins    
        </td>
    </tr>
	<tr>
		<td height="10px" colspan="7">
		</td>
	</tr>
        <tr>
            <td align="center">Pin Type</td>
            <td align="center">
                <asp:DropDownList ID="DropDownList1" CssClass="my-textbox" runat="server" Width="100px">
                    <asp:ListItem Selected="True" Value="1000">1000</asp:ListItem>
                    <asp:ListItem Value="2500">2500</asp:ListItem>
                </asp:DropDownList>
            </td>
		<td align="center">User Id :</td>
        <td align="center"><asp:TextBox ID="txtUserId" runat="server" CssClass="my-textbox"></asp:TextBox></td>
		<td align="center">No Of Pins : </td>
        <td align="center"><asp:TextBox ID="txtpins" runat="server" CssClass="my-textbox"></asp:TextBox></td>
		 <td align="center">
            <asp:Button ID="buttonClick" runat="server" OnClick="buttonClick_Click" Width="200%" Text="Send" CssClass="lb-buttion" ></asp:Button>
         </td>

    </tr>
        <tr>
            <td colspan="7" align="center"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
        </tr>
     <tr>
       
    </tr>
</table>
    <br />
<table align="center" class="my-table" id="pin-gen" width="900px">
	<tr>
		<td align="center">    
    <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="my-grid">
    </asp:GridView>
    </td>
    </tr>
    </table>
</asp:Content>

