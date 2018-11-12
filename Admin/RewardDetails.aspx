<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="RewardDetails.aspx.cs" Inherits="Admin_RewardDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    Reward Details
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-8">



        <div class="form-group">
            <label>Name</label>
            <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox>

        </div>
        <div class="form-group">
            <label>pair </label>
            <asp:TextBox ID="txtpair" runat="server" class="form-control"></asp:TextBox>

        </div>
        <div class="form-group">
            <label>Amount </label>
            <asp:TextBox ID="txtamount" runat="server" class="form-control"></asp:TextBox>

        </div>
        <div class="form-group">
            <label>Percentage </label>
            <asp:TextBox ID="txtper" runat="server" class="form-control"></asp:TextBox>

        </div>
       
        <div class="form-group">
            <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server"
                Text="Submit" OnClick="btnsubmit_Click" />
        </div>
    </div>
</asp:Content>

