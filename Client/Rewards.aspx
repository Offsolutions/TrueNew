<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Rewards.aspx.cs" Inherits="Client_Rewards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnllist" runat="server">

   
     <div class="col-md-12">
        <div class="col-md-3">
            Left Pair : <asp:Label ID="lblleft" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-md-3">
            Right Pair : <asp:Label ID="lblright" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <br />
     <div class="col-md-12">


        <table id="example" class="table table-striped table-bordered " cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Pair</th>
                    <th>Rewards</th> 
                    <th>Rewards Income Capping</th> 
                    <th>Reward Income</th>
                     <th>Level</th>
                    
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server" OnItemDataBound="gvpins_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <td>
                            <asp:Label ID="lblpins" runat="server" Text='<%#Eval("pair") %>' Enabled="false"><%#Eval("pair") %></asp:Label></td>
                        <asp:HiddenField ID="hfid" Value='<%#Eval("id") %>' runat="server" />
                        <td>
                             <%#Eval("rewardsname") %></td>
                      <td>
                            Rs. <%#Eval("amount") %></td>
                         <td>
                           Rs.  <asp:Label ID="lblincome" runat="server" Text="0"></asp:Label></td>
                       <td>

                           <asp:LinkButton ID="lnklevel" runat="server" Enabled="false">Pending</asp:LinkButton>
                       </td>
                       


                </ItemTemplate>
            </asp:ListView>
        </table>


    </div>
         </asp:Panel>
</asp:Content>

