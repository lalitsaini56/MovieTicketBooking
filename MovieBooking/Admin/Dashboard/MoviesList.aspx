<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" EnableEventValidation="false" EnableViewStateMac="false" EnableViewState="false" CodeBehind="MoviesList.aspx.cs" Inherits="MovieBooking.Admin.Dashboard.MoviesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/movie-list.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <form action="/" method="post" runat="server">
        <section class="content-wrapper">
            <div class="container-fluid">
                <div class="row">
                    <section role="main" class="col-md-9 col-lg-12 px-4 margin-bottom">
                        <div class="col-lg-12 border-bottom">
                            <a href="AddMovies.aspx" class="btn btn-primary float-right">Add Movie</a>
                        </div>
                        <div class="pt-8 pb-2 mb-3 border-bottom">
                            <div class="row">
                                <h1>Movies</h1>

                            </div>

                            <asp:Repeater runat="server" ID="Repeater1">
                                <ItemTemplate>
                                        <div class="card-view">
                                            <div class="card-header">
                                                <div class="card-header-icon" style="height: 100%">
                                                    <asp:Image runat="server" class="image movie-img" Style="max-height: 100%" src='<%# Eval("ImagePath") %>' />
                                                    <a href="#">
                                                        <i class="material-icons header-icon fa"></i>
                                                    </a>
                                                </div>
                                            </div>

                                            <div class="card-movie-content">
                                                <div class="card-movie-content-head">
                                                    <a href="#">
                                                        <asp:Label runat="server" class="card-movie-title" Text='<%# Eval("MovieName") %>'></asp:Label>
                                                    </a>
                                                    <div class="ratings">
                                                        <span>
                                                            <asp:Label runat="server" Text='<%# Eval("MovieRating") %>'></asp:Label></span>/5
                                                    </div>
                                                </div>
                                                <div class="card-movie-info">
                                                    <div class="movie-running-time">
                                                        <label>Last update</label>

                                                        <span>
                                                            <asp:Label runat="server" Text='<%# Eval("LastModifieddate") %>'></asp:Label></span>
                                                    </div>
                                                    <div class="movie-running-time">
                                                        <label>Running time</label>
                                                        <span>
                                                            <asp:Label runat="server" Text='<%# Eval("MovieDuration") %>'></asp:Label></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </section>
                </div>
            </div>
        </section>
    </form>
</asp:Content>
