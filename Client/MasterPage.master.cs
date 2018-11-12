using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
public partial class Client_MasterPage : System.Web.UI.MasterPage
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["user"] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {
           // string name = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + Session["user"].ToString() + "'"));
           // lblname.Text = "Welcome To " + name;
            lnklogout.Visible = true;
            lnklogin.Visible = false;
            chkstock();
            chksale();
        }
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select name from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd.Connection = con;
            Label2.Text = Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select ID from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd.Connection = con;
            Label1.Text = Convert.ToString(cmd.ExecuteScalar());
        }
        con.Dispose();
    }
    public void chkstock()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from tblAssignstock where regno='" + Session["user"] + "'");
        if (dt.Rows.Count > 0)
        {
            pnlstock.Visible = true;
        }

    }
    public void chksale()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from singleorder where sellerregno='" + Session["user"] + "'");
        if (dt.Rows.Count > 0)
        {
            pnlstock.Visible = true;
        }

    }

}
