using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_RewardLevel : System.Web.UI.Page
{

    SQLHelper objsql = new SQLHelper();
    DataTable dt = new DataTable();
    public static string reg, total;
    public static int totalpurchase = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                reg = Request.QueryString["id"].ToString();
            }
            bind();
        }
    }
    protected void bind()
    {
        string chk = Common.Get(objsql.GetSingleValue("select regno from tblmasterorder where regno='" + reg + "'"));
        if (chk == "")
        {
            //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please puchase first')", true);
        }
        //  int check = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select regno from tblmasterorder where regno='" + Session["user"] + "'")));
        else
        {
            totalpurchase = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select sum(amount) from tblmasterorder where regno='" + reg + "'")));


        }
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select cnt from cnt_down(@ID,'Left') option (maxrecursion 0)";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = reg;
            cmd.Connection = con;
            lblleft.Text =Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select cnt from cnt_down(@ID,'Right') option (maxrecursion 0)";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = reg;
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
            HiddenField sale = (HiddenField)e.Item.FindControl("hfsale");
            LinkButton level = (LinkButton)e.Item.FindControl("lnklevel");
            LinkButton rbtn = (LinkButton)e.Item.FindControl("lnkreward");

            if (totalpurchase >= Convert.ToInt32(sale.Value))
            {
                level.Text = "Purchase";
                level.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                level.Text = "Pending";
                level.ForeColor = System.Drawing.Color.Red;
            }
            if (level.Text == "Purchase")
            {
                string check = Common.Get(objsql.GetSingleValue("select rewardname from tblrewardincome where regno='" + reg + "' and rewardname='" + id.Value + "'"));
                if (check != "")
                {
                    rbtn.Text = "Reward Done";
                    rbtn.Enabled = false;
                    rbtn.CssClass = "btn btn-primary";
                    rbtn.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    rbtn.Text = "Apply Reward";
                    rbtn.CssClass = "btn btn-success";

                }
            }


            //if (Convert.ToInt32(pins.Text) <= Convert.ToInt32(lblleft.Text) && Convert.ToInt32(pins.Text) <= Convert.ToInt32(lblright.Text))
            //{
            //    level.Text = "Achieved";
            //    income.Text = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + Session["user"] + "' and rewardname='" + id.Value + "'"));
            //}
            //else
            //{
            //    level.CssClass = "text-danger";
            //}


        }
    }

    protected void gvpins_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        //string id = (sender as LinkButton).CommandArgument;
        string id = e.CommandArgument.ToString();
        string chk = Common.Get(objsql.GetSingleValue("select regno from tblmasterorder where regno='" + reg + "'"));
        if (e.CommandName == "submit")
        {
            Label pins = (Label)e.Item.FindControl("lblpins");
            string pin = pins.Text;
            if (pin == "2:1")
            {
                pin = "1";
            }
            else
            {

            }
            if ((Convert.ToInt32(pin)) >= (Convert.ToInt32(lblleft.Text)) & (Convert.ToInt32(pin) >= (Convert.ToInt32(lblright.Text))))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Pair are not sufficient')", true);
            }

            else if (chk == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Puchase is not sufficient')", true);
            }
            else
            {
                objsql.ExecuteNonQuery("insert into tblrewardincome (regno,rewardname,rewardincome) values ('" + reg + "','" + id + "','0')");
                bind();
            }
        }
    }
}