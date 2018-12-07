using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd1 = new SqlCommand();
        
        cmd1.CommandText = "select count(*) from wallet where stat='B' and convert(varchar,date_entry,106)=convert(varchar,@DATE_ENTRY,106)";
        

        cmd1.Parameters.Add("@DATE_ENTRY", SqlDbType.DateTime).Value = Convert.ToDateTime(DateTime.Now.AddHours(12).AddMinutes(30)); 
        cmd1.Connection = con;
        if (Convert.ToInt64(cmd1.ExecuteScalar()) == 0)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BINARYS";

            cmd.Parameters.Add("@DATE_ENTRY", SqlDbType.DateTime).Value = Convert.ToDateTime(DateTime.Now.AddHours(12).AddMinutes(30));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }
        con.Dispose();
    }
}
