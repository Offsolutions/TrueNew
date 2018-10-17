
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

[WebService]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class AutoComplete : WebService
{
    public AutoComplete()
    {
    }

    [WebMethod]
    public string[] GetCompletionList(string prefixText, int count)
    {
        if (count == 0)
        {
            count = 10;
        }
        DataTable dt = GetRecords(prefixText);
        List<string> items = new List<string>(count);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string strName = dt.Rows[i][0].ToString();
            items.Add(strName);
        }
        return items.ToArray();
    }

    public DataTable GetRecords(string strName)
    {
        //string strConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //SqlConnection con = new SqlConnection(strConn);
        //SqlCommand cmd = new SqlCommand();
        //cmd.Connection = con;
        //cmd.CommandType = System.Data.CommandType.Text;
        //cmd.Parameters.AddWithValue("@Name", strName);
        //cmd.CommandText = "Select distinct name from tbltemplate where name like '%'+@Name+'%'";
        //DataSet objDs = new DataSet();
        //SqlDataAdapter dAdapter = new SqlDataAdapter();
        //dAdapter.SelectCommand = cmd;
        //con.Open();
        //dAdapter.Fill(objDs);
        //con.Close();
        //return objDs.Tables[0];

     
        string constr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
        SqlConnection con = new SqlConnection(constr);
        
        //string constr = System.Configuration.ConfigurationSettings.AppSettings["ConStr"];
        //SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.Parameters.AddWithValue("@Name", strName);
        cmd.CommandText = "Select (customername+','+customerid+','+mobileno) as customer from tblcustomer where customername like '%'+@Name+'%'";
        DataSet objDs = new DataSet();
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        dAdapter.SelectCommand = cmd;
        con.Open();
        dAdapter.Fill(objDs);
        con.Close();
        return objDs.Tables[0];

    }
}

