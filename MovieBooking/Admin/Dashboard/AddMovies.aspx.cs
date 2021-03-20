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
    public partial class AddMovies : System.Web.UI.Page
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
                TimeSpan movieDuration = (Convert.ToDateTime(txtEndTime.Text.Trim()) - Convert.ToDateTime(txtStartTime.Text.Trim()));
                TimeSpan timeDuration = new TimeSpan(movieDuration.Hours, movieDuration.Minutes, movieDuration.Milliseconds);
                AddMovie objAddMovie = new AddMovie
                {
                    MovieName = txtMovieName.Text.Trim(),
                    MovieDirector = txtMovieDirector.Text.Trim(),
                    MovieActors = txtMovieActors.Text.Trim(),
                    MovieSummary = txtMovieSummary.Text.Trim(),
                    MovieImageName = hdnImagePath.Value,
                    MovieDuration = timeDuration.ToString()
                };
                XmlSerializer xmlserializer = new XmlSerializer(objAddMovie.GetType());
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, objAddMovie);
                    movieDetails = stringWriter.ToString();
                }
                string tStatus = objMovieBooking.BeAddMovie(movieDetails);

            }

            catch (Exception ex)
            {

            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (flpMovieImage.HasFile)
                {
                    string fileExtenstion = System.IO.Path.GetExtension(flpMovieImage.FileName);
                    string movieImagePath = Server.MapPath("~/MovieImages/");
                    if (fileExtenstion == ".jpg" || fileExtenstion == ".png" || fileExtenstion == ".jpeg")
                    {
                        Random random = new Random();
                        string fileName = flpMovieImage.FileName.Replace(fileExtenstion,"") + "_" + random.Next(1000000) + fileExtenstion;
                        flpMovieImage.SaveAs(movieImagePath + fileName);
                        hdnImagePath.Value = "../../MovieImages/" + fileName;
                    }
                    if (flpMovieImage.FileBytes.Length <= 20000)
                    {
                    }
                }
            }

            catch (Exception ex)
            {

            }

        }
    }

    public class AddMovie
    {
        public string MovieName { get; set; }
        public string MovieDirector { get; set; }
        public string MovieActors { get; set; }
        public string MovieDuration { get; set; }
        public string MovieImageName { get; set; }
        public string MovieSummary { get; set; }

    }
}