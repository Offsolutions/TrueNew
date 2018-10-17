using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public static string date = "";
    private static TimeZoneInfo INDIAN_ZONE;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dt = objsql.GetTable("select * from achiever");
            //if (dt.Rows.Count > 0)
            //{
            //    lvac.DataSource = dt;
            //    lvac.DataBind();
            //}
            //dt = objsql.GetTable("select * from latestnews");
            //if (dt.Rows.Count > 0)
            //{
            //    ListView1.DataSource = dt;
            //    ListView1.DataBind();
            //}


            INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            date = indianTime.ToString("HH");

        }
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