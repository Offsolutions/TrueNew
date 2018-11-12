<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="Admin_AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    Product
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="col-md-8">



        <div class="form-group">
            <label>Name</label>
            <asp:TextBox ID="txtname" runat="server" CssClass="form-control"></asp:TextBox>

        </div>
        <%--<div class="form-group">
            <label>Product code</label>
                <asp:TextBox ID="txtcode" runat="server" CssClass="form-control"></asp:TextBox>
        </div>--%>

        <div class="form-group">
            <label>DP </label>
            <asp:TextBox ID="txtdp" runat="server" CssClass="form-control"></asp:TextBox>

        </div>
        <div class="form-group">
            <label>Pv </label>
            <asp:TextBox ID="txtpv" runat="server" CssClass="form-control"></asp:TextBox>

        </div>
        <div class="form-group">
            <label>Upload Image</label>
            <asp:FileUpload ID="sliderimage" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server"
                Text="Submit" OnClick="btnsubmit_Click" />
        </div>
    </div>
    <div class="col-md-4">
    </div>

</asp:Content>

