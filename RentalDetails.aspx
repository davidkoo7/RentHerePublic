<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RentalDetails.aspx.cs" Inherits="RentalDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Rental Infomation	</a></li>
        </ul>

        <div class="row">
            <!--Middle Part Start-->
            <div id="content" class="col-sm-9">
                <h2 class="title">Rental Information</h2>
                <h2 class="title">Status: </h2>
                <asp:Repeater ID="rptItemRentalInfo" OnItemDataBound="rptItemRentalInfo_ItemDataBound" runat="server">
                    <ItemTemplate>
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <td colspan="2" class="text-left">Rental Details</td>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td style="width: 50%;" class="text-left"><b>Rental ID:</b>
                                        <asp:Label ID="lblRentalID" runat="server" Text='<%# Eval("rentalID") %>' />

                                        <br>
                                        <b>Date  Created:</b>
                                        <asp:Label ID="lblDateCreated" runat="server" Text='<%# Eval("dateCreated") %>' />

                                        <br>
                                        <b>Pick Up Location:</b>
                                        <asp:Label ID="lblPickUpLocation" runat="server" Text='<%# Eval("pickUpLocation") %>' />

                                        <br>
                                        <b>Pick Up Time:</b>
                                        <asp:Label ID="lblPickUpTime" runat="server" Text='<%# Eval("pickUpTime") %>' />






                                        <br>
                                    </td>
                                    <td style="width: 50%;" class="text-left">
                                        <b>Return Location: </b>
                                        <asp:Label ID="lblReturnLocation" runat="server" Text='<%# Eval("returnLocation") %>' />

                                        <br>
                                        <b>Return Time: </b>
                                        <asp:Label ID="lblReturnTime" runat="server" Text='<%# Eval("returnTime") %>' />
                                    </td>
                                    <br>
                                </tr>
                            </tbody>
                        </table>
                        <div class="table-responsive">
                            <table class="table table-bordered">
                                <thead>
                                    <tr>



                                        <td class="text-center">Image</td>
                                        <td class="text-left">Product Name</td>
                                        <td class="text-left">Rental Period</td>
                                        <td class="text-left">Rental Rate</td>

                                        <td class="text-left">Deposit Amount</td>
                                        <td class="text-right">Total</td>
                                    </tr>
                                </thead>
                                <tbody>




                                    <tr>



                                        <td class="text-center"><a href="product.html">
                                            <img width="60px" src="/image/item/<%# DataBinder.Eval(Container.DataItem, "Item.img1") %>" class="img-thumbnail"></a></td>
                                        <td class="text-left"><a href="product.html">
                                            <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("Item.name") %>' /></a></td>
                                        <td class="text-right">
                                            <asp:Label ID="lblRentalPeriod" runat="server" Text='<%# checkEndDate("" + Eval("rentalID")) %>'></asp:Label></td>
                                        <td class="text-right">
                                            <asp:Label ID="lblRentalRate" runat="server" Text='<%# Eval("rentalFee") %>'></asp:Label></td>
                                        <td class="text-right">
                                            <asp:Label ID="lblDepositAmount" runat="server" Text='<%# Eval("deposit") %>'></asp:Label></td>
                                        <td class="text-right">
                                            <asp:Label ID="lblTotalAmount" runat="server" Text=""></asp:Label></td>
                                    </tr>



                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td class="text-right" colspan="1"><strong>Meeting Location:</strong></td>
                                        <td class="text-left" colspan="5">
                                            <asp:Label ID="lblMeetingLocation" runat="server" Text=""></asp:Label></td>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="text-right" colspan="5"><strong>Total Amount Payable:</strong></td>
                                        <td class="text-right"><asp:Label ID="lblTotalAmountPayable" runat="server" Text=""></asp:Label></td>
</td>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <h3>Payment History</h3>
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <td class="text-left">Date Added</td>
                            <td class="text-left">Status</td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="text-left">20/06/2016</td>
                            <td class="text-left">Processing</td>
                        </tr>
                        <tr>
                            <td class="text-left">21/06/2016</td>
                            <td class="text-left">Shipped</td>
                        </tr>
                        <tr>
                            <td class="text-left">24/06/2016</td>
                            <td class="text-left">Complete</td>
                        </tr>
                    </tbody>
                </table>

                <h3>Payment History</h3>
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <td class="text-left">PaymentID</td>
                            <td class="text-left">Amount</td>

                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="text-left">20/06/2016</td>
                            <td class="text-left">Processing</td>
                        </tr>
                        <tr>
                            <td class="text-left">21/06/2016</td>
                            <td class="text-left">Shipped</td>
                        </tr>
                        <tr>
                            <td class="text-left">24/06/2016</td>
                            <td class="text-left">Complete</td>
                        </tr>
                    </tbody>
                </table>
                <div class="buttons clearfix">
                    <div class="pull-right">
                        <a class="btn btn-primary" href="#">Continue</a>
                    </div>
                </div>

            </div>
            <!--Middle Part End-->
            <!--Right Part Start -->
            <aside class="col-sm-3 hidden-xs" id="column-right">
                <h2 class="subtitle">Account</h2>
                <div class="list-group">
                    <ul class="list-item">
                        <li><a href="login.html">Login</a>
                        </li>
                        <li><a href="register.html">Register</a>
                        </li>
                        <li><a href="#">Forgotten Password</a>
                        </li>
                        <li><a href="#">My Account</a>
                        </li>
                        <li><a href="#">Address Books</a>
                        </li>
                        <li><a href="wishlist.html">Wish List</a>
                        </li>
                        <li><a href="#">Order History</a>
                        </li>
                        <li><a href="#">Downloads</a>
                        </li>
                        <li><a href="#">Reward Points</a>
                        </li>
                        <li><a href="#">Returns</a>
                        </li>
                        <li><a href="#">Transactions</a>
                        </li>
                        <li><a href="#">Newsletter</a>
                        </li>
                        <li><a href="#">Recurring payments</a>
                        </li>
                    </ul>
                </div>
            </aside>
            <!--Right Part End -->
        </div>
    </div>

</asp:Content>

