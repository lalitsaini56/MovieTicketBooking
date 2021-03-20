using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using BeMoviesBooking.DataAccess;
using System.Xml;
using System.Xml.Serialization;
using MovieBooking.App_Code;
using System.IO;

namespace MovieBooking.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToString(Session["User_OTP"]) != txtOTP.Text)
                {
                    General.DisplaySweetAlertPopup(this, "Error", "Invalid OTP", MessageType.error);
                }
                string userDetails = "";
                Member objMember = new Member();
                AccountRegistration userRegistration = new AccountRegistration
                {
                    FirstName = txtFirstName.Text.Trim(),
                    MiddleName = txtMiddleName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    MobileNo = txtMobileNo.Text.Trim(),
                    EmailID = txtEmailID.Text.Trim(),
                    IsAdmin = false,
                    Password = txtPassword.Text.Trim()
                };
                XmlSerializer xmlserializer = new XmlSerializer(userRegistration.GetType());
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, userRegistration);
                    userDetails = stringWriter.ToString();
                }
                string tStatus = objMember.beSaveRegistrationDetails(userDetails);
                General.DisplaySweetAlertPopup(this, "Success", "User Created Successfully", MessageType.success);
                Clear();
            }
            catch (Exception ex)
            {
                General.DisplaySweetAlertPopup(this, "Error", "Server Error!, please try again", MessageType.error);
            }
        }


        protected void Clear()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmailID.Text = "";
            txtPassword.Text = "";
            txtMobileNo.Text = "";
            txtConfirmPassword.Text = "";
            txtOTP.Text = "";
            btnGetOTP.Visible = true;
            btnRegister.Visible = false;
            txtOTP.Enabled = false;
        }

        protected void btnGetOTP_Click(object sender, EventArgs e)
        {
            try
            {
                string mailText = "";
                txtFirstName.Enabled = false;
                txtMiddleName.Enabled = false;
                txtLastName.Enabled = false;
                txtMobileNo.Enabled = false;
                txtEmailID.Enabled = false;
                txtPassword.Enabled = false;
                txtConfirmPassword.Enabled = false;
                btnRegister.Visible = true;
                txtOTP.Enabled = true;
                btnGetOTP.Visible = false;
                Random random = new Random();
                int OTP = random.Next(100000, 1000000);

                Session["User_OTP"] = OTP;
                using (StreamReader sr = new StreamReader(Server.MapPath("~\\MailTemplates\\CandidateOTP.html")))
                {
                    mailText = sr.ReadToEnd();
                    sr.Close();
                }
                mailText = mailText.Replace("[CandidateName]", txtFirstName.Text.Trim());
                mailText = mailText.Replace("[CandidateEmailID]", txtEmailID.Text.Trim());
                mailText = mailText.Replace("[OTP]", Convert.ToString(OTP));
                MailSending mailSending = new MailSending();
                mailSending.SendMailCommon(txtEmailID.Text.Trim(), "", "Movie Theatre OTP", mailText, "", "piyush95ksp@gmail.com");
                General.DisplaySweetAlertPopup(this, "Success", "OTP sent to registered E-mail ID", MessageType.success);
            }
            catch(Exception ex)
            {
                General.DisplaySweetAlertPopup(this, "Error", "Server Error!, please try again", MessageType.error);
            }
        }
    }
}