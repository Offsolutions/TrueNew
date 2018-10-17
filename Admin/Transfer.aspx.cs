using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Transfer : System.Web.UI.Page
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
            cmd.CommandText = "select * from TRANSFERTODD";
            cmd.Connection = con;
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            con.Dispose();
        }
        bindDD();
        bindItem();
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
    public void bindItem()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from ITEM_CREATION");
        DropDownList2.DataSource = dt;
        DropDownList2.DataTextField = "Name";
        DropDownList2.DataValueField = "ID";
        DropDownList2.DataBind();
        //DropDownList2.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    protected void buttonClick_Click(object sender, EventArgs e)
    {
        objsql.ExecuteNonQuery("insert into TRANSFERTODD (DATE_ENTRY,DD,ITEM,QTY) values('" + System.DateTime.Now + "','" + DropDownList1.SelectedValue + "','"+DropDownList2.SelectedValue+"','"+txtqty.Text+"')");
        Response.Redirect("Transfer.aspx");
    }
}