<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="grid f-size" HeaderStyle-CssClass="gridhead" AutoGenerateColumns="false">
         <Columns>
             <asp:BoundField DataField="SNO" HeaderText="S.No" />
             <asp:BoundField DataField="User ID" HeaderText="User ID" />
              <asp:BoundField DataField="joined" HeaderText="joined" />
               <%--<asp:BoundField DataField="INS" HeaderText="INS" />
               <asp:BoundField DataField="PREV" HeaderText="PREV" />--%>
               
         </Columns>
    </asp:GridView>
    </div>
    </form>
</body>
</html>
