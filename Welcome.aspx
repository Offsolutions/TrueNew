<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpbread" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="jumbotron">
        <h2>Welcome To
            <asp:Label ID="lblname" runat="server" Text=""></asp:Label></h2>
        <br />
        <p>Your Joining Has Been Created</p>
        <p>
            Registration id is: <strong>
                <asp:Label ID="lblreg" runat="server" Text=""></asp:Label></strong>  and Password Is: <strong>
                    <asp:Label ID="lblpass" runat="server" Text=""></asp:Label></strong>
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfooter" runat="Server">
</asp:Content>

