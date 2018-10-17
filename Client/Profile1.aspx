<%@ Page Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Profile1.aspx.cs" Inherits="Client_Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .form-group {
            padding: 35px 0px 0px 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="content-container">
            <div>
                <h2 class="content-header-title">Payment Profile</h2>
            </div>

            <br/>
            <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
            <div class="row">
                <fieldset>
                    <legend>Profile</legend>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-2">UDIO CARD NO.</div>

                            <div class="col-sm-4">
                                <asp:TextBox CssClass="form-control unicase-form-control text-input" ID="TextBox1" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-sm-2">
                                UDIO MOBILE NO.
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtname" ErrorMessage="Enter Name" ValidationGroup="aa">*</asp:RequiredFieldValidator>
                            </div>

                            <div class="col-sm-4">
                                <asp:TextBox CssClass="form-control unicase-form-control text-input" ID="txtname" runat="server"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-2">BTC Address</div>
                            <div class="col-sm-4">
                                <asp:TextBox CssClass="form-control unicase-form-control text-input" ID="txtmobile"
                                    runat="server" MaxLength="10"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">Bank Name</div>
                            <div class="col-sm-4">
                                <asp:TextBox CssClass="form-control unicase-form-control text-input" ID="TextBox2"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-2">Ac. No.</div>
                            <div class="col-sm-4">
                                <asp:TextBox CssClass="form-control unicase-form-control text-input" ID="TextBox3"
                                    runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">IFSC</div>
                            <div class="col-sm-4">
                                <asp:TextBox CssClass="form-control unicase-form-control text-input" ID="TextBox4"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-2">PAN</div>
                            <div class="col-sm-4">
                                <asp:TextBox CssClass="form-control unicase-form-control text-input" ID="TextBox5"
                                    runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">AADHAR</div>
                            <div class="col-sm-4">
                                <asp:TextBox CssClass="form-control unicase-form-control text-input" ID="TextBox6"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    </fieldset>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-md-6 col-md-offset-6">
                        <asp:Button CssClass="btn-upper btn btn-primary checkout-page-button" ID="Button1" runat="server" Text="Register"
                            OnClick="Button1_Click" ValidationGroup="aa" />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True"
                            Font-Size="Large" ForeColor="#FFF"></asp:Label>
                    </div>
                </div>
            </div>
           </div>
        </div>
</asp:Content>

