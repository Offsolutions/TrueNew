using System;
using System.Net;
using System.IO;
using System.Web.Mail;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Collections.Specialized;



    public class IPN
    {
        #region Variables
        public String stringPost, CmdString, objHttp, OrderID, Txn_id, Payment_status, Receiver_email, Item_name,
                Item_number, Quantity, Invoice, Custom,
                Payment_gross, Payer_email, Pending_reason, Payment_date, Payment_fee,
                Txn_type, First_name, Last_name, Address_street, Address_city, Address_state,
                Address_zip, Address_country, Address_status, Payer_status, Payer_id, Payment_type,
                Notify_version, Verify_sign, Subscr_date, Period1, Period2, Period3,
                Amount, Recurring, Reattempt, Retry_at, Recur_times,response;
        #endregion

        public delegate bool SaveFunc(string custom);


        #region "IPN(NameValueCollection nvc)"
        public IPN(NameValueCollection nvc)
        {
            Logs.Write("In IPN functiobn ");
            // assign posted variables to local variables 
            stringPost = nvc.ToString();
            Logs.Write("Russs ---- " +stringPost  + " --------------Russs");
            Txn_id = nvc["txn_id"];
            Receiver_email = nvc["receiver_email"];
            Item_name = nvc["item_name_1"];
            Item_number = nvc["item_number_1"];
            Quantity = nvc["quantity_1"];
            Amount = nvc["amount_1"];
            Invoice = nvc["invoice"];
            Custom = nvc["custom"];
            Payment_status = nvc["payment_status"];
            Pending_reason = nvc["pending_reason"];
            if (Payment_status != "Pending")
                Pending_reason = " ";

            Payment_date = nvc["payment_date"];
            Payment_fee = nvc["payment_fee"];
            Payment_gross = nvc["payment_gross"];
            Txn_type = nvc["txn_type"];
            First_name = nvc["first_name"];
            Last_name = nvc["last_name"];
            Address_street = nvc["address_street"];
            Address_city = nvc["address_city"];
            Address_state = nvc["address_state"];
            Address_zip = nvc["address_zip"];
            Address_country = nvc["address_country"];
            Address_status = nvc["address_status"];
            Payer_email = nvc["payer_email"];
            Payer_status = nvc["payer_status"];
            Payer_id = nvc["payer_id"];
            Payment_type = nvc["payment_type"];
            Notify_version = nvc["notify_version"];
            Verify_sign = nvc["verify_sign"];
        }
        #endregion

       
        #region "CheckIPN()"
        public bool CheckIPN(SaveFunc save)
        {
            Logs.Write("in CheckIpn function");
            bool result = false;
            GetStatus();
            Logs.Write("in CheckIpn response");
            Logs.Write("response="+response);
            Logs.Write("PaymentStatus=" + Payment_status);

            if (Payment_status == "Completed")
            {

                Logs.Write("In the case completed");
                result = save(Custom + ":" + Invoice + ":" + Txn_id);

            }
            else
            {

            }
            return result;
        }
        private void GetStatus()
        {
          //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://www.paypal.com/cgi-bin/webscr");
           HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://www.sandbox.paypal.com/cgi-bin/webscr");
           // HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(" https://www.paypal.com/cgi-bin/webscr?cmd=p/mer/WAX_landing-outside");
      
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = stringPost.Length + 21;  // length plus 21 because &cmd=_notify-validate is 21 chars long 
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            StreamWriter streamWriter = null;
            streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
            stringPost = stringPost + "&cmd=_notify-validate";
            streamWriter.Write(stringPost);
            streamWriter.Close();
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
                streamReader.Close();
            }
            if (httpWebResponse.StatusCode != HttpStatusCode.OK)
                response = "ERROR";
        }
        #endregion

    }


