using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BeMoviesBooking;

namespace MovieBooking
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _Error = "1";
            DataSet objDS = new DataSet();
            BeMovieBooking objMovieBooking = new BeMovieBooking();
            objDS = objMovieBooking.BeGetLatestMovies(ref _Error);
            for (int i = 0; i < objDS.Tables[0].Rows.Count; i++)
                objDS.Tables[0].Rows[i]["ImagePath"] = Convert.ToString(objDS.Tables[0].Rows[i]["ImagePath"]).Replace("../../", "../");
            rptMovies.DataSource = objDS;
            rptMovies.DataBind();

            objDS = objMovieBooking.BeGetLatestProducts(ref _Error);
            for (int i = 0; i < objDS.Tables[0].Rows.Count; i++)
                objDS.Tables[0].Rows[i]["ImagePath"] = Convert.ToString(objDS.Tables[0].Rows[i]["ImagePath"]).Replace("../../", "../");
            rptProducts.DataSource = objDS;
            rptProducts.DataBind();

        }
    }
}