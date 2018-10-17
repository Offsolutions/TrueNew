using System;
using System.Transactions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Globalization;

public partial class Registration : System.Web.UI.Page
{

    public static string pin = "", sponser = "", pintype = "", newregno = "", pass = "", lastdata;
    SQLHelper objsql = new SQLHelper();
    string constring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    public static Boolean proposalstatus = false;
    public static int lefdirect = 0, rightdirect = 0, left = 0, right = 0,cappingleft=0,cappingright=0;
    int checkcapping = 0;
    Common cm = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["pin"] != null || Request.QueryString["sponser"] != null)
            {
                //lblsponsername.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + sponser + "'"));
                //lblleafnode.Text = lastnode(sponser);
                //pintype = Common.Get(objsql.GetSingleValue("select pintype from pins where pin='" + pin + "'"));
                //lastdata = lastnode(sponser);
            }
        }
    }

    #region Check Valid Upline
    protected void txtproposerid_TextChanged(object sender, EventArgs e)
    {

        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("VAL_DOWNLINE", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PID", txtproposerid.Text.Trim());         // proposer id
                cmd.Parameters.AddWithValue("@ID", txtsponserid.Text.Trim());                             // sponser id
                cmd.Parameters.Add("@Down", SqlDbType.VarChar, 30);
                cmd.Parameters["@Down"].Direction = ParameterDirection.Output;  // outpur parameter
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                string check = cmd.Parameters["@Down"].Value.ToString();
                if (check == "")
                {
                    lblproposername.Text = "Proposer is Not Vaid in up line";
                }
                else
                {
                    lblproposername.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtproposerid.Text + "'"));
                    proposalstatus = true;
                    lblleafnode.Text = lastnode(sponser);
                }
                //  lblFruitName.Text = "Last Node: " + cmd.Parameters["@printvalue"].Value.ToString();
            }
        }
    }
    #endregion

    protected string lastnode(string sponser)
    {
        using (SqlConnection con = new SqlConnection(constring))
        {

            using (SqlCommand cmd = new SqlCommand("LastNode", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", txtsponserid.Text.Trim());           //sponser id
                cmd.Parameters.AddWithValue("@node", rdonode.SelectedItem.Value);                            //node
                cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
                cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return cmd.Parameters["@printvalue"].Value.ToString();

            }

        }
    }

    protected void rdonode_TextChanged(object sender, EventArgs e)
    {
        lblleafnode.Text = lastnode(sponser);
        // lastdata = lastnode(sponser);
    }

    protected void btnjoin_Click(object sender, EventArgs e)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            try
            {

                // insert in usersnew table
                // sregno= lastnode
                //spillsregno = sponser
                newregno = cm.GenerateRegno();
                pass = cm.Generatepass();
                #region Check capping
                if (sponser != "")
                {
                    string countcapping = "";


                    string grt = System.DateTime.Now.ToString("tt");
                    if (grt == "PM")
                    {
                        string today = System.DateTime.Now.ToString("yyyy-MM-dd");
                        string time = "12:00:00";
                        today = today + " " + time;
                        countcapping = Common.Get(objsql.GetSingleValue("select count(*) from usersnew where spillsregno='" + sponser + "' and joined>='" + today + "'"));

                    }
                    else
                    {
                        string today = System.DateTime.Now.ToString("yyyy-MM-dd 12:00:00");
                        countcapping = Common.Get(objsql.GetSingleValue("select count(*) from usersnew where spillsregno='" + sponser + "' and joined<='" + today + "'"));

                    }
                    if (Convert.ToInt32(countcapping) >= 5)
                    {
                        objsql.ExecuteNonQuery("insert into usersnew(regno,pass,fname,lname,dob,add1,city,pin,state,country,mobile,nomirel,sregno,node,status,joined,grace,spillsregno,updated,updatepin,pintypeid,aadharcard,proposerregno,relation,active,capping) values('" + newregno + "','" + pass + "','" + txtname.Text + "','" + txtrelation.Text + "','" + dob() + "','" + txtadd.Text + "','" + txtcity.Text + "','" + txtpincode.Text + "','" + txtstate.Text + "','" + txtcountry.Text + "','" + txtphn.Text + "','" + txtnominee.Text + "','" + lastnode(sponser) + "','" + rdonode.SelectedItem.Value + "','y','" + DateTime.Now + "','10','" + sponser + "','n','" + txtpin.Text + "','" + pintype + "','" + txtaadhar.Text + "','" + txtproposerid.Text + "','" + ddlrelation.SelectedItem.Text + "','0','1')");
                        #region insert in leg table
                        DataTable capp = new DataTable();
                        capp = objsql.GetTable("select * from legs where regno='" + sponser + "'");
                        if (capp != null)
                        {
                            if (rdonode.SelectedItem.Value == "one")
                            {

                                cappingleft = (Convert.ToInt32(capp.Rows[0]["cappingleft"]) + 1);
                                objsql.ExecuteNonQuery("update legs set cappingleft='" + cappingleft + "' where regno='" + sponser + "'");
                            }
                            else
                            {
                                cappingright = (Convert.ToInt32(capp.Rows[0]["cappingright"]) + 1);
                                objsql.ExecuteNonQuery("update legs set cappingright='" + cappingright + "' where regno='" + sponser + "'");
                            }
                        }
                        else
                        {
                            if (rdonode.SelectedItem.Value == "one")
                            {

                                cappingleft = 1;
                                objsql.ExecuteNonQuery("update legs set cappingleft='" + cappingleft + "' where regno='" + sponser + "'");

                            }
                            else
                            {
                                cappingright = 1;
                                objsql.ExecuteNonQuery("update legs set cappingright='" + cappingright + "' where regno='" + sponser + "'");

                            }
                        }
                        
             //           objsql.ExecuteNonQuery("insert into legs(regno,leftleg,rightleg,leftdirect,rightdirect,status,cappingleft,cappingright)values('" + newregno + "','0','0','0','0','0','"+cappingleft+"','"+cappingright+"')");






                        #endregion
                    }
                    else
                    {
                        objsql.ExecuteNonQuery("insert into usersnew(regno,pass,fname,lname,dob,add1,city,pin,state,country,mobile,nomirel,sregno,node,status,joined,grace,spillsregno,updated,updatepin,pintypeid,aadharcard,proposerregno,relation,active,capping) values('" + newregno + "','" + pass + "','" + txtname.Text + "','" + txtrelation.Text + "','" + dob() + "','" + txtadd.Text + "','" + txtcity.Text + "','" + txtpincode.Text + "','" + txtstate.Text + "','" + txtcountry.Text + "','" + txtphn.Text + "','" + txtnominee.Text + "','" + lastnode(sponser) + "','" + rdonode.SelectedItem.Value + "','y','" + DateTime.Now + "','10','" + sponser + "','n','" + txtpin.Text + "','" + pintype + "','" + txtaadhar.Text + "','" + txtproposerid.Text + "','" + ddlrelation.SelectedItem.Text + "','0','0')");
                        #region insert in leg table
                        

                        objsql.ExecuteNonQuery("insert into legs(regno,leftleg,rightleg,leftdirect,rightdirect,status,cappingleft,cappingright)values('" + newregno + "','0','0','0','0','0','0','0')");






                        #endregion
                    }
                }
                #endregion
                // joining installment
                // objsql.ExecuteNonQuery("insert into installments(regno,installment,amount,dated,paidby) values('" + newregno + "','1','1000','" + DateTime.Now + "','')");
                objsql.ExecuteNonQuery("update pins set status='y', subregno='" + newregno + "' where pin='" + txtpin.Text + "'");
                

                ts.Complete();
                ts.Dispose();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Thank You For Registration ')", true);
                Response.Redirect("welcome.aspx?id=" + newregno + "&pass=" + pass + "&name=" + txtname.Text);

            }
            catch (Exception a)
            {

                string msz = a.Message;
                throw;
            }
        }
    }
    protected string dob()
    {
        return ddlmonth.SelectedItem.Text + "/" + ddlday.SelectedItem.Text + "/" + ddlyear.SelectedItem.Text;
    }

    protected void txtsponserid_TextChanged(object sender, EventArgs e)
    {
        lblsponsername.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtsponserid.Text + "'"));
        sponser = txtsponserid.Text;
        lastdata = lastnode(sponser);
        lblleafnode.Text = lastnode(sponser);
        capping(txtsponserid.Text);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    protected void txtpin_TextChanged(object sender, EventArgs e)
    {
        string pin = Common.Get(objsql.GetSingleValue("select pin from pins where pin='" + txtpin.Text + "' and status='n'"));
        if (pin != "")
        {
            lblstatus.Text = "Pin Available";
        }
        else
        {
            lblstatus.Text = "Pin Not Available";
            btnjoin.Enabled = false;
        }
    }
    public void capping(string sponser)
    {

    }
}