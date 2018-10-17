<%@ Page Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="PwdChg.aspx.cs" Inherits="Client_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    Dashboard    
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
    .form-group 
    {
        padding: 35px 0px 0px 0px;
    }
 </style> 
<div class="row">
<fieldset>
  <legend>Change Password</legend>
</fieldset>
</div>
    <div class="form-group">
    <div class="row">
    <div class="col-md-2">Old Password <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox1" ErrorMessage="Enter Old Password" 
                    ValidationGroup="aa">*</asp:RequiredFieldValidator></div>
    <div class="col-md-5"><asp:TextBox CssClass="form-control unicase-form-control text-input" ID="TextBox1" runat="server" 
                    TextMode="Password"></asp:TextBox></div>
    </div>
    </div>
    <div class="form-group">
    <div class="row">
    <div class="col-md-2"">New Password <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox2" ErrorMessage="Enter New Password" 
                    ValidationGroup="aa">*</asp:RequiredFieldValidator></div>
    <div class="col-md-5"><asp:TextBox CssClass="form-control unicase-form-control text-input" ID="TextBox2" runat="server" 
                    TextMode="Password"></asp:TextBox></div>
    </div>
    </div>
    <div class="form-group">
    <div class="row">
    <div class="col-md-2"">Confirm Password <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBox3" ErrorMessage="Enter Confirm Password" 
                    ValidationGroup="aa">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="TextBox3" ControlToValidate="TextBox2" 
                    ErrorMessage="Password not matched" ValidationGroup="aa">*</asp:CompareValidator></div>
    <div class="col-md-5">
            <asp:TextBox CssClass="form-control unicase-form-control text-input" ID="TextBox3" runat="server" 
                    TextMode="Password"></asp:TextBox>
    </div>
    </div>
    </div>
    <div class="form-group">
    <div class="row">
    <div class="col-md-6 col-md-offset-6">
                  <asp:Button CssClass="btn-upper btn btn-primary checkout-page-button" ID="Button1" runat="server" 
                    Text="Change Password" onclick="Button1_Click" 
                  ValidationGroup="aa" />      
    </div>
    </div>
    <div class="row">
    <div class="col-sm-12">
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    </div>
    </div>
    </div>
</asp:Content>

