using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Configuration;


 



	public class GetImage
	{
        public static Bitmap ResizeImage(System.Drawing.Image imgPhoto, int Height, int Width)
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

            int destWidth = (int)System.Math.Ceiling(sourceWidth * nPercent);
            int destHeight = (int)System.Math.Ceiling(sourceHeight * nPercent);

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
	}


   

