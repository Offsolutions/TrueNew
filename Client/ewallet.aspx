<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="ewallet.aspx.cs" Inherits="Client_ewallet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 187px;
        }
        .auto-style4 {
            width: 130px;
        }
        .auto-style5 {
            width: 187px;
            height: 19px;
        }
        .auto-style7 {
        }
        .auto-style11 {
            width: 172px;
        }
        .auto-style12 {
            width: 172px;
            height: 19px;
        }
        .auto-style13 {
            width: 138px;
        }
        .auto-style14 {
        }
        table#ctl00_cpmain_RadioButtonList1 tbody tr {
    display: inline;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-12 text-right">
      <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-default" Text="Print" OnClientClick = "return PrintPanel();" />
    </div>
    <asp:Panel ID="pnlContents" runat="server">

    <div class="col-md-12">
        <h4 style="margin-bottom: 20px;">Income Details</h4>
    
            <table style="width: 100%;" class="table table-bordered">
            <tr>
                <td><strong>Name : <asp:Label ID="lblname" runat="server" Text="Label"></asp:Label></strong></td>
                <td><strong>Reg Id : <asp:Label ID="lblregno" runat="server" Text="Label"></asp:Label></strong></td>
               
            </tr>
            <tr>
                <td colspan="2">
                    <table style="width: 100%;" class="table table-bordered">
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td><strong>Income</strong></td>
                        </tr>
                        <tr>
                            <td class="auto-style5"><strong></strong></td>
                            <td class="auto-style12"><%=leftpair %></td>
                            <td class="auto-style14" colspan="2" rowspan="2">Pair Income : 100 </td>
                            <td class="auto-style7" rowspan="2">
                                <asp:Label ID="lblincome" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2"><strong></strong></td>
                            <td class="auto-style11"><%=rightpair %></td>
                        </tr>
                        <tr>
                            <td class="auto-style2"></td>
                            <td class="auto-style11">
                                <asp:Label ID="lblcapping" runat="server" Text="0"></asp:Label></td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style4"><strong Class="text-primary">Total Income</strong></td>
                            <td>
                                <asp:Label ID="lbltotal" runat="server" Text="0" ></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style4"><strong Class="text-danger">TDS @ 5%</strong></td>
                            <td>
                                <asp:Label ID="lbltds" runat="server" Text="0" ></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style4"><strong Class="text-danger">Admin @ 10%</strong></td>
                            <td>
                                <asp:Label ID="lbladmin" runat="server" Text="0" ></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style4"><strong Class="text-success">Payable</strong></td>
                            <td>
                                <asp:Label ID="lblnet" runat="server" Text="0" ></asp:Label></td>
                        </tr>
                    </table>
                </td>
               
            </tr>
          
        </table>
        </div>
        <div class="col-md-12">
            <h4 style="margin-bottom: 20px;">Withdrawls</h4>
            <table id="example2" class="table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Sr.No</th>
                <th>Dated</th>
                <th>Amount</th>
                
                <th>Action</th>
              
            </tr>
        </thead>
            <asp:ListView ID="ListView1" runat="server" OnItemDataBound="ListView1_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td><%# Container.DataItemIndex+1 %></td>
                    
                    <td><asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("date_entry")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="lblamt" runat="server" Text='<%#Eval("amount") %>'><%#Eval("amount") %></asp:Label></td>
                  
                    <td>
                                            </td>
                    
                </tr>
              
            </ItemTemplate>
        </asp:ListView>
        </table>
            <div class="col-md-12 text-center">
               <strong> Balance : <%=bal %> </strong>
            </div>
        </div>
        

    
        </asp:Panel>
</asp:Content>

