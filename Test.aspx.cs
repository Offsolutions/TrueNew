using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["ID"] = "1001";
        //f1();
        bind();
    }
    public void f1()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "DOWNLINE";
        //if (RadioButton1.Checked == true)
        //{
        //    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
        //}
        
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select regno from usersnew where sregno=@ID1 and node='two'";
            cmd1.Parameters.Add("@ID1", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd1.Connection = con;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToString(cmd1.ExecuteScalar());
        
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        GridView1.DataSource = cmd.ExecuteReader();
        GridView1.DataBind();
        con.Dispose();
    }

    protected void bind()
    {
        dt = objsql.GetTable("select * from legs order by regno");
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dd in dt.Rows)
            {
                objsql.ExecuteNonQuery("insert into tblcapping(regno,date,todayleft,todayright,leftleg,rightleg) values('" + dd["regno"] + "','" + System.DateTime.Now + "','0','0','" + dd["leftleg"] + "','" + dd["rightleg"] + "')");
            }
        }

    }
}