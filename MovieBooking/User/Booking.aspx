<%@ Page Title="" Language="C#" MasterPageFile="~/User/Site.Master" AutoEventWireup="true" EnableEventValidation="false" EnableViewStateMac="false" EnableViewState="true" CodeBehind="Booking.aspx.cs" Inherits="MovieBooking.User.Booking" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../css/booking.css" rel="stylesheet" />
    <script>
        function disableBookedSeat(disabledSeats) {
            debugger;
            console.log(disabledSeats);
            let seats = disabledSeats.split(',');
            for (i = 0; i < seats.length; i++) {
                var seat = document.getElementById(seats[i]);
                seat.disabled = true;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="plane">
        <div class="cockpit">
            <h1>Please select a seat</h1>
        </div>
        <div class="exit exit--front fuselage">
        </div>
        <ol class="cabin fuselage">
            <li class="row row--1">
                <ol class="seats" type="A">
                    <li class="seat">
                        <asp:CheckBox ID="A1" runat="server" OnCheckedChanged="A1_CheckedChanged" Text="A1" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="B1" runat="server" OnCheckedChanged="B1_CheckedChanged" Text="B1" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="C1" runat="server" OnCheckedChanged="C1_CheckedChanged" Text="C1" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="D1" runat="server" OnCheckedChanged="D1_CheckedChanged" Text="D1" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="E1" runat="server" OnCheckedChanged="E1_CheckedChanged" Text="E1" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="F1" runat="server" OnCheckedChanged="F1_CheckedChanged" Text="F1" AutoPostBack="true" />
                    </li>
                </ol>
            </li>
            <li class="row row--2">
                <ol class="seats" type="A">
                    <li class="seat">
                        <asp:CheckBox ID="A2" runat="server" OnCheckedChanged="A2_CheckedChanged" Text="A2" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="B2" runat="server" OnCheckedChanged="B2_CheckedChanged" Text="B2" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="C2" runat="server" OnCheckedChanged="C2_CheckedChanged" Text="C2" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="D2" runat="server" OnCheckedChanged="D2_CheckedChanged" Text="D2" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="E2" runat="server" OnCheckedChanged="E2_CheckedChanged" Text="E2" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="F2" runat="server" OnCheckedChanged="F2_CheckedChanged" Text="F2" AutoPostBack="true" />
                    </li>
                </ol>
            </li>
            <li class="row row--3">
                <ol class="seats" type="A">
                    <li class="seat">
                        <asp:CheckBox ID="A3" runat="server" OnCheckedChanged="A3_CheckedChanged" Text="A3" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="B3" runat="server" OnCheckedChanged="B3_CheckedChanged" Text="B3" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="C3" runat="server" OnCheckedChanged="C3_CheckedChanged" Text="C3" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="D3" runat="server" OnCheckedChanged="D3_CheckedChanged" Text="D3" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="E3" runat="server" OnCheckedChanged="E3_CheckedChanged" Text="E3" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="F3" runat="server" OnCheckedChanged="F3_CheckedChanged" Text="F3" AutoPostBack="true" />
                    </li>
                </ol>
            </li>
            <li class="row row--4">
                <ol class="seats" type="A">
                    <li class="seat">
                        <asp:CheckBox ID="A4" runat="server" OnCheckedChanged="A4_CheckedChanged" Text="A4" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="B4" runat="server" OnCheckedChanged="B4_CheckedChanged" Text="B4" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="C4" runat="server" OnCheckedChanged="C4_CheckedChanged" Text="C4" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="D4" runat="server" OnCheckedChanged="D4_CheckedChanged" Text="D4" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="E4" runat="server" OnCheckedChanged="E4_CheckedChanged" Text="E4" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="F4" runat="server" OnCheckedChanged="F4_CheckedChanged" Text="F4" AutoPostBack="true" />
                    </li>
                </ol>
            </li>
            <li class="row row--5">
                <ol class="seats" type="A">
                    <li class="seat">
                        <asp:CheckBox ID="A5" runat="server" OnCheckedChanged="A5_CheckedChanged" Text="A5" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="B5" runat="server" OnCheckedChanged="B5_CheckedChanged" Text="B5" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="C5" runat="server" OnCheckedChanged="C5_CheckedChanged" Text="C5" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="D5" runat="server" OnCheckedChanged="D5_CheckedChanged" Text="D5" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="E5" runat="server" OnCheckedChanged="E5_CheckedChanged" Text="E5" AutoPostBack="true" />
                    </li>
                    <li class="seat">
                        <asp:CheckBox ID="F5" runat="server" OnCheckedChanged="F5_CheckedChanged" Text="F5" AutoPostBack="true" />
                    </li>
                </ol>
            </li>

        </ol>
        <div class="exit exit--back fuselage">
        </div>
        <div class="d-flex justify-content-center">
            <asp:Button ID="btnProceed" runat="server" Text="Proceed" class="btn btn-danger" OnClick="btnProceed_Click" />
        </div>
        <asp:HiddenField ID="hdnMovieID" runat="server" />
    </div>

</asp:Content>
