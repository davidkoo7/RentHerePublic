<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateSupportTicket.aspx.cs" Inherits="CreateSupportTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Submit Ticket</a></li>
        </ul>

        <div class="row">
            <!--Middle Part Start-->
            <div id="content" class="col-sm-9">
                <h2 class="title">Submit a ticket</h2>
                <p>Please enter support ticket information</p>

                <div class="form-horizontal">
                    <div class="form-group required">
                        <label for="input-to-name" class="col-sm-2 control-label">Title</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="tbxTitle" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group required">
                        <label for="input-to-name" class="col-sm-2 control-label">Urgency</label>
                        <div class="col-sm-10">
                            <div class="radio">
                                <asp:DropDownList ID="ddlUrgency" runat="server">
                                    <asp:ListItem>Low</asp:ListItem>
                                    <asp:ListItem>Medium</asp:ListItem>
                                    <asp:ListItem>High</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>


                    <div class="form-group">
                        <label for="input-message" class="col-sm-2 control-label">
                            <span title="" data-toggle="tooltip" data-original-title="Optional">Message</span>
                        </label>
                        <div class="col-sm-10">
                            
                            <textarea runat="server" class="form-control" ID="txtArea" rows="5" cols="40" name="message"></textarea>
                        </div>
                    </div>
                    <div class="buttons clearfix">
                        <div class="pull-right">
                            <asp:Button class="btn btn-primary" OnClick="btnSubmit_Click" ID="btnSubmit" runat="server" Text="Submit" />
                        </div>
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

