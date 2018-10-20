using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class Admin_products : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Label1.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from ITEM_CREATION";
            cmd.Connection = con;
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            con.Dispose();
        }
    }
    protected void buttonClick_Click(object sender, EventArgs e)
    {
        objsql.ExecuteNonQuery("insert into ITEM_CREATION (NAME,DP,PV) values('" + txtname.Text.ToUpper() + "','"+txtdp.Text+"','"+txtpv.Text+"')");
            Response.Redirect("products.aspx");
          
    }
}