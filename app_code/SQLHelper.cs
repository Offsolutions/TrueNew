using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Web;
public class SQLHelper
{
    SqlConnection con;
    SqlCommand com;
    SqlDataAdapter da;
    private SqlConnection _connection;
    private SqlCommand _command;
    private SqlDataAdapter _adapter;
    private SqlDataReader _reader;
    private DataSet ds;
    SqlParameter _sqlParameter = new SqlParameter();
    const string passphrase = "password";

    #region DB Connection
    private void OpenConnection()
    {
        if (_connection == null)
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        }
        if (_connection.State == ConnectionState.Closed)
        {
            _connection.Open();
        }
        _command = new SqlCommand();
        _command.Connection = _connection;
    } 
    #endregion

    #region connection closed
    private void CloseConnection()
    {
        SqlConnection.ClearPool(_connection);
        SqlConnection.ClearAllPools();

        if (_connection.State == ConnectionState.Open)
            _connection.Close();
    } 
    #endregion

    #region Constructor
    public SQLHelper()
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con = new SqlConnection(constr);
        com = new SqlCommand();
        com.Connection = con;
        da = new SqlDataAdapter();
        da.SelectCommand = com;
    }

    public SQLHelper(string ConStr)
    {
        con = new SqlConnection(ConStr);
        com = new SqlCommand();
        com.Connection = con;
        da = new SqlDataAdapter();
        da.SelectCommand = com;
    }
    #endregion

    #region GetDataset
    public DataSet GetDataset(string qry)
    {
        com.CommandText = qry;
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    public DataSet GetDataset(SqlCommand com)
    {
        com.Connection = this.con;
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    #endregion

    #region GetTable
    public DataTable GetTable(string qry)
    {
        // try
        //  {
        com.CommandText = qry;
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
        //  }
        //  catch(Exception ex)
        //  {
        //      System.Web.HttpContext.Current.Response.Write(qry);

        //       System.Web.HttpContext.Current.Response.End();
        //      return new DataTable ();

        //  }
    }
    public DataTable GetTable(SqlCommand com)
    {
        com.Connection = this.con;
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    #endregion

    #region GetSingleValue
    public object GetSingleValue(string qry)
    {
        con.Close();
        com.CommandText = qry;
        con.Open();
        object obj = com.ExecuteScalar();
        con.Close();
        return obj;
    }
    public object GetSingleValue(SqlCommand com)
    {
        com.Connection = this.con;
        con.Open();
        object obj = com.ExecuteScalar();
        con.Close();
        return obj;
    }
    #endregion

    #region ExecuteNonQuery
    public void ExecuteNonQuery(string qry)
    {
        //try
        //{
        con.Close();
        com.CommandText = qry;
        con.Open();
        com.ExecuteNonQuery();
        con.Close();
        // }
        // catch (Exception ex)
        // {
        //    System.Web.HttpContext.Current.Response.Write(qry);
        //     System.Web.HttpContext.Current.Response.End();

        //  }
    }

    public int ExecuteNonQuery1(string qry)
    {
        con.Close();
        com.CommandText = qry;
        con.Open();
        return com.ExecuteNonQuery();


    }
    public void ExecuteNonQuery(SqlCommand com)
    {
        com.Connection = this.con;
        con.Open();
        com.ExecuteNonQuery();
        con.Close();
    }
    #endregion

    public int Return_Parameter_NonExecuteQuery(string _procedureName, SqlParameter[] _Parameters, SqlParameter[] _Outputparameter)
    {
        this.OpenConnection();
        SqlParameter _sqlParameter = new SqlParameter();
        SqlParameter _sqlOutputParameter = new SqlParameter();
        _command.CommandType = CommandType.StoredProcedure;
        _command.CommandText = _procedureName;
        if (_command.Parameters.Count > 0)
            _command.Parameters.Clear();
        foreach (SqlParameter LoopVar_Param in _Parameters)
        {
            _sqlParameter = LoopVar_Param;
            _command.Parameters.Add(_sqlParameter);
        }
        foreach (SqlParameter LoopVar_Param in _Outputparameter)
        {
            _sqlOutputParameter = LoopVar_Param;
            _command.Parameters.Add(_sqlOutputParameter);
            _command.Parameters[_sqlOutputParameter.ParameterName].Direction = ParameterDirection.Output;
        }
        _command.ExecuteNonQuery();
        int returnresult = Convert.ToInt32(_command.Parameters[_sqlOutputParameter.ParameterName].Value);
        return returnresult;
    }
    public int ExecuteNonQueryByProc(string _procedureName, SqlParameter[] _Parameters)
    {
        this.OpenConnection();
        SqlParameter _sqlParameter = new SqlParameter();
        _command.CommandType = CommandType.StoredProcedure;
        _command.CommandText = _procedureName;
        if (_command.Parameters.Count > 0)
            _command.Parameters.Clear();
        foreach (SqlParameter LoopVar_Param in _Parameters)
        {
            _sqlParameter = LoopVar_Param;
            _command.Parameters.Add(_sqlParameter);
        }
        int i = _command.ExecuteNonQuery();
        CloseConnection();
        return i;
    }
    public int ExecuteScalerByQuery(string _query)
    {
        try
        {
            this.OpenConnection();
            _command.CommandText = _query;
            int i = (int)_command.ExecuteScalar();
            CloseConnection();
            return i;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
    public DataSet Get_DataSet(string strQry)
    {
        _adapter = new SqlDataAdapter(strQry, con);
        ds = new DataSet();
        _adapter.Fill(ds);
        return ds;
    }

    public void Select(string ProcedureName, ListView list)
    {
       
        try
        {
            con.Open();
            com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = ProcedureName;
            com.Connection = con;

            com.ExecuteNonQuery();
           
           

            SqlDataAdapter da = new SqlDataAdapter(com);

            DataSet ds = new DataSet();

            da.Fill(ds);
            list.DataSource = ds;
            list.DataBind();
            com = null;
        }
        finally
        {
            con.Close();
        }

    }
    public object pages(string id, string column)
    {
        con.Close();
        com = new SqlCommand();
        string query = "select " + column + " from tblPage where id='" + id + "'";
        com.CommandText = query;
        com.Connection = this.con;
        con.Open();
        object obj = com.ExecuteScalar();
        con.Close();
        return obj;


    }
    public void BindDropDownList(string Query, string Display, string Value, DropDownList Combo)
    {
        con.Open();
        com = new SqlCommand();
        com.CommandType = CommandType.Text;
        com.CommandText = Query;
        com.Connection = con;
        _reader = com.ExecuteReader(CommandBehavior.CloseConnection);
        com.Dispose();
        com = null;

        Combo.DataSource = _reader;
        Combo.DataTextField = Display;
        Combo.DataValueField = Value;
        Combo.DataBind();
        Combo.Items.Insert(0, "<-SELECT->");
        Combo.Items[0].Value = "0";
    }
    public void SelectById(string ProcedureName, ListView list,string id)
    {

        try
        {
            
            con.Close();
            con.Open();
            com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = ProcedureName;
            com.Parameters.AddWithValue("@Id", id);
            com.Connection = con;

            com.ExecuteNonQuery();



            SqlDataAdapter da = new SqlDataAdapter(com);

            DataSet ds = new DataSet();

            da.Fill(ds);
            list.DataSource = ds;
            list.DataBind();
            com = null;
        }
        finally
        {
            con.Close();
        }

    }
    public void random(string TableName, string NoOfcolumn ,ListView list)
    {
        con.Close();
        com = new SqlCommand();
        string query = "select  Top " + NoOfcolumn + " * from " + TableName + " where Status='1' ORDER BY NEWID()";
        com.CommandText = query;
        com.Connection = this.con;
        con.Open();
        object obj = com.ExecuteScalar();
        SqlDataAdapter da = new SqlDataAdapter(com);

        DataSet ds = new DataSet();

        da.Fill(ds);
        list.DataSource = ds;
        list.DataBind();
        com = null;
        con.Close();
      //  return obj;


    }
    public void SelectItemById(string ProcedureName, ListView list, string Id)
    {

        try
        {
            con.Open();
            com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = ProcedureName;
            com.Parameters.AddWithValue("@Album_Code", Id);
            com.Connection = con;

            com.ExecuteNonQuery();



            SqlDataAdapter da = new SqlDataAdapter(com);

            DataSet ds = new DataSet();

            da.Fill(ds);
            list.DataSource = ds;
            list.DataBind();
            com = null;
        }
        finally
        {
            con.Close();
        }

    }
    public void menu(string TableName, string NoOfcolumn, ListView list,string condition)
    {
        string query;
        con.Close();
        com = new SqlCommand();
        if (NoOfcolumn == "*")
        {
             query = "select  *  from " + TableName + " where Status='1' and Type='" + condition + "'";
        }
        else
        {
             query = "select  Distinct " + NoOfcolumn + "  from " + TableName + " where Status='1' and Type='" + condition + "'";
        }
        
        com.CommandText = query;
        com.Connection = this.con;
        con.Open();
        object obj = com.ExecuteScalar();
        SqlDataAdapter da = new SqlDataAdapter(com);

        DataSet ds = new DataSet();

        da.Fill(ds);
        list.DataSource = ds;
        list.DataBind();
        com = null;
        con.Close();
        //  return obj;


    }
    public void selectsub(string ProcedureName, ListView list, string Id)
    {

        try
        {
            con.Close();
            con.Open();
            com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = ProcedureName;
            com.Parameters.AddWithValue("@Country", Id);
            com.Connection = con;

            com.ExecuteNonQuery();



            SqlDataAdapter da = new SqlDataAdapter(com);

            DataSet ds = new DataSet();

            da.Fill(ds);
            list.DataSource = ds;
            list.DataBind();
            com = null;
        }
        finally
        {
            con.Close();
        }

    }
    public void selectwithcolumn(string ProcedureName, ListView list, string Id, string column)
    {

        try
        {
            con.Close();
            con.Open();
            com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = ProcedureName;
            com.Parameters.AddWithValue(column, Id);
            com.Connection = con;

            com.ExecuteNonQuery();



            SqlDataAdapter da = new SqlDataAdapter(com);

            DataSet ds = new DataSet();

            da.Fill(ds);
            list.DataSource = ds;
            list.DataBind();
            com = null;
        }
        finally
        {
            con.Close();
        }

    }

    public string EncryptData(string Message)
    {
        byte[] Results;
        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
        TDESAlgorithm.Key = TDESKey;
        TDESAlgorithm.Mode = CipherMode.ECB;
        TDESAlgorithm.Padding = PaddingMode.PKCS7;
        byte[] DataToEncrypt = UTF8.GetBytes(Message);
        try
        {
            ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
            Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
        }
        finally
        {
            TDESAlgorithm.Clear();
            HashProvider.Clear();
        }
        return Convert.ToBase64String(Results);
    }
    public string PopulateBody(string userName, string title, string url, string description)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Thanks.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{UserName}", userName);
        body = body.Replace("{Title}", title);
        body = body.Replace("{Url}", url);
        body = body.Replace("{Description}", description);
        return body;
    }
    public string SendSMS(string User, string sender, string to, string message)
    {
        string stringpost = "key=459EDA8C909B85&campaign=1&routeid=7&type=text&contacts="+to+"&msg="+message+"&senderid=YOURND";
       // string stringpost = "username=" + User + "&message=" + message + "&sendername=" + sender + "&smstype=TRANS&numbers=" + to + "&apikey=0e85ac6f-18fe-4e20-b305-6d7ac9b799ac";
        //Response.Write(stringpost)
        string functionReturnValue = null;
        functionReturnValue = "";

        HttpWebRequest objWebRequest = null;
        HttpWebResponse objWebResponse = null;
        StreamWriter objStreamWriter = null;
        StreamReader objStreamReader = null;

        try
        {
            string stringResult = null;

            objWebRequest = (HttpWebRequest)WebRequest.Create("http://www.sambsms.com/app/smsapi/index.php?");
            //domain name: Domain name Replace With Your Domain  
            objWebRequest.Method = "Post";

            // Response.Write(objWebRequest)

            // Use below code if you want to SETUP PROXY.
            //Parameters to pass: 1. ProxyAddress 2. Port
            //You can find both the parameters in Connection settings of your internet explorer.


            // If You are In the proxy Then You Uncomment the below lines and Enter IP And Port Number


            //System.Net.WebProxy myProxy = new System.Net.WebProxy("192.168.1.108", 6666);
            //myProxy.BypassProxyOnLocal = true;
            //objWebRequest.Proxy = myProxy;

            objWebRequest.ContentType = "application/x-www-form-urlencoded";

            objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
            objStreamWriter.Write(stringpost);
            objStreamWriter.Flush();
            objStreamWriter.Close();

            objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();


            objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();

            objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
            stringResult = objStreamReader.ReadToEnd();
            objStreamReader.Close();
            return (stringResult);
        }
        catch (Exception ex)
        {
            return (ex.ToString());

        }
        finally
        {
            if ((objStreamWriter != null))
            {
                objStreamWriter.Close();
            }
            if ((objStreamReader != null))
            {
                objStreamReader.Close();
            }
            objWebRequest = null;
            objWebResponse = null;

        }
    }
    public string GenerateRandomOTP(int iOTPLength, string[] saAllowedCharacters)
    {

        string sOTP = String.Empty;

        string sTempChars = String.Empty;

        Random rand = new Random();

        for (int i = 0; i < iOTPLength; i++)

        {

            int p = rand.Next(0, saAllowedCharacters.Length);

            sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

            sOTP += sTempChars;

        }

        return sOTP;

    }
    public string uploadfile(FileUpload file)
    { Common com = new Common();
        if (file.HasFile)
        {
            string fileName1 = file.FileName;
            string StdPic = "Achiever" + "_" + com.Generatepass() + "_" + fileName1;
            string filePath2 = HttpContext.Current.Server.MapPath("../uploadimage/" + StdPic);
            file.SaveAs(filePath2);
            return StdPic;
        }
        else
        {
            return "NoImage";
        }
    }
}
