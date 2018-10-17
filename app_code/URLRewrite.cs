using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for URLRewrite
/// </summary>
public class URLRewrite
{
    SQLHelper objSql = new SQLHelper();
	public URLRewrite()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string  Replace(string name)
    {
        name = name.Replace(" ", "-") + ".htm";
        return name;
    }

    
}
