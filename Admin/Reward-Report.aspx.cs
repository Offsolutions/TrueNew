using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Reward_Report : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }

    }
    protected void bind()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select m.id,m.name,m.father,m.bankname,acno,ifsc,(select sum(r.rewardincome) from tblrewardincome r where r.regno=m.id) as total,(select sum(paid) from tblpayreward where regno=m.id) as pay,((select sum(rewardincome) from tblrewardincome where regno=m.id) -(select sum(paid) from tblpayreward where regno=m.id) ) as pending from member_creation m , tblrewardincome a where m.id = a.regno order by m.id");
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        objsql.ExecuteNonQuery("insert into tblpayreward (regno,paid,date,mode,chqno) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + System.DateTime.Now + "','','" + TextBox3.Text + "')");
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd45 = new SqlCommand();
        cmd45.CommandText = "select name from member_creation where id=@ID";
        cmd45.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
        cmd45.Connection = con;
        SqlCommand cmd451 = new SqlCommand();
        cmd451.CommandText = "select mobile from member_creation where id=@ID";
        cmd451.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
        cmd451.Connection = con;
        string mobile = Convert.ToString(cmd451.ExecuteScalar());
        string msg = "Dear " + Convert.ToString(cmd45.ExecuteScalar()) + ". Rs." + Convert.ToString(TextBox2.Text) + "/- has been transferred in your Bank Account. For More Detail visit www.trueherb1313.com.";
        //  string result = apicall("http://login.smsmedia.org/api/mt/SendSMS?user=jaykaysoftwares@yahoo.com&password=pintu&senderid=Airway&channel=Trans&DCS=0&flashsms=0&number=91" + mobile + "&text=" + msg + "&route=1");
       // apicall("http://sms.officialsms.in/sendSMS?username=TrueHerb&message=" + msg + "&sendername=TUHERB&smstype=TRANS&numbers=" + mobile + "&apikey=ee04a007-060f-4504-b132-752d08fdfcf2");
        Response.Redirect("reward-report.aspx");

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