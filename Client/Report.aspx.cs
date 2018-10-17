using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class Admin_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Report";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
            con.Dispose();
        }
    }
}