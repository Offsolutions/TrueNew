<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="RewardLevel.aspx.cs" Inherits="Client_RewardLevel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-12">
        <div class="col-md-3">
            Left Pair : <asp:Label ID="lblleft" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-md-3">
            Right Pair : <asp:Label ID="lblright" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="col-md-12">


        <table id="example" class="table table-striped table-bordered " cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Pair</th>
                    <th>Rewards</th> 
                    <th>Sale</th> 
                    <th>Purchase</th>
                    <th>Reward Level</th>
                    
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server" OnItemDataBound="gvpins_ItemDataBound" OnItemCommand="gvpins_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %>
                            <asp:HiddenField ID="hfsale" Value='<%#Eval("sale") %>' runat="server" />
                          
                        </td>

                        <td>
                            <asp:Label ID="lblpins" runat="server" Text='<%#Eval("pair") %>' Enabled="false"><%#Eval("pair") %></asp:Label></td>
                        <asp:HiddenField ID="hfid" Value='<%#Eval("id") %>' runat="server" />
                        <td>
                             <%#Eval("rewardsname") %></td>
                      <td>
                            Rs. <%#Eval("sale") %></td>
                         
                       <td>

                           <asp:LinkButton ID="lnklevel" runat="server" Enabled="false">Pending</asp:LinkButton>
                       </td>
                        <td>
                             <asp:LinkButton ID="lnkreward" CommandArgument='<%#Eval("id") %>' CommandName="submit" CssClass="btn btn-danger" runat="server" >Reward Pending</asp:LinkButton>
                        </td>
                       


                </ItemTemplate>
            </asp:ListView>
        </table>


    </div>
</asp:Content>

