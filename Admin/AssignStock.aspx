<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AssignStock.aspx.cs" Inherits="Admin_AssignStock" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <h3>Assign Stock</h3>
    <hr />
    <div class="col-md-8">
          <div class="form-group">
            <label>User Name</label>
            <asp:TextBox ID="txtuser" runat="server" class="form-control" OnTextChanged="txtuser_TextChanged" AutoPostBack="true" ></asp:TextBox>
              <asp:Label ID="lbluser" runat="server" Text="Label"></asp:Label>
            

        </div>
        <div class="form-group">
            <label>Product Name</label>
            <asp:TextBox ID="txtname" runat="server" class="form-control" ></asp:TextBox>
            <asp:Label ID="lblproduct" runat="server" Text="Label"  Visible="false"></asp:Label>
            <cc1:AutoCompleteExtender ID="txtname_AutoCompleteExtender" runat="server" BehaviorID="txtname_AutoCompleteExtender" MinimumPrefixLength="2"  CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" ServiceMethod="SearchProduct" TargetControlID="txtname" FirstRowSelected="false">
            </cc1:AutoCompleteExtender>
           
        </div>
        <div class="form-group">
            <label>Stock</label>
            <asp:TextBox ID="txtqty" runat="server" class="form-control" placeholder="qty"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server"
                Text="Submit" OnClick="btnsubmit_Click"/>
        </div>

    </div>
</asp:Content>

