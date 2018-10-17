using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

public partial class Client_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            SqlDataAdapter sd = new SqlDataAdapter("select row_number() over (order by pin) as Sr,Pin,Amount as Unit from user_pin where id='" + Session["id"] + "' and (not pin in (select pin from member_creation)) order by pin", con);
            DataSet ds = new DataSet();
            sd.Fill(ds);
            if (ds != null)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            con.Dispose();
            f1();
        }
    }
    public void f1()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        SqlDataAdapter sd = new SqlDataAdapter("select row_number() over (order by (select date_entry from member_creation where pin=u.pin) desc) as Sr,Pin,Amount as Unit ,(select id from member_creation where pin=u.pin) as ID,(select spon from member_creation where pin=u.pin) as SPON,(select date_entry from member_creation where pin=u.pin) as DATE from user_pin u where id='" + Session["id"] + "' and (pin in (select pin from member_creation)) order by (select date_entry from member_creation where pin=u.pin) desc", con);
        DataSet ds = new DataSet();
        sd.Fill(ds);
        if (ds != null)
        {
            GridView2.DataSource = ds;
            GridView2.DataBind();
        }
        con.Dispose();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string Pin = Convert.ToString(GridView1.DataKeys[e.RowIndex].Value);
        Response.Write("<script>window.open('../Reg.aspx?pin=" + Pin + "','_blank')</script>");
    }
}