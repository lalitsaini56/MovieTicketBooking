<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="MovieBooking.Admin.Dashboard.CustomerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <form runat="server" method="post">
        <section class="content-wrapper">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">Customer List</h3>
                            </div>
                            <!-- /.card-header -->
                            <div class="card-body">
                                <asp:GridView ID="grdCustomerList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Customer ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" class="card-movie-title" Text='<%# Eval("CustomerID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Customer Name">
                                            <ItemTemplate>
                                                <asp:Label runat="server" class="card-movie-title" Text='<%# Eval("CustomerName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Booking Date">
                                            <ItemTemplate>
                                                <asp:Label runat="server" class="card-movie-title" Text='<%# Eval("BookingDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Movie Name">
                                            <ItemTemplate>
                                                <asp:Label runat="server" class="card-movie-title" Text='<%# Eval("MovieName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Seat No">
                                            <ItemTemplate>
                                                <asp:Label runat="server" class="card-movie-title" Text='<%# Eval("SeatNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                            <!-- /.card-body -->
                        </div>
                        <!-- /.card -->
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </section>
    </form>
</asp:Content>
