using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Session["id"] = null;
        }
    }
    public string apicall(string url)
    {
        string results = "";
        try
        {
            HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
            StreamReader sr = new StreamReader(httpres.GetResponseStream());
            results = sr.ReadToEnd();
            sr.Close();
        }
        catch { }
        return results;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
            cmd.Connection = con;
            if (Convert.ToString(cmd.ExecuteScalar()) != Convert.ToString(TextBox1.Text.ToUpper()))
            {
                Response.Write("<script>alert('ID not Exist!')</script>");
            }
            else
            {
                SqlCommand cmd11 = new SqlCommand();
                cmd11.CommandText = "select pass from member_creation where id=@ID";
                cmd11.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
                cmd11.Connection = con;
                if (Convert.ToString(cmd11.ExecuteScalar()).ToUpper() != Convert.ToString(TextBox2.Text.ToUpper()))
                {
                    Response.Write("<script>alert('Password not Matched!')</script>");
                }
                else
                {
                    Session["id"] = Convert.ToString(TextBox1.Text.ToUpper());
                    {
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "select mobile from member_creation where id=@ID";
                        cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
                        cmd1.Connection = con;
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.CommandText = "select name from member_creation where id=@ID";
                        cmd2.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
                        cmd2.Connection = con;
                        SqlCommand cmd3 = new SqlCommand();
                        cmd3.CommandText = "select pass from member_creation where id=@ID";
                        cmd3.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
                        cmd3.Connection = con;
                        string mobile = Convert.ToString(cmd1.ExecuteScalar());
                        string msg = "Dear " + Convert.ToString(cmd2.ExecuteScalar()) + " (" + Convert.ToString(TextBox1.Text.ToUpper()) + "). Welcome to Airways Advertisers, Please Update your KYC. If already updated, kindly ignore this message.";
                        //string result = apicall("http://login.smsmedia.org/api/mt/SendSMS?user=jaykaysoftwares@yahoo.com&password=pintu&senderid=Airway&channel=Trans&DCS=0&flashsms=0&number=91" + mobile + "&text=" + msg + "&route=1");
                    }
                    Response.Redirect("client");
                }
            }
        }
        con.Dispose();
    }
}