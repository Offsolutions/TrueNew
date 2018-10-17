<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

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
                        <h2>LOG IN</h2>
                        <form id="login-form" data-parsley-validate="">
                            <ul class="list-unstyled">
                                <li>Member ID <asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Fill ID" 
                                            Text="*" ValidationGroup="aa" ControlToValidate="TextBox1"></asp:RequiredFieldValidator></li>
                                <li><asp:TextBox ID="TextBox1" runat="server" CssClass="form-control unicase-form-control text-input"></asp:TextBox><span id="PageContentPlaceholder_RequiredFieldValidator2" style="display:none;">*</span></li>
                                <li>Password <asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Fill Password" 
                                            Text="*" ValidationGroup="aa" ControlToValidate="TextBox2"></asp:RequiredFieldValidator></li>
                                <li><asp:TextBox ID="TextBox2" runat="server" CssClass="form-control unicase-form-control text-input" TextMode="Password"></asp:TextBox><span id="PageContentPlaceholder_RequiredFieldValidator1" style="display:none;">*</span></li>
                                <li class="forgot-password"><a href="#">FORGOT PASSWORD?</a></li>
                                <li><p class="text-right"><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Sign In" ValidationGroup="aa" CssClass="udio-btn" /></p></li>
                            </ul>
                        </form>
                    </div>
                    <p class="already-account"><a href="reg.aspx">NEW USER? SIGN UP HERE</a></p>
                </div>
            </div>
        </div>
    </div>
</section>
</asp:Content>

