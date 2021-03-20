using MovieBooking.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieBooking.User
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //General.DisplaySweetAlertPopup(this, "Error", "Server Error!, please try again", MessageType.error);

            if (Request.QueryString["MovieID"] != null)
            {
                hdnMovieID.Value = Request.QueryString["MovieID"];
                int NoOfSeat = (Convert.ToString(Session["BookedSeat"]).Split(',')).Length;
                btnPay.Visible = true;
                lblAmount.Text = Convert.ToString(NoOfSeat * 250);
            }

            else if(Request.QueryString["Price"] != null)
            {
                lblAmount.Text = Convert.ToString(Request.QueryString["Price"]);
                btnProductPay.Visible = true;
            }
            else
                Response.Redirect("~/Account/Login.aspx");

            
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            string bookedSeat = Convert.ToString(Session["BookedSeat"]);
            BeMoviesBooking.BeMovieBooking objBe = new BeMoviesBooking.BeMovieBooking();
            objBe.BeSaveBooking(Convert.ToString(Session["CustomerID"]), hdnMovieID.Value, bookedSeat, DateTime.Now.ToString());
            General.DisplaySweetAlertPopup(this, "Success", "Movie Booked Sucessfully", MessageType.success);
        }

        protected void btnProductPay_Click(object sender, EventArgs e)
        {
            General.DisplaySweetAlertPopup(this, "Success", "Payment Completed Sucessfully", MessageType.success);
        }
    }
}