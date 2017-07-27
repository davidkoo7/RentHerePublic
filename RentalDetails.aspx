<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RentalDetails.aspx.cs" Inherits="RentalDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="dist/hotel-datepicker.css">

    <script type="text/javascript" src="dist/fecha.min.js"></script>
    <script type="text/javascript" src="dist/hotel-datepicker.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Rental Infomation	</a></li>
        </ul>
        <asp:Repeater ID="rptItemRentalInfo" OnItemDataBound="rptItemRentalInfo_ItemDataBound" runat="server">
            <ItemTemplate>
                <div class="row">
                    <!--Middle Part Start-->
                    <div id="content" class="col-sm-9">
                        <h2 class="title">Rental Information</h2>
                        <h2 class="title">Status:
                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("status") %>' /></h2>

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
                                        <td class="text-right">
                                            <asp:Label ID="lblTotalAmountPayable" runat="server" Text=""></asp:Label></td>
                                        </td>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="buttons clearfix">
            <div class="pull-left">
                <asp:Button CssClass="btn btn-primary" OnClick="btnExtend_Click" Visible="false" ID="btnExtend" runat="server" Text="Item Extension" />
                <asp:Button CssClass="btn btn-primary" OnClick="btnDispute_Click" Visible="false" ID="btnDispute" runat="server" Text="Dispute Member" />

            </div>
            <div class="pull-right">
                <asp:Button CssClass="btn btn-primary" data-toggle="modal" data-target="#myModal" Visible="false" ID="btnRetrivalCode" runat="server" Text="Item Returned" />
                <asp:Button CssClass="btn btn-primary" data-toggle="modal" data-target="#myModal" Visible="false" ID="btnReleaseCode" runat="server" Text="Item Received" />

            </div>
        </div>
        <p></p>
        <br />


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
        <input style="table-layout: fixed;" type="text" name="input-id" id="input-id" value="" class="form-control">
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

       

    <div id="myModalExtension" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">
                        <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Label ID="lblCode" runat="server" Text=""></asp:Label>
                    </p>
                    <input id="tbxValue" runat="server" type="number" placeholder="Please enter the code" name="number" class="form-control" />
                    <p></p>
                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" runat="server" Text="Submit" />
                    <p></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>
            <script type="text/javascript" src="js/datetimepicker/moment.js"></script>
        <script type="text/javascript" src="js/datetimepicker/bootstrap-datetimepicker.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui/jquery-ui.min.js"></script>

    <script type="text/javascript">
        (function () {
            // ------------------- DEMO 1 ------------------- //

            var today = new Date();
            var tomorrow = new Date();
            tomorrow.setDate(tomorrow.getDate() + 1);
            var HotelDatepicker = document.getElementById('input-id');
            input1.value = fecha.format(today, 'YYYY-MM-DD') + ' - ' + fecha.format(tomorrow, 'YYYY-MM-DD');

        })();

        </script>

</asp:Content>

