using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;

public class Common
{
    const string passphrase = "password";
    #region [ Get DB Values ]

    // Get String Value

    #region [ Get(object obj) & Get(object obj,int maxchars) ]
    public static string Get(object obj)
    {
        if (obj == System.DBNull.Value || obj == null)
            return "";
        else
            return obj.ToString();
    }
    public static string Get(object obj, int maxchars)
    {
        if (obj == System.DBNull.Value || obj == null)
            return "";
        else
        {
            string str = obj.ToString();
            str = str.Substring(0, (str.Length > maxchars ? maxchars : str.Length));
            return str;
        }
    }
    #endregion

    // Get int value

    #region [ GetInt(object obj) ]
    public static int GetInt(object obj)
    {
        
            try
            {
                return Convert.ToInt16(obj);
            }
            catch 
            {
                return 0;
            }
       
    }
    #endregion

    // Get Boolean value

    #region [ GetBool(object obj) ]
    public static bool GetBool(object obj)
    {
        if (obj == System.DBNull.Value || obj == null || obj.ToString()=="")
            return false;
        else
            return Convert.ToBoolean(obj);
    }
    #endregion

    // Get Date Value

    #region [ GetDate(object obj) ]
    public static DateTime GetDate(object obj)
    {
        if (obj == System.DBNull.Value || obj == null)
            return DateTime.Now;
        else
            return Convert.ToDateTime(obj);
    }
    #endregion

    // Get Decimal Value

    #region [ GetDecimal(object obj) ]
    public static decimal GetDecimal(object obj)
    {
        if (obj == System.DBNull.Value || obj == null || obj.ToString() == "")
            return 0;
        else
            return Convert.ToDecimal(obj);
    }
    #endregion

    #endregion

    #region [ CheckUniqueId(string email) ]
    public bool CheckUniqueId(string email)
    {
        SQLHelper objSQL = new SQLHelper();
        int res = Convert.ToInt32(objSQL.GetSingleValue("sp_CheckUniqueId '" + email.Trim() + "'"));
        if (res > 0)
            return false;
        else
            return true;
    }
    #endregion

    #region [ GetCount(string Tablename) ]
    public int GetCount(string Tablename)
    {
        SQLHelper objSQL = new SQLHelper();
        int count = 0;
        if (Tablename == "orders")
            count = Common.GetInt(objSQL.GetSingleValue("select count(*) from orders join customers on customer_id = order_customer_id"));
        else if (Tablename == "testimonials")
            count = Common.GetInt(objSQL.GetSingleValue("select count(*) from testimonials join customers on customer_id = testimonial_customer_id"));
        else if (Tablename == "pages")
        {
            DirectoryInfo dirInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/StaticPages"));
            FileInfo[] files = dirInfo.GetFiles();
            count = files.Length;
        }
        else if (Tablename == "quotes")
            count = Common.GetInt(objSQL.GetSingleValue("select count(*) from custom_quote join customers on customer_id = custom_quote_customer_id AND IsProcessed='0'"));
        else if (Tablename == "tblMessages")
            count = Common.GetInt(objSQL.GetSingleValue("select count(*) from tblMessages where Status = 'saved'"));
        else
            count = Common.GetInt(objSQL.GetSingleValue("select count(*) from " + Tablename));
        return count;
    }
    #endregion

