using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnklogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/login.aspx");

    }

    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/login.aspx");
    }
}
