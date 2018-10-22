using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class excelupdate : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        

        string path = "";
        //product = "";
        if (FileUpload1.HasFile)
        {
            try
            {
                string filename = FileUpload1.FileName;

                path = "~/UploadFile/" + filename;
                FileUpload1.SaveAs(Server.MapPath("~/UploadFile/") + filename);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();

                Page.ClientScript.RegisterStartupScript(typeof(Page), "ControlFocus", "<script> alert('" + message + "')</script>", true);
            }
        }

        DataSet ds = new DataSet();

        OleDbCommand excelCommand = new OleDbCommand(); OleDbDataAdapter excelDataAdapter = new OleDbDataAdapter();

        string excelConnStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath(path) + ";Extended Properties=Excel 12.0;";

        OleDbConnection excelConn = new OleDbConnection(excelConnStr);

        excelConn.Open();
        DataTable dtPatterns = new DataTable();
        excelCommand = new OleDbCommand("select * from [sheet1$]", excelConn);

        excelDataAdapter.SelectCommand = excelCommand;

        excelDataAdapter.Fill(dtPatterns);

        ds.Tables.Add(dtPatterns);
        //using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
        //{

            foreach (DataRow dr in dtPatterns.Rows)
            {
                //try
                //{

                    objsql.ExecuteNonQuery("insert into MEMBER_CREATION Values('" + dr[0] + "','" + dr[1] + "','" + dr[2] + "','" + dr[3] + "','" + dr[4] + "','" + dr[5] + "','" + dr[6] + "','" + dr[7] + "','" + 
                        dr[8] + "','" + dr[9] + "','" + dr[10] + "','" + dr[11] + "','" + dr[12] + "','" + dr[13] + "','" + dr[14] + "','" + dr[15] + "','" + dr[16] + "','" + dr[17] + "','" + dr[18] + "','" + 
                        dr[19] + "','" + dr[20] + "','" + dr[21] + "','" + dr[22] + "','" + dr[23] + "','" + dr[24] + "')");
                 
                //}
                //catch (TransactionException q)
                //{
                //    ts.Dispose();
                //    string msz = q.Message.ToString();
                //    Page.ClientScript.RegisterStartupScript(typeof(Page), "ControlFocus", "<script> alert('" + msz + "')</script>", true);
                //}
            }
        //    ts.Complete();
        //    ts.Dispose();
        //}
      //  data();

    }
    protected void data()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd1 = new SqlCommand();

        cmd1.CommandText = "select count(*) from wallet where stat='B' and convert(varchar,date_entry,106)=convert(varchar,@DATE_ENTRY,106)";
        cmd1.Parameters.Add("@DATE_ENTRY", SqlDbType.DateTime).Value = DropDownList1.SelectedItem.Text;
        DateTime ddtime = Convert.ToDateTime(DateTime.Now.AddHours(12).AddMinutes(30));
        cmd1.Connection = con;
        if (Convert.ToInt64(cmd1.ExecuteScalar()) == 0)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BINARYS";

            cmd.Parameters.Add("@DATE_ENTRY", SqlDbType.DateTime).Value = DropDownList1.SelectedItem.Text;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }
        con.Dispose();
    }
}