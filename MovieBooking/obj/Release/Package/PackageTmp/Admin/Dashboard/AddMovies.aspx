<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" EnableEventValidation="false" EnableViewStateMac="false" EnableViewState="false" CodeBehind="AddMovies.aspx.cs" Inherits="MovieBooking.Account.AddMovies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../plugins/summernote/summernote-bs4.css" rel="stylesheet" />
    <script type="text/javascript" src="../plugins/summernote/summernote-bs4.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <form runat="server">
        <section class="content-wrapper">
            <div class="container-fluid pl-4">
                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                            <label>Movie Name</label>
                            <asp:TextBox ID="txtMovieName" runat="server" CssClass="form-control" placeholder="Enter Movie Name"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>Movie Director</label>
                            <asp:TextBox ID="txtMovieDirector" runat="server" CssClass="form-control" placeholder="Enter Movie Director Name"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>Movie Actors</label>
                            <asp:TextBox ID="txtMovieActors" runat="server" CssClass="form-control" placeholder="Enter Movie Actor and Actress Name"></asp:TextBox>
                        </div>

                        <div class="row form-group">
                            <div class="col-md-6">
                                <label>Start Time</label>
                                <asp:TextBox ID="txtStartTime" runat="server" CssClass="form-control" type="time"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label>End Time</label>
                                <asp:TextBox ID="txtEndTime" runat="server" CssClass="form-control" type="time"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label>Movie Image</label>
                            <div class="input-group">
                                <div class="custom-file">
                                    <asp:FileUpload ID="flpMovieImage" runat="server" class="custom-file-input" />
                                    <label class="custom-file-label" for="exampleInputFile">Choose file</label>
                                </div>
                                <div class="input-group-append">
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-default" OnClick="btnUpload_Click" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label>Movie Summary</label>
                            <asp:TextBox ID="txtMovieSummary" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" placeholder="Enter Movie Movie Summary"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <asp:HiddenField runat="server" ID="hdnImagePath" />
    </form>
</asp:Content>
