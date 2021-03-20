using System;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;


namespace MovieBooking.App_Code
{
    public class General
    {
        public static string getConfigElement(string Element)
        {
            try
            {
                XmlDocument objConfig = new XmlDocument();
                objConfig.Load(AppDomain.CurrentDomain.BaseDirectory + @"/Xml/Configuration.config");
                return objConfig.GetElementsByTagName(Element)[0].InnerText;
            }
            catch
            {
                return "";
            }
        }
        public static string getMessage(string Element)
        {
            try
            {
                XmlDocument objConfig = new XmlDocument();
                objConfig.Load(AppDomain.CurrentDomain.BaseDirectory + @"/Xml/Message.xml");
                return objConfig.GetElementsByTagName(Element)[0].InnerText;
            }
            catch
            {
                return "";
            }
        }
        public static void Logout()
        {
            HttpContext.Current.Response.Redirect("~\\Defalut.aspx", false);
            return;
        }
        public static void DisplaySweetAlertPopup( Page page, string title, string message, MessageType messageType)
        {
                Page pg = HttpContext.Current.CurrentHandler as Page;
                pg.ClientScript.RegisterStartupScript(page.GetType(), "msg", "Showpop('" + title + "', '" + message + "', '" + messageType + "');", true);
        }
        public static void runJavascriptNew(string script, UpdatePanel updt = null)
        {
            if (updt == null)
            {
                Page pg = HttpContext.Current.CurrentHandler as Page;
                pg.ClientScript.RegisterStartupScript(pg.GetType(), "msg", script, true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(updt, updt.GetType(), "msg", script, true);
            }
        }
        public static void DisplayNotification(string _Message, bool isError = false)
        {
            string er = isError == true ? "1" : "0";
            Page pg = HttpContext.Current.CurrentHandler as Page;
            pg.ClientScript.RegisterStartupScript(pg.GetType(), "msg", "showNotification('" + _Message + "'," + er + ");", true);
        }
        public static void DisplayNotification(string _Message, UpdatePanel updt, bool isError = false)
        {
            string er = isError == true ? "1" : "0";
            ScriptManager.RegisterStartupScript(updt, updt.GetType(), "msg", "showNotification('" + _Message + "'," + er + ");", true);
        }
        public static void runJavascript(string script, UpdatePanel updt = null)
        {
            if (updt == null)
            {
                Page pg = HttpContext.Current.CurrentHandler as Page;
                pg.ClientScript.RegisterStartupScript(pg.GetType(), "msg", script, true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(updt, updt.GetType(), "msg", script, true);
            }
        }
    }

    public class Validation
    {
        public static bool ValidateEmail(string _EmailID)
        {
            string strRegex = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w(2,4)+)*(\.\w{2,3})+$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(_EmailID))
            {
                string value1 = _EmailID.Split('@')[0];
                string value2 = _EmailID.Split('@')[1];
                if (value1.Contains("__"))
                    return false;
                //else if ((value1.Length - (value1.Replace(".", "").Length)) > 2)
                //    return false;
                else if (value2 != "")
                {
                    if (value2.Split('.').Length > 4)
                        return false;
                    else
                    {
                        value2 = value2.Replace(".", "");

                        return ValidateName(value2);
                    }
                }
                else
                    return true;
            }
            else
                return false;
        }
        public static bool ValidateMobile(string _Name)
        {
            string strRegex = @"^[0-9]{10}$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(_Name))
                return true;
            else
                return false;
        }
        private static bool ValidateName(string _Name)
        {
            string strRegex = @"^\w+( \w+)*$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(_Name))
                return true;
            else
                return false;
        }
    }

  

    public enum MessageType
    {
        error,
        success,
        info
    }
}