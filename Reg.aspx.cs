using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Net;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            TextBox1.Text = Request.QueryString["pin"];
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            {
                SqlCommand cmd21 = new SqlCommand();
                cmd21.CommandText = "select pin from user_pin where pin=@pin and (not pin in(select pin from member_creation))";
                cmd21.Connection = con;
                cmd21.Parameters.Add("@pin", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text).ToUpper();
                if (Convert.ToString(cmd21.ExecuteScalar()).ToUpper() != Convert.ToString(TextBox1.Text).ToUpper())
                {
                    Response.Write("<script>alert('Pin is not Valid!')</script>");
                }
                else
                {
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandText = "select id from member_creation where id=@sr";
                    cmd2.Connection = con;
                    cmd2.Parameters.Add("@sr", SqlDbType.VarChar).Value = Convert.ToString(TextBox2.Text).ToUpper();
                    if (Convert.ToString(cmd2.ExecuteScalar()).ToUpper() != Convert.ToString(TextBox2.Text).ToUpper())
                    {
                        Response.Write("<script>alert('Your Sponsor ID is not Valid!')</script>");
                    }
                    else
                    {
                        Random r = new Random();
                        Int64 id = r.Next(10000, 99999);
                        SqlCommand cmd27 = new SqlCommand();
                        cmd27.CommandText = "select id from member_creation where id=@sr";
                        cmd27.Connection = con;
                        cmd27.Parameters.Add("@sr", SqlDbType.VarChar).Value = Convert.ToString(id).ToUpper();
                        if (Convert.ToString(cmd27.ExecuteScalar()).ToUpper() == Convert.ToString(id).ToUpper())
                        {
                            Response.Write("<script>alert('ID already Exist!')</script>");
                        }
                        else
                        {
                            string side = "";
                            if (RadioButton1.Checked == true)
                            {
                                side = "Left";
                            }
                            else
                            {
                                side = "Right";
                            }
                            string aa;
                            string upleg;
                            aa = Convert.ToString(TextBox2.Text.ToUpper());
                            upleg = aa;
                            while (aa != "")
                            {
                                SqlCommand cmd4 = new SqlCommand();
                                cmd4.CommandText = "select id from member_creation where upleg=@spon and side=@side";
                                cmd4.Parameters.Add("@spon", SqlDbType.VarChar).Value = Convert.ToString(aa);
                                cmd4.Parameters.Add("@side", SqlDbType.VarChar).Value = side;
                                cmd4.Connection = con;
                                aa = Convert.ToString(cmd4.ExecuteScalar());
                                if (aa != "")
                                {
                                    upleg = aa;
                                }
                                cmd4.Dispose();
                            }
                            {
                                Int64 pass = r.Next(100000,999999);
                                {
                                    SqlCommand cmd3 = new SqlCommand();
                                    //cmd3.CommandText = "insert into member_creation values(@id,@pin,@name,@father,@dob,@address,@email,@mobile,@pass,@dateentry,@spon,@BANK,@IFSC,@BANKAC,@pan,'@NOMINEE','@RELATION',@upleg,@side)";
                                    cmd3.CommandText = "insert into member_creation values(@id,@pin,@name,@father,@dob,@address,@email,@mobile,@pass,@dateentry,@spon,@BANKNAME,@IFSC,@ACNO,@pan,@accountholder,'@NOMINEE','@RELATION',@upleg,@side,@UDIOCARD,@UDIOMOBILE,@BTCADDRESS,@AADHAR,@UPGRADE,@bv,@self)";
                                    cmd3.Connection = con;
                                    cmd3.Parameters.Add("@id", SqlDbType.VarChar).Value = Convert.ToString(id);
                                    cmd3.Parameters.Add("@pin", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text).ToUpper();
                                    cmd3.Parameters.Add("@name", SqlDbType.VarChar).Value = Convert.ToString(TextBox3.Text.ToUpper());
                                    cmd3.Parameters.Add("@father", SqlDbType.VarChar).Value = Convert.ToString("");
                                    cmd3.Parameters.Add("@dob", SqlDbType.DateTime).Value = Convert.ToDateTime("5/5/2000");
                                    cmd3.Parameters.Add("@address", SqlDbType.VarChar).Value = Convert.ToString("");
                                    cmd3.Parameters.Add("@email", SqlDbType.VarChar).Value = Convert.ToString("");
                                    cmd3.Parameters.Add("@mobile", SqlDbType.VarChar).Value = Convert.ToString(TextBox4.Text.ToUpper());
                                    cmd3.Parameters.Add("@pass", SqlDbType.VarChar).Value = Convert.ToString(pass);
                                    cmd3.Parameters.Add("@dateentry", SqlDbType.DateTime).Value = Convert.ToDateTime(DateTime.Now.AddHours(12).AddMinutes(30));
                                    cmd3.Parameters.Add("@spon", SqlDbType.VarChar).Value = Convert.ToString(TextBox2.Text.ToUpper());
                                    cmd3.Parameters.Add("@BANKNAME", SqlDbType.VarChar).Value = Convert.ToString("");
                                    cmd3.Parameters.Add("@IFSC", SqlDbType.VarChar).Value = Convert.ToString("");
                                    cmd3.Parameters.Add("@ACNO", SqlDbType.VarChar).Value = Convert.ToString("");
                                    cmd3.Parameters.Add("@pan", SqlDbType.VarChar).Value = Convert.ToString("");
                                    cmd3.Parameters.Add("@accountholder", SqlDbType.VarChar).Value = Convert.ToString("");
                                    cmd3.Parameters.Add("@NOMINEE", SqlDbType.VarChar).Value = Convert.ToString("");
                                    cmd3.Parameters.Add("@RELATION", SqlDbType.VarChar).Value = Convert.ToString("");
                                    cmd3.Parameters.Add("@upleg", SqlDbType.VarChar).Value = Convert.ToString(upleg);
                                    cmd3.Parameters.Add("@side", SqlDbType.VarChar).Value = Convert.ToString(side);
                                    cmd3.Parameters.Add("@UDIOCARD", SqlDbType.VarChar).Value = Convert.ToString("");
                                    cmd3.Parameters.Add("@UDIOMOBILE", SqlDbType.VarChar).Value = Convert.ToString("");
                                    cmd3.Parameters.Add("@BTCADDRESS", SqlDbType.VarChar).Value = Convert.ToString("");
                                    cmd3.Parameters.Add("@AADHAR", SqlDbType.VarChar).Value = Convert.ToString("");
                                    cmd3.Parameters.Add("@UPGRADE", SqlDbType.VarChar).Value = "y";
                                    cmd3.Parameters.Add("@bv", SqlDbType.Int).Value = 0;
                                    cmd3.Parameters.Add("@self", SqlDbType.Int).Value = 0;
                                    cmd3.ExecuteNonQuery();
                                }
                                {
                                    string mobile = Convert.ToString(TextBox4.Text);
                                    string msg = "Dear " + Convert.ToString(TextBox3.Text) + ". Welcome to True Herb India. Your ID is (" + Convert.ToString(id) + ") and Password is (" + Convert.ToString(pass) + "). Thanks for Joining Us. For More Detail visit www.TrueHerbIndia.com.";
                                    string result = apicall("http://sms.officialsms.in/sendSMS?username=TrueHerb&message=" + msg + "&sendername=TUHERB&smstype=TRANS&numbers=" + mobile + "&apikey=ee04a007-060f-4504-b132-752d08fdfcf2");

                                }
                                TextBox2.Text = "";
                                TextBox3.Text = "";
                                TextBox4.Text = "";
                                TextBox1.Text = "";
                                Response.Write("<script>alert('Your ID is : " + id + " and Password is : " + pass + "')</script>");
                            }
                        }
                    }
                }
                con.Dispose();
            }
        }
    }
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd2 = new SqlCommand();
        cmd2.CommandText = "select name from member_creation where id=@sr";
        cmd2.Connection = con;
        cmd2.Parameters.Add("@sr", SqlDbType.VarChar).Value = Convert.ToString(TextBox4.Text);
        //Label2.Text = Convert.ToString(cmd2.ExecuteScalar());
        con.Dispose();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd2 = new SqlCommand();
        cmd2.CommandText = "select name from member_creation where id=@sr";
        cmd2.Connection = con;
        //cmd2.Parameters.Add("@sr", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text);
        //Label3.Text = Convert.ToString(cmd2.ExecuteScalar());
        con.Dispose();
    }
}
