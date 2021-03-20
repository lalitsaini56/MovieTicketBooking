/*
 * Sample Project Created for Freshers or Junior Developers.
 * Developed by Vasu Ravuri, Please look at below link for more details
 * http://dotnettrainer.wordpress.com/ or http://onlinetrainingdotnet.com
 */


namespace BeMoviesBooking.BusinessInfo
{
    /// <summary>
    /// Summary description for Member
    /// </summary>
    public class MemberInfo
    {
        public MemberInfo()
        {
            _address = new AddressInfo(); 
        }
        #region Class Members

        private int _memberId;
        private int _addressId;
        private string _lastName;
        private string _firstName;
        private string _middleName;
        private string _phoneNo;
        private string _mobileNo;
        private string _email;
        private string _memberType;
        private AddressInfo _address = null;

        //these properties can also declared as  public int MemberId { get; set; }
        public int MemberId
        {
            get { return _memberId; }
            set { _memberId = value; }
        }
        public int AddressId
        {
            get { return _addressId; }
            set { _addressId = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }
        public string PhoneNo
        {
            get { return _phoneNo; }
            set { _phoneNo = value; }
        }
        public string MobileNo
        {
            get { return _mobileNo; }
            set { _mobileNo = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string MemberType
        {
            get { return _memberType; }
            set { _memberType = value; }
        }
        public AddressInfo AddressInfo
        {
            get { return _address; }
            set { _address = value; }
        }

        #endregion

    }
    public class AddressInfo
    {
        #region Class Members

        private int _addressId;
        private string _address1;
        private string _address2;
        private string _city;
        private string _state;
        private string _zip;

        //these properties can also declared as  public int AddressId { get; set; }

        public int AddressId
        {
            get { return _addressId; }
            set { _addressId = value; }
        }
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        public string Address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }
        #endregion
    }
}
