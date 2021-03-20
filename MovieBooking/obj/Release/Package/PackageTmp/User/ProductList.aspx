<%@ Page Title="" Language="C#" MasterPageFile="~/User/Site.Master" AutoEventWireup="true" EnableEventValidation="false" EnableViewStateMac="false" EnableViewState="false" CodeBehind="ProductList.aspx.cs" Inherits="MovieBooking.User.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Admin/css/movie-list.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <%--<form action="/" method="post" runat="server">
        <section class="content-wrapper">--%>
    <div class="container-fluid">
        <div class="row">
            <section role="main" class="col-md-9 col-lg-12 px-4 margin-bottom">

                <div class="pt-8 pb-2 mb-3 border-bottom">
                    <div class="row">
                        <h1>Products</h1>
                    </div>

                    <asp:Repeater runat="server" ID="rptProducts">
                        <ItemTemplate>

                            <div class="card-view">
                                <div class="card-header">
                                    <div class="card-header-icon" style="height: 100%">
                                        <asp:Image runat="server" class="image movie-img" Style="max-height: 100%" src='<%# Eval("ImagePath") %>' />

                                    </div>
                                </div>

                                <div class="card-movie-content">
                                    <div class="card-movie-content-head">
                                        <a href="#">
                                            <asp:Label runat="server" class="card-movie-title" Text='<%# Eval("ProductName") %>'></asp:Label>
                                        </a>
                                        <div class="ratings">
                                            <span>
                                                <asp:Label runat="server" Text='<%# Eval("ProductRating") %>'></asp:Label></span>/5
                                        </div>
                                    </div>
                                    <div class="card-movie-info">
                                        <div class="product-running-time">
                                            <label>Price</label>

                                            <span>
                                                <asp:Label runat="server" Text='<%# Eval("ProductPrice") %>'></asp:Label></span>
                                        </div>
                                        <div class="product-running-time">
                                            <label>About Product</label>
                                            <span>
                                                <asp:Label runat="server" Text='<%# Eval("ProductSummary") %>'></asp:Label></span>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <asp:LinkButton ID="btnBook" runat="server" CssClass="btn btn-primary" Text="Add To Cart" href='<%# "Payment.aspx?Price=" + Eval("ProductPrice")%>' />
                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </section>
        </div>
    </div>
    <%--</section>
    </form>--%>
</asp:Content>
