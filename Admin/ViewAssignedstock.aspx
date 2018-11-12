<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ViewAssignedstock.aspx.cs" Inherits="Admin_ViewAssignedstock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h3>Assigned Stock</h3>
    <hr />
   
    <asp:GridView ID="gvpins" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" >
        <Columns>

   
             <asp:BoundField DataField="name" HeaderText="Product Name" />
            <asp:BoundField DataField="code" HeaderText="Code" />
            <asp:BoundField DataField="name" HeaderText="User Name" />
            <asp:BoundField DataField="regno" HeaderText="RegNo." />
            <asp:BoundField DataField="stock" HeaderText="Stock" />
            <asp:TemplateField HeaderText="Date" >
                <ItemTemplate>
            <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("date")).ToString("dd/MM/yyyy") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
             <%--<asp:BoundField DataField="date" HeaderText="date" />--%>
           
        </Columns>
    </asp:GridView>
</asp:Content>

