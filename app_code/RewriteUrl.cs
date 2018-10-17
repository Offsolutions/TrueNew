using System;
using System.Data;
using System.Web;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;



	/// <summary>
	/// Summary description for RewriteUrl.
	/// </summary>
	public class RewriteUrl
	{
        SQLHelper objSQL = new SQLHelper();

		public RewriteUrl()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void  ChangeUrl(string url)
		{

                string filename = GetRequestedFileName(url);
              
                DataTable dt = GetRetaltedIDAndTable(filename);
                if (dt.Rows.Count > 0)
                {
                                      HttpContext.Current.RewritePath( CreateURL(dt, url));
                }           
		}


      

        public string GetRequestedFileName(string url)
        {
           
            return url.ToString().Substring(url.LastIndexOf("/") + 1);
           
        }

        public DataTable GetRetaltedIDAndTable(string title)
        {
            DataTable dt = new DataTable();
            dt=objSQL.GetTable("select * from links where link='" + title + "'");
           

            return dt;
        
        }

        public string CreateURL(DataTable dt,string url)
        {
            string newurl = "";
            if (dt.Rows[0]["relatedtable"].ToString().ToLower() == "tblbusinesscategory")
                newurl = "category.aspx?bussid=" + dt.Rows[0]["relatedid"].ToString() + "&newurl=" + url;

            if (dt.Rows[0]["relatedtable"].ToString().ToLower() == "tblbusinesssubcategory")
                newurl = "category-detail.aspx?bussid=" + dt.Rows[0]["relatedid"].ToString() + "&newurl=" + url;

           return newurl;

          
        }

	}

