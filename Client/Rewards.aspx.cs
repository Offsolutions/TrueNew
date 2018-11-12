using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_Rewards : System.Web.UI.Page
{

    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            bind(Session["user"].ToString());
        }
    }
    protected void bind(string regno)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select cnt from cnt_down(@ID,'Left') option (maxrecursion 0)";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Session["user"].ToString();
            cmd.Connection = con;
            lblleft.Text = Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select cnt from cnt_down(@ID,'Right') option (maxrecursion 0)";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Session["user"].ToString();
            cmd.Connection = con;
            lblright.Text = Convert.ToString(cmd.ExecuteScalar());
        }
        dt = objsql.GetTable("select * from tblrewarddetails");
        if (dt.Rows.Count > 0)
        {
            gvpins.DataSource = dt;
            gvpins.DataBind();
        }

    }



    protected void gvpins_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label pins = (Label)e.Item.FindControl("lblpins");
            Label income = (Label)e.Item.FindControl("lblincome");
            HiddenField id = (HiddenField)e.Item.FindControl("hfid");
            LinkButton level = (LinkButton)e.Item.FindControl("lnklevel");
            if (pins.Text == "2:1")
            {
                pins.Text = "1";
            }
            if (Convert.ToInt32(pins.Text) <= Convert.ToInt32(lblleft.Text) && Convert.ToInt32(pins.Text) <= Convert.ToInt32(lblright.Text))
            {
                level.Text = "Achieved";
                income.Text = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + Session["user"].ToString() + "' and rewardname='" + id.Value + "'"));
            }
            else
            {
                level.CssClass = "text-danger";
            }


        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataTable dt2 = new DataTable();
        dt2 = objsql.GetTable("select * from member_creation where id='" + Session["user"].ToString() + "'");
        if (dt2.Rows.Count > 0)
        {
            pnllist.Visible = true;
            // txtreg.Text = txtregid.Text;
            bind(Session["user"].ToString());

        }
        else
        {
            pnllist.Visible = false;

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Data Found')", true);

        }
    }
}