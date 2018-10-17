using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;

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
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select count(*) as PINS from user_pin";
                cmd.Connection = con;
                Label2.Text = Convert.ToString(cmd.ExecuteScalar());
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select count(*) from user_pin where pin in(select pin from member_creation)";
                cmd.Connection = con;
                Label3.Text = Convert.ToString(cmd.ExecuteScalar());
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select u.ID,u.AMOUNT,count(*) as PINS,(select count(*) from user_pin where id=u.id and pin in(select pin from member_creation)) as USED from user_pin u group by u.id,u.amount order by u.id";
                cmd.Connection = con;
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
            con.Dispose();
        }
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
    protected void buttonClick_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select id from member_creation where id=@ID";
        cmd.Parameters.Add("@ID",SqlDbType.VarChar).Value = Convert.ToString(txtUserId.Text.ToUpper());
        cmd.Connection = con;
        if (Convert.ToString(cmd.ExecuteScalar()) != Convert.ToString(txtUserId.Text.ToUpper()))
        {
            Label1.Visible = true;
            Label1.Text = "ID is not Correct!";
        }
        else
        {
            String se, aaa;
            {
                {
                    Random r = new Random();
                    Int32 w = Convert.ToInt32(txtpins.Text);
                    aaa = "";
                    for (int q = 0; q < w; q++)
                    {
                        se = "";
                        for (int i = 0; i < 5; i++)
                        {
                            for (int it = 0; it < 5; it++)
                            {
                                int aa = r.Next(65, 90);
                                char c = Convert.ToChar(aa);
                                se = se + c;
                                aaa = se;
                            }
                            if (i < 4)
                            {
                                se = se + "-";
                            }
                        }
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "select pin from user_pin where pin=@pin";
                        cmd1.Connection = con;
                        cmd1.Parameters.Add("@pin", SqlDbType.VarChar).Value = Convert.ToString(aaa);
                        object k = cmd1.ExecuteScalar();
                        string u = aaa;
                        cmd1.Dispose();
                        if (k != u)
                        {
                            {
                                SqlCommand cmd2 = new SqlCommand();
                                cmd2.CommandText = "insert into user_pin values(@pin,@ID,@amount)";
                                cmd2.Connection = con;
                                cmd2.Parameters.Add("@pin", SqlDbType.VarChar).Value = Convert.ToString(aaa);
                                cmd2.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtUserId.Text.ToUpper());
                                cmd2.Parameters.Add("@amount", SqlDbType.BigInt).Value = Convert.ToInt64(DropDownList1.SelectedValue);
                                cmd2.ExecuteNonQuery();
                            }
                        }
                    }
                }
                string mobile = "";
                {
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandText = "select mobile from member_creation where id=@ID";
                    cmd2.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtUserId.Text.ToUpper());
                    cmd2.Connection = con;
                    mobile = Convert.ToString(cmd2.ExecuteScalar());
                }
                string name = "";
                {
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandText = "select name from member_creation where id=@ID";
                    cmd2.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(txtUserId.Text.ToUpper());
                    cmd2.Connection = con;
                    name = Convert.ToString(cmd2.ExecuteScalar());
                }
                string msg = "Dear " + Convert.ToString(name) + ". " + Convert.ToString(txtpins.Text.ToUpper()) + " pins of Rs. " + Convert.ToString(Convert.ToInt64(txtpins.Text) * Convert.ToInt64(DropDownList1.SelectedValue)) + " are transferred in your account. Kindly visit www.SanjeevaniHerbs.com.";
                string result = apicall("http://login.smsmedia.org/api/mt/SendSMS?user=sherbs&password=sherbs@123&senderid=SHerbs&channel=Trans&DCS=0&flashsms=0&number=91" + mobile + "&text=" + msg + "&route=1");
                Response.Redirect("TransPin.aspx");
            }
        }
        con.Dispose();
    }
}