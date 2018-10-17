using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Client_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "DOWNLINE";
        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        GridView1.DataSource = cmd.ExecuteReader();
        GridView1.DataBind();
        con.Dispose();
    }
}
