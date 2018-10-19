<%@ Page Language="C#" AutoEventWireup="true" CodeFile="excelupdate.aspx.cs" Inherits="excelupdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Excel Uploading </title>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="row">
                <div class="col-md-12">
                    <h1>Upload Excel</h1>
                    <div class="col-md-6">
                        <div class="form-group">
                            File
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                        </div>
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </div>
                </div>

            </div>

        </div>
    </form>
</body>
</html>
