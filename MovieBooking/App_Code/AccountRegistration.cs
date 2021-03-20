using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieBooking.App_Code
{
    public class AccountRegistration
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public Boolean IsAdmin { get; set; }
        public string MovieDuration { get; set; }
    }
}