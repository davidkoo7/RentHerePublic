<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisputePage.aspx.cs" Inherits="DisputePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        *, *:before, *:after {
            box-sizing: border-box;
        }

        .chat .chat-history {
            padding: 30px 30px 20px;
            border-bottom: 2px solid white;
        }

            .chat .chat-history .message-data {
                margin-bottom: 15px;
            }

            .chat .chat-history .message-data-time {
                color: #a8aab1;
                padding-left: 6px;
            }

            .chat .chat-history .message {
                color: white;
                padding: 18px 20px;
                line-height: 26px;
                font-size: 13px;
                border-radius: 5px;
                margin-bottom: 30px;
                width: 90%;
                position: relative;
            }

                .chat .chat-history .message:after {
                    content: "";
                    position: absolute;
                    top: -15px;
                    left: 20px;
                    border-width: 0 15px 15px;
                    border-style: solid;
                    border-color: #CCDBDC transparent;
                    display: block;
                    width: 0;
                }

            .chat .chat-history .you-message {
                background: #CCDBDC;
                color: #003366;
            }

            .chat .chat-history .me-message {
                background: #E9724C;
            }

                .chat .chat-history .me-message:after {
                    border-color: #E9724C transparent;
                    right: 20px;
                    top: -15px;
                    left: auto;
                    bottom: auto;
                }

        .chat .chat-message {
            padding: 30px;
        }

            .chat .chat-message .fa-file-o, .chat .chat-message .fa-file-image-o {
                font-size: 13px;
                color: gray;
                cursor: pointer;
            }

        .chat-ul li {
            list-style-type: none;
        }

        .align-left {
            text-align: left;
        }

        .align-right {
            text-align: right;
        }

        .float-right {
            float: right;
        }

        .clearfix:after {
            visibility: hidden;
            display: block;
            font-size: 0;
            content: " ";
            clear: both;
            height: 0;
        }

        .you {
            color: #CCDBDC;
        }

        .me {
            color: #E9724C;
        }

        h1, h2, h3, h4, h5, h6 {
            font-family: "Raleway",sans-serif;
            color: #003366;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Repeater ID="rptInfo" runat="server">
        <ItemTemplate>
            <div class="main-container container">
                <ul class="breadcrumb">
                    <li><a href="#"><i class="fa fa-home"></i></a></li>
                    <li><a href="#">Rental Infomation	</a></li>
                </ul>

                <div class="row">
                    <!--Middle Part Start-->
                    <div id="content" class="col-sm-9">
                        <h2 class="title">Rental Information</h2>
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
    <div class="chat">
        <div class="chat-history">
            <ul class="chat-ul">
                <asp:Repeater ID="rptMessages" runat="server">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# retrieveMessage(Convert.ToString(Eval("Member.MemberID")), Convert.ToString(Eval("Staff.StaffID")), Convert.ToString(Eval("reply")), String.Format("{0:dd MMM yy   HH:mm}", Eval("Date")))%>'></asp:Label>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <!-- end chat-history -->

    </div>
    <!-- end chat -->


    <asp:Label ID="Label2" runat="server" Text="Label">Reason: </asp:Label>

    <asp:Button ID="btnResolve" runat="server" Visible="false" Text="Resolve" OnClick="btnResolve_Click" OnClientClick="return confirm('You are about to close the dispute case. As the action is irreversible, are you sure?')" />
    <asp:DropDownList ID="ddlReason" runat="server" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" AutoPostBack="True">
        <asp:ListItem>--Select Reason--</asp:ListItem>
        <asp:ListItem>Rentee No-Show (Collection)</asp:ListItem>
        <asp:ListItem>Rentee No-Show (Return) </asp:ListItem>

        <asp:ListItem>Spoiled Item Returned</asp:ListItem>
        <asp:ListItem>Unacceptable Rentee Review</asp:ListItem>
        <asp:ListItem>Renter No-Show (Collection)</asp:ListItem>
        <asp:ListItem>Renter No-Show (Return) </asp:ListItem>

        <asp:ListItem>Item Condition Wrong</asp:ListItem>
        <asp:ListItem>Deposit Not Returned</asp:ListItem>
        <asp:ListItem>Unacceptable Renter Review</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="tbxMessage" runat="server" Style="resize: none;" TextMode="MultiLine" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" MaxLength="255"></asp:TextBox>
    
    <div class="">
        <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="btnSubmit_Click" TabIndex="1" />
    </div>

    <div class="buttons clearfix">
        <div class="pull-right">
    <td class="text-center"><a class="btn btn-warning" title="" data-toggle="tooltip" href="RentalHistory.aspx" data-original-title="Back to Rental History">Back<i class=""></i></a>
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
    <!-- //Main Container -->

</asp:Content>

