using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_RewardDetails : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                bind(Request.QueryString["id"].ToString());
            }
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            objsql.ExecuteNonQuery("update tblrewarddetails set rewardsname='" + txtname.Text + "',pair='" + txtpair.Text + "',amount='" + txtamount.Text + "',percentage='" + txtper.Text + "' where id='" + Request.QueryString["id"] + "'");
        }
        else
        {
            objsql.ExecuteNonQuery("insert into tblrewarddetails(rewardsname,pair,amount,percentage) values('" + txtname.Text + "','" + txtpair.Text + "','" + txtamount.Text + "','" + txtper.Text + "')");

        }
        Response.Redirect("view-rewards.aspx");
    }
    protected void bind(string id)
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from tblrewarddetails where id='" + id + "'");
        if (dt.Rows.Count > 0)
        {
            txtname.Text = dt.Rows[0]["rewardsname"].ToString();
            txtpair.Text = dt.Rows[0]["pair"].ToString();
            txtamount.Text = dt.Rows[0]["amount"].ToString();
            txtper.Text = dt.Rows[0]["percentage"].ToString();
        }
    }
}