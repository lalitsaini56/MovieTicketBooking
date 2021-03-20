using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BeMoviesBooking;
using System.Data;

namespace MovieBooking.Admin.Dashboard
{
    public partial class MoviesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _Error = "";
            try
            {
                DataSet objDS = new DataSet();
                BeMovieBooking objMovieBooking = new BeMovieBooking();
                objDS = objMovieBooking.BeGetMovies(ref _Error);
                Repeater1.DataSource = objDS;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAddMovie_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMovies.aspx");
        }
    }
}