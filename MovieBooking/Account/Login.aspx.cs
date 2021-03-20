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
    public partial class Login : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string _Error = "";
            DataSet objDS = new DataSet();
            try
            {
                Member member = new Member();
                objDS = member.beGetUserLogin(txtUserName.Text.Trim(), txtPassword.Text.Trim(), ref _Error);
                if (!(_Error.StartsWith("-")))
                {
                    if (objDS.Tables[0].Rows.Count > 0)
                    {
                        string Name = Convert.ToString(objDS.Tables[0].Rows[0]["Name"]);
                        Session["CustomerID"] = Convert.ToString(objDS.Tables[0].Rows[0]["CustomerID"]);
                        Session["Login_Name"] = Name;
                        Response.Redirect("~/User/MoviesList.aspx");
                    }
                    else
                        General.DisplaySweetAlertPopup(this, "Alert", "Invalid Credentials!, please try again", MessageType.info);
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