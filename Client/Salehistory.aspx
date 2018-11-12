<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Salehistory.aspx.cs" Inherits="Client_Salehistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <h2>Sale History</h2>
    <br />
    <br />
    <div class="col-md-12">



        <table id="example" class="table table-striped table-bordered" cellspacing="0" style="width: 100%;">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Date</th>
                    <th>Product Name</th>
                    <th>Quantity</th>
                    <th>Dp</th>
                    <th>Pv</th>
                    <th>Buyer</th>
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <td>
                            <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("date")).ToString("dd/MM/yyyy") %>'></asp:Label>
                        </td>

                        <td>
                            <%#Eval("name") %></td>
                        <td>
                            <%#Eval("qty") %></td>
                        <td>
                            <%#Eval("dp") %></td>
                        <td>
                            <%#Eval("pv") %></td>
                        <td>
                            <%#Eval("regno") %></td>



                </ItemTemplate>
            </asp:ListView>
        </table>


    </div>
</asp:Content>

