using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Xml;


namespace MovieBooking.App_Code
{
    public class MailSending
    {
        public string SendMailCommon(string MailTos, string MailCCs, string tSubject, string tBody, string FromMailid, string MailBcc)
        {
            MailBcc += "," + General.getConfigElement("MailBcc");
            MailTos = MailTos.Trim().TrimEnd(',').TrimStart(',');
            MailCCs = MailCCs.Trim().TrimEnd(',').TrimStart(',');
            MailBcc = MailBcc.Trim().TrimEnd(',').TrimStart(',');
            //ErrorLog.WriteErrorLog(tBody);
            try
            {
                if (ConfigurationManager.AppSettings["DisableMailSending"] == "1")
                {

                    return "0";
                }
                string SMTPServerName = General.getConfigElement("SMTPServer"), UserID = General.getConfigElement("SMTPUserID"), Password = General.getConfigElement("SMTPPassword"), SMTPPortNumber = General.getConfigElement("SMTPPort"), SMTPFromMailID = General.getConfigElement("SMTPFromMailID");

                #region Test Mail
                if (General.getConfigElement("IsTestMail") == "1")
                {
                    tBody = "<div style=\"font-family:Calibri; font-size:14px;\">To: " + MailTos + "<br />Cc: " + MailCCs + "<br />Bcc: " + MailBcc + "<br /><hr /></div>" + tBody;
                    MailTos = General.getConfigElement("TestMailID");
                    MailCCs = "";
                }
                #endregion
                bool IsHTML = true;
                if (MailTos != "")
                {
                    //tBody = tBody.Replace("\r\n", "<br />");
                    if (General.getConfigElement("IsWebMail") == "1")
                    {
                        #region Web Mail

                        System.Web.Mail.MailMessage myMessage = new System.Web.Mail.MailMessage();
                        myMessage.Subject = tSubject;
                        if (SMTPServerName != "")
                            System.Web.Mail.SmtpMail.SmtpServer = SMTPServerName;

                        if (MailTos != "")
                            myMessage.To = MailTos;
                        if (MailCCs != "")
                            myMessage.Cc = MailCCs;
                        if (MailBcc != "")
                            myMessage.Bcc = MailBcc;


                        myMessage.Body = tBody;
                        if (IsHTML)
                            myMessage.BodyFormat = System.Web.Mail.MailFormat.Html;
                        System.Web.Mail.SmtpMail.Send(myMessage);

                        return "1";

                        #endregion
                    }
                    else
                    {

                        #region Net Mail

                        string[] EmailIDColl = null;
                        System.Net.Mail.MailMessage mymsg1 = new System.Net.Mail.MailMessage();
                        mymsg1.Subject = tSubject;
                        mymsg1.IsBodyHtml = IsHTML;

                        EmailIDColl = MailTos.Split(';', ',');
                        foreach (string singleEmailID in EmailIDColl)
                            if (singleEmailID != "")
                                mymsg1.To.Add(singleEmailID);



                        EmailIDColl = MailCCs.Split(';', ',');
                        foreach (string singleEmailID in EmailIDColl)
                            if (singleEmailID != "")
                            {
                                try
                                {
                                    mymsg1.CC.Add(singleEmailID);
                                }
                                catch (Exception ex)
                                {

                                    return "-1" + ex.Message + ex.StackTrace;
                                }
                            }
                        if (MailBcc != "")
                        {
                            EmailIDColl = MailBcc.Trim(',').Split(';', ',');
                            foreach (string singleEmailID in EmailIDColl)
                                if (singleEmailID != "")
                                {
                                    try
                                    {
                                        mymsg1.Bcc.Add(singleEmailID);
                                    }
                                    catch (Exception ex)
                                    {

                                        return "-1" + ex.Message + ex.StackTrace;
                                    }
                                }
                        }


                        mymsg1.Body = tBody;
                        System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient(SMTPServerName);

                        //if (FromMailid != "")
                        //    mymsg1.From = new System.Net.Mail.MailAddress(FromMailid);
                        //else
                        mymsg1.From = new System.Net.Mail.MailAddress(SMTPFromMailID);

                        if (General.getConfigElement("UseDefaultCredential") == "1")
                        {
                            // Credentials are necessary if the server requires the client 
                            // to authenticate before it will send e-mail on the client's behalf.
                            //sc.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                        }
                        else
                            sc.Credentials = new System.Net.NetworkCredential(UserID, Password);

                        if (General.getConfigElement("EnableSSLMail") == "1")
                            sc.EnableSsl = true;
                        if (SMTPPortNumber != "")
                            sc.Port = Convert.ToInt16(SMTPPortNumber);

                        //StringBuilder sb = new StringBuilder();
                        //sb.AppendLine("To Address: " + MailTos);
                        //sb.AppendLine("Cc Address: " + MailCCs);
                        //sb.AppendLine("Bcc Address: " + MailBcc);
                        //sb.AppendLine("From Address: " + mymsg1.From.ToString());
                        //sb.AppendLine("SMTP Server: " + sc.Host);
                        //sb.AppendLine("SMTP Port: " + sc.Port.ToString());
                        //sb.AppendLine("User ID: " + General.getConfigElement("SMTPUserID"));
                        //sb.AppendLine("Password: " + General.getConfigElement("SMTPPassword"));
                        //sb.AppendLine("Enable SSL: " + sc.EnableSsl.ToString());
                        //ErrorLog.WriteErrorLog(sb.ToString());
                        sc.Send(mymsg1);

                        return "0";

                        #endregion
                    }
                }
                else
                {
                    ErrorLog.WriteErrorLog("-2 mail sending Error");
                    return "-2";

                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteErrorLog("-1 mail sending Error");
                ErrorLog.WriteErrorLog(ex.Message, ex.StackTrace);
                return "-1 :" + ex.Message + Environment.NewLine + ex.StackTrace;
            }
        }
    }

}