using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MovieBooking.Admin.Dashboard
{
    public partial class CustomerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet objDS = new DataSet();
            string _Error = "";
            try
            {
                if (true)
                {
                    BeMoviesBooking.BeMovieBooking objBe = new BeMoviesBooking.BeMovieBooking();
                    objDS = objBe.BeGetCustomers(ref _Error);
                    grdCustomerList.DataSource = objDS;
                    grdCustomerList.DataBind();
                }
                
            }
            catch(Exception ex)
            {

            }
        }
    }
}