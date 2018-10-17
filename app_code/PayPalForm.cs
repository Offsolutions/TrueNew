using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;



    public class PayPalForm
    {
        string tamplate = "";
        Hashtable values = null;
        int itemnumber = 0;

        public enum CommandType
        {
            Cart,
            XClick
        }

        #region "IsSubmit"
        bool _issubmit = false;
        public bool IsSubmit
        {
            get { return _issubmit; }
            set { _issubmit = value; }
        }
        #endregion

        #region "PayPalForm()"
        public PayPalForm()
        {
            tamplate = "<input type='hidden' name='{0}' value='{1}'>";
            values = new Hashtable();

            // Main Import. Fields
            values.Add("cmd", "_cart");
            values.Add("business", "");
            values.Add("return", "");
            values.Add("notify_url", "");
            values.Add("cancel_return", "");
            values.Add("discount_amount_cart", "");

            values.Add("invoice", System.Web.HttpContext.Current.Request.Cookies["cartid"].Value); //15042008030218

            // Shipping Charges
            values.Add("no_shipping", "1");
            values.Add("shipping_1", "0");
            


            // Others
            values.Add("no_note", "1");
            values.Add("currency_code", "USD");
            values.Add("upload", "1");
            values.Add("custom", "");

            //values.Add("amount", "0");
            //values.Add("quantity", "0");
            //values.Add("handling_cart", "0");
        }
        #endregion

        #region "Command" "Business" "ReturnUrl" "NotifyUrl" "CancelUrl" "Invoice" "Custom"
        public CommandType Command
        {
            set
            {
                string v1 = (value == CommandType.Cart ? "_cart" :
                     (value == CommandType.XClick ? "_xclick" : "none"));
                values["cmd"] = v1;
            }
        }
        public string Business
        {
            set
            {
                values["business"] = value;
            }
        }
        public string ReturnUrl
        {
            set
            {
                values["return"] = value;
            }
        }

        public string Discount
        {
            set
            {
                values["discount_amount_cart"] = value;
            }
        }
        public string NotifyUrl
        {
            set
            {
                values["notify_url"] = value;
            }
        }
        public string CancelUrl
        {
            set
            {
                values["cancel_return"] = value;
            }
        }
        public string Invoice
        {
            set
            {
                values["invoice"] = value;
            }
        }
        public string Custom
        {
            set
            {
                values["custom"] = value;
            }
        }
        #endregion        
        
        #region "AddItem(string ItemName, int Quantity, float amount) | AddItem(int ItemNumber,string ItemName, int Quantity, float amount)"
        public void AddItem(string ItemName, int Quantity, float amount)
        {
            string num = (++itemnumber).ToString();
            values.Add("item_number_" + num, num);
            values.Add("item_name_" + num, ItemName);
            values.Add("quantity_" + num, Quantity);
            values.Add("amount_" + num, amount);
        }
        public void AddItem(int ItemNumber,string ItemName, int Quantity, decimal amount)
        {
            string num = (++itemnumber).ToString();
            values.Add("item_number_" + num, ItemNumber.ToString());
            values.Add("item_name_" + num, ItemName);
            values.Add("quantity_" + num, Quantity);
            values.Add("amount_" + num, amount);
        }
        #endregion

        #region "Shipping"
        public string Shipping
        {
            set
            {
                values["no_shipping"] = "0";
                values["shipping_1"] = value;
            }
        }
        #endregion

        #region "GetForm()"
        public string GetForm()
        {
          string result = "<form  name='PayPal_Button' id='PayPal_Button' action='https://www.paypal.com/cgi-bin/webscr' method='post'>{0}</form>";
            // string result = "<form  name='PayPal_Button' id='PayPal_Button' action='https://www.sandbox.paypal.com/cgi-bin/webscr' method='post'>{0}</form>";
           // string result = "<form  name='PayPal_Button' id='PayPal_Button' action=' https://www.paypal.com/cgi-bin/webscr?cmd=p/mer/WAX_landing-outside' method='post'>{0}</form>";
       


            string[] keys = new string[values.Count];
            values.Keys.CopyTo(keys, 0);
            string tmp = "";
            for (int i = 0; i < keys.Length; i++)
                tmp += string.Format(tamplate, keys[i], values[keys[i]].ToString());

            result = string.Format(result, tmp);
            if (_issubmit)
                result += "<script> setTimeout('document.getElementById(\"PayPal_Button\").submit()',1000); </script>";
            return result;
        }
        #endregion



        private string generateInvoice()
        {
            Random random = new Random();
            string s = "";
            for (int i = 0; i < 10; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }
    }
