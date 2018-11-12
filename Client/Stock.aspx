<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Stock.aspx.cs" Inherits="Client_Stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Assigned Stock</h2>

   <br /><br />
    <asp:GridView ID="gvpins" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" >
        <Columns>

   
             <asp:BoundField DataField="name" HeaderText="Product Name" />
            <asp:BoundField DataField="code" HeaderText="Code" />
            <asp:BoundField DataField="regno" HeaderText="RegNo." Visible="false" />
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

