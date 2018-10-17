using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Session["adm"] = null;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select sr from admin where sr=@ID";
        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
        cmd.Connection = con;
        if (Convert.ToString(cmd.ExecuteScalar()).ToUpper() != Convert.ToString(TextBox1.Text.ToUpper()))
        {
            Response.Write("<script>alert('ID not Exist!')</script>");
        }
        else
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select pass from admin where sr=@ID";
            cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
            cmd1.Connection = con;
            if (Convert.ToString(cmd1.ExecuteScalar()).ToUpper() != Convert.ToString(TextBox2.Text.ToUpper()))
            {
                Response.Write("<script>alert('Password not Matched!')</script>");
            }
            else
            {
                Session["adm"] = Convert.ToString(TextBox1.Text.ToUpper());
                Response.Redirect("admin");
            }
        }
        con.Dispose();
    }
}