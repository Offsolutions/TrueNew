<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Daily-Reward-Income.aspx.cs" Inherits="Admin_Daily_Reward_Income" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Reward Income
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>

    <cc1:CalendarExtender runat="server" Enabled="True" Format="yyyy-MM-dd" TargetControlID="txtdate" ID="txtdate_CalendarExtender"></cc1:CalendarExtender>
    <div class="col-md-12">
        <asp:Button ID="btnsubmit" OnClick="btnsubmit_Click" runat="server" Text="Submit" />

        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Regno</th>
                    <th>Invoice</th>  
                     <th>Amount</th>
                 
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <td>
                           <%#Eval("id") %></td>
                        
                        <td>
                            <%#Eval("purchaseid") %></td>
                     <td>
                            <%#Eval("amount") %></td>
                       
                       


                </ItemTemplate>
            </asp:ListView>
        </table>


    </div>
      Daily Total Income  : <asp:Label ID="lblincome" runat="server" Text="0"></asp:Label><br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="btn btn-success" Text="Distribute Reward" />
</asp:Content>

