using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Client_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label17.Visible = false;
        Label18.Visible = false;
        Label19.Visible = false;
        Label20.Visible = false;
        Label21.Visible = false;
        Label22.Visible = false;
        if (Page.IsPostBack == false)
        {
            Tree(Convert.ToString(Session["id"]));
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton1.Text));
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton3.Text));
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton2.Text));
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton4.Text));
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton5.Text));
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Tree(Convert.ToString(LinkButton6.Text));
    }
    public void Tree(string Sr)
    {
        Image1.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_black.png";
        Image3.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_black.png";
        Image6.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_black.png";
        Image9.ImageUrl = "../dashboard/assets/udio_web/assets/../dashboard/assets/udio_web/assets/img/user_black.png";
        Image12.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_black.png";
        Image15.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_black.png";
        Image18.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_black.png";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select cnt from cnt_down(@ID,'Left') option (maxrecursion 0)";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            Label23.Text = "Left IDs : " + Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select cnt_bus from cnt_down(@ID,'Left') option (maxrecursion 0)";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            Label23.Text = Label23.Text + "<br>Left Business : " + Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select cnt_bus-(select isnull(sum(lbus),0) from flush_out where id=@ID) from cnt_down(@ID,'Left') option (maxrecursion 0)";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            Label23.Text = Label23.Text + "<br>Left New Business : " + Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select cnt from cnt_down(@ID,'Right') option (maxrecursion 0)";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            Label25.Text = "Right IDs : " + Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select cnt_bus from cnt_down(@ID,'Right') option (maxrecursion 0)";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            Label25.Text = Label25.Text + "<br>Right Business : " + Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select cnt_bus-(select isnull(sum(rbus),0) from flush_out where id=@ID) from cnt_down(@ID,'Right') option (maxrecursion 0)";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            Label25.Text = Label25.Text + "<br>Right New Business : " + Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select id from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            Label8.Text = Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select name from member_creation where id=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            Label8.Text = Label8.Text + "<br>" + Convert.ToString(cmd.ExecuteScalar());
        }
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select isnull(sum(amount),0) from wallet where id=@ID and stat='V'";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Connection = con;
            if (Convert.ToInt64(cmd.ExecuteScalar()) == 0)
            {
                Image1.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_red.png";
            }
            if (Convert.ToInt64(cmd.ExecuteScalar()) == 1100)
            {
                Image1.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_green.png";
            }
            if (Convert.ToInt64(cmd.ExecuteScalar()) == 5100)
            {
                Image1.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_blue.png";
            }
            SqlCommand cmd5 = new SqlCommand();
            cmd5.CommandText = "select count(*) from wallet where id=@ID and stat='F'";
            cmd5.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd5.Connection = con;
            if (Convert.ToInt64(cmd5.ExecuteScalar()) == 1)
            {
                Image1.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_gold.png";
            }
        }
        {
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select id from member_creation where upleg=@ID and side='Left'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                LinkButton1.Text = Convert.ToString(cmd.ExecuteScalar());
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select name from member_creation where upleg=@ID and side='Left'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                Label10.Text = Convert.ToString(cmd.ExecuteScalar());
                //Label10.Text = "";
            }
            {
                SqlCommand cmd11 = new SqlCommand();
                cmd11.CommandText = "select isnull(sum(amount),0) from wallet where id=(select id from member_creation where upleg=@ID and side='Left') and stat='V'";
                cmd11.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd11.Connection = con;
                if (Convert.ToInt64(cmd11.ExecuteScalar()) == 0)
                {
                    Image3.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_red.png";
                }
                if (Convert.ToInt64(cmd11.ExecuteScalar()) == 1100)
                {
                    Image3.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_green.png";
                }
                if (Convert.ToInt64(cmd11.ExecuteScalar()) == 5100)
                {
                    Image3.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_blue.png";
                }
                SqlCommand cmd5 = new SqlCommand();
                cmd5.CommandText = "select count(*) from wallet where id=(select id from member_creation where upleg=@ID and side='Left') and stat='F'";
                cmd5.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd5.Connection = con;
                if (Convert.ToInt64(cmd5.ExecuteScalar()) == 1)
                {
                    Image3.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_gold.png";
                }
                SqlCommand cmd12 = new SqlCommand();
                cmd12.CommandText = "select count(*) from member_creation where id=(select id from member_creation where upleg=@ID and side='Left')";
                cmd12.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd12.Connection = con;
                if (Convert.ToInt64(cmd12.ExecuteScalar()) == 0)
                {
                   // Image3.ImageUrl = "../img/user_black.png";
                    Image3.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_black.png";
                }
            }
        }
        {
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select id from member_creation where upleg=@ID and side='Right'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                LinkButton4.Text = Convert.ToString(cmd.ExecuteScalar());
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select name from member_creation where upleg=@ID and side='Right'";
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd.Connection = con;
                Label11.Text = Convert.ToString(cmd.ExecuteScalar());
                //Label11.Text = "";
            }
            {
                SqlCommand cmd11 = new SqlCommand();
                cmd11.CommandText = "select isnull(sum(amount),0) from wallet where id=(select id from member_creation where upleg=@ID and side='Right') and stat='V'";
                cmd11.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd11.Connection = con;
                if (Convert.ToInt64(cmd11.ExecuteScalar()) == 0)
                {
                    Image6.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_red.png";
                }
                if (Convert.ToInt64(cmd11.ExecuteScalar()) == 1100)
                {
                    Image6.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_green.png";
                }
                if (Convert.ToInt64(cmd11.ExecuteScalar()) == 5100)
                {
                    Image6.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_blue.png";
                }
                SqlCommand cmd5 = new SqlCommand();
                cmd5.CommandText = "select count(*) from wallet where id=(select id from member_creation where upleg=@ID and side='Right') and stat='F'";
                cmd5.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd5.Connection = con;
                if (Convert.ToInt64(cmd5.ExecuteScalar()) == 1)
                {
                    Image6.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_gold.png";
                }
                SqlCommand cmd12 = new SqlCommand();
                cmd12.CommandText = "select count(*) from member_creation where id=(select id from member_creation where upleg=@ID and side='Right')";
                cmd12.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                cmd12.Connection = con;
                if (Convert.ToInt64(cmd12.ExecuteScalar()) == 0)
                {
                    Image6.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_black.png";
                }
            }
        }
        {
            {
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Left'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    LinkButton2.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select name from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Left'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    Label12.Text = Convert.ToString(cmd.ExecuteScalar());
                    //Label12.Text = "";
                }
                {
                    SqlCommand cmd11 = new SqlCommand();
                    cmd11.CommandText = "select isnull(sum(amount),0) from wallet where id=(select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Left') and stat='V'";
                    cmd11.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd11.Connection = con;
                    if (Convert.ToInt64(cmd11.ExecuteScalar()) == 0)
                    {
                        Image9.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_red.png";
                    }
                    if (Convert.ToInt64(cmd11.ExecuteScalar()) == 1100)
                    {
                        Image9.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_green.png";
                    }
                    if (Convert.ToInt64(cmd11.ExecuteScalar()) == 5100)
                    {
                        Image9.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_blue.png";
                    }
                    SqlCommand cmd5 = new SqlCommand();
                    cmd5.CommandText = "select count(*) from wallet where id=(select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Left') and stat='F'";
                    cmd5.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd5.Connection = con;
                    if (Convert.ToInt64(cmd5.ExecuteScalar()) == 1)
                    {
                        Image9.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_gold.png";
                    }
                    SqlCommand cmd12 = new SqlCommand();
                    cmd12.CommandText = "select count(*) from member_creation where id=(select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Left')";
                    cmd12.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd12.Connection = con;
                    if (Convert.ToInt64(cmd12.ExecuteScalar()) == 0)
                    {
                        Image9.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_black.png";
                    }
                }
            }
            {
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Right'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    LinkButton3.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select name from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Right'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    Label13.Text = Convert.ToString(cmd.ExecuteScalar());
                    //Label13.Text = "";
                }
                {
                    SqlCommand cmd11 = new SqlCommand();
                    cmd11.CommandText = "select isnull(sum(amount),0) from wallet where id=(select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Right') and stat='V'";
                    cmd11.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd11.Connection = con;
                    if (Convert.ToInt64(cmd11.ExecuteScalar()) == 0)
                    {
                        Image12.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_red.png";
                    }
                    if (Convert.ToInt64(cmd11.ExecuteScalar()) == 1100)
                    {
                        Image12.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_green.png";
                    }
                    if (Convert.ToInt64(cmd11.ExecuteScalar()) == 5100)
                    {
                        Image12.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_blue.png";
                    }
                    SqlCommand cmd5 = new SqlCommand();
                    cmd5.CommandText = "select count(*) from wallet where id=(select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Right') and stat='F'";
                    cmd5.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd5.Connection = con;
                    if (Convert.ToInt64(cmd5.ExecuteScalar()) == 1)
                    {
                        Image12.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_gold.png";
                    }
                    SqlCommand cmd12 = new SqlCommand();
                    cmd12.CommandText = "select count(*) from member_creation where id=(select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Left') and side='Right')";
                    cmd12.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd12.Connection = con;
                    if (Convert.ToInt64(cmd12.ExecuteScalar()) == 0)
                    {
                        Image12.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_black.png";
                    }
                }
            }
        }
        {
            {
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Left'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    LinkButton5.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select name from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Left'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    Label14.Text = Convert.ToString(cmd.ExecuteScalar());
                    //Label14.Text = "";
                }
                {
                    SqlCommand cmd11 = new SqlCommand();
                    cmd11.CommandText = "select isnull(sum(amount),0) from wallet where id=(select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Left') and stat='V'";
                    cmd11.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd11.Connection = con;
                    if (Convert.ToInt64(cmd11.ExecuteScalar()) == 0)
                    {
                        Image15.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_red.png";
                    }
                    if (Convert.ToInt64(cmd11.ExecuteScalar()) == 1100)
                    {
                        Image15.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_green.png";
                    }
                    if (Convert.ToInt64(cmd11.ExecuteScalar()) == 5100)
                    {
                        Image15.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_blue.png";
                    }
                    SqlCommand cmd5 = new SqlCommand();
                    cmd5.CommandText = "select count(*) from wallet where id=(select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Left') and stat='F'";
                    cmd5.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd5.Connection = con;
                    if (Convert.ToInt64(cmd5.ExecuteScalar()) == 1)
                    {
                        Image15.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_gold.png";
                    }
                    SqlCommand cmd12 = new SqlCommand();
                    cmd12.CommandText = "select count(*) from member_creation where id=(select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Left')";
                    cmd12.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd12.Connection = con;
                    if (Convert.ToInt64(cmd12.ExecuteScalar()) == 0)
                    {
                        Image15.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_black.png";
                    }
                }
            }
            {
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Right'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    LinkButton6.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select name from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Right'";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd.Connection = con;
                    Label15.Text = Convert.ToString(cmd.ExecuteScalar());
                    //Label15.Text = "";
                }
                {
                    SqlCommand cmd11 = new SqlCommand();
                    cmd11.CommandText = "select isnull(sum(amount),0) from wallet where id=(select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Right') and stat='V'";
                    cmd11.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd11.Connection = con;
                    if (Convert.ToInt64(cmd11.ExecuteScalar()) == 0)
                    {
                        Image18.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_red.png";
                    }
                    if (Convert.ToInt64(cmd11.ExecuteScalar()) == 1100)
                    {
                        Image18.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_green.png";
                    }
                    if (Convert.ToInt64(cmd11.ExecuteScalar()) == 5100)
                    {
                        Image18.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_blue.png";
                    }
                    SqlCommand cmd5 = new SqlCommand();
                    cmd5.CommandText = "select count(*) from wallet where id=(select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Right') and stat='F'";
                    cmd5.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd5.Connection = con;
                    if (Convert.ToInt64(cmd5.ExecuteScalar()) == 1)
                    {
                        Image18.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_gold.png";
                    }
                    SqlCommand cmd12 = new SqlCommand();
                    cmd12.CommandText = "select count(*) from member_creation where id=(select id from member_creation where upleg in (select id from member_creation where upleg=@ID and side='Right') and side='Right')";
                    cmd12.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
                    cmd12.Connection = con;
                    if (Convert.ToInt64(cmd12.ExecuteScalar()) == 0)
                    {
                        Image18.ImageUrl = "../dashboard/assets/udio_web/assets/img/user_black.png";
                    }
                }
            }
        }
        con.Dispose();
    }
}
