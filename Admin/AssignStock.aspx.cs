using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AssignStock : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    //string constring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchProduct(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["con"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select name from tblproducts where " +
                "name like @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", prefixText);
                cmd.Connection = conn;
                conn.Open();
                List<string> products = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        products.Add(sdr["name"].ToString());
                    }
                }
                conn.Close();
                return products;
            }
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        if (txtname.Text != null)
        {
            lblproduct.Text = Common.Get(objsql.GetSingleValue("select code from tblproducts where name='" + txtname.Text + "'"));
        }
        int qty = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select stock from tblstock where code ='" + lblproduct.Text + "'")));
        if (qty < Convert.ToInt32(txtqty.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only " + qty + " stock is left')", true);
        }
        else
        {
            string preval = Common.Get(objsql.GetSingleValue("select stock from tblAssignstock where regno='" + txtuser.Text + "' and code='" + lblproduct.Text + "'"));
            if (preval != null && preval != "")
            {
                int latest = Convert.ToInt32(preval) + Convert.ToInt32(txtqty.Text);
                objsql.ExecuteNonQuery("update tblAssignstock set stock='" + latest.ToString() + "' where regno='" + txtuser.Text + "' and code='" + lblproduct.Text + "'");
            }
            else
            {
                objsql.ExecuteNonQuery("insert into tblAssignstock(regno,code,stock,date) Values('" + txtuser.Text + "','" + lblproduct.Text + "','" + txtqty.Text + "','" + System.DateTime.Now.ToString("MM/dd/yyyy") + "')");
            }
            int total = Convert.ToInt32(qty) - Convert.ToInt32(txtqty.Text);
            objsql.ExecuteNonQuery("update tblstock set stock='" + total.ToString() + "' where code='" + lblproduct.Text + "'");
        }
        txtqty.Text = "";
        txtname.Text = "";
    }

    protected void txtuser_TextChanged(object sender, EventArgs e)
    {
        lbluser.Text = Common.Get(objsql.GetSingleValue("select name from member_creation where id='" + txtuser.Text + "'"));
    }
}