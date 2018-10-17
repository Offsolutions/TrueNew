using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


/// <summary>
/// Summary description for cart
/// </summary>
public class cart
{
    SQLHelper objSql = new SQLHelper();
    //int totalprice;
    DataTable CartTable;
    DataRow dr;

    public static string item
    {
        get
        {
            if (HttpContext.Current.Request.Cookies["cartid"] != null)
            {
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
                SqlDataAdapter adp = new SqlDataAdapter("select id,itemcode,productid,description,qty,price,imagefile,total,imagefile2 from tblCart  where cookienumber='" + HttpContext.Current.Request.Cookies["cartid"].Value + "'", con);
                adp.Fill(dt);
                HttpContext.Current.Session["carttable"] = dt;
            }

            if (HttpContext.Current.Session["carttable"] != null)
            {
                DataTable dt = (DataTable) HttpContext.Current.Session["carttable"];
                return dt.Rows.Count.ToString()+" Items";
            }
            else
            {
                return "Empty";
            }

        }
    }

    public static string CartTotalprice
    {
        get
        {
            if (HttpContext.Current.Request.Cookies["cartid"] != null)
            {
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
                SqlDataAdapter adp = new SqlDataAdapter("select id,itemcode,productid,description,qty,price,imagefile,total,imagefile2 from tblCart  where cookienumber='" + HttpContext.Current.Request.Cookies["cartid"].Value + "'", con);
                adp.Fill(dt);
                HttpContext.Current.Session["carttable"] = dt;
            }

            if (HttpContext.Current.Session["carttable"] != null)
            {
                HttpContext.Current.Session["totaltprice"] = 0;
               DataTable CartTable = (DataTable)HttpContext.Current.Session["carttable"];
                foreach (DataRow dr in CartTable.Rows)
                {
                    HttpContext.Current.Session["totaltprice"] = Convert.ToDecimal(HttpContext.Current.Session["totaltprice"]) + Convert.ToDecimal(dr["price"]);
                }
                return HttpContext.Current.Session["totaltprice"].ToString();
            }
            else
            {
                return "0.00";

            }
        }
    }

	public cart()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void CreateBasKate()
    {
        CartTable = new DataTable();
        
        CartTable.Columns.Add("id");
        CartTable.Columns.Add("itemcode");
        CartTable.Columns.Add("productid");
        CartTable.Columns.Add("imagefile");
        CartTable.Columns.Add("description");
        CartTable.Columns.Add("qty");
        CartTable.Columns.Add("Price");
        CartTable.Columns.Add("total");
        CartTable.Columns.Add("imagefile2");
    }

    public int AddItemToCart(string id, string itemcode, int productid, string description, decimal price, int qty, string imagefile, string imagefile2)
    {
       // int flag = 0;
        if (HttpContext.Current.Session["carttable"] == null)
        {
            CreateBasKate();

            if (HttpContext.Current.Request.Cookies["cartid"] != null)
            {

                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
                SqlDataAdapter adp = new SqlDataAdapter("select id,itemcode,productid,description,qty,price,imagefile,total,imagefile2 from tblCart  where cookienumber='" + HttpContext.Current.Request.Cookies["cartid"].Value + "'", con);
                adp.Fill(CartTable);
                HttpContext.Current.Session["carttable"] = CartTable;
            }
        }
        else
            CartTable = (DataTable)HttpContext.Current.Session["carttable"];



        AddProduct(id, itemcode, productid, description, price, qty, imagefile,imagefile2);
        return 0;
    }

    protected void AddProduct(string id, string itemcode,int productid, string description, decimal price, int qty,string imagefile,string imagefile2)
    {
        DataTable dt = new DataTable();
        dr = CartTable.NewRow();
        dr["id"] = id;
        dr["itemcode"] = itemcode;
        dr["productid"] = productid;
        dr["imagefile"] = imagefile;
        dr["description"] = description;
        dr["qty"] = qty;
        dr["price"] = price;
        dr["Total"] = price;
        dr["imagefile2"] = imagefile2;
     
        CartTable.Rows.Add(dr);


        addCartItemToTable(dr);

        HttpContext.Current.Session["carttable"] = CartTable;

    }

    public void RemoveItem(int id)
    {
        if (HttpContext.Current.Session["carttable"] != null)
        {
            CartTable = (DataTable)HttpContext.Current.Session["carttable"];
            objSql.ExecuteNonQuery("delete from tblcart where id=" + id);
        }

        CartTable = GetCart();
        HttpContext.Current.Session["carttable"] = CartTable;
    }


    public string gettotelprice()
        {
            CreateBasKate();

            if (HttpContext.Current.Request.Cookies["cartid"] != null)
            {

                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
                SqlDataAdapter adp = new SqlDataAdapter("select * from tblCart  where cookienumber='" + HttpContext.Current.Request.Cookies["cartid"].Value + "'", con);
                adp.Fill(CartTable);
                HttpContext.Current.Session["carttable"] = CartTable;
            }
            HttpContext.Current.Session["totaltprice"] = 0;
            if (HttpContext.Current.Session["carttable"] != null)
            {
                CartTable = (DataTable)HttpContext.Current.Session["carttable"];
                foreach (DataRow dr in CartTable.Rows)
                {
                    HttpContext.Current.Session["totaltprice"] = Convert.ToDecimal(HttpContext.Current.Session["totaltprice"]) + Convert.ToDecimal(dr["total"]);
                }
            }
            return HttpContext.Current.Session["totaltprice"].ToString();
    }

    public DataTable GetCart()
    {

        if (HttpContext.Current.Session["carttable"] != null)
        {
            gettotelprice();
            return CartTable;
        }
        else
        {
            CreateBasKate();

            if (HttpContext.Current.Request.Cookies["cartid"] != null)
            {

                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
                SqlDataAdapter adp = new SqlDataAdapter("select * from tblCart  where cookienumber='" + HttpContext.Current.Request.Cookies["cartid"].Value + "'", con);
                adp.Fill(CartTable);
                HttpContext.Current.Session["carttable"] = CartTable;
            }
            gettotelprice();
            return CartTable;
        }
        
    }





    protected void addCartItemToTable(DataRow dr)
    {
        string cartId="";
        if (HttpContext.Current.Request.Cookies["cartid"] == null)
        {
            cartId = GenerateRandomCode();
            HttpCookie objCookie = new HttpCookie("cartid");
            objCookie.Value = cartId;

            HttpContext.Current.Response.Cookies.Add(objCookie);
        }
        else
        {
            cartId = HttpContext.Current.Request.Cookies["cartid"].Value.ToString(); 
        }
        string id = dr["productid"].ToString();
        string itemcode = dr["itemcode"].ToString();
        string description = dr["description"].ToString();
        string price = dr["price"].ToString();
        string qty =dr["qty"].ToString();
        string imagefile = dr["imagefile"].ToString();
        string total = dr["total"].ToString();
        string imagefile2 = dr["imagefile2"].ToString();
        objSql.ExecuteNonQuery("insert into tblcart (productid,itemcode,description,price,qty,imagefile,CookieNumber,total,imagefile2) values (" + id + ",'" + 
            itemcode +
            "','" + description + "'," + price + "," + qty + ",'" + imagefile + "','" + cartId + "',"+total+",'"+imagefile2+"')");
         
       


    }

    private string GenerateRandomCode()
    {
        Random random = new Random();
        string s = "";
        for (int i = 0; i < 4; i++)
            s = String.Concat(s, random.Next(10).ToString());
        return s;
    }




}
