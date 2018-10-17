using System;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition","attachment;filename=" + Convert.ToDateTime(DateTime.Now.AddHours(11).AddMinutes(30)) + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE (TABLE_TYPE = 'BASE TABLE') and table_name!='sysdiagrams'";
        cmd.Connection = con;
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            f1(dr[0].ToString());
            f2(dr[0].ToString());
            f3(dr[0].ToString());
        }
        f4("C");
        f4("D");
        f4("P");
        f4("FN");
        f4("R");
        f4("RF");
        f4("TR");
        f4("IF");
        f4("TF");
        f4("V");
        Response.Flush();
        Response.End();
    }
    public void f1(string s)
    {
        string strQuery = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE (TABLE_TYPE = 'BASE TABLE') and table_name='" + s + "'";
        data(strQuery);
    }
    public void f2(string s)
    {
        string strQuery = "SELECT ORDINAL_POSITION, COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + s + "'";
        data(strQuery);
    }
    public void f3(string s)
    {
        string strQuery = "select * From " + s;
        data(strQuery);
    }
    public void f4(string s)
    {
        string strQuery = "SELECT s.name + '.' + o.name AS ProcedureName, c.text AS ProcedureSteps FROM sys.syscomments AS c INNER JOIN sys.objects AS o ON c.id = o.object_id INNER JOIN sys.schemas AS s ON o.schema_id = s.schema_id WHERE (o.type = '" + s + "') AND (s.name LIKE 'olmolm%') ORDER BY ProcedureName, c.colid";
        data(strQuery);
    }
    public void data(string strQuery)
    {
        SqlCommand cmd = new SqlCommand(strQuery);
        DataTable dt = GetData(cmd);
        GridView GridView1 = new GridView();
        GridView1.AllowPaging = false;
        GridView1.DataSource = dt;
        GridView1.DataBind();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridView1.Rows[i].Attributes.Add("class", "textmode");
        }
        GridView1.RenderControl(hw);
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
    }
    private DataTable GetData(SqlCommand cmd)
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            sda.Dispose();
            con.Dispose();
        }
    }
}