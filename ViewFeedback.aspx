<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewFeedback.aspx.cs" Inherits="ViewFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Repeater ID="rptInfo" runat="server">
        <ItemTemplate>
            <div class="main-container container">
                <ul class="breadcrumb">
                    <li><a href="#"><i class="fa fa-home"></i></a></li>
                    <li><a href="#">Feedback Infomation	</a></li>
                </ul>

                <div class="row">
                    <!--Middle Part Start-->
                    <div id="content" class="col-sm-9">
                        <h2 class="title">Feedback Information</h2>
                        <h2 class="title">Status:                                            
                            <a href="RentalDetails.aspx?rentalID=<%#Eval("rentalID") %>"><asp:Label ID="lblStatus" runat="server" Text='<%# "" + Eval("status") %>'></asp:Label></a>
                        </h2>
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr>
                                    <td colspan="2" class="text-left">Rental Details</td>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td style="width: 50%;" class="text-left"><b>Rental ID:</b> 
                                                           <a href="RentalDetails.aspx?rentalID=<%#Eval("rentalID") %>"> <asp:Label ID="lblRentalID" runat="server" Text='<%# Eval("rentalID") %>' /></a>
								<br>
                                        <b>Date  Created:</b>   <asp:Label ID="lblDateCreated" runat="server" Text='<%# "" + Eval("dateCreated") %>'></asp:Label>
																<br>
                                        <b>Pick Up Location:</b>  <asp:Label ID="lblPickUpLocation" runat="server" Text='<%# "" + Eval("pickUpLocation") %>'></asp:Label>
								<br>
                                        <b>Pick Up Time:</b>  <asp:Label ID="lblPickUpTime" runat="server" Text='<%# "" + Eval("pickUpTime") %>'></asp:Label>
								<br>
                                        <b>Return Location: </b>  <asp:Label ID="lblReturnLocvation" runat="server" Text='<%# "" + Eval("returnLocation") %>'></asp:Label>
								<br>
                                        <b>Return Time: </b> <asp:Label ID="lblReturnTime" runat="server" Text='<%# "" + Eval("returnTime") %>'></asp:Label>
																

								
								<br>
                                    </td>
                                    <td style="width: 50%;" class="text-left"><b>Rental Start Date:</b> <asp:Label ID="lblStartDate" runat="server" Text='<%# "" + Eval("startDate") %>'></asp:Label>
								<br>
                                        <b>Rental End Date:</b> <asp:Label ID="Label1" runat="server" Text='<%# "" + Eval("endDate") %>'></asp:Label> 
																<br>
                                        <b>Deposit:</b> <asp:Label ID="lblDeposit" runat="server" Text='<%# "" + Eval("deposit") %>'></asp:Label>
								<br>
                                        <b>Rental Fee:</b> <asp:Label ID="Label4" runat="server" Text='<%# "" + Eval("rentalFee") %>'></asp:Label> </td>
                                    <br>
                                </tr>
                            </tbody>
                        </table>
        </ItemTemplate>
    </asp:Repeater>

            <div class="container">
                <div class="row">
                    <div class="col-sm-8">
                        <div class="panel panel-white border-top-green">
                            <div class="panel-body chat">
                                <div class="row">
                                    <asp:Repeater ID="rptFeedbackInfo" runat="server">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFeedback" runat="server" Text='<%# retrieveMessage(Convert.ToString(Eval("submittedBy.MemberID")), Convert.ToString(Eval("FeedbackTo.MemberID")), Convert.ToString(Eval("comments")), Convert.ToString(Eval("replyFeedback")), String.Format("{0:dd MMM yy   HH:mm}", Eval("Date")), Convert.ToString(Eval("rating")))%>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:Repeater>


                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <!-- end chat -->
            <%--                            <button runat="server" onclick="return controlBtn" onServerClick="controlBtn" id="btnPositive" type="button" class="btn btn-success">
                    <i class="feature-icon fa fa-smile-o"></i> Positive
                </button>


                <div type="button" class="btn btn-warning">
                    <i class="feature-icon fa fa-frown-o"></i> Neutral
                </div>
                               
                <button runat="server" id="btnNegative" type="button" class="btn btn-danger">
                    <i class="feature-icon fa fa-meh-o"></i> Negative
                </button>--%>
            <div class="col-md-12">
                <%--                <asp:RadioButton type="radio" CssClass="" Text="Positive" GroupName="feedback" ID="rbtnPositive" runat="server" />
                <asp:RadioButton type="radio" Text="Positive" GroupName="feedback" ID="rbtnNeutral" runat="server" />
                <asp:RadioButton type="radio" Text="Positive" GroupName="feedback" ID="rbtnNegative" runat="server" />--%>
               
                <asp:Panel ID="pnlSetControl" runat="server">

                    <div class="btn btn-success">
                        <label class="radio-inline">
                            <input runat="server" id="rbtnPositive" type="radio" name="newsletter" value="1">
                            Positive
                        </label>
                    </div>


                    <div class="btn btn-warning">
                        <label class="radio-inline">
                            <input runat="server" id="rbtnNeutral" type="radio" name="newsletter" value="2">
                            Neutral
                        </label>
                    </div>


                    <div class="btn btn-danger">
                        <label class="radio-inline">
                            <input runat="server" id="rbtnNegative" type="radio" name="newsletter" value="3">
                            Negative
                        </label>
                    </div>
                </asp:Panel>

            </div>
            <p></p>
            <br />
            <div class="form-group">
                <p></p>

                <div class="col-sm-12">
                    <textarea runat="server" class="form-control" id="txtArea" rows="5" cols="40" name="message"></textarea>
                    <div class="pull-left">
                        <p></p>
                        <asp:Button class="btn btn-primary" OnClick="btnSubmit_Click" ID="btnSubmit" runat="server" Text="Submit" />

                    </div>
                </div>
            </div>
            <div class="buttons clearfix">
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
    <!-- //Main Container -->

</asp:Content>