    #region [ GetDistinct(DataTable dt, string ColumnName) ]
    public static DataTable GetDistinct(DataTable dt, string ColumnName)
    {
        DataTable result = dt.Copy();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            bool flag = false;
            for (int j = 0; j < result.Rows.Count; j++)
            {
                if (flag && result.Rows[j][ColumnName] == dt.Rows[i][ColumnName])
                {
                    result.Rows[j].Delete();
                    j--;
                }
                else if (result.Rows[j][ColumnName].ToString().Trim() == dt.Rows[i][ColumnName].ToString().Trim())
                    flag = true;
            }
        }
        return result;
    }
    #endregion


    #region [ GetDistinct(ArrayList obj) ]
    public static ArrayList GetDistinct(ArrayList obj)
    {
        for (int i = 0; i < obj.Count - 1; i++)
        {
            for (int j = i + 1; j < obj.Count; j++)
            {
                if (obj[i].Equals(obj[j]))
                {
                    obj.RemoveAt(j);
                    j = j - 1;
                }
            }
        }
        return obj;
    }
    #endregion


    #region [ IsExist(DataTable dt, string[] Values ]
    public static bool IsExist(DataTable dt, string[] Values) // sequence of columns in datatable and values in array must be same.
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            bool flag = true;
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                if (Values[j] != dt.Rows[i][j].ToString())
                    flag = false;
            }
            if (flag)
                return true;
        }
        return false;
    }
    #endregion

    #region [ ArrayList getSortedSize(ArrayList arr) ]
    public static ArrayList getSortedSize(ArrayList arr)
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("objvalue");
        dt.Columns.Add("objunit");
        for (int i = 0; i < arr.Count; i++)
        {
            DataRow dr = dt.NewRow();

            dr["objvalue"] = arr[i].ToString().Split(" ".ToCharArray())[0];
            dr["objunit"] = arr[i].ToString().Split(" ".ToCharArray())[1];
            dt.Rows.Add(dr);
        }
        DataView dv = new DataView(dt);

        dv.Sort = "objunit,objvalue asc";
        dt = dv.ToTable();
        arr.Clear();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            arr.Add(dt.Rows[i][0].ToString() + " " + dt.Rows[i][1].ToString());
        }
        return arr;
    }
    #endregion


    #region [ Filter(string obj) ]
    public static string Filter(string obj)
    {
        // coding to do 
        string[] badChars = { "select", "drop", "--", "insert", "delete", "xp_", "update", "exec" };
        for (int i = 0; i < 8; i++)
        {
            obj = obj.Replace(badChars[i], "");
        }
        obj= obj.Replace("'","''");
        return obj;
    }
    #endregion

    #region Generate Class code
    public string GenerateClassCode(int length)
    {
        StringBuilder classCode = new StringBuilder();
        Random r = new Random();

        //string alphabets = "abcdefghijklmnopqrstuvwxyz";
        string numbers = "01234567890123456789012345";

        for (int i = 0; i <= length; i++)
        {
           // classCode.Append(alphabets[r.Next(alphabets.Length)].ToString().ToUpper());
            classCode.Append(numbers[r.Next(numbers.Length)]);
        }


        return classCode.ToString();
    }
    public string GenerateRegno()
    {
        SQLHelper objsql = new SQLHelper();
        string max = Common.Get(objsql.GetSingleValue("select max(regno) from usersnew"));


        return (Convert.ToInt32(max) + Convert.ToInt32(1)).ToString();
    }
    public string Generatepass()
    {
        StringBuilder classCode = new StringBuilder();
        Random r = new Random();

        //string alphabets = "abcdefghijklmnopqrstuvwxyz";
        string numbers = "01234567890123456789012345";

        for (int i = 0; i <= 4; i++)
        {
            // classCode.Append(alphabets[r.Next(alphabets.Length)].ToString().ToUpper());
            classCode.Append(numbers[r.Next(numbers.Length)]);
        }


        return classCode.ToString();
    }
    #endregion
    #region Resize Image
    protected Bitmap ResizeImage(System.Drawing.Image imgPhoto, int Height, int Width)
    {
        int sourceWidth = imgPhoto.Width;
        int sourceHeight = imgPhoto.Height;
        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;

        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;

        nPercentW = ((float)Width / (float)sourceWidth);
        nPercentH = ((float)Height / (float)sourceHeight);
        if (nPercentH < nPercentW)
        {
            nPercent = nPercentH;
            destX = System.Convert.ToInt16((Width - (sourceWidth * nPercent)) / 2);
        }
        else
        {
            nPercent = nPercentW;
            destY = System.Convert.ToInt16((Height - (sourceHeight * nPercent)) / 2);
        }

        int destWidth = (int)Math.Ceiling(sourceWidth * nPercent);
        int destHeight = (int)Math.Ceiling(sourceHeight * nPercent);

        Bitmap bmPhoto = new Bitmap(Width, Height, imgPhoto.PixelFormat);

        bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

        Graphics grPhoto = Graphics.FromImage(bmPhoto);
        grPhoto.Clear(Color.White);

        grPhoto.CompositingQuality = CompositingQuality.HighQuality;
        grPhoto.SmoothingMode = SmoothingMode.HighQuality;
        grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
        Rectangle rect = new Rectangle(0, 0, Width, Height);
        grPhoto.DrawImage(imgPhoto, rect, new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);
        grPhoto.Dispose();
        return bmPhoto;
    }
    #endregion
    #region Encrypt/Decrypt Data
    public string EncryptData(string Message)
    {
        byte[] Results;
        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
        TDESAlgorithm.Key = TDESKey;
        TDESAlgorithm.Mode = CipherMode.ECB;
        TDESAlgorithm.Padding = PaddingMode.PKCS7;
        byte[] DataToEncrypt = UTF8.GetBytes(Message);
        try
        {
            ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
            Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
        }
        finally
        {
            TDESAlgorithm.Clear();
            HashProvider.Clear();
        }
        return Convert.ToBase64String(Results);
    }
    public string DecryptData(string Message)
    {
        byte[] Results;
        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
        TDESAlgorithm.Key = TDESKey;
        TDESAlgorithm.Mode = CipherMode.ECB;
        TDESAlgorithm.Padding = PaddingMode.PKCS7;
        byte[] DataToDecrypt = Convert.FromBase64String(Message);
        try
        {
            ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
            Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
        }
        finally
        {
            TDESAlgorithm.Clear();
            HashProvider.Clear();
        }
        return UTF8.GetString(Results);
    }
    #endregion
}