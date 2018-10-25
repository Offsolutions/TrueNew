<%@ Page Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Client_Default2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	  <div>
		<h2 class="content-header-title">Personal Profile</h2>
      </div>

     <br/>
   <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
<div class="row">

    <div class="form-group col-md-8">
        <label for="exampleInputEmail1">Id</label>
       
         <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>
    </div>
     <div class="form-group col-md-8">
        <label for="exampleInputEmail1">Name</label>
       
        <asp:TextBox CssClass="form-control" ID="txtname" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                  ControlToValidate="txtname" ErrorMessage="Enter Name" ValidationGroup="aa"></asp:RequiredFieldValidator>
    </div>
     <div class="form-group col-md-8">
        <label for="exampleInputEmail1">Contact Number</label>
         <asp:TextBox CssClass="form-control " ID="txtmobile" 
                  runat="server" MaxLength="10"></asp:TextBox>
    </div>
     <div class="form-group col-md-8">
        <label for="exampleInputEmail1">Address</label>
       <asp:TextBox CssClass="form-control unicase-form-control text-input" ID="TextBox2" runat="server"></asp:TextBox>
    </div>

     <div class="form-group col-md-8">
        <label for="exampleInputEmail1">Address</label>
        <asp:TextBox CssClass="form-control" ID="txtemail" runat="server"></asp:TextBox>
    </div>
     <div class="form-group col-md-8">
          <asp:Button CssClass="btn btn-primary " ID="Button1" runat="server" Text="Register" 
                  onclick="Button1_Click" ValidationGroup="aa" />      
         <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" 
                  Font-Size="Large" ForeColor="#FFF"></asp:Label>      
    </div>


</div>
</asp:Content>

