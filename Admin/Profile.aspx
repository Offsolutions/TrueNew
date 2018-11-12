<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Admin_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-group col-md-8">
        <label for="exampleInputEmail1">Name</label>
        <asp:TextBox CssClass="form-control" ID="txtname" runat="server"></asp:TextBox>
    </div>
    <div class="form-group col-md-8">
        <label for="exampleInputEmail1">Father Name</label>
        <asp:TextBox CssClass="form-control" ID="txtfname" runat="server"></asp:TextBox>
    </div>
    <div class="form-group col-md-8">
        <label for="exampleInputEmail1">DOB</label>
        <asp:TextBox CssClass="form-control" ID="txtdob" runat="server"></asp:TextBox>
    </div>
    <div class="form-group col-md-8">
        <label for="exampleInputEmail1">Address</label>
        <asp:TextBox CssClass="form-control" ID="txtadd" runat="server"></asp:TextBox>
    </div>
    <div class="form-group col-md-8">
        <label for="exampleInputEmail1">Email</label>
        <asp:TextBox CssClass="form-control" ID="txtemail" runat="server"></asp:TextBox>
    </div>
    <div class="form-group col-md-8">
        <label for="exampleInputEmail1">Mobile</label>
        <asp:TextBox CssClass="form-control" ID="txtmob" runat="server"></asp:TextBox>
    </div>
    <div class="form-group col-md-8">
        <label for="exampleInputEmail1">Password</label>
        <asp:TextBox CssClass="form-control" ID="txtpass" runat="server"></asp:TextBox>
    </div>
    <div class="form-group col-md-8">
        <label for="exampleInputEmail1">Bank Name</label>
        <asp:TextBox CssClass="form-control" ID="txtbname" runat="server"></asp:TextBox>
     </div>
     <div class="form-group col-md-8">
        <label for="exampleInputEmail1">IFSC Code</label>
        <asp:TextBox CssClass="form-control" ID="txtifsc" runat="server"></asp:TextBox>
     </div>
     <div class="form-group col-md-8">
        <label for="exampleInputEmail1">Account Number</label>
        <asp:TextBox CssClass="form-control" ID="txtacc" runat="server"></asp:TextBox>
     </div>
     <div class="form-group col-md-8">
        <label for="exampleInputEmail1">Pan Card</label>
        <asp:TextBox CssClass="form-control" ID="txtpan" runat="server"></asp:TextBox>
     </div>
     <div class="form-group col-md-8">
        <label for="exampleInputEmail1">Aadhar Number</label>
        <asp:TextBox CssClass="form-control" ID="txtadhar" runat="server"></asp:TextBox>
     </div>

    <asp:Button CssClass="btn btn-primary " ID="Button1" runat="server" Text="Register" 
                  onclick="Button1_Click" />     
</asp:Content>

