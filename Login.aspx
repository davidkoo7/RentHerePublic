<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <!-- Navbar switcher -->
    <!-- //end Navbar switcher -->
    <!-- //Header Container  -->
    <!-- Main Container  -->
    <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Account</a></li>
            <li><a href="#">Login</a></li>
        </ul>

        <div class="row">
            <div id="content" class="col-sm-12">
                <div class="page-login">

                    <div class="account-border">
                        <div class="row">
                            <div class="col-sm-6 new-customer">
                                <div class="well">
                                    <h2><i class="fa fa-file-o" aria-hidden="true"></i>New Customer</h2>
                                    <p>By creating an account you will be able to shop faster, be up to date on an order's status, and keep track of the orders you have previously made.</p>
                                </div>
                                <div class="bottom-form">
                                    <a href="/Register.aspx" class="btn btn-default pull-right">Continue</a>
                                </div>
                            </div>

                            <div>
                                <div class="col-sm-6 customer-login">
                                    <div class="well">
                                        <h2><i class="fa fa-file-text-o" aria-hidden="true"></i>Returning Customer</h2>
                                        <p><strong>I am a returning customer</strong></p>
                                        <div class="form-group">
                                            <label class="control-label " for="input-email">Email Address</label>
                                            <input type="text" runat="server" name="email" value="" id="tbxEmail" class="form-control" />
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label " for="input-password">Password</label>
                                            <input type="password" runat="server" name="password" value="" id="tbxPassword" class="form-control" />
                                        </div>
                                    </div>

                                                                        <asp:Panel ID="pnlOutput" Visible="false" runat="server">
                                        <div class="alert alert-warning">
                                            <i class="fa fa-info-circle"></i>
                                            <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
                                        </div>
                                                                            <p></p>
                                    </asp:Panel>

                                    <div class="bottom-form">
                                        <a href="#" data-toggle="modal" data-target="#myModal" class="forgot">Forgotten Password</a>

                                        <asp:Button CssClass="btn btn-default pull-right" OnClick="btnLogin_Click" ID="btnLogin" runat="server" Text="Login" />
                                    </div>



                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <!-- //Main Container -->

    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Forgot Password</h4>
                </div>
                <div class="modal-body">
                    <p>Email:</p>
                    <input id="tbxForgotEmail" type="email" placeholder="email" name="email" class="form-control" />
                    <p></p>
                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" runat="server" Text="Submit" />
                    <p></p>
                    <asp:Panel ID="pnlForgotPasswordOutput" Visible="false" runat="server">
                        <div class="alert alert-info"><i class="fa fa-info-circle"></i>
                            <asp:Label ID="lblForgotEmailOutput" runat="server" Text=""></asp:Label></div>
                    </asp:Panel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>

</asp:Content>

