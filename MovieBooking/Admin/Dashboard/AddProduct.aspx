<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" EnableEventValidation="false" EnableViewStateMac="false" EnableViewState="false" CodeBehind="AddProduct.aspx.cs" Inherits="MovieBooking.Account.AddProduct" %>

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
                            <label>Product Name</label>
                            <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" placeholder="Enter Product"></asp:TextBox>
                        </div>

                      <%--  <div class="form-group">
                            <label>Movie Director</label>
                            <asp:TextBox ID="txtProductCategory" runat="server" CssClass="form-control" placeholder="Enter Movie Director Name"></asp:TextBox>
                        </div>--%>

                      <%--  <div class="form-group">
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
                        </div>--%>

                        <div class="form-group">
                            <label>Product Image</label>
                            <div class="input-group">
                                <div class="custom-file">
                                    <asp:FileUpload ID="flpProduct" runat="server" class="custom-file-input" />
                                    <label class="custom-file-label" for="exampleInputFile">Choose file</label>
                                </div>
                                <div class="input-group-append">
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-default" OnClick="btnUpload_Click" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label>Product Summary</label>
                            <asp:TextBox ID="txtProductSummary" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" placeholder="Enter Product Summary"></asp:TextBox>
                        </div>
                         <div class="form-group">
                            <label>Product Price</label>
                            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" placeholder="Enter Product Price"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</asp:Content>
