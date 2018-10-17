using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Client_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Label1.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select  id,Name,Email,Mobile from member_creation where Id=@ID";
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Convert.ToString(Session["Id"]);
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                txtname.Text = dr["Name"].ToString();
                txtemail.Text = dr["Email"].ToString();
                txtmobile.Text = dr["Mobile"].ToString();
                TextBox1.Text = dr["id"].ToString();
            }
            con.Dispose();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["adm"] != null)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Update Member_Creation Set Name =@Name,Email=@Email ,Mobile=@Mobile  Where Id= @Id";
            cmd.Connection = con;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Convert.ToString(Session["Id"]);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Convert.ToString(txtname.Text).ToUpper();
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtemail.Text;
            cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = txtmobile.Text.ToUpper();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            Label1.Visible = true;
            Label1.Text = "Personal Profile Updated Successfully!";
        }
    }
}
