using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MovieBooking.User
{
    public partial class Booking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerID"] == null)
                Response.Redirect("~/Account/Login.aspx");
            hdnMovieID.Value = Convert.ToString(Request.QueryString["MovieID"]);
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            string disabledSeats = "";
            try
            {
                BeMoviesBooking.BeMovieBooking objBe = new BeMoviesBooking.BeMovieBooking();
                string BookedSeat = objBe.BeGetBookedSeatsAccordingDate(DateTime.Now.ToString("yyyy-MM-dd"));
                if (BookedSeat.EndsWith(","))
                    BookedSeat = BookedSeat.TrimEnd(',');
                if (BookedSeat != "")
                    disabledSeats = "'A2,B2,C2,A4,B4,C4,D2,E2,F2,D4,E4,F4" + "," + BookedSeat + "'";
                else
                    disabledSeats = "'A2,B2,C2,A4,B4,C4,D2,E2,F2,D4,E4,F4'";
                string str = "<script>disableBookedSeat(" + disabledSeats + ");</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", str, false);
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            try
            {
                string bookedSeat = "";
                ContentPlaceHolder MainContent = Page.Master.FindControl("MainContent") as ContentPlaceHolder;
                for (int i = 'A'; i <= 'F'; i++)
                {
                    for (int j = 1; j <= 5; j++)
                    {
                        string chkId = Convert.ToChar(i).ToString() + j.ToString();
                        CheckBox checkBox = MainContent.FindControl(chkId) as CheckBox;
                        if (checkBox.Checked)
                        {
                            bookedSeat += chkId + ",";
                        }
                    }
                }
                if (bookedSeat.EndsWith(","))
                    bookedSeat = bookedSeat.TrimEnd(',');

                Session["BookedSeat"] = bookedSeat;
                Response.Redirect("~/User/Payment.aspx?MovieID=" + hdnMovieID.Value);

            }
            catch (Exception ex)
            {

            }
        }

        protected void A1_CheckedChanged(object sender, EventArgs e)
        {
            B1.Checked = A1.Checked;
        }

        protected void B1_CheckedChanged(object sender, EventArgs e)
        {
            A1.Checked = B1.Checked;
        }

        protected void C1_CheckedChanged(object sender, EventArgs e)
        {
            D1.Checked = C1.Checked;
        }

        protected void D1_CheckedChanged(object sender, EventArgs e)
        {
            C1.Checked = D1.Checked;
        }

        protected void E1_CheckedChanged(object sender, EventArgs e)
        {
            F1.Checked = E1.Checked;
        }

        protected void F1_CheckedChanged(object sender, EventArgs e)
        {
            E1.Checked = F1.Checked;
        }

        protected void A2_CheckedChanged(object sender, EventArgs e)
        {
            B2.Checked = A2.Checked;
        }

        protected void B2_CheckedChanged(object sender, EventArgs e)
        {
            A2.Checked = B2.Checked;
        }

        protected void C2_CheckedChanged(object sender, EventArgs e)
        {
            D2.Checked = C2.Checked;
        }

        protected void D2_CheckedChanged(object sender, EventArgs e)
        {
            C2.Checked = D2.Checked;
        }

        protected void E2_CheckedChanged(object sender, EventArgs e)
        {
            F2.Checked = E2.Checked;
        }

        protected void F2_CheckedChanged(object sender, EventArgs e)
        {
            E2.Checked = F2.Checked;
        }

        protected void A3_CheckedChanged(object sender, EventArgs e)
        {
            B3.Checked = A3.Checked;
        }

        protected void B3_CheckedChanged(object sender, EventArgs e)
        {
            A3.Checked = B3.Checked;
        }

        protected void C3_CheckedChanged(object sender, EventArgs e)
        {
            D3.Checked = C3.Checked;
        }

        protected void D3_CheckedChanged(object sender, EventArgs e)
        {
            C3.Checked = D3.Checked;
        }

        protected void E3_CheckedChanged(object sender, EventArgs e)
        {
            F3.Checked = E3.Checked;
        }

        protected void F3_CheckedChanged(object sender, EventArgs e)
        {
            E3.Checked = F3.Checked;
        }

        protected void A4_CheckedChanged(object sender, EventArgs e)
        {
            B4.Checked = A4.Checked;
        }

        protected void B4_CheckedChanged(object sender, EventArgs e)
        {
            A4.Checked = B4.Checked;
        }

        protected void C4_CheckedChanged(object sender, EventArgs e)
        {
            D4.Checked = C4.Checked;
        }

        protected void D4_CheckedChanged(object sender, EventArgs e)
        {
            C4.Checked = D4.Checked;
        }

        protected void E4_CheckedChanged(object sender, EventArgs e)
        {
            F4.Checked = E4.Checked;
        }

        protected void F4_CheckedChanged(object sender, EventArgs e)
        {
            E4.Checked = F4.Checked;
        }

        protected void A5_CheckedChanged(object sender, EventArgs e)
        {
            B5.Checked = A5.Checked;
        }

        protected void B5_CheckedChanged(object sender, EventArgs e)
        {
            A5.Checked = B5.Checked;
        }

        protected void C5_CheckedChanged(object sender, EventArgs e)
        {
            D5.Checked = C5.Checked;
        }

        protected void D5_CheckedChanged(object sender, EventArgs e)
        {
            C5.Checked = D5.Checked;
        }

        protected void E5_CheckedChanged(object sender, EventArgs e)
        {
            F5.Checked = E5.Checked;
        }

        protected void F5_CheckedChanged(object sender, EventArgs e)
        {
            E5.Checked = F5.Checked;
        }

    }
}