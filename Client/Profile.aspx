<%@ Page Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Client_Default2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .form-group 
    {
        padding: 50px 0px 0px 0px;
    }
 </style> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	  <div>
		<h2 class="content-header-title">Personal Profile</h2>
      </div>

     <br/>
   <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
<div class="row">
<fieldset>
  <legend>Profile</legend>
    <div class="form-group">
    <div class="row">
    <div class="col-sm-2">ID</div>

    <div class="col-sm-4">
         <asp:TextBox CssClass="form-control unicase-form-control text-input" ID="TextBox1" runat="server"></asp:TextBox>
        </div>

    <div class="col-sm-2">Name <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                  ControlToValidate="txtname" ErrorMessage="Enter Name" ValidationGroup="aa"></asp:RequiredFieldValidator></div>

    <div class="col-sm-4">
        <asp:TextBox CssClass="form-control unicase-form-control text-input" ID="txtname" runat="server"></asp:TextBox>
              
    </div>
    </div>
    </div>
    <div class="form-group">
    <div class="row">
          <div class="col-sm-2">Contact Number</div>
          <div class="col-sm-4">
              <asp:TextBox CssClass="form-control unicase-form-control text-input" ID="txtmobile" 
                  runat="server" MaxLength="10"></asp:TextBox>
            </div>
          <div class="col-sm-2">Address</div>
          <div class="col-sm-4">
            <asp:TextBox CssClass="form-control unicase-form-control text-input" ID="TextBox2" runat="server"></asp:TextBox>
          </div>
        </div>
    </div>
    <div class="form-group">
    <div class="row">
          <div class="col-sm-2">E-Mail</div>
          <div class="col-sm-4">
              <asp:TextBox CssClass="form-control unicase-form-control text-input" ID="txtemail" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-2"></div>
            <div class="col-sm-4"></div>
          </div>
        </div>
    <div class="form-group">
    <div class="row">
         <div class="col-md-6 col-md-offset-6">
            <asp:Button CssClass="btn-upper btn btn-primary checkout-page-button" ID="Button1" runat="server" Text="Register" 
                  onclick="Button1_Click" ValidationGroup="aa" />      
              <br />
            <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" 
                  Font-Size="Large" ForeColor="#FFF"></asp:Label>      
            </div>
        </div>
        </div>
</fieldset>
</div>
</asp:Content>

