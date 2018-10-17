using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;

public partial class Admin_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Label1.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            SqlDataAdapter sd = new SqlDataAdapter("select m.ID,m.NAME,m.BANKNAME as BANK,m.ACNO,m.IFSC,(select isnull(sum(amount),0) from wallet where (stat='D' or stat='B') and id=m.id) as AMOUNT,cast((select isnull(sum(amount),0) from wallet where (stat='D' or stat='B') and id=m.id)*.1 as decimal(10,2)) as 'CHG',cast((select isnull(sum(amount),0) from wallet where (stat='D' or stat='B') and id=m.id)*.9 as decimal(10,2)) as NET,(select isnull(sum(amount),0) from wallet where stat='P' and id=m.id) as PAID,((select isnull(sum(amount),0) from wallet where (stat='D' or stat='B') and id=m.id)*.9)-(select isnull(sum(amount),0) from wallet where stat='P' and id=m.id) as 'TO PAY' from member_creation m where (((select isnull(sum(amount),0) from wallet where (stat='D' or stat='B') and id=m.id)*.9)-(select isnull(sum(amount),0) from wallet where stat='P' and id=m.id))>0 order by m.id", con);
            DataSet ds = new DataSet();
            sd.Fill(ds);
            if (ds != null)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
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

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select id from member_creation where id=@sr";
        cmd.Parameters.Add("@sr", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text);
        cmd.Connection = con;
        string aa = Convert.ToString(cmd.ExecuteScalar());
        if (aa != Convert.ToString(TextBox1.Text))
        {
            Label1.Visible = true;
            Label1.Text = "ID not Exist!";
        }
        else
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = "insert into wallet values(@ID,@DATE_ENTRY,@ID2,@AMOUNT,'P')";
            cmd1.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
            cmd1.Parameters.Add("@ID2", SqlDbType.VarChar).Value = Convert.ToString(TextBox3.Text.ToUpper());
            cmd1.Parameters.Add("@DATE_ENTRY", SqlDbType.DateTime).Value = Convert.ToDateTime(DateTime.Now.AddHours(11).AddMinutes(30));
            cmd1.Parameters.Add("@AMOUNT", SqlDbType.BigInt).Value = Convert.ToInt64(TextBox2.Text);
            cmd1.ExecuteNonQuery();
            SqlCommand cmd45 = new SqlCommand();
            cmd45.CommandText = "select name from member_creation where id=@ID";
            cmd45.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
            cmd45.Connection = con;
            SqlCommand cmd451 = new SqlCommand();
            cmd451.CommandText = "select mobile from member_creation where id=@ID";
            cmd451.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(TextBox1.Text.ToUpper());
            cmd451.Connection = con;
            string mobile = Convert.ToString(cmd451.ExecuteScalar());
            string msg = "Dear " + Convert.ToString(cmd45.ExecuteScalar()) + ". Rs." + Convert.ToString(TextBox2.Text)  + "/- has been transferred in your Bank Account. For More Detail visit www.AirwaysAdvertisers.biz.";
            string result = apicall("http://login.smsmedia.org/api/mt/SendSMS?user=jaykaysoftwares@yahoo.com&password=pintu&senderid=Airway&channel=Trans&DCS=0&flashsms=0&number=91" + mobile + "&text=" + msg + "&route=1");
            Response.Redirect("bank.aspx");
        }
        con.Dispose();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string Sr = Convert.ToString(GridView1.DataKeys[e.RowIndex].Value);
        Session["id"] = Sr;
        Response.Redirect("~/Client");
    }
}