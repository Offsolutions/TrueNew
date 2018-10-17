using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net;

public partial class Client_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select pass from member_creation where id=@ID";
        cmd.Parameters.Add("@ID",SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
        cmd.Connection = con;
        if (Convert.ToString(cmd.ExecuteScalar()).ToUpper() != Convert.ToString(TextBox1.Text.ToUpper()))
        {
            Label2.Visible = true;
            Label2.Text = "Old Password is not Correct!";
        }
        else
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "update member_creation set pass=@PASS where id=@ID";
            cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd1.Parameters.Add("@PASS", SqlDbType.VarChar).Value = Convert.ToString(TextBox2.Text.ToUpper());
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();
            Response.Redirect("PwdChg.aspx");
        }
        con.Dispose();
    }
    public string apicall(string url)
    {
        HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
        StreamReader sr = new StreamReader(httpres.GetResponseStream());
        string results = sr.ReadToEnd();
        sr.Close();
        return results;
    }
}
