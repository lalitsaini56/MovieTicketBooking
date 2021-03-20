<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MovieBooking._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <header>
        <div class="mySlides" style="background-image: url(../img/Slide1.jpg)">
            <div class="my-slide">
            </div>
        </div>
        <div class="mySlides" style="background-image: url(../img/Slide2.jpg)">
            <div class="my-slide">
            </div>
        </div>
        <div class="mySlides" style="background-image: url(../img/Slide3.jpg)">
            <div class="my-slide">
            </div>
        </div>
    </header>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Page Content -->
    <div class="container">
        <h1 class="my-4">Welcome to Threater Time</h1>
        <!-- Marketing Icons Section -->
        <div class="row">
            <asp:Repeater runat="server" ID="rptMovies">
                <ItemTemplate>
                    <div class="col-lg-4 mb-4">
                        <div class="card h-100">
                            <h4 class="card-header"><%# Eval("MovieName") %></h4>
                            <div class="card-body">
                                <p class="card-text">
                                    <img src='<%# Eval("ImagePath") %>' style="width: 100%;" />
                                </p>
                            </div>
                            <div class="card-footer">
                                <h6 class="card-header">Duration: <%# Eval("MovieDuration") %></h6>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!-- /.row -->

        <!-- Portfolio Section -->
        <h2>Products</h2>

        <div class="row">
            <asp:Repeater runat="server" ID="rptProducts">
                <ItemTemplate>
                    <div class="col-lg-4 mb-4">
                        <div class="card h-100">
                            <h4 class="card-header"><%# Eval("ProductName") %></h4>
                            <div class="card-body">
                                <p class="card-text">
                                    <img src='<%# Eval("ImagePath") %>' style="width: 100%;" />
                                </p>
                            </div>
                            <%--<div class="card-footer">--%>
                                <h6 class="card-header"> <%# Eval("ProductSummary") %></h6>
                            <%--</div>--%>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!-- /.row -->
        <hr />
        <!-- Features Section -->
        <div class="row">
            <div class="col-lg-6">
                <h3>Best Investor of Year</h3>
                <strong>Mr. Randhawa is best Investor of our project.</strong>
                <p>
                    He invested alot in this project in the memory of his parents...
                   
                    <br />
                    Thank you Mr.randhawa
                </p>
            </div>
            <div class="col-lg-6">
                <img class="img-fluid rounded" src="../img/punjabi_singer_guru_randhawa.jpg" alt="">
                <hr>

                <!-- Call to Action Section -->
                <div class="row mb-4" style="display: none;">
                    <div class="col-md-8">
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Molestias, expedita, saepe, vero rerum deleniti beatae veniam harum neque nemo praesentium cum alias asperiores commodi.</p>
                    </div>
                    <div class="col-md-4">
                        <a class="btn btn-lg btn-secondary btn-block" href="#">Call to Action</a>
                    </div>
                </div>

            </div>
            <!-- /.container -->
        </div>
    </div>
    <!-- Footer -->
   <%-- <footer class="py-5 bg-dark" style="margin-left: -15%;">
        <div class="container">
            <p class="m-0 text-center text-white">Copyright &copy; Your Website 2020</p>
        </div>
        <!-- /.container -->
    </footer>--%>

    <!-- Bootstrap core JavaScript -->
    <style>
        .mySlides {
            height: 50vh;
            width: 100%;
            background-size: cover;
            background-repeat: no-repeat;
            border-radius: 10px;
        }

        .my-slide {
            width: 100%
        }
    </style>
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script>
        var myIndex = 0;
        carousel();

        function carousel() {
            var i;
            var x = document.getElementsByClassName("mySlides");
            for (i = 0; i < x.length; i++) {
                x[i].style.display = "none";
            }
            myIndex++;
            if (myIndex > x.length) { myIndex = 1 }
            x[myIndex - 1].style.display = "block";
            setTimeout(carousel, 2000); // Change image every 2 seconds
        }
    </script>
</asp:Content>
