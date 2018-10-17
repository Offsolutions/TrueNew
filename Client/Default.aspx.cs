using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Client_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select count(*) from member_creation where spon=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd.Connection = con;
            Label1.Text = Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select cnt from cnt_down1(@ID,'A')";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd.Connection = con;
          //  Label2.Text = Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select BAL from BAL(@ID)";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd.Connection = con;
            Label4.Text = Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select isnull(sum(amount-100),0) from wallet where stat='V' and id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd.Connection = con;
            Label5.Text = Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select isnull(sum(amount),0) from wallet where (stat='B' or stat='D' or stat='FC') and id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd.Connection = con;
            Label3.Text = Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select isnull(sum(amount),0) from wallet where (stat='P') and id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd.Connection = con;
            Label6.Text = Convert.ToString(cmd.ExecuteScalar());
        }
        con.Dispose();
    }
}