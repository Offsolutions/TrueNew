using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Client_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Tree(Convert.ToString(Session["id"]));
        }
    }
    public void Tree(string Sr)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        con.Open();
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select row_number() over (order by date_entry) as 'S.No',ID as 'UserId',NAME,date_entry as 'DOJ',(select isnull(sum(amount),0) from wallet where stat='V' and id=m.id) as TOPUP from member_creation m where spon=@ID order by date_entry";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Sr;
            cmd.Parameters.Add("@ID1", SqlDbType.VarChar).Value = Convert.ToString(Session["ID"]);
            cmd.Connection = con;
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
        }
        con.Dispose();
    }
    protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        string ID = Convert.ToString(GridView1.DataKeys[e.RowIndex].Value);
        Tree(ID);
    }
}
