using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Net.Mail;


    public class Logs
    {
        public static void Write(string Message)
        {
            //HttpContext.Current.Response.Write(Message);
            
            // Write Logs
            string path = HttpContext.Current.Server.MapPath("~/uploadimage/log.txt");
            StreamWriter sw = File.AppendText(path);
            sw.WriteLine(DateTime.Now.ToString("dd - MMMM - yyyy : hh:mm:ss"));
            sw.WriteLine(Message);
            sw.WriteLine("\n");
            sw.Close();

            //// Sending error to crystal id
            //Mails obj = new Mails();
            //obj.To = "crystal.test.team@gmail.com";
            //obj.From = "admin@crystaltechesolutions.com";
            //obj.Subject = "Error in AINIMusic";
            //obj.Body = Message;
            //obj.Send();
            
        }
    }

