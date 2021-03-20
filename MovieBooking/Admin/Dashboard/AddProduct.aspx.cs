using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using BeMoviesBooking;

namespace MovieBooking.Account
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string movieDetails = "";
            try
            {
                BeMovieBooking objMovieBooking = new BeMovieBooking();
                Product objAddProduct = new Product
                {
                    ProductName = txtProductName.Text.Trim(),
                    ProductPrice = txtPrice.Text.Trim(),
                    //MovieActors = txtMovieActors.Text.Trim(),
                    ProductSummary = txtProductSummary.Text.Trim(),
                    ProductImageName = Convert.ToString(Session["FileName"]),
                    //MovieDuration = timeDuration.ToString()
                };
                XmlSerializer xmlserializer = new XmlSerializer(objAddProduct.GetType());
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, objAddProduct);
                    movieDetails = stringWriter.ToString();
                }
                string tStatus = objMovieBooking.BeAddProduct(movieDetails);

            }

            catch (Exception ex)
            {

            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (flpProduct.HasFile)
                {
                    string fileExtenstion = System.IO.Path.GetExtension(flpProduct.FileName);
                    string movieImagePath = Server.MapPath("~/MovieImages/");
                    if (fileExtenstion == ".jpg" || fileExtenstion == ".png" || fileExtenstion == ".jpeg")
                    {
                        Random random = new Random();
                        string fileName = flpProduct.FileName.Replace(fileExtenstion, "") + "_" + random.Next(1000000) + fileExtenstion;
                        flpProduct.SaveAs(movieImagePath + fileName);
                        Session["FileName"] = "../../MovieImages/" + fileName;
                    }
                    if (flpProduct.FileBytes.Length <= 20000)
                    {
                    }
                }
            }

            catch (Exception ex)
            {

            }

        }
    }

    public class Product
    {
        public string ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductImageName { get; set; }
        public string ProductSummary { get; set; }

    }
}