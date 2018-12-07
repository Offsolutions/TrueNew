using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_ewallet : System.Web.UI.Page
{

    SQLHelper objsql = new SQLHelper();
    public int leftpair = 0, rightpair = 0;
    DataTable dt = new DataTable();
    public int  pair = 0, pairincome = 0;
    public string value1 = "", value2 = "";
    public double total = 0.0,bal=0.0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"].ToString() != "" || Session["user"].ToString() != null)
            {
                //pair = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select pintype from pins where pin=(select updatepin from usersnew where regno='" + Session["user"].ToString() + "')")));



                //if (pair == 750)
                //{
                //    pairincome = 100;
                //}
                //else
                //{
                //    pairincome = 100;
                //}
                bind(Session["user"].ToString());
            }




        }
    }
    protected void bind(string reg)
    {
        lblregno.Text = reg.ToString();
        lblname.Text = Common.Get(objsql.GetSingleValue("select name from member_creation where id='" + reg + "'"));
        //leftpair = int.Parse(Common.Get(objsql.GetSingleValue("select leftleg from tblcapping where regno='" + reg + "'")));
        //rightpair = int.Parse(Common.Get(objsql.GetSingleValue("select rightleg from tblcapping where regno='" + reg + "'")));
        income();
        lbltotal.Text = lblincome.Text;
        //  lblptotal.Text = (Convert.ToInt32(lblpincome.Text) * Convert.ToInt32(proposer)).ToString();
        //lbltotal.Text = (Convert.ToInt32(lblstotal.Text) + Convert.ToInt32(lblptotal.Text)).ToString();
        lbltds.Text = ((Convert.ToDouble(lbltotal.Text) * Convert.ToInt32(5)) / Convert.ToInt32(100)).ToString();
        lbladmin.Text = ((Convert.ToDouble(lbltotal.Text) * Convert.ToInt32(10)) / Convert.ToInt32(100)).ToString();
        lblnet.Text = (Convert.ToDouble(lbltotal.Text) - (Convert.ToInt32(lbltds.Text) + Convert.ToInt32(lbladmin.Text))).ToString();
        dt = objsql.GetTable("select * from wallet where id='" + reg + "' and stat='P'");
        if (dt.Rows.Count > 0)
        {
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }
        else
        {
            bal = Convert.ToInt32(lblnet.Text);
        }
    }
    protected void income()
    {
        //DataTable dt2 = new DataTable();
        //dt2 = objsql.GetTable("select * from tblcapping where regno='" + Session["user"] + "'");
        //if (dt2.Rows.Count > 0)
        //{
        //    int left = Convert.ToInt32(dt2.Rows[0]["leftleg"]);
        //    // int cappingleft = Convert.ToInt32(dt2.Rows[0]["cappingleft"]);
        //    //if (cappingleft > left)
        //    //{
        //    //    left = left;
        //    //}
        //    //else
        //    //{
        //    //    left = left - cappingleft;
        //    //}
        //    int right = Convert.ToInt32(dt2.Rows[0]["rightleg"]);
        //    //int cappingright = Convert.ToInt32(dt2.Rows[0]["cappingright"]);
        //    //if (cappingright > right)
        //    //{
        //    //    //  right = right - cappingright;
        //    //}
        //    //else
        //    //{
        //    //    right = right - cappingright;
        //    //}

        //    if ((left >= 2 && right >= 1) || (left >= 1 && right >= 2))
        //    {
        //        if (left < right)
        //        {
        //            lblincome.Text = (left * pairincome).ToString();
        //        }
        //        else if (left == right)
        //        {
        //            left = left - 1;
        //            lblincome.Text = (left * pairincome).ToString();
        //        }
        //        else
        //        {
        //            lblincome.Text = (right * pairincome).ToString();
        //        }

        //    }
        //    else
        //    {
        //        if (left == right)
        //        {
        //            int minus = left - 1;
        //            lblincome.Text = (pairincome * minus).ToString();
        //        }
        //        else if (left < right)
        //        {
        //            int minus = left - 1;
        //            lblincome.Text = (pairincome * minus).ToString();
        //        }
        //        else
        //        {
        //            int minus = right - 1;
        //            lblincome.Text = (pairincome * minus).ToString();
        //        }
        //    }

        //    capping();
        //}
        lblincome.Text = Common.Get(objsql.GetSingleValue("select isnull(sum(amount),0) from wallet where (stat='D' or stat='B') and id='" + Session["user"] + "'"));
    }
    //protected void income()
    //{
    //    DataTable dt2 = new DataTable();
    //    dt2 = objsql.GetTable("select * from legs where regno='" + Session["user"] + "'");
    //    if (dt2.Rows.Count > 0)
    //    {
    //        int left = Convert.ToInt32(dt2.Rows[0]["leftleg"]);
    //        int cappingleft = Convert.ToInt32(dt2.Rows[0]["cappingleft"]);
    //        if (cappingleft > left)
    //        {
    //            left = left;
    //        }
    //        else
    //        {
    //            left = left - cappingleft;
    //        }
    //        int right = Convert.ToInt32(dt2.Rows[0]["rightleg"]);
    //        int cappingright = Convert.ToInt32(dt2.Rows[0]["cappingright"]);
    //        if (cappingright > right)
    //        {
    //            //  right = right - cappingright;
    //        }
    //        else
    //        {
    //            right = right - cappingright;
    //        }

    //        if ((left >= 2 && right >= 1) || (left >= 1 && right >= 2))
    //        {
    //            if (left < right)
    //            {
    //                lblincome.Text = (left * pairincome).ToString();
    //            }
    //            else if (left == right)
    //            {
    //                left = left - 1;
    //                lblincome.Text = (left * pairincome).ToString();
    //            }
    //            else
    //            {
    //                lblincome.Text = (right * pairincome).ToString();
    //            }

    //            //if (left == right)
    //            //{
    //            //    int minus = left - 1;
    //            //    lblincome.Text = (300 * minus).ToString();
    //            //}
    //            //if (left < right)
    //            //{
    //            //    int minus = left - 1;
    //            //    lblincome.Text = (300 * minus).ToString();
    //            //}
    //            //else
    //            //{
    //            //    int minus = right - 1;
    //            //    lblincome.Text = (300 * minus).ToString();
    //            //}

    //        }
    //        else
    //        {
    //            if (left == right)
    //            {
    //                int minus = left - 1;
    //                lblincome.Text = (pairincome * minus).ToString();
    //            }
    //            else if (left < right)
    //            {
    //                int minus = left - 1;
    //                lblincome.Text = (pairincome * minus).ToString();
    //            }
    //            else
    //            {
    //                int minus = right - 1;
    //                lblincome.Text = (pairincome * minus).ToString();
    //            }
    //        }

    //        capping();
    //    }
    //}
    //protected void capping()
    //{
    //    int left = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select cappingleft from legs where regno='" + Session["user"] + "' ")));
    //    int right = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select cappingright from legs where regno='" + Session["user"] + "' ")));
    //    lblcapping.Text = (left + right).ToString();

    //}

    protected void capping()
    {
        int left = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select leftleg from tblcapping where regno='" + Session["user"] + "' ")));
        int right = Convert.ToInt32(Common.Get(objsql.GetSingleValue("select rightleg from tblcapping where regno='" + Session["user"] + "' ")));
        lblcapping.Text = (left + right).ToString();

    }






    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label amt = (Label)e.Item.FindControl("lblamt");
            total += Convert.ToDouble(amt.Text);

        }
        bal = Convert.ToDouble(lblnet.Text) - total;
    }


}