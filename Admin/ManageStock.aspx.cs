using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageStock : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public string imagename, img, qty = "0";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            txtname.Text = Common.Get(objsql.GetSingleValue("select name from tblproducts where code ='" + Request.QueryString["id"] + "'"));
        }

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            string code = Common.Get(objsql.GetSingleValue("select code from tblstock where code ='" + Request.QueryString["id"] + "'"));
            if (code != "")
            {
                qty = Common.Get(objsql.GetSingleValue("select stock from tblstock where code ='" + Request.QueryString["id"] + "'"));
                int total = Convert.ToInt32(qty) + Convert.ToInt32(txtqty.Text);
                objsql.ExecuteNonQuery("update tblstock set stock='" + total.ToString() + "' where code='" + Request.QueryString["id"] + "'");

            }
            else
            {
                objsql.ExecuteNonQuery("insert into tblstock(code,stock,date) values ('" + Request.QueryString["id"] + "','" + txtqty.Text + "','" + System.DateTime.Now.ToString("MM/dd/yyyy") + "')");
            }
        }

        Response.Redirect("products.aspx");
    }

}