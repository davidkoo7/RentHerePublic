<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ItemPostedDetails.aspx.cs" Inherits="ItemPostedDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:Repeater ID="rptInfo" runat="server">
        <ItemTemplate>
            <div class="main-container container">
                <ul class="breadcrumb">
                    <li><a href="#"><i class="fa fa-home"></i></a></li>
                    <li><a href="#">Item Infomation	</a></li>
                </ul>

                <div class="row">
                    <!--Middle Part Start-->
                    <div id="content" class="col-sm-9">
                        <h2 class="title">Item Information</h2>
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <td colspan="2" class="text-left">Item Details</td>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td style="width: 50%;" class="text-left"><b>Item ID:</b>
                                        <a href="productDetails.aspx?itemID=<%#Eval("itemID") %>">
                                            <asp:Label ID="lblRentalID" runat="server" Text='<%# Eval("itemID") %>' /></a>
                                        <br>
                                        <b>Item Name:</b>
                                        <asp:Label ID="lblitemName" runat="server" Text='<%# "" + Eval("name") %>'></asp:Label>
                                        <br>
                                        <b>Posted  Date:</b>
                                        <asp:Label ID="lblPostedDate" runat="server" Text='<%# "" + String.Format("{0:MM/dd/yy}", Eval("postedDate")) %>'></asp:Label>
                                        <br>
                                        <b>Location:</b>
                                        <asp:Label ID="lblLocation" runat="server" Text='<%# "" + Eval("Location.name") %>'></asp:Label>
                                        <br>
                                        <b>Category:</b>
                                        <asp:Label ID="lblCategoryName" runat="server" Text='<%# "" + Eval("CategoryName.name") %>'></asp:Label>



                                        <br>
                                    </td>
                                    <td style="width: 50%;" class="text-left"><b>Rental Rate:</b>
                                        <asp:Label ID="lblDeposit" runat="server" Text='<%# "" + Eval("deposit") %>'></asp:Label>
                                        <br>
                                        <b>Price Per Day:</b>
                                        <asp:Label ID="lblpricePerDay" runat="server" Text='<%# "" + Eval("pricePerDay") %>'></asp:Label>
                                        <br>
                                        <b>Price Per Week:</b>
                                        <asp:Label ID="lblpricePerWeek" runat="server" Text='<%# "" + Eval("pricePerWeek") %>'></asp:Label>
                                        <br>
                                        <b>Price Per Month:</b>
                                        <asp:Label ID="lblpricePerMonth" runat="server" Text='<%# "" + Eval("pricePerMonth") %>'></asp:Label>
                                        <br>
                                    </td>
                                    <br>
                                </tr>
                            </tbody>
                        </table>
        </ItemTemplate>
    </asp:Repeater>

    <h3>Rental History</h3>
    <table class="table table-bordered table-hover">
        <thead>
            <tr>
                <td class="text-left">RentalID</td>
                <td class="text-left">Rental Period</td>
                <td class="text-left">Status</td>
                <td class="text-left">Rentee Name</td>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptRentalHistory" runat="server">
                <ItemTemplate>
                    <tr>

                        <td class="text-left">
                            <asp:Label ID="lblRentalID" runat="server" Text='<%# "" + Eval("rentalID") %>'></asp:Label></td>
                        <td class="text-left">
                            <asp:Label ID="lblRentalPeriod" runat="server" Text='<%# Utility.getRentalPeriod("" + Eval("rentalID")) %>'></asp:Label></td>
                        <td class="text-left">
                            <asp:Label ID="lblStatus" runat="server" Text='<%# "" + Eval("status") %>'></asp:Label></td>

                        <td class="text-center">
                            <a href="User.aspx?memberID=<%#Eval("Rentee.MemberID") %>">
                                <asp:Label ID="lblRenteeName" runat="server" Text='<%# "" + Eval("Rentee.name") %>'></asp:Label>
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>

