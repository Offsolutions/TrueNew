<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpbread" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">
    <section class="page-section-ptb">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="section-title text-center">
                        <span>We provide high quality services</span>
                        <h3 class="text-center">Get In Touch</h3>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12"><div class="touch-in white-bg">
                    <div class="col-lg-4 col-sm-4 bottom-m3">
                        <div class="contact-box">
                            <div class="contact-icon">
                                <i class="ti-direction-alt text-blue"></i>
                            </div>
                            <div class="contact-info text-center">
                                NEAR RAILWAY FATAK, MAKHU
Teh. Zira, Dist. Ferozpur ( PB )
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-4 bottom-m3">
                        <div class="contact-box">
                            <div class="contact-icon">
                                <i class="ti-headphone-alt text-blue"></i>
                            </div>
                            <div class="contact-info text-center">
                                <h5>	
+91-7707826378</h5>
                                <span>Mon-Fri 8:30am-6:30pm</span>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-4">
                        <div class="contact-box">
                            <div class="contact-icon">
                                <i class="ti-email text-blue"></i>
                            </div>
                            <div class="contact-info text-center">
                                <h5>	
INFO@YOURSNEED.COM</h5>
                                <span>24 X 7 online support</span>
                            </div>
                        </div>
                    </div>
                </div></div>
            </div>
        </div>
    </section>
    <section class="page-section-pb">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h3 class="mb-40">SEND MESSAGE</h3>
                </div>
                <div class="col-lg-12 col-md-12">
                    <div id="formmessage" style="display:none">Success/Error Message Goes Here</div>
                    <form id="contactform" class="gray-form row" role="form" method="post" action="http://themes.potenzaglobalsolutions.com/html/seohub-seo-marketing-social-media-multipurpose-html5-template/php/contact-form.php">
                        <div class="col-lg-6 col-md-6">
                            <div class="form-group">
                                <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Website URL">
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6">
                            <div class="form-group">
                                <input type="email" class="form-control" id="exampleInputphone" placeholder="Your Name">
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6">
                            <div class="form-group">
                                <input type="email" class="form-control" id="exampleInputPassword1" placeholder="Email Adress">
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6">
                            <div class="form-group">
                                <input type="email" class="form-control" id="exampleInputphone1" placeholder="Phone Number">
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12">
                            <div class="form-group">
                                <textarea class="form-control" rows="7" placeholder="Massage"></textarea>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12">
                            <input type="hidden" name="action" value="sendEmail">
                            <button id="submit" name="submit" type="submit" value="Send" class="button"><span>Submit Now</span></button>
                        </div>
                    </form>
                    <div id="ajaxloader" style="display:none"><img class="center-block" src="images/form-loader.gif" alt=""></div> 
                </div>
            </div>
        </div>
    </section>
    <section class="contact-map">
        <div class="container-fluid">
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d13664.320748438891!2d74.98131252081228!3d31.10750325412703!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x391a201e447075fd%3A0x11513a0f008899ef!2sMakhu%2C+Punjab+142044!5e0!3m2!1sen!2sin!4v1525085250165" width="100%" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfooter" Runat="Server">
</asp:Content>

