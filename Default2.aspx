<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 152px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Registration Id</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">First Name</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">S/o,W/o,D/o</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Joining Date</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Address</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Gender</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Mobileno.</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Marital Status</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
    </div>
    </form>
</body>
</html>
