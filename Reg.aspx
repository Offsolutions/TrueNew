<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="reg.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
//<![CDATA[
    var Croogo = { "basePath": "\/", "params": { "plugin": null, "controller": "pages", "action": "login", "named": []} };
//]]>
</script>    <style>
        .alert-success, .alert-error{
            position: absolute;
            text-align: center;
            width: 100%;
            z-index: 999;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section class="forms-section">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-3 form-wrapper login-form">
                <div class="form-outer">
                    <div class="outer">
                        <h2>REGISTER NEW MEMBER</h2>
                        <form id="login-form" data-parsley-validate="">
                            <ul class="list-unstyled">
                                <li>Enter Registration Key <asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Fill Registration Key" 
                                            Text="*" ValidationGroup="aa" ControlToValidate="TextBox1"></asp:RequiredFieldValidator></li>
                                <li><asp:TextBox ID="TextBox1" runat="server" CssClass="form-control unicase-form-control text-input"></asp:TextBox><span id="Span2" style="display:none;">*</span></li>
                                <li>Enter Sponsor ID <asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Fill Sponsor ID" 
                                            Text="*" ValidationGroup="aa" ControlToValidate="TextBox2"></asp:RequiredFieldValidator></li>
                                <li><asp:TextBox ID="TextBox2" runat="server" CssClass="form-control unicase-form-control text-input"></asp:TextBox><span id="Span1" style="display:none;">*</span></li>
                                <li>
                                <div class="col-md-6">
                                    <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="bb" CssClass="radio-inline" Text="Left" style="position:initial"/>
                                </div>
                                <div class="col-md-6">
                                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="bb" CssClass="radio-inline" Text="Right" style="position:initial" />
                                 </div>
                                 </li>
                                <li>Enter Name <asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Fill Name" 
                                            Text="*" ValidationGroup="aa" ControlToValidate="TextBox3"></asp:RequiredFieldValidator></li>
                                <li><asp:TextBox ID="TextBox3" runat="server" CssClass="form-control unicase-form-control text-input"></asp:TextBox><span id="PageContentPlaceholder_RequiredFieldValidator3" style="display:none;">*</span></li>
                                <li>Enter Mobile No. <asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Fill Mobile" 
                                            Text="*" ValidationGroup="aa" ControlToValidate="TextBox4"></asp:RequiredFieldValidator></li>
                                <li><asp:TextBox ID="TextBox4" runat="server" CssClass="form-control unicase-form-control text-input"></asp:TextBox><span id="PageContentPlaceholder_RequiredFieldValidator10" style="display:none;">*</span></li>
                                <li><p class="text-right"><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Register" ValidationGroup="aa" CssClass="udio-btn" /></p></li>
                            </ul>
                        </form>
                    </div>
                    <p class="already-account">ALREADY SIGNED UP? <a href="login.aspx">LOGIN HERE</a> </p>
                </div>
            </div>
        </div>
    </div>
</section>
</asp:Content>
