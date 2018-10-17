using System;
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
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select ROW_NUMBER () over (order by w.date_entry) as 'Sr. No.',convert(varchar,w.date_entry,106) as DATE,(select isnull(sum(amount),0) from wallet where stat='B' and id=w.id and date_entry=w.date_entry) as AMOUNT,(select isnull(sum(lbus),0) from flush_out where id=w.id and date_entry=w.date_entry) as 'LEFT FLUSH',(select isnull(sum(rbus),0) from flush_out where id=w.id and date_entry=w.date_entry) as 'RIGHT FLUSH' from wallet w where stat='B' and id=@ID order by w.date_entry";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["id"]);
                cmd.Connection = con;
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
            con.Dispose();
        }
    }
}