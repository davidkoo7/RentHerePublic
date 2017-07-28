<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ICVerification.aspx.cs" Inherits="ICVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">IC Verification</a></li>
        </ul>

        <div class="row">
            <!--Middle Part Start-->
            <div id="content" class="col-sm-9">
                <h2 class="title">IC Verification</h2>
                <p>Verify IC</p>

                <div class="form-horizontal">
                    <div class="form-group required">
                        <label for="input-to-name" class="col-sm-2 control-label">Identification Number</label>
                        <div class="col-sm-10">
                            <input runat="server" type="text" class="form-control" id="tbxIdentificationNumber" value="" name="to_name">
                        </div>
                    </div>
                    <div class="form-group required">
                        <label for="input-to-email" class="col-sm-2 control-label">Identification Picture</label>
                        <div class="col-sm-10">
                            <asp:FileUpload CssClass="form-control" ID="flIdentificationPicture" runat="server" />
                        </div>
                    </div>

                    <div class="buttons clearfix">
                        <div class="pull-right">
                            <asp:Button OnClick="btnSubmit_Click" CssClass="btn btn-primary" ID="btnSubmit" runat="server" Text="Submit" />
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

