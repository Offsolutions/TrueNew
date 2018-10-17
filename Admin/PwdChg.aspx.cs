using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class Client_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string q = "select * from admin where Pass ='" + TextBox1.Text.ToUpper() + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand(q, con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            dr.Close();
            string q1 = "update admin set Pass='" + TextBox2.Text.ToUpper() + "' where pass='" + TextBox1.Text.ToUpper() + "'";
            SqlCommand cmd1 = new SqlCommand(q1, con);
            cmd1.ExecuteNonQuery();
            Label2.Visible = true;
            Label2.Text = "Your Password has been changed";
        }
        else
        {
            Label2.Visible = true;
            Label2.Text = "Your old password is not correct";
        }
        con.Dispose();
        cmd.Dispose();
    }
}
