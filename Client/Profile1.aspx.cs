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
            cmd.CommandText = "select  udiocard,udiomobile,btcaddress,bankname,ifsc,acno,pan,aadhar from member_creation where Id=@ID";
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Convert.ToString(Session["Id"]);
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                txtname.Text = dr["udiomobile"].ToString();
                if (Convert.ToString(txtname.Text) != "")
                {
                    txtname.Enabled = false;
                }
                txtmobile.Text = dr["btcaddress"].ToString();
                if (Convert.ToString(txtmobile.Text) != "")
                {
                    txtmobile.Enabled = false;
                }
                TextBox1.Text = dr["udiocard"].ToString();
                if (Convert.ToString(TextBox1.Text) != "")
                {
                    TextBox1.Enabled = false;
                }
                TextBox2.Text = dr["bankname"].ToString();
                if (Convert.ToString(TextBox2.Text) != "")
                {
                    TextBox2.Enabled = false;
                }
                TextBox3.Text = dr["acno"].ToString();
                if (Convert.ToString(TextBox3.Text) != "")
                {
                    TextBox3.Enabled = false;
                }
                TextBox4.Text = dr["ifsc"].ToString();
                if (Convert.ToString(TextBox4.Text) != "")
                {
                    TextBox4.Enabled = false;
                }
                TextBox5.Text = dr["pan"].ToString();
                if (Convert.ToString(TextBox5.Text) != "")
                {
                    TextBox5.Enabled = false;
                }
                TextBox6.Text = dr["aadhar"].ToString();
                if (Convert.ToString(TextBox6.Text) != "")
                {
                    TextBox6.Enabled = false;
                }
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
            cmd.CommandText = "Update Member_Creation Set udiocard=@udiocard,udiomobile=@Name,btcaddress=@Mobile,bankname=@bankname,acno=@acno,ifsc=@ifsc,pan=@pan,aadhar=@aadhar  Where Id= @Id";
            cmd.Connection = con;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Convert.ToString(Session["Id"]);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Convert.ToString(txtname.Text).ToUpper();
            cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = txtmobile.Text.ToUpper();
            cmd.Parameters.Add("@udiocard", SqlDbType.VarChar).Value = TextBox1.Text.ToUpper();
            cmd.Parameters.Add("@bankname", SqlDbType.VarChar).Value = TextBox2.Text.ToUpper();
            cmd.Parameters.Add("@acno", SqlDbType.VarChar).Value = TextBox3.Text.ToUpper();
            cmd.Parameters.Add("@ifsc", SqlDbType.VarChar).Value = TextBox4.Text.ToUpper();
            cmd.Parameters.Add("@pan", SqlDbType.VarChar).Value = TextBox5.Text.ToUpper();
            cmd.Parameters.Add("@aadhar", SqlDbType.VarChar).Value = TextBox6.Text.ToUpper();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            Label1.Visible = true;
            Label1.Text = "Payment Profile Updated Successfully!";
        }
    }
}
