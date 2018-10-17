
<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Client_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style>
    .Nrs{font-size:20px;}
</style>
<div class="row no-gutter">
    <div class="col-sm-12 col-md-12 col-lg-12" style="background:#fff;">
    <div class="p-20 clearfix">
        <h4 class="color40"><span>Welcome </span> </h4>
    </div>
    </div>
</div>
<div>
          <div class="col-md-12 col-space">
<div id='cssmenu'>
    
    <ul>
        
        <li><div class="col-md-u">
              <div class="card small vPan">
                <div class="theme-secondary-lighten-1 p-time">
                 <div class="fl Nicon"><i class="fa fa-user-plus" style="font-size: 2.7em;"></i></div>
                    <div align="right" class="Nrs"><asp:Label ID="Label1" runat="server" Text=""></asp:Label></div>
                    <div class="status dFont">My Direct &nbsp;</div>
                  </div>
             </div>
            </div></li>

            <li><div class="col-md-u">
              <div class="card small vPan">
                <div class="theme-lighten-2 p-time">
                 <div class="fl Nicon"><i class="fa fa-users" style="font-size: 2.7em;"></i></div>
                    <div align='right' class="Nrs"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></div>
                    <div class="status dFont">My Group</div>
                  </div>
               </div>
            </div></li>

            <li><div class="col-md-u">
              <div class="card small vPan">
                <div class="green lighten-1 p-time">
                 <div class="fl Nicon"><i class="md md-cash f-size"></i></div>
                    <div align='right' class="Nrs"><i class="fa fa-inr"></i> <asp:Label ID="Label3" runat="server" Text=""></asp:Label></div>
                    <div class="status dFont">My Income</div>
                  </div>
                </div>
            </div></li>

            <li><div class="col-md-u">
              <div class="card small vPan">
              <div class="theme-lighten-1 p-time">
                 <div class="fl Nicon"><i class="md md-cash f-size"></i></div>
                    <div align='right' class="Nrs"><i class="fa fa-inr"></i> <asp:Label ID="Label4" runat="server" Text=""></asp:Label></div>
                    <div class="status dFont">My Balance</div>
                  </div>
          
              </div>
            </div></li>
            <li><div class="col-md-u">
              <div class="card small vPan">
               <div class="theme-lighten-5 p-time">
                 <div class="fl Nicon"><i class="md md-cash f-size"></i></div>
                    <div align='right' class="Nrs"><i class="fa fa-inr"></i> <asp:Label ID="Label5" runat="server" Text=""></asp:Label></div>
                    <div class="status dFont">My Topup</div>
                  </div>                  
              </div>
            </div></li>

             <li><div class="col-md-u">
              <div class="card small vPan">
                <div class="theme-lighten-5 p-time">
                 <div class="fl Nicon"><i class="md md-cash f-size"></i></div>
                    <div align='right' class="Nrs"><i class="fa fa-inr"></i> <asp:Label ID="Label6" runat="server" Text=""></asp:Label></div>
                    <div class="status dFont">My Payments</div>
                  </div>                  
              </div>
            </div></a></li>     
        
    </ul>
  
</div>
 </div>
</div>

</asp:Content>

