using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Transactions;

public partial class Admin_Daily_Reward_Income : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    DataTable dtleg = new DataTable();
    public static string regno = "";
    public static string date = "";
    private static TimeZoneInfo INDIAN_ZONE;
    string constring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    public int count = 0, reg,left=0,right=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            date = indianTime.ToString("yyyy-MM-dd");

            string id = Common.Get(objsql.GetSingleValue("select id from tblrewardstatus where date='" + date + "' and status='1'"));
            if (id == "")
            {
                dailyincome();
            }
            else
            {
                Button1.Visible = false;
            }
            // bind();
        }

    }
    protected void data()
        {
        DataTable dtt = new DataTable();
        dtt = objsql.GetTable("select distinct rewardname from tblrewardincome");
        if (dtt.Rows.Count > 0)
        {
            foreach (DataRow dr in dtt.Rows)
            {
                DataTable dt1 = new DataTable();
                dt1 = objsql.GetTable("select * from tblrewardincome where rewardname='" + dr["rewardname"] + "'");
                if (dt1.Rows.Count > 0)
                {
                    foreach(DataRow drr in dt1.Rows)
                    {
                        string getincome = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where id='" + drr["id"] + "'"));
                        if (getincome != "")
                        {
                            string reward = drr["rewardname"].ToString();
                            double total = (Convert.ToDouble(getincome) + Convert.ToDouble(rewardincome(reward)));
                            objsql.ExecuteNonQuery("update tblrewardincome set rewardincome='" + total + "' where id='"+drr["id"]+"'");
                        }
                    }
                }
            }
            objsql.ExecuteNonQuery("insert into tblrewardstatus (date,status) values('" + date + "','1')");
        }
    }
    protected void bind()
    {
        
            try
            {
                DataTable dt = new DataTable();
                dt = objsql.GetTable("select * from member_creation order by id ");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        
                            reg = Convert.ToInt32(dt.Rows[0]["id"]);
                        regno = Convert.ToString(dt.Rows[0]["id"]);
                        SqlConnection con = new SqlConnection();
                            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                            con.Open();
                            {
                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandText = "select cnt from cnt_down(@ID,'Left') option (maxrecursion 0)";
                                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = reg;
                                cmd.Connection = con;
                                left = Convert.ToInt32(cmd.ExecuteScalar());
                            }
                            {
                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandText = "select cnt from cnt_down(@ID,'Right') option (maxrecursion 0)";
                                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = reg;
                                cmd.Connection = con;
                                right = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            // condition 1
                            //string check = checklevel("1", regno); // check level first paid
                            //if(check!="")
                            //{


                            //}
                            #region Level1
                            if ((left >= 2 && right >= 1) || (left >= 1 && right >= 2))
                            {
                                Boolean income = LevelIncome("6", regno);
                                if (income == true)
                                {
                                    string getincome = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + regno + "' and rewardname='6'"));
                                    if (getincome != "")
                                    {
                                        double total = (Convert.ToDouble(getincome) + Convert.ToDouble(rewardincome("6")));
                                        objsql.ExecuteNonQuery("update tblrewardincome set rewardincome='" + total + "' where regno='" + regno + "' and rewardname='6'");
                                    }


                                }


                            }
                            #endregion

                            // condition 2
                            #region Level 2
                            if ((left >= 10 && right >= 10))
                            {
                                Boolean income = LevelIncome("7", regno);
                                if (income == true)
                                {
                                    string getincome = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + regno + "' and rewardname='7'"));
                                    if (getincome != "")
                                    {
                                        double total = (Convert.ToDouble(getincome) + Convert.ToDouble(rewardincomeNext("7", "10")));
                                        objsql.ExecuteNonQuery("update tblrewardincome set rewardincome='" + total + "' where regno='" + regno + "' and rewardname='7'");
                                    }

                                }

                            }
                            #endregion
                            // condition 3
                            #region Level 3
                            if ((left >= 30 && right >= 30))
                            {
                                Boolean income = LevelIncome("8", regno);
                                if (income == true)
                                {
                                    string getincome = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + regno + "' and rewardname='8'"));
                                    if (getincome != "")
                                    {
                                        double total = (Convert.ToDouble(getincome) + Convert.ToDouble(rewardincomeNext("8", "30")));
                                        objsql.ExecuteNonQuery("update tblrewardincome set rewardincome='" + total + "' where regno='" + regno + "' and rewardname='8'");
                                    }

                                }

                            }
                            #endregion
                            // condition 4
                            #region Level 4
                            if ((left >= 100 && right >= 100))
                            {
                                Boolean income = LevelIncome("9", regno);
                                if (income == true)
                                {
                                    string getincome = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + regno + "' and rewardname='9'"));
                                    if (getincome != "")
                                    {
                                        double total = (Convert.ToDouble(getincome) + Convert.ToDouble(rewardincomeNext("9", "100")));
                                        objsql.ExecuteNonQuery("update tblrewardincome set rewardincome='" + total + "' where regno='" + regno + "' and rewardname='9'");
                                    }

                                }

                            }
                            #endregion
                            // condition 5
                            #region Level 5
                            if ((left >= 200 && right >= 200))
                            {
                                Boolean income = LevelIncome("10", regno);
                                if (income == true)
                                {
                                    string getincome = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + regno + "' and rewardname='10'"));
                                    if (getincome != "")
                                    {
                                        double total = (Convert.ToDouble(getincome) + Convert.ToDouble(rewardincomeNext("10", "200")));
                                        objsql.ExecuteNonQuery("update tblrewardincome set rewardincome='" + total + "' where regno='" + regno + "' and rewardname='10'");
                                    }

                                }

                            }
                            #endregion
                            // condition 6
                            #region Level 6
                            if ((left >= 500 && right >= 500))
                            {
                                Boolean income = LevelIncome("11", regno);
                                if (income == true)
                                {
                                    string getincome = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + regno + "' and rewardname='11'"));
                                    if (getincome != "")
                                    {
                                        double total = (Convert.ToDouble(getincome) + Convert.ToDouble(rewardincomeNext("11", "500")));
                                        objsql.ExecuteNonQuery("update tblrewardincome set rewardincome='" + total + "' where regno='" + regno + "' and rewardname='11'");
                                    }

                                }

                            }
                            #endregion
                            // condition 7
                            #region Level 7
                            if ((left >= 1000 && right >= 1000))
                            {
                                Boolean income = LevelIncome("12", regno);
                                if (income == true)
                                {
                                    string getincome = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + regno + "' and rewardname='12'"));
                                    if (getincome != "")
                                    {
                                        double total = (Convert.ToDouble(getincome) + Convert.ToDouble(rewardincomeNext("12", "1000")));
                                        objsql.ExecuteNonQuery("update tblrewardincome set rewardincome='" + total + "' where regno='" + regno + "' and rewardname='12'");
                                    }

                                }

                            }
                            #endregion
                            // condition 8
                            #region Level 8
                            if ((left >= 2000 && right >= 2000))
                            {
                                Boolean income = LevelIncome("13", regno);
                                if (income == true)
                                {
                                    string getincome = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + regno + "' and rewardname='13'"));
                                    if (getincome != "")
                                    {
                                        double total = (Convert.ToDouble(getincome) + Convert.ToDouble(rewardincomeNext("13", "2000")));
                                        objsql.ExecuteNonQuery("update tblrewardincome set rewardincome='" + total + "' where regno='" + regno + "' and rewardname='13'");
                                    }

                                }

                            }
                            #endregion
                            // condition 9
                            #region Level 9
                            if ((left >= 5000 && right >= 5000))
                            {
                                Boolean income = LevelIncome("14", regno);
                                if (income == true)
                                {
                                    string getincome = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + regno + "' and rewardname='14'"));
                                    if (getincome != "")
                                    {
                                        double total = (Convert.ToDouble(getincome) + Convert.ToDouble(rewardincomeNext("14", "5000")));
                                        objsql.ExecuteNonQuery("update tblrewardincome set rewardincome='" + total + "' where regno='" + regno + "' and rewardname='14'");
                                    }

                                }

                            }
                            #endregion
                            // condition 10
                            #region Level 10
                            if ((left >= 20000 && right >= 20000))
                            {
                                Boolean income = LevelIncome("15", regno);
                                if (income == true)
                                {
                                    string getincome = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + regno + "' and rewardname='15'"));
                                    if (getincome != "")
                                    {
                                        double total = (Convert.ToDouble(getincome) + Convert.ToDouble(rewardincomeNext("15", "20000")));
                                        objsql.ExecuteNonQuery("update tblrewardincome set rewardincome='" + total + "' where regno='" + regno + "' and rewardname='15'");
                                    }

                                }

                            }
                            #endregion
                            // condition 11
                            #region Level 11
                            if ((left >= 50000 && right >= 50000))
                            {
                                Boolean income = LevelIncome("16", regno);
                                if (income == true)
                                {
                                    string getincome = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + regno + "' and rewardname='16'"));
                                    if (getincome != "")
                                    {
                                        double total = (Convert.ToDouble(getincome) + Convert.ToDouble(rewardincomeNext("16", "50000")));
                                        objsql.ExecuteNonQuery("update tblrewardincome set rewardincome='" + total + "' where regno='" + regno + "' and rewardname='16'");
                                    }

                                }

                            }
                            #endregion
                            // condition 12
                            #region Level 12
                            if ((left >= 150000 && right >= 150000))
                            {
                                Boolean income = LevelIncome("17", regno);
                                if (income == true)
                                {
                                    string getincome = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + regno + "' and rewardname='17'"));
                                    if (getincome != "")
                                    {
                                        double total = (Convert.ToDouble(getincome) + Convert.ToDouble(rewardincomeNext("17", "150000")));
                                        objsql.ExecuteNonQuery("update tblrewardincome set rewardincome='" + total + "' where regno='" + regno + "' and rewardname='17'");
                                    }

                                }

                            }
                            #endregion
                            // condition 13
                            #region Level 13
                            if ((left >= 400000 && right >= 400000))
                            {
                                Boolean income = LevelIncome("18", regno);
                                if (income == true)
                                {
                                    string getincome = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + regno + "' and rewardname='18'"));
                                    if (getincome != "")
                                    {
                                        double total = (Convert.ToDouble(getincome) + Convert.ToDouble(rewardincomeNext("18", "400000")));
                                        objsql.ExecuteNonQuery("update tblrewardincome set rewardincome='" + total + "' where regno='" + regno + "' and rewardname='18'");
                                    }

                                }

                            }
                            #endregion


                            objsql.ExecuteNonQuery("insert into tblrewardstatus (date,status) values('" + date + "','1')");

                        
                        //ts.Complete();
                        //ts.Dispose();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Reward Income Submited')", true);
                        dailyincome();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        
    }
    protected string checklevel(string level, string regno)
    {
        string check = Common.Get(objsql.GetSingleValue("select * from tblmasterorder where regno='" + regno + "' and pinlevel='" + level + "'"));
        return check;
    }
    protected string rewardincome(string Level)
    {
        string income = Common.Get(objsql.GetSingleValue("select sum(amount) from tblmasterorder where date='" + date + "'"));
        string percentage = Common.Get(objsql.GetSingleValue("select percentage from tblrewarddetails where id='" + Level + "'"));
        string tax = ((Convert.ToDouble(income) * Convert.ToDouble(percentage) / Convert.ToInt32(100))).ToString();
        string count = objsql.GetSingleValue("select count(*) from tblrewardincome where rewardname='" + Level + "'").ToString();
        string divide = (Convert.ToDouble(tax) / Convert.ToDouble(count)).ToString();
        return divide;
    }
    protected string rewardincomeNext(string Level, string Pair)
    {
        string income = Common.Get(objsql.GetSingleValue("select sum(amount) from tblmasterorder where date='" + date + "'"));
        string percentage = Common.Get(objsql.GetSingleValue("select percentage from tblrewarddetails where id='" + Level + "'"));
        string tax = ((Convert.ToDouble(income) * Convert.ToDouble(percentage) / Convert.ToInt32(100))).ToString();
        string count = LevelNext(Pair);
        string divide = (Convert.ToDouble(tax) / Convert.ToDouble(count)).ToString();
        return divide;
    }

    protected bool LevelIncome(string level, string regno)
    {
        string levelincome = Common.Get(objsql.GetSingleValue("select rewardincome from tblrewardincome where regno='" + regno + "' and   rewardname='" + level + "' "));
        DataTable dtlevel = new DataTable();
        if (levelincome != "")
        {

            dtlevel = objsql.GetTable("select * from tblrewarddetails where id='" + level + "'");
            if (dtlevel.Rows.Count > 0)
            {
                double levelachieveincome = Convert.ToDouble(dtlevel.Rows[0]["amount"]);
                if (Convert.ToDouble(levelincome) <= levelachieveincome)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;
    }
    protected string Levelcount()
    {
        using (SqlConnection con = new SqlConnection(constring))
        {

            using (SqlCommand cmd = new SqlCommand("RewardLevel", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
                cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return cmd.Parameters["@printvalue"].Value.ToString();

            }

        }
    }
    protected string LevelNext(string Level)
    {
        using (SqlConnection con = new SqlConnection(constring))
        {

            using (SqlCommand cmd = new SqlCommand("RewardNext", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
                cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@Level", Level);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return cmd.Parameters["@printvalue"].Value.ToString();

            }

        }
    }
    protected void dailyincome()
    {
        DataTable dt = new DataTable();
        string check = Common.Get(objsql.GetSingleValue("select id from tblrewardstatus where date='" + date + "' and status='1'"));
        if (check != "")
        {

        }
        else
        {
            dt = objsql.GetTable("select * from tblmasterorder where date='" + date + "'");
            if (dt.Rows.Count > 0)
            {
                gvpins.DataSource = dt;
                gvpins.DataBind();
                lblincome.Text = Common.Get(objsql.GetSingleValue("select sum(amount) from tblmasterorder where date='" + date + "'"));

            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (Convert.ToInt32(lblincome.Text) != 0)
        {
            DataTable dt2 = objsql.GetTable("select * from tblrewardstatus where date='" + date + "'");
            if (dt2.Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Reward Income Already Submit On '" + date + "'')", true);
            }
            else
            {
                data();
            }

        }

        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry Today No Income')", true);

        }



    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        date = txtdate.Text;
        
            dailyincome();
        
        
    }
}