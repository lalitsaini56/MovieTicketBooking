using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BeMoviesBooking.DataAccess;
using System.IO;
using MovieBooking.App_Code;


namespace MovieBooking.Account
{
    public partial class ForgetPassword : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string _Error = "", mailText = "";
            DataSet objDS = new DataSet();
            try
            {
                Member member = new Member();
                objDS = member.beGetUserPassword(txtUserName.Text.Trim(), ref _Error);
                if (!(_Error.StartsWith("-")))
                {
                    if (objDS.Tables[0].Rows.Count > 0)
                    {
                        using (StreamReader sr = new StreamReader(Server.MapPath("~\\MailTemplates\\CandForgotPassword.html")))
                        {
                            mailText = sr.ReadToEnd();
                            sr.Close();
                        }
                        mailText = mailText.Replace("[CandidateName]", Convert.ToString(objDS.Tables[0].Rows[0]["CandidateName"]));
                        mailText = mailText.Replace("[CandidateEmailID]", Convert.ToString(objDS.Tables[0].Rows[0]["EmailID"]));
                        mailText = mailText.Replace("[CandidatePassword]", Convert.ToString(objDS.Tables[0].Rows[0]["Password"]));
                        MailSending mailSending = new MailSending();
                        mailSending.SendMailCommon(txtUserName.Text.Trim(), "", "Movie Theatre Password", mailText, "", "piyush95ksp@gmail.com");
                        General.DisplaySweetAlertPopup(this, "Success", "Login credentials sent to registered E-mail ID", MessageType.success);
                    }
                    else
                        General.DisplaySweetAlertPopup(this, "Alert", "Data Not Found", MessageType.info);
                }

                else
                    General.DisplaySweetAlertPopup(this, "Error", "Server Error!, please try again", MessageType.error);
            }
            catch (Exception ex)
            {
                General.DisplaySweetAlertPopup(this, "Error", "Server Error!, please try again", MessageType.error);
            }
        }
    }
}