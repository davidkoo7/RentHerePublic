<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        .StripeElement {
            background-color: white;
            padding: 8px 12px;
            border-radius: 4px;
            border: 1px solid transparent;
            box-shadow: 0 1px 3px 0 #e6ebf1;
            -webkit-transition: box-shadow 150ms ease;
            transition: box-shadow 150ms ease;
        }

        .StripeElement--focus {
            box-shadow: 0 1px 3px 0 #cfd7df;
        }

        .StripeElement--invalid {
            border-color: #fa755a;
        }

        .StripeElement--webkit-autofill {
            background-color: #fefde5 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Checkout</a></li>

        </ul>

        <div class="row">
            <!--Middle Part Start-->
            <div id="content" class="col-lg-12">
                <h2 class="title">Checkout</h2>
                <div class="so-onepagecheckout ">



                    <div class="col-lg-12">
                        <div class="row">

                            <div class="col-sm-12">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title"><i class="fa fa-shopping-cart"></i>Shopping cart</h4>
                                    </div>
                                    <div class="panel-body">
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


                                                        <asp:Repeater ID="rptItemRentalInfo" runat="server">
                                                            <ItemTemplate>
                                                                <td class="text-center"><a href="product.html">
                                                                    <img width="60px" src="/image/item/<%# DataBinder.Eval(Container.DataItem, "img1") %>" class="img-thumbnail"></a></td>
                                                                <td class="text-left"><a href="product.html">
                                                                    <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("name") %>' /></a></td>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <td class="text-right">
                                                            <asp:Label ID="lblRentalPeriod" runat="server" Text=""></asp:Label></td>
                                                        <td class="text-right">
                                                            <asp:Label ID="lblRentalRate" runat="server" Text="Select date and Update"></asp:Label></td>
                                                        <td class="text-right">
                                                            <asp:Label ID="lblDepositAmount" runat="server" Text=""></asp:Label></td>
                                                        <td class="text-right">
                                                            <asp:Label ID="lblTotalAmount" runat="server" Text=""></asp:Label></td>
                                                    </tr>



                                                </tbody>


                                                <tfoot>
                                                    <tr>
                                                    </tr>
                                                    <tr>
                                                        <td class="text-right" colspan="5"><strong>Total Amount Payable:</strong></td>
                                                        <td class="text-right">
                                                            <asp:Label ID="lblTotalAmountPayable" runat="server" Text=""></asp:Label></td>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div class="panel panel-default no-padding">
                                <div class="col-sm-12 checkout-shipping-methods">
                                    <div class="panel-heading">
                                        <h4 class="panel-title"><i class="fa fa-quotes"></i>Credit Card Info</h4>
                                    </div>
                                    <div class="panel-body">
                                        <script src="https://js.stripe.com/v3/"></script>

                                        <div action="/charge" method="post" id="payment-form">
                                            <div class="form-row">
                                                <label for="card-element">
                                                    Credit or debit card
                                                </label>
                                                <div id="card-element">
                                                    <!-- a Stripe Element will be inserted here. -->
                                                </div>

                                                <!-- Used to display form errors -->
                                                <div id="card-errors" role="alert"></div>
                                            </div>

                                            <asp:Button ID="btnPay" OnClick="btnPay_Click" runat="server" Text="Pay Now" />

                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>







                    </div>
                </div>
            </div>
        </div>
        <script>
            // Create a Stripe client
            var stripe = Stripe('pk_test_2O7D78OBubjUApxMMbvbHLVr');

            // Create an instance of Elements
            var elements = stripe.elements();

            // Custom styling can be passed to options when creating an Element.
            // (Note that this demo uses a wider set of styles than the guide below.)
            var style = {
                base: {
                    color: '#32325d',
                    lineHeight: '24px',
                    fontFamily: '"Helvetica Neue", Helvetica, sans-serif',
                    fontSmoothing: 'antialiased',
                    fontSize: '16px',
                    '::placeholder': {
                        color: '#aab7c4'
                    }
                },
                invalid: {
                    color: '#fa755a',
                    iconColor: '#fa755a'
                }
            };

            // Create an instance of the card Element
            var card = elements.create('card', { style: style });

            // Add an instance of the card Element into the `card-element` <div>
            card.mount('#card-element');

            // Handle real-time validation errors from the card Element.
            card.addEventListener('change', function (event) {
                var displayError = document.getElementById('card-errors');
                if (event.error) {
                    displayError.textContent = event.error.message;
                } else {
                    displayError.textContent = '';
                }
            });

            // Handle form submission
            var form = document.getElementById('payment-form');
            form.addEventListener('submit', function (event) {
                event.preventDefault();

                stripe.createToken(card).then(function (result) {
                    if (result.error) {
                        // Inform the user if there was an error
                        var errorElement = document.getElementById('card-errors');
                        errorElement.textContent = result.error.message;
                    } else {
                        // Send the token to your server
                        stripeTokenHandler(result.token);
                    }
                });
            });
            </script>
</asp:Content>

