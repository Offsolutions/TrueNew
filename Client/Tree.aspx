<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Tree.aspx.cs" Inherits="Client_Default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table width="100%" class="client_table">
    <tr>
      <td align="center" valign="top" colspan="5" class="client_home_hd" id="usertopbottom">Tree</td>
      <br />
    </tr>
    <tr>
      <td  class="tableborderform" align="center"><table width="100%"border="0"cellpadding="0" cellspacing="0" align="center" >
          <tr>
            <td colspan="2" class="textstylecenter1" align="center"><asp:Label ID="Label23" runat="server" Text="Label"  Font-Size="Small"></asp:Label></td >
            <td width="0" class="textstylecenter1" align="center" ><asp:Image ID="Image1" runat="server" ImageUrl="~/img/user_black.png" Width="50px" /></td >
            <td colspan="2" width="233" class="textstylecenter1" align="center"><asp:Label ID="Label25" runat="server" Text="Label" Font-Size="Small"></asp:Label></td>
          </tr>
          <tr valign="top" align="center">
            <td width="140" class="textstylecenter1" >&nbsp;</td >
            <td width="140" class="textstylecenter1" >&nbsp;</td >
            <td width="140" align="center" class="textstylecenter1"  ><asp:Label ID="Label8" runat="server" Text="Label" Font-Bold=true Font-Size=Large></asp:Label></td >
            <td width="140" class="textstylecenter1" >&nbsp;</td >
            <td width="140" class="textstylecenter1" >&nbsp;</td >
          </tr>
          <tr><td><br /></td></tr>
          <tr>
            <td  colspan="2" class="textstylecenter1" align="center"><asp:Image ID="Image3" runat="server" ImageUrl="~/imges/user_black.png" Width="50px" /></td >
            <td align="center" class="textstylecenter1" >&nbsp;</td >
            <td  colspan="2" class="textstylecenter1" align="center"><asp:Image ID="Image6" runat="server" ImageUrl="~/imges/user_black.png" Width="50px" /></td >
          </tr>
          <tr valign="top" height="40">
            <td  colspan="2" class="textstylecenter1" align="center"><asp:LinkButton 
                 Font-Bold=true Font-Size=Large ID="LinkButton1" runat="server" onclick="LinkButton1_Click"></asp:LinkButton>
             <br />
              <asp:Label ID="Label10" runat="server" Font-Size="Small"></asp:Label>
              <br />
              <asp:Label ID="Label17" runat="server" Font-Size="Small"></asp:Label></td >
            <td align="center" class="textstylecenter1" >&nbsp;</td >
            <td  colspan="2" class="textstylecenter1" align="center"><asp:LinkButton
                 Font-Bold=true Font-Size=Large ID="LinkButton4" runat="server" onclick="LinkButton4_Click"></asp:LinkButton>
              <br />
              <asp:Label ID="Label11" runat="server" Font-Size="Small"></asp:Label>
              <br />
              <asp:Label ID="Label18" runat="server" Font-Size="Small"></asp:Label></td >
          </tr>
          <tr><td><br /></td></tr>
          <tr>
            <td width="140" align="center" class="textstylecenter1" ><asp:Image ID="Image9" runat="server" ImageUrl="~/imges/user_black.png" Width="50px" /></td >
            <td width="140"  align="center" class="textstylecenter1"><asp:Image ID="Image12" runat="server" ImageUrl="~/imges/user_black.png" Width="50px" /></td >
            <td width="140" align="center" class="textstylecenter1" >&nbsp;</td >
            <td width="140" align="center" class="textstylecenter1" ><asp:Image ID="Image15" runat="server" ImageUrl="~/imges/user_black.png" Width="50px" /></td >
            <td width="140" align="center" class="textstylecenter1" ><asp:Image ID="Image18" runat="server" ImageUrl="~/imges/user_black.png" Width="50px" /></td >
          </tr>
          
          <tr valign="top" >
            <td width="140"  align="center" class="textstylecenter1"><asp:LinkButton 
                 Font-Bold=true Font-Size=Large ID="LinkButton2" runat="server" onclick="LinkButton2_Click"></asp:LinkButton>
              <br />
              <asp:Label ID="Label12" runat="server" Font-Size="Small"></asp:Label>
              <br />
              <asp:Label ID="Label19" runat="server" Font-Size="Small"></asp:Label></td >
            <td width="140" align="center" class="textstylecenter1" ><asp:LinkButton  
                 Font-Bold=true Font-Size=Large ID="LinkButton3" runat="server" onclick="LinkButton3_Click"></asp:LinkButton>
              <br />
              <asp:Label ID="Label13" runat="server" Font-Size="Small"></asp:Label>
              <br />
              <asp:Label ID="Label20" runat="server" Font-Size="Small"></asp:Label></td >
            <td width="140" align="center" class="textstylecenter1" >&nbsp;</td >
            <td width="140" align="center" class="textstylecenter1" ><asp:LinkButton 
                 Font-Bold=true Font-Size=Large ID="LinkButton5" runat="server" onclick="LinkButton5_Click"></asp:LinkButton>
              <br />
              <asp:Label ID="Label14" runat="server" Font-Size="Small"></asp:Label>
              <br />
              <asp:Label ID="Label21" runat="server" Font-Size="Small"></asp:Label></td >
            <td width="140"  align="center" class="textstylecenter1"><asp:LinkButton 
                 Font-Bold=true Font-Size=Large ID="LinkButton6" runat="server" onclick="LinkButton6_Click"></asp:LinkButton>
              <br />
              <asp:Label ID="Label15" runat="server" Font-Size="Small"></asp:Label>
              <br />
              <asp:Label ID="Label22" runat="server" Font-Size="Small"></asp:Label></td >
          </tr>
        </table></td >
    </tr>
  </table>
</asp:Content>
