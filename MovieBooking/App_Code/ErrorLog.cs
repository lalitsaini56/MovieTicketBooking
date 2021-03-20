using System;
using System.IO;
using System.Web;


namespace MovieBooking.App_Code
{
    public class ErrorLog
    {
        public ErrorLog()
        {

        }
        public void WriteErrorLog(string _Function, string _Error, string _Commant)
        {
            try
            {
                if (_Error.ToLower().Contains("thread was being aborted") == false)
                {
                    string _Path = HttpContext.Current.Server.MapPath("~\\Logs\\");
                    if (!Directory.Exists(_Path))
                        Directory.CreateDirectory(_Path);
                    ErrorXml x = new ErrorXml();
                    x.Error = _Error;
                    x.Details = _Commant;
                    x.Comments = "";
                    x.Function = _Function;
                    StreamWriter _STW = new StreamWriter(_Path + DateTime.Today.ToString("ddMMyyyy") + ".log", true);
                    _STW.WriteLine(x.GetSerializedText());
                    _STW.Flush();
                    _STW.Dispose();
                }
            }
            catch { }
        }
        public static void WriteErrorLog(string _Error, string _Commant)
        {
            try
            {
                if (_Error.ToLower().Contains("thread was being aborted") == false)
                {
                    string _Path = HttpContext.Current.Server.MapPath("~\\Logs\\");
                    if (!Directory.Exists(_Path))
                        Directory.CreateDirectory(_Path);
                    ErrorXml x = new ErrorXml();
                    x.Error = _Error;
                    x.Details = _Commant;
                    x.Comments = "";
                    x.Function = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name.ToString();
                    StreamWriter _STW = new StreamWriter(_Path + DateTime.Today.ToString("ddMMyyyy") + ".log", true);
                    _STW.WriteLine(x.GetSerializedText());
                    _STW.Flush();
                    _STW.Dispose();
                }
            }
            catch { }
        }
        public static void WriteErrorLog(string _Error)
        {
            try
            {
                if (_Error.ToLower().Contains("thread was being aborted") == false)
                {
                    string _Path = HttpContext.Current.Server.MapPath("~\\Logs\\");
                    if (!Directory.Exists(_Path))
                        Directory.CreateDirectory(_Path);
                    ErrorXml x = new ErrorXml();
                    x.Error = _Error;
                    x.Details = "";
                    x.Comments = "";
                    x.Function = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name.ToString();
                    StreamWriter _STW = new StreamWriter(_Path + DateTime.Today.ToString("ddMMyyyy") + ".log", true);
                    _STW.WriteLine(x.GetSerializedText());
                    _STW.Flush();
                    _STW.Dispose();
                }
            }
            catch { }
        }
    }
}
public class ErrorXml
{
    public string Error, Details, Comments, Function, Path, IPAddress, BrowserType, BrowserName, BrowserVersion, ErrorTime;
    public string GetSerializedText()
    {
        StringWriter _SW = new StringWriter();
        _SW.WriteLine(" ------------------------- " + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + " -------------------------");
        _SW.WriteLine("Error            : " + Error);
        _SW.WriteLine("Details          : " + Details);
        _SW.WriteLine("Comments         : " + Comments);
        _SW.WriteLine("Function         : " + Function);
        _SW.WriteLine("Path             : " + HttpContext.Current.Request.Path);
        _SW.WriteLine("IP Address       : " + System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName()).GetValue(0).ToString());
        _SW.WriteLine("Browser Type     : " + HttpContext.Current.Request.Browser.Type.ToString());
        _SW.WriteLine("Browser Name     : " + HttpContext.Current.Request.Browser.Browser.ToString());
        _SW.WriteLine("Browser Version  : " + HttpContext.Current.Request.Browser.Version.ToString());
        _SW.WriteLine(" ------------------------- End -------------------------");
        string a = _SW.ToString();
        _SW.Close();
        _SW.Dispose();
        return a;
    }
}