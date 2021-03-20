<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" EnableEventValidation="false" Inherits="MovieBooking.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">

        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                    <div class="col-lg-4 d-none d-lg-block bg-register-image"></div>
                    <div class="col-lg-8">
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Create an Account!</h1>
                            </div>

                            <div class="form-group row">
                                <div class="col-sm-4 ">
                                    <asp:TextBox type="text" class="form-control form-control-user" runat="server" ID="txtFirstName" placeholder="First Name"></asp:TextBox>

                                </div>

                                <div class="col-sm-4 ">
                                    <asp:TextBox type="text" class="form-control form-control-user" runat="server" ID="txtMiddleName" placeholder="Middle Name"></asp:TextBox>

                                </div>

                                <div class="col-sm-4">
                                    <asp:TextBox type="text" class="form-control form-control-user" runat="server" ID="txtLastName" placeholder="Last Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">

                                <div class="col-sm-6 ">
                                    <asp:TextBox type="text" class="form-control form-control-user" runat="server" ID="txtMobileNo" placeholder="Mobile No" MaxLength="10"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 ">
                                    <asp:TextBox class="form-control form-control-user" runat="server" ID="txtEmailID" placeholder="Email Address"></asp:TextBox>
                                </div>



                            </div>
                            <div class="form-group row">
                                <div class="col-sm-6 ">
                                    <asp:TextBox type="password" class="form-control form-control-user" runat="server" ID="txtPassword" placeholder="Password"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox type="password" class="form-control form-control-user" runat="server" ID="txtConfirmPassword" placeholder="Confirm Password"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col-sm-6 ">
                                    <asp:TextBox class="form-control form-control-user" Enabled="false" runat="server" ID="txtOTP" placeholder="OTP" MaxLength="6"></asp:TextBox>
                                </div>

                            </div>

                            <asp:LinkButton ID="btnGetOTP" runat="server" class="btn btn-primary btn-user btn-block" Text="Get OTP" OnClientClick="return Validate();" OnClick="btnGetOTP_Click">
                            </asp:LinkButton>

                            <asp:LinkButton ID="btnRegister" runat="server" class="btn btn-primary btn-user btn-block" Text="Register Account" OnClick="btnRegister_Click" Visible="false">
                            </asp:LinkButton>

                            <hr>
                            <div class="text-center">
                                <a class="small" href="ForgotPassword.aspx">Forgot Password?</a>
                            </div>
                            <div class="text-center">
                                <a class="small" href="login.aspx">Already have an account? Login!</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <script>
        function validateEmail(email) {
            var pattern = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            return pattern.test(String(email).toLowerCase());
        }

        function validateName(name) {
            var pattern = /^[a-zA-Z'.\s]{1,50}/;
            return pattern.test(String(name).toLowerCase());
        }v

        function validateMobile(mobileNo) {
            var pattern = /[0-9]{10}/;
            return pattern.test(String(mobileNo).toLowerCase());
        }

    </script>
    <script type="text/javascript">
        function Validate() {
            debugger;
            var msg = "";
            if (!validateEmail(document.getElementById('<% =txtEmailID.ClientID %>').value.trim())) {
                msg += "Enter a valid Email ID\r\n\r\n";
            }

            if (!validateMobile(document.getElementById('<% =txtMobileNo.ClientID %>').value.trim())) {
                msg += "Enter a valid MobileNo. \r\n\r\n";
            }

            if (!validateName(document.getElementById('<% =txtFirstName.ClientID %>').value.trim())) {
                msg += "Enter a valid first name\r\n\r\n";
            }

          <%--  if (!validateName(document.getElementById('<% =txtMiddleName.ClientID %>').value.trim())) {
                msg += "Enter a valid middle name\r\n\r\n";
            }--%>

            if (!validateName(document.getElementById('<% =txtLastName.ClientID %>').value.trim())) {
                msg += "Enter a valid last name\r\n\r\n";
            }


            if (document.getElementById('<% =txtPassword.ClientID %>').value.length <= 6) {
                msg += "Enter a valid Pasword.\r\n\r\n";
            }

            if (document.getElementById('<% =txtPassword.ClientID %>').value != document.getElementById('<% =txtConfirmPassword.ClientID %>').value) {
                msg += "Entered password and confirm password is not match.\r\n\r\n";
            }

            if (msg != '') {
                alert(msg)
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
