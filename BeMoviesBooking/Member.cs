using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Configuration;
using System.Xml;

namespace BeMoviesBooking.DataAccess
{
    public class Member
    {

        SqlConnection cn = null;
        private SqlParameterCollection _parameters;
        SqlTransaction _sqlTran = null;
        public SqlParameterCollection Parameters
        {
            get { return _parameters; }
        }

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

        //public ParameterCollection Parameters = null;

        private SqlCommand cmd = null;
        public Member()
        {
            if (true)//1234567890
            {
                ImagineUpline.Global.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString1"].ToString();
                _parameters = GetInitCollection();
                string con = ConfigurationSettings.AppSettings["ConnectionString1"].ToString();
                cn = new SqlConnection(con);
            }
        }

        public void BeginTran()
        {
            _sqlTran = cn.BeginTransaction();
        }
        public void CommitTran()
        {
            if (_sqlTran != null)
                _sqlTran.Commit();
        }
        public void RollBackTran()
        {
            if (_sqlTran != null)
                _sqlTran.Rollback();
        }


        public void OpenConn(bool openConn)
        {
            if (true)//1234567890
            {
                if (openConn == true && cn.State.ToString() != "open")
                {
                    cn.Open();
                }
                else if (openConn == false && cn.State.ToString() == "open")
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }
        public void ExecuteNonQuery(string procName)
        {
            if (true)//1234567890
            {
                cmd = new SqlCommand();
                cmd.CommandText = procName;
                foreach (SqlParameter param in _parameters)
                    cmd.Parameters.Add(((ICloneable)param).Clone());
                cmd.Connection = cn;
                if (_sqlTran != null)
                    cmd.Transaction = _sqlTran;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                _parameters = cmd.Parameters;
            }
        }
        public SqlDataReader ExecReader(string procName)
        {
            SqlDataReader dr = null;
            if (true)//1234567890
            {
                cmd = new SqlCommand();
                cmd.CommandText = procName;
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (SqlParameter param in _parameters)
                    cmd.Parameters.Add(((ICloneable)param).Clone());
                //SqlDataReader 
                dr = cmd.ExecuteReader();
                _parameters = cmd.Parameters;
            }
            return dr;
        }

        /*SqlParameterCollection doesn't have public constructor hence using reflection to create a instance.
         We can also use generic list (List<SqlParameter>) to hold these parameters*/
        private SqlParameterCollection GetInitCollection()
        {
            return (SqlParameterCollection)typeof(SqlParameterCollection).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null).Invoke(null);
        }
        public DataSet BeGetAdminLogin(string tEmailID, string tPassword, ref string _Error)
        {
            DataSet ds = null;
            try
            {
                OpenConn(true);
                String query = "usp_GetAdminLogin";
                SqlCommand com = new SqlCommand(query, cn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@emailID", tEmailID);
                com.Parameters.AddWithValue("@password", tPassword);
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                _Error = "1";
            }
            catch (Exception ex)
            {
                _Error = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            finally
            {
                OpenConn(false);
            }
            return ds;
        }
        public DataSet beGetUserLogin(string tEmailID, string tPassword, ref string _Error)
        {
            DataSet ds = null;
            try
            {
                OpenConn(true);
                String query = "usp_GetUserLogin";
                SqlCommand com = new SqlCommand(query, cn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@emailID", tEmailID);
                com.Parameters.AddWithValue("@password", tPassword);
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                _Error = "1";
            }
            catch (Exception ex)
            {
                _Error = "-4:" + ex.Message + Environment.NewLine + ex.StackTrace;
            }
            finally
            {
                OpenConn(false);
            }
            return ds;
        }
        public DataSet beGetUserPassword(string tEmailID,  ref string _Error)
        {
            DataSet ds = null;
            try
            {
                OpenConn(true);
                String query = "usp_GetUserPassword";
                SqlCommand com = new SqlCommand(query, cn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@emailID", tEmailID);
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                _Error = "1";
            }
            catch (Exception ex)
            {
                _Error = "-4:" + ex.Message + Environment.NewLine + ex.StackTrace;
            }
            finally
            {
                OpenConn(false);
            }
            return ds;
        }
        public string beSaveRegistrationDetails(string AdminLoginDetails)
        {
            string tFirstName = "", tMiddleName = "", tLastName = "", tMobileNo = "", tEmailID = "", tPassword = "";
            bool tIsAdmin = false;
            XmlDocument objDoc = null;
            XmlNode objNode = null;
            SqlConnection objCon = null;
            SqlDataAdapter objDA = null;
            SqlCommandBuilder objCB = null;

            #region Retrive Data from XML
            try
            {
                objDoc = new XmlDocument();
                objDoc.LoadXml(AdminLoginDetails);

                objNode = objDoc.GetElementsByTagName("FirstName")[0];
                if (objNode != null)
                    tFirstName = objNode.InnerText;

                objNode = objDoc.GetElementsByTagName("MiddleName")[0];
                if (objNode != null)
                    tMiddleName = objNode.InnerText;

                objNode = objDoc.GetElementsByTagName("LastName")[0];
                if (objNode != null)
                    tLastName = objNode.InnerText;

                objNode = objDoc.GetElementsByTagName("MobileNo")[0];
                if (objNode != null)
                    tMobileNo = objNode.InnerText;

                objNode = objDoc.GetElementsByTagName("EmailID")[0];
                if (objNode != null)
                    tEmailID = objNode.InnerText;

                objNode = objDoc.GetElementsByTagName("Password")[0];
                if (objNode != null)
                    tPassword = objNode.InnerText;

                objNode = objDoc.GetElementsByTagName("IsAdmin")[0];
                if (objNode != null)
                    tIsAdmin = Convert.ToBoolean(objNode.InnerText);

            }
            catch (Exception ex)
            {
                return "-2: " + ex.Message + Environment.NewLine + ex.StackTrace;
            }
            #endregion Retrive Data from XML

            #region DataBase
            try
            {
                string tQuery = "Select Top 0 RID, FirstName, MiddleName, LastName, MobileNo, EmailID, Password, Status, IsAdmin from tbl_Login with (nolock)";
                using (objCon = new SqlConnection(ImagineUpline.Global.ConnectionString))
                {
                    objDA = new SqlDataAdapter(tQuery, objCon);
                    objCB = new SqlCommandBuilder(objDA);

                    objCB.GetUpdateCommand();
                    using (DataSet objDS = new DataSet())
                    {
                        objDA.Fill(objDS);
                        DataRow dr = objDS.Tables[0].NewRow();
                        dr["FirstName"] = tFirstName;
                        dr["MiddleName"] = tMiddleName;
                        dr["LastName"] = tLastName;
                        dr["MobileNo"] = tMobileNo;
                        dr["EmailID"] = tEmailID;
                        dr["Password"] = tPassword;
                        dr["Status"] = 1;
                        dr["IsAdmin"] = tIsAdmin;

                        objDS.Tables[0].Rows.Add(dr);
                        objDA.Update(objDS);
                    }
                }
                return "1";
            }
            catch (Exception ex)
            {
                return "-4: " + ex.Message + Environment.NewLine + ex.StackTrace;
            }
            #endregion DataBase
        }

        public string beSaveLogin(string tFirstname, string tMID, string tLastName, string tFatherName, string tMotherName, string tmobileno, string tUserName, string tPassword)
        {
            string i = "";
            if (true)//1234567890
            {
                try
                {
                    OpenConn(true);
                    SqlCommand cmd;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    String sql = "";
                    sql = "Insert into login(FirstName,MidName,LastName,FatherName,MotherName,Collage,Age,Mobleno,ModifiedUser,UserName,Password) values('" + tFirstname + "','" + tMID + "','" + tLastName + "','" + tFatherName + "','" + tMotherName + "','','','" + tmobileno + "','','" + tUserName + "','" + tPassword + "')";
                    cmd = new SqlCommand(sql, cn);
                    i = Convert.ToString(cmd.ExecuteNonQuery());
                    cmd.Dispose();
                }
                finally
                {
                    OpenConn(false);
                }
            }
            return i;
        }
        public DataSet beGetSelectList()
        {
            DataSet ds = null;
            if (true)//1234567890
            {
                try
                {
                    OpenConn(true);
                    String query = "Getalldata";
                    SqlCommand com = new SqlCommand(query, cn);
                    com.CommandType = CommandType.StoredProcedure;
                    // com.Parameters.AddWithValue("@Action", HiddenField2.Value).ToString();
                    ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(ds);
                }
                finally
                {
                    OpenConn(false);
                }
            }
            return ds;
        }

        public DataSet beGetcandidateDetails()
        {
            DataSet ds = null;
            if (true)//1234567890
            {
                try
                {
                    OpenConn(true);
                    SqlCommand cmd = new SqlCommand("Select * from candidateDetails", cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                }
                finally
                {
                    OpenConn(false);
                }
            }
            return ds;
        }
        public string beGetTripPlannerCandidateDetails(string txtFirstName, string txtLastName, string txtFatherName, string txtMotherName, string txtEmailid, string txtMobileNumber, string txtTripName, string txtNumberofDays, string txtLocation, string txtState, string txtcountry, string txtDescription, string txtAmountPerHead, string txtExtraCharge, string filename, byte[] bytes)
        {
            string i = "";
            if (true)//1234567890
            {
                try
                {
                    OpenConn(true);
                    SqlCommand cmd;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    String sql = "";
                    sql = "Insert into CANDIDATEDETAILS(FirstName,LastName,FatherName,MotherName,Mobleno,Emailid,Name,NoofDays,LLocation,State,Country,Description,Amountperhead,ExtraChange,Filename,filedata) values('" + txtFirstName + "','" + txtLastName + "','" + txtFatherName + "','" + txtMotherName + "','" + txtEmailid + "','" + txtMobileNumber + "','" + txtTripName + "','" + txtNumberofDays + "','" + txtLocation + "','" + txtState + "','" + txtcountry + "','" + txtDescription + "','" + txtAmountPerHead + "','" + txtExtraCharge + "','" + filename + "','" + Convert.ToBase64String(bytes) + "')";
                    cmd = new SqlCommand(sql, cn);
                    i = Convert.ToString(cmd.ExecuteNonQuery());
                    cmd.Dispose();
                }
                finally
                {
                    OpenConn(false);
                }
            }
            return i;
        }

        public string beDeleteTripPlanner(string str1)
        {
            string i = "";
            if (true)//1234567890
            {
                try
                {
                    OpenConn(true);
                    SqlCommand cmd = new SqlCommand("delete FROM candidateDetails where rid='" + Convert.ToInt32(str1.ToString()) + "'", cn);
                    i = Convert.ToString(cmd.ExecuteNonQuery());
                }
                finally
                {
                    OpenConn(false);
                }
            }
            return i;
        }
        public string beUpdateTripPlanner(string FirstName, string MidName, string LastName, string FatherName, string MotherName, string Age, string Mobleno, string userid)
        {
            string i = "";
            if (true)//1234567890
            {
                try
                {
                    OpenConn(true);
                    SqlCommand cmd = new SqlCommand("UPDATE candidateDetails set FirstName='" + FirstName + "',MidName='" + MidName + "',LastName='" + LastName + "' ,FatherName='" + FatherName + "', MotherName='" + MotherName + "', Age='" + Age + "', Mobleno='" + Mobleno + "' where rid='" + userid + "'", cn);
                    i = Convert.ToString(cmd.ExecuteNonQuery());
                }
                finally
                {
                    OpenConn(false);
                }
            }
            return i;
        }
        public DataSet beGetTripDetails()
        {
            DataSet ds = null;
            if (true)//1234567890
            {
                try
                {
                    OpenConn(true);
                    SqlCommand cmd = new SqlCommand("Select * from TripDetails", cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                }
                finally
                {
                    OpenConn(false);
                }
            }
            return ds;
        }
        public string beDeleteTripDetails(string str1)
        {
            string i = "";
            if (true)//1234567890
            {
                try
                {
                    OpenConn(true);
                    SqlCommand cmd = new SqlCommand("delete FROM TripDetails where rid='" + Convert.ToInt32(str1.ToString()) + "'", cn);
                    i = Convert.ToString(cmd.ExecuteNonQuery());
                }
                finally
                {
                    OpenConn(false);
                }
            }
            return i;
        }
        public string beUpdateTripDetails(string Name, string NoofDays, string Location, string State, string Country, string Description, string Amountperhead, string ExtraChange, string userid)
        {
            string i = "";
            if (true)//1234567890
            {
                try
                {
                    OpenConn(true);

                    SqlCommand cmd = new SqlCommand("UPDATE TripDetails set Name='" + Name + "',NoofDays='" + NoofDays + "',LLocation='" + Location + "' ,State='" + State + "', Country='" + Country + "', Description='" + Description + "', Amountperhead='" + Amountperhead + "',ExtraChange='" + ExtraChange + "' where rid='" + userid + "'", cn);
                    i = Convert.ToString(cmd.ExecuteNonQuery());
                }
                finally
                {
                    OpenConn(false);
                }
            }
            return i;
        }

        public string beInsertTripDetails(string tTripName, string tNumberofDays, string tLocation, string tState, string tcountry, string tDescription, string tAmountPerHead, string tExtraCharge, string filename, byte[] bytes)
        {
            string i = "";
            if (true)//1234567890
            {
                try
                {
                    OpenConn(true);

                    SqlCommand cmd;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    String sql = "Insert into TripDetails(Name,NoofDays,LLocation,State,Country,Description,Amountperhead,ExtraChange,Filename,filedata) values('" + tTripName + "','" + tNumberofDays + "','" + tLocation + "','" + tState + "','" + tcountry + "','" + tDescription + "','" + tAmountPerHead + "','" + tExtraCharge + "','" + filename + "','" + Convert.ToBase64String(bytes) + "')";
                    cmd = new SqlCommand(sql, cn);
                    i = Convert.ToString(cmd.ExecuteNonQuery());
                    cmd.Dispose();
                }
                finally
                {
                    OpenConn(false);
                }
            }
            return i;
        }
    }
}