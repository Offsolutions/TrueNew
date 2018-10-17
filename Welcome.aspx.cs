using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Welcome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != "")
        {
            lblreg.Text = Request.QueryString["id"].ToString();
            lblpass.Text = Request.QueryString["pass"].ToString();
            lblname.Text = Request.QueryString["name"].ToString();
        }
    }
}