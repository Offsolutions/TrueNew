using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Profile : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                data(Request.QueryString["id"]);
            }
        }
    }
    protected void data(string id)
    {
        dt = objsql.GetTable("select * from member_creation where id='" + id + "' ");
        if (dt.Rows.Count > 0)
        {
            txtacc.Text = dt.Rows[0]["acno"].ToString();
            txtadd.Text = dt.Rows[0]["address"].ToString();
            txtadhar.Text = dt.Rows[0]["aadhar"].ToString();
            txtbname.Text = dt.Rows[0]["bankname"].ToString();
            txtdob.Text = dt.Rows[0]["dob"].ToString();
            txtemail.Text = dt.Rows[0]["email"].ToString();
            txtfname.Text = dt.Rows[0]["father"].ToString();
            txtifsc.Text = dt.Rows[0]["ifsc"].ToString();
            txtmob.Text = dt.Rows[0]["mobile"].ToString();
            txtname.Text = dt.Rows[0]["name"].ToString();
            txtpan.Text = dt.Rows[0]["pan"].ToString();
            txtpass.Text = dt.Rows[0]["pass"].ToString();





        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        objsql.ExecuteNonQuery("update member_creation set name='" + txtname.Text + "',father='" + txtfname.Text + "',dob='" + txtdob.Text + "',address='" + txtadd.Text + "',email='" + txtemail.Text + "',mobile='" + txtmob.Text + "',pass='" + txtpass.Text + "',bankname='" + txtbname.Text + "',ifsc='" + txtifsc.Text + "',acno='" + txtacc.Text + "',pan='" + txtpan.Text + "',aadhar='" + txtadhar.Text + "' where id='" + Request.QueryString["id"] + "'");

    }
}