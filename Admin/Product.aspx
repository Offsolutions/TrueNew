<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Admin_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="gvpins" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" >
        <Columns>
<%--            <asp:BoundField DataField="month" HeaderText="Month" />--%>
   
            <asp:BoundField DataField="name" HeaderText="Product Name" />
            <asp:BoundField DataField="code" HeaderText="Code" />
          
            <asp:BoundField DataField="dp" HeaderText="DP" />
             <asp:BoundField DataField="pv" HeaderText="PV" />
              <asp:TemplateField HeaderText="Image" >
                <ItemTemplate>
                   
                  <img src='../uploadimage/<%#Eval("image") %>' width="80" />
                </ItemTemplate>
                
              </asp:TemplateField>
            <asp:BoundField DataField="stock" HeaderText="Stock" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                   <asp:LinkButton ID="lnkedit" CommandArgument='<%#Eval("id") %>' OnClick="lnkedit_Click" runat="server">Edit</asp:LinkButton>
                   <asp:LinkButton ID="LinkButton1"  CommandArgument='<%#Eval("id") %>' runat="server" OnClick="LinkButton1_Click">Delete</asp:LinkButton>
                   <asp:LinkButton ID="LinkButton2" CommandArgument='<%#Eval("code") %>' OnClick="LinkButton2_Click" runat="server">Enter Stock</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>
    </asp:GridView>
</asp:Content>

