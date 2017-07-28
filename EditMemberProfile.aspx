<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditMemberProfile.aspx.cs" Inherits="EditMemberProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Account</a></li>
            <li><a href="#">My Account</a></li>
        </ul>

        <div class="row">
            <!--Middle Part Start-->
            <div class="col-sm-9" id="content">
                <h2 class="title">My Account</h2>
                <p class="lead">
                    Hello, <strong>
                        <asp:Label ID="lblMemberName" runat="server" Text="Label"></asp:Label>
                    </strong>- To update your account information.
                </p>
                <div>
                    <div class="row">
                        <div class="col-sm-6">
                            <fieldset id="personal-details">
                                <legend>Personal Details</legend>
                                <div class="form-group required">
                                    <label for="input-firstname" class="control-label">Full Name</label>
                                    <asp:TextBox Enabled="false" CssClass="form-control" placeholder="Full Name" ID="tbxFullName" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group required">
                                    <label for="input-telephone" class="control-label">Mobile Phone</label>
                                    <asp:TextBox Enabled="false" CssClass="form-control" placeholder="Mobile Phone" ID="tbxMobilePhone" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="input-fax" class="control-label">Status</label>
                                    <asp:TextBox Enable="false" CssClass="form-control" Enabled="false" ID="tbxStatus" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="input-email" class="control-label">E-mail</label>
                                    <asp:TextBox CssClass="form-control" Enabled="false" placeholder="Email" ID="tbxEmail" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="input-fax" class="control-label">Date Joined</label>
                                    <asp:TextBox CssClass="form-control" Enabled="false" placeholder="Date Joined" ID="tbxDateJoined" runat="server"></asp:TextBox>
                                </div>
                            </fieldset>
                            <br>
                        </div>
                        <div class="col-sm-6">
                            <fieldset>
                                <legend>Address</legend>
                                <div class="form-group required">
                                    <label for="input-firstname" class="control-label">Address</label>
                                    <asp:TextBox Enabled="false" CssClass="form-control" placeholder="Address" ID="tbxAddress" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group required">
                                    <label for="input-firstname" class="control-label">Date Of Birth</label>
                                    <asp:TextBox Enabled="false" CssClass="form-control" placeholder="Address" ID="tbxDOB" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group required">
                                    <label for="input-password" class="control-label">Postal Code</label>
                                    <asp:TextBox Enabled="false" type="number" CssClass="form-control" placeholder="Postal Code" ID="tbxPostalCode" runat="server"></asp:TextBox>
                                </div>
                                <div class="buttons clearfix">
                                    <div class="pull-right">
                                        <asp:Button ID="btnEdit" OnClick="btnEdit_Click" CssClass="btn btn-md btn-primary" runat="server" Text="Edit" />
                                        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn btn-md btn-primary" Visible="false" runat="server" Text="Submit" />
                                        <a href="#"" data-toggle="modal" data-target="#myModal" class="forgot">Change Password</a>

                                    </div>
                                </div>
                            </fieldset>

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

    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Change Password</h4>
                </div>
                <div class="modal-body">
                    <p>Email:</p>
                    <input id="tbxCurrentPassword" runat="server" type="password" placeholder="current password" name="password" class="form-control" />
                                        <p></p>

                    <input id="tbxNewPassword" runat="server" type="password" placeholder="new password" name="password" class="form-control" />
                    <p></p>
                    <asp:Button ID="btnSubmitNewPassword" OnClick="btnSubmitNewPassword_Click" CssClass="btn btn-primary" runat="server" Text="Submit" />
                    <p></p>

                    <asp:Panel ID="pnlNewPasswordOutput" Visible="false" runat="server">
                        <div class="alert alert-info">
                            <i class="fa fa-info-circle"></i>
                            <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>

</asp:Content>

