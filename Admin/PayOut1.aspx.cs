using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class Admin_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();

        SqlDataAdapter sd = new SqlDataAdapter("select ID,convert(varchar,date_entry,6) as DATE,AMOUNT,cast((amount*5)/90 as decimal(10,2)) as TDS,cast((amount*5)/90 as decimal(10,2)) as CHG,ID2 as 'CHEQUE',cast((amount*100)/90 as decimal(10,2)) as TOTAL from wallet where stat='P' order by date_entry", con);
        DataSet ds = new DataSet();
        sd.Fill(ds);
        if (ds != null)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        con.Dispose();
    }
}
