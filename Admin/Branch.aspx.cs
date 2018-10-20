using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_Branch : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Label1.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from BRANCH_CREATION";
            cmd.Connection = con;
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            con.Dispose();
        }
        bindDD();
    }
    public void bindDD()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from DD_CREATION");
        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "Name";
        DropDownList1.DataValueField = "ID";
        DropDownList1.DataBind();
        //DropDownList1.Items.Insert(0, new ListItem("--Select DD--", "0"));

    }

    protected void buttonClick_Click(object sender, EventArgs e)
    {
        objsql.ExecuteNonQuery("insert into BRANCH_CREATION (DD,NAME,PASS) values('"+DropDownList1.SelectedValue+"','" + txtname.Text.ToUpper() + "','" + txtpass.Text.ToUpper() + "')");
        Response.Redirect("Branch.aspx");
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
    }
    }