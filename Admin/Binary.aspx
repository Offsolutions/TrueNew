<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Binary.aspx.cs" Inherits="Admin_Default2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:GridView ID="GridView1" runat="server" CssClass="table table-full table-full-small table-hover table-bordered" DataKeyNames="DATE" 
            EnableModelValidation="True" onrowupdating="GridView1_RowUpdating">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update">Click</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle
                BorderStyle="Dotted" BorderWidth="1px" />
        </asp:GridView>
        <br />
<asp:GridView ID="GridView2" runat="server" CssClass="table table-full table-full-small table-hover table-bordered">
        </asp:GridView>
</asp:Content>

