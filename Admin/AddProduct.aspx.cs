using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddProduct : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string img;
    public string imagename;
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
        //if (Request.QueryString["id"] != null)
        //{
        //    objsql.ExecuteNonQuery("update tblproducts set name='" + txtname.Text + "',dp='" + txtdp.Text + "',pv='"+txtpv.Text+"' where id='" + Request.QueryString["id"] + "'");
        //}
        //else
        //{
        //    objsql.ExecuteNonQuery("insert into tblproducts(name,dp,pv) values('" + txtname.Text + "','" + txtdp.Text + "','"+txtpv.Text+"')");

        //}
        if (sliderimage.HasFile)
        {
            string sliderpic = sliderimage.FileName;
            imagename =  sliderpic;
            string filePath2 = MapPath("../uploadimage/" + imagename);
            Stream Buffer2 = sliderimage.PostedFile.InputStream;
            System.Drawing.Image Image2 = System.Drawing.Image.FromStream(Buffer2);
            Bitmap bmp2 = GetImage.ResizeImage(Image2, Image2.Height, Image2.Width);
            bmp2.Save(filePath2, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        else
        {
            imagename = img;
        }
        if (Request.QueryString["id"] != null)
        {
            objsql.ExecuteNonQuery("update tblproducts set name='" + txtname.Text + "',dp='" + txtdp.Text + "',pv='" + txtpv.Text + "',image='" + imagename + "' where id='" + Request.QueryString["id"] + "'");
        }
        else
        {

            objsql.ExecuteNonQuery("insert into tblproducts(name,code,dp,pv,image) values('" + txtname.Text + "','" + Common.GenProductCode() + "','" + txtdp.Text + "','" + txtpv.Text + "','" + imagename + "')");
        }
        img = "";
        Response.Redirect("view-Products.aspx");
    }
    protected void bind(string id)
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select * from tblproducts where id='" + id + "'");
        if (dt.Rows.Count > 0)
        {
            txtname.Text = dt.Rows[0]["name"].ToString();
            txtdp.Text = dt.Rows[0]["dp"].ToString();
            txtpv.Text = dt.Rows[0]["pv"].ToString();
            //txtcode.Text = dt.Rows[0]["code"].ToString();
            img = dt.Rows[0]["image"].ToString();
        }
    }
}