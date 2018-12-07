using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_SaleProduct : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public DataTable MyDT = new DataTable();
    public DataTable MyTABLE = new DataTable();
    DataRow MyRow;
    string constring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    int id = 0, total = 0, qty2 = 0, pvpr = 0;
    public static string invoice = "", check = "", code = "", user;
    public static int cnt = 0;
    Common cm = new Common();
    public static string date = "", qnnty = "0";
    private static TimeZoneInfo INDIAN_ZONE;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (cnt == 0)
            {
                Session["DataTable"] = "";

                invoice = cm.Generatepass();
            }
            else
            {

            }
            user = Session["user"].ToString();
        }

    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchCustomers(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {


                //"select name from tblproducts where " +
                //  "name like @SearchText + '%'";
                cmd.CommandText = "select p.name from tblproducts p join tblAssignstock assign on p.code=assign.code and assign.regno='" + user + "' and " +
                "p.name like @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", prefixText);
                cmd.Connection = conn;
                conn.Open();
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["name"].ToString());
                    }
                }
                conn.Close();
                return customers;
            }

        }
    }
    protected void bindtotal()
    {
        foreach (GridViewRow gr in GridView1.Rows)
        {
            Label tot = (Label)gr.FindControl("total");
            total += Convert.ToInt32(tot.Text);
            lbltotal.Text = total.ToString();

            Label pvtot = (Label)gr.FindControl("pvtotal");
            pvpr += Convert.ToInt32(pvtot.Text);
            lblpvtotal.Text = pvpr.ToString();
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
        date = indianTime.ToString("MM/dd/yyyy");
        objsql.ExecuteNonQuery("insert into tblmasterorder(purchaseid,regno,amount,sellerregno,status,Date) values('" + invoice + "','" + txtregno.Text + "','" + lbltotal.Text + "','" + Session["user"] + "','1','" + date + "')");

        foreach (GridViewRow gr in GridView1.Rows)
        {
            HiddenField item = (HiddenField)gr.FindControl("hfid");
            HiddenField qty = (HiddenField)gr.FindControl("qty");

            objsql.ExecuteNonQuery("insert into singleorder(purchaseid,date,regno,item,qty,sellerregno) values('" + invoice + "','" + date + "','" + txtregno.Text + "','" + item.Value + "','" + qty.Value + "','" + Session["user"] + "')");

            string stock = Common.Get(objsql.GetSingleValue("select stock from tblAssignstock where code ='" + code + "' and regno='" + Session["user"] + "'"));
            string dedqty = ((Convert.ToInt32(stock)) - (Convert.ToInt32(qty.Value))).ToString();
            objsql.ExecuteNonQuery("update tblAssignstock set stock='" + dedqty + "' where code ='" + code + "' and regno='" + Session["user"] + "'");

        }
        cnt = 0;
        DataTable dtr = new DataTable();
        dtr = objsql.GetTable("select bv,self,side,upleg from member_creation where id='" + txtregno.Text + "'");
        string pv = dtr.Rows[0]["bv"].ToString();
        string self = dtr.Rows[0]["self"].ToString();
        string side = dtr.Rows[0]["side"].ToString();
        string upleg = dtr.Rows[0]["upleg"].ToString();
        int selftotal = (Convert.ToInt32(self) + Convert.ToInt32(lblpvtotal.Text));
        objsql.ExecuteNonQuery("update member_creation set self='" + selftotal.ToString() + "' where id='" + txtregno.Text + "'");
        using (SqlConnection con = new SqlConnection(constring))
        {

            using (SqlCommand cmd = new SqlCommand("EveryNode", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", txtregno.Text);           // sponser id
                cmd.Parameters.AddWithValue("@node", side);                            // node
                cmd.Parameters.AddWithValue("@checkid", txtregno.Text);
                cmd.Parameters.AddWithValue("@bvp", lblpvtotal.Text);
                cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
                cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        Response.Redirect("salehistory.aspx");

    }

    protected void txtregno_TextChanged(object sender, EventArgs e)
    {
        lblname.Text = Common.Get(objsql.GetSingleValue("select name from member_creation where id='" + txtregno.Text + "'"));
        cnt = 0;
    }

    //public void checkqty()
    //{
    //    code = Common.Get(objsql.GetSingleValue("select code from tblproducts where name='" + txtname.Text + "'"));
    //    check = Common.Get(objsql.GetSingleValue("select stock from tblAssignstock where code='" + code + "' and regno='" + Session["user"].ToString() + "'"));
    //    if (Convert.ToInt32(check) < Convert.ToInt32(txtqty.Text))
    //    {
    //        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Only " + check + " stock is left');", true);
    //        // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only " + check + " stock is left')", true);
    //    }
    //}

    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        code = Common.Get(objsql.GetSingleValue("select code from tblproducts where name='" + txtname.Text + "'"));
        check = Common.Get(objsql.GetSingleValue("select stock from tblAssignstock where code='" + code + "' and regno='" + Session["user"].ToString() + "'"));
        if (cnt != 0)
        {
            MyTABLE = (DataTable)Session["DataTable"];

            foreach (DataRow dtrow in MyTABLE.Rows)
            {
                if (code == dtrow["Code"].ToString())
                {
                    qnnty = ((Convert.ToInt32(dtrow["Quantity"].ToString())) + (Convert.ToInt32(txtqty.Text))).ToString();
                }
            }
        }
        else
        {
            qnnty = txtqty.Text;
        }
        if (Convert.ToInt32(check) < Convert.ToInt32(qnnty))
        {
            txtqty.Text = "";
            qnnty = "0";
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Only " + check + " stock is left');", true);
            // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only " + check + " stock is left')", true);
        }
        else
        {
            //if (Convert.ToInt32(check) >= Convert.ToInt32(txtqty.Text))
            //{

            if (cnt == 0)
            {
                //if (Session["DataTable"] == "" && Session["DataTable"]!=null)
                //{

                MyDT.Columns.Add("id", System.Type.GetType("System.Int32"));

                MyDT.Columns.Add("Name");

                MyDT.Columns.Add("Quantity");
                MyDT.Columns.Add("Price");
                MyDT.Columns.Add("PV");
                MyDT.Columns.Add("Total");
                MyDT.Columns.Add("PVTotal");
                MyDT.Columns.Add("pid");
                MyDT.Columns.Add("Code");
                MyDT.Columns.Add();

                MyRow = MyDT.NewRow();

                MyRow[0] = MyDT.Rows.Count + 1;

                MyRow[1] = txtname.Text;

                MyRow[2] = txtqty.Text;
                MyRow[3] = Common.Get(objsql.GetSingleValue("select Dp from tblproducts where code='" + code + "'"));
                MyRow[4] = Common.Get(objsql.GetSingleValue("select pv from tblproducts where code='" + code + "'"));
                MyRow[5] = (Convert.ToInt32(MyRow[3]) * Convert.ToInt32(MyRow[2]));
                MyRow[6] = (Convert.ToInt32(MyRow[4]) * Convert.ToInt32(MyRow[2]));
                MyRow[7] = Common.Get(objsql.GetSingleValue("select id from tblproducts where code='" + code + "'"));
                MyRow[8] = code;
                MyDT.Rows.Add(MyRow);


                Session["DataTable"] = MyDT;
                cnt += 1;

            }

            else
            {
                MyDT = (DataTable)Session["DataTable"];
                string pccode = null;
                foreach (DataRow dtr in MyDT.Rows)
                {
                    if (code == dtr["Code"].ToString())
                    {
                        pccode = "already";
                        int qt = (Convert.ToInt32(MyDT.Rows[0][2].ToString()) + Convert.ToInt32(txtqty.Text));

                        DataRow dr = dtr;
                        dr["Quantity"] = qt.ToString();
                        dr["Price"] = Common.Get(objsql.GetSingleValue("select Dp from tblproducts where code='" + code + "'"));
                        dr["PV"] = Common.Get(objsql.GetSingleValue("select pv from tblproducts where code='" + code + "'"));
                        dr["Total"] = (Convert.ToInt32(dr["Price"].ToString()) * Convert.ToInt32(qt));
                        dr["PVTotal"] = (Convert.ToInt32(dr["PV"].ToString()) * Convert.ToInt32(qt));
                        MyDT.AcceptChanges();
                    }
                }

                if (pccode != null)
                {


                }
                else
                {
                    MyDT = (DataTable)Session["DataTable"];
                    MyRow = MyDT.NewRow();

                    MyRow[0] = MyDT.Rows.Count + 1;

                    MyRow[1] = txtname.Text;

                    MyRow[2] = txtqty.Text;
                    MyRow[3] = Common.Get(objsql.GetSingleValue("select Dp from tblproducts where code='" + code + "'"));
                    MyRow[4] = Common.Get(objsql.GetSingleValue("select pv from tblproducts where code='" + code + "'"));
                    MyRow[5] = (Convert.ToInt32(MyRow[3]) * Convert.ToInt32(MyRow[2]));
                    MyRow[6] = (Convert.ToInt32(MyRow[4]) * Convert.ToInt32(MyRow[2]));
                    MyRow[7] = Common.Get(objsql.GetSingleValue("select id from tblproducts where code='" + code + "'"));
                    MyRow[8] = code;
                    MyDT.Rows.Add(MyRow);
                }

                Session["DataTable"] = MyDT;
            }
            GridView1.DataSource = MyDT;
            GridView1.DataBind();
            bindtotal();
            Button1.Visible = true;
            txtname.Text = "";
            txtqty.Text = "";

        }

        //else
        //{
        //    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Only " + check + " stock is left');", true);
        //    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only " + check + " stock is left')", true);
        //}

    }
}