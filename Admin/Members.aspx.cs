﻿using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Admin_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            con.Open();
            SqlDataAdapter sd = new SqlDataAdapter("select ROW_NUMBER () over (order by m.date_entry) as 'Sr. No.',m.Id,m.NAME,m.MOBILE,m.spon as SPONSER,m.PASS As PASSWORD,convert(varchar,m.DATE_ENTRY,6) as DOJ,(select bal from bal(m.id)) as BAL,(select isnull(sum(amount),0) from wallet where stat='V' and id=m.id) as TOPUP from member_creation m order by m.date_entry", con);
            DataSet ds = new DataSet();
            sd.Fill(ds);
            if (ds != null)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
    }
   
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string Sr = Convert.ToString(GridView1.DataKeys[e.RowIndex].Value);
        Session["id"] = Sr;
        Session["user"] = Sr;
        Response.Redirect("~/client/");
    }





    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        Response.Redirect("profile.aspx?id=" + id);
    }
}