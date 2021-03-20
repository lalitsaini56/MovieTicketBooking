<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" EnableEventValidation="false" Inherits="MovieBooking.Account.Login" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <%--    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>--%>
    <div class="container">
        <!-- Outer Row -->
        <div class="row justify-content-center">
            <div class="col-xl-10 col-lg-12 col-md-9">
                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                            <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                            <div class="col-lg-6">
                                <div class="p-5">
                                    <div class="text-center">
                                        <h1 class="h4 text-gray-900 mb-4">Welcome Back!</h1>
                                    </div>
                                        <div class="form-group">
                                            <asp:TextBox  class="form-control form-control-user" ID="txtUserName" runat="server"  placeholder="Enter Email Address..."></asp:TextBox>

                                          

                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox type="password" class="form-control form-control-user" ID="txtPassword" runat="server" placeholder="Password"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <div class="custom-control custom-checkbox small">
                                                <input type="checkbox" class="custom-control-input" id="customCheck">
                                                <label class="custom-control-label" for="customCheck">Remember Me</label>
                                            </div>
                                        </div>
                                        <asp:LinkButton ID="btnLogin1" runat="server" class="btn btn-primary btn-user btn-block" OnClientClick="return Validate();" Text="Login" OnClick="btnLogin_Click">
                                        </asp:LinkButton><%--href="Manage.aspx"--%>
                                        <%--<hr>
                    <a href="index.html" class="btn btn-google btn-user btn-block">
                      <i class="fab fa-google fa-fw"></i> Login with Google
                    </a>
                    <a href="index.html" class="btn btn-facebook btn-user btn-block" >
                      <i class="fab fa-facebook-f fa-fw"></i> Login with Facebook
                    </a>--%>
                                    </form>
                                    <hr>
                                    <div class="text-center">
                                        <a class="small" href="ForgotPassword.aspx">Forgot Password?</a>
                                    </div>
                                    <div class="text-center">
                                        <a class="small" href="register.aspx">Create an Account!</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
   
     <script type="text/javascript">
        function Validate() {
            debugger;
            var msg = "";
            if (!validateEmail(document.getElementById('<% =txtUserName.ClientID %>').value.trim())) {
                msg += "Enter a valid Email ID\r\n\r\n";
            }

            if (document.getElementById('<% =txtPassword.ClientID %>').value.length <=6) {
                msg += "Enter a valid Pasword ID\r\n\r\n";
            }

            if (msg != '') {
                alert(msg)
                return false;
            }
            return true;
        }

        function validateEmail(email) {
            var pattern = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            return pattern.test(String(email).toLowerCase());
        }

     </script>

    <!-- Bootstrap core JavaScript-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
    <!-- Custom scripts for all pages-->
    <script src="js/sb-admin-2.min.js"></script>
</asp:Content>
