<%@ Page Title="" Language="C#" MasterPageFile="~/User/Site.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="MovieBooking.User.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Payment</h3>
    <div class="d-flex justify-content-center align-items-center">
        <div style="width: 60%">
            <div class='form-row row'>
                <div class='col-md-12'>
                    <label class='control-label'>Name on Card</label>
                    <input class='form-control' size='4' type='text'>
                </div>
            </div>
            <div class='form-row'>
                <div class='col-md-12 required'>
                    <label class='control-label'>Card Number</label>
                    <input autocomplete='off' class='form-control' size='20' type='text'>
                </div>

            </div>
            <div class='form-row'>
                <div class='col-xs-4 form-group cvc required'>
                    <label class='control-label'>CVC</label>
                    <input autocomplete='off' class='form-control card-cvc' placeholder='ex. 311' size='4' type='text'>
                </div>
                <div class='col-xs-4 form-group expiration required'>
                    <label class='control-label'>Month</label>
                    <input class='form-control card-expiry-month' placeholder='MM' size='2' type='text'>
                </div>
                <div class='col-xs-4 form-group expiration required'>
                    <label class='control-label'>Year</label>
                    <input class='form-control card-expiry-year' placeholder='YYYY' size='4' type='text'>
                </div>
            </div>
            <div class='form-row'>
                <div class='col-md-12'>
                    <div class='form-control total btn btn-info'>
                        Total:
                 
                                <span class='amount'>
                                    <asp:Label runat="server" ID="lblAmount"></asp:Label>
                                </span>
                    </div>
                </div>
            </div>
            <div class='form-row mt-3'>
                <div class='col-md-12 form-group'>
                    <asp:Button ID="btnPay" runat="server" class='form-control btn btn-primary submit-button' OnClick="btnPay_Click" Text="Pay »" Visible="false" />
                    <asp:Button ID="btnProductPay" runat="server" class='form-control btn btn-primary submit-button' OnClick="btnProductPay_Click" Text="Pay »" Visible="false" />
                </div>
            </div>
            <div class='form-row'>
                <div class='col-md-12 error form-group hide'>
                    <%--<div class='alert-danger alert'>
                        Please correct the errors and try again.
               
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnMovieID" runat="server" />
</asp:Content>
