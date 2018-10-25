
<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Client_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style>
    .Nrs{font-size:20px;}
    .col-md-2 {
    float: left;
    /* padding: 10px; */

}
    .Dash {
    padding: 20px;
    background: menu;
    margin: 10px;
}
    .green {
    background: #27ae60;
}
    .pink {
    background-color: #ff00009e;
}
    .blue {
    background: #3498db;
}
    .yellow {
    background: #ffc61d;
}
</style>
<div class="row no-gutter">
    <div class="col-sm-12 col-md-12 col-lg-12" style="background:#fff;">
    <div class="p-20 clearfix">
        <h4 class="color40"><span> </span> </h4>
    </div>
    </div>
</div>
<div>
          <div class="col-md-12 col-space">
<div id='cssmenu'>
    
    <div class="col-lg-3 col-sm-3 bottom-m3 Dash green">
            <div class="contact-box">
                <div class="contact-icon">
                    <span class="fa fa-user"></span>
                </div>
                <div class="contact-info">
                    <h5>My Direct</h5>
                    <h6>
                        <span id="ctl00_cpmain_leftdr"><asp:Label ID="Label1" runat="server" Text=""></asp:Label></span>
                        </h6>

                </div>
            </div>
        </div>
        
   <div class="col-lg-3 col-sm-3 bottom-m3 Dash pink">
            <div class="contact-box">
                <div class="contact-icon">
                    <span class="fa fa-user"></span>
                </div>
                <div class="contact-info">
                    <h5>My Group</h5>
                    <h6>
                        <span id="ctl00_cpmain_leftdr"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></span>
                        </h6>

                </div>
            </div>
        </div>

        <div class="col-lg-3 col-sm-3 bottom-m3 Dash blue">
            <div class="contact-box">
                <div class="contact-icon">
                    <span class="fa fa-user"></span>
                </div>
                <div class="contact-info">
                    <h5>My Income</h5>
                    <h6>
                        <span id="ctl00_cpmain_leftdr"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></span>
                        </h6>

                </div>
            </div>
        </div>
    <div class="col-lg-3 col-sm-3 bottom-m3 Dash pink">
            <div class="contact-box">
                <div class="contact-icon">
                    <span class="fa fa-user"></span>
                </div>
                <div class="contact-info">
                    <h5>My Balance</h5>
                    <h6>
                        <span id="ctl00_cpmain_leftdr"><asp:Label ID="Label4" runat="server" Text=""></asp:Label></span>
                        </h6>

                </div>
            </div>
        </div>
             <div class="col-lg-3 col-sm-3 bottom-m3 Dash yellow">
            <div class="contact-box">
                <div class="contact-icon">
                    <span class="fa fa-user"></span>
                </div>
                <div class="contact-info">
                    <h5>My Topup</h5>
                    <h6>
                        <span id="ctl00_cpmain_leftdr"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></span>
                        </h6>

                </div>
            </div>
        </div>
    <div class="col-lg-3 col-sm-3 bottom-m3 Dash green">
            <div class="contact-box">
                <div class="contact-icon">
                    <span class="fa fa-user"></span>
                </div>
                <div class="contact-info">
                    <h5>My Payments</h5>
                    <h6>
                        <span id="ctl00_cpmain_leftdr"><asp:Label ID="Label6" runat="server" Text=""></asp:Label></span>
                        </h6>

                </div>
            </div>
        </div>
            

           
       
    
  
</div>
 </div>
</div>

</asp:Content>

