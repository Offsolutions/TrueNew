using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    string constring = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime ddtime = Convert.ToDateTime(DateTime.Now.AddHours(12).AddMinutes(30));
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(constring))
        {

            using (SqlCommand cmd = new SqlCommand("VAL_DOWNLINE", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PID", 1053);           // sponser id
                cmd.Parameters.AddWithValue("@ID", 1054);                            // node
                cmd.Parameters.Add("@Down", SqlDbType.VarChar, 30);
                cmd.Parameters["@Down"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                string a = cmd.Parameters["@Down"].Value.ToString();

            }

        }
    }
    public string apicall(string url)
    {
        HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
        StreamReader sr = new StreamReader(httpres.GetResponseStream());
        string results = sr.ReadToEnd();
        sr.Close();
        return results;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
       // SendSMS("9780551900", "test");
        string ph = "9780551900";
        string message = "hello222";
        string result = apicall("http://bulksms.antisoftindia.com/api/sendhttp.php?authkey=5040A9l5MkNR5a485965&mobiles=" + ph + "&message=" + message + "&sender=THerbs" + "&route=4 ");
    }
    public string SendSMS(string to, string mesage)
    {
        string stringpost = "authkey=5040A9l5MkNR5a485965" + " &mobiles=" + to + "&message=" + mesage + "&sender=THerbs" + "&route=4 ";
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

            objWebRequest = (HttpWebRequest)WebRequest.Create("http://bulksms.antisoftindia.com/api/sendhttp.php");
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
}