using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Admin_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            SqlDataAdapter sd = new SqlDataAdapter("select ROW_NUMBER () over (order by w.date_entry) as 'Sr. No.',w.DATE_ENTRY as DATE,(select count(*) from wallet where stat='B' and date_entry=w.date_entry and amount>0) as MEMBERS,(select isnull(sum(amount),0) from wallet where stat='B' and date_entry=w.date_entry) as AMOUNT from wallet w where stat='B' group by date_entry order by w.date_entry", con);
            DataSet ds = new DataSet();
            sd.Fill(ds);
            if (ds != null)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
    }
   
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DateTime Sr = Convert.ToDateTime(GridView1.DataKeys[e.RowIndex].Value);
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select ROW_NUMBER () over (order by w.ID) as 'Sr. No.',w.ID,(select isnull(sum(amount),0) from wallet where stat='B' and id=w.id) as AMOUNT,(select isnull(sum(lbus),0) from flush_out where id=w.id and date_entry=w.date_entry) as 'LEFT FLUSH',(select isnull(sum(rbus),0) from flush_out where id=w.id and date_entry=w.date_entry) as 'RIGHT FLUSH' from wallet w where stat='B' and amount>0 and convert(varchar,date_entry,106)=convert(varchar,@DATE,106) order by w.ID";
        cmd.Parameters.Add("@DATE",SqlDbType.DateTime).Value = Sr;
        cmd.Connection = con;
        GridView2.DataSource = cmd.ExecuteReader();
        GridView2.DataBind();
    }
}