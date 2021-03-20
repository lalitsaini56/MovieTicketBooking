using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BeMoviesBooking;
using System.Data;

namespace MovieBooking.User
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
                for (int i = 0; i < objDS.Tables[0].Rows.Count; i++)
                    objDS.Tables[0].Rows[i]["ImagePath"] = Convert.ToString(objDS.Tables[0].Rows[i]["ImagePath"]).Replace("../../", "../");
                rptMovies.DataSource = objDS;
                rptMovies.DataBind();
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