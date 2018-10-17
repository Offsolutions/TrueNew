<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Pins.aspx.cs" Inherits="Client_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpedding="0" cellspacing="0">
	<tr>
		<td height="20px">
		</td>
	</tr>
</table>
    <asp:GridView ID="GridView1" runat="server" CssClass="my-grid" Width="100%" DataKeyNames="Pin" Caption='<table width="100%"><tr><td align="center" style="font-size:20px">Un-Used Pins</td></tr></table>'
            EnableModelValidation="True" onrowupdating="GridView1_RowUpdating" HeaderStyle-CssClass="gridhead">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" CssClass="gray">Click</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle
                BorderStyle="Dotted" BorderWidth="1px" />
</asp:GridView>
  <asp:GridView ID="GridView2" runat="server" CssClass="my-grid" Width="100%" Caption='<table width="100%"><tr><td align="center" style="font-size:20px">Used Pins</td></tr></table>'>
</asp:GridView>
</asp:Content>

