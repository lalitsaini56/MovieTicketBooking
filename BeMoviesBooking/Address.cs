/*
 * Sample Project Created for Freshers or Junior Developers.
 * Developed by Vasu Ravuri, Please look at below link for more details
 * http://dotnettrainer.wordpress.com/ or http://onlinetrainingdotnet.com
 */
using System;
using System.Data;
using System.Data.SqlClient;
using BeMoviesBooking.BusinessInfo;
//using Licance;

/// <summary>
/// Database operations on Address table.
/// </summary>
namespace BeMoviesBooking.DataAccess
{
    public class Address
    {
        /// <summary>
        /// To insert data into address table.
        /// </summary>
        /// <param name="addressInfo"></param>
        /// <param name="dataAccess"></param>
        /// 
        private bool CheckLicence()
        {
            try
            {
                bool Isvalid = true;
                //LicanceClass tLicence = new LicanceClass();
                //Isvalid = tLicence.CheckLicenceValidation(DateTime.Now.ToString());
                return Isvalid;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //public void InsertAddress(AddressInfo addressInfo, DataAccess dataAccess)
        //{
        //    if (true)//1234567890
        //    {
        //        /*This method doesn't need to open/close database connection because it is using parent connection information.*/
        //        FillParameters(addressInfo, "Insert", dataAccess);
        //        dataAccess.ExecuteNonQuery(DbCommands.sp_InsetUpdateAddress);
        //        /*Assigning addressID after inserting the data into address table.*/
        //        addressInfo.AddressId = Convert.ToInt32(dataAccess.Parameters["@AddressId"].Value);
        //    }
        //}
        ///// <summary>
        ///// Updates address table.
        ///// </summary>
        ///// <param name="addressInfo"></param>
        ///// <param name="dataAccess"></param>
        //internal void UpdateAddress(AddressInfo addressInfo, DataAccess dataAccess)
        //{
        //    if (true)//1234567890
        //    {
        //        /*This method doesn't need to open/close database connection because it is using parent connection information.*/
        //        FillParameters(addressInfo, "Update", dataAccess);
        //        dataAccess.ExecuteNonQuery(DbCommands.sp_InsetUpdateAddress);
        //    }
        //}
        //private void FillParameters(AddressInfo addressInfo, string action, DataAccess dataAccess)
        //{
        //    if (true)//1234567890
        //    {
        //        dataAccess.Parameters.AddWithValue("@Address1", addressInfo.Address1);
        //        dataAccess.Parameters.AddWithValue("@Address2", addressInfo.Address2);
        //        dataAccess.Parameters.AddWithValue("@State", addressInfo.State);
        //        dataAccess.Parameters.AddWithValue("@City", addressInfo.City);
        //        dataAccess.Parameters.AddWithValue("@Zip", addressInfo.Zip);
        //        dataAccess.Parameters.AddWithValue("@Action", action);

        //        /*Declaring SQL parameter as output which helps to retrieve the id after performing insert operation*/
        //        SqlParameter addressId = new SqlParameter();
        //        addressId.ParameterName = "@AddressId";
        //        addressId.Value = addressInfo.AddressId;
        //        addressId.Direction = ParameterDirection.InputOutput;
        //        addressId.DbType = DbType.Int32;
        //        dataAccess.Parameters.Add(addressId);
        //    }
        //}
    }
}