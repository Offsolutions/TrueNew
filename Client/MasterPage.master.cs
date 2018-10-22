using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
public partial class Client_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select name from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd.Connection = con;
            Label2.Text = Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select ID from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd.Connection = con;
            Label1.Text = Convert.ToString(cmd.ExecuteScalar());
        }
        con.Dispose();
    }
}
