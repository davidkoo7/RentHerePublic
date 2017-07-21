<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Account</a></li>
            <li><a href="#">Register</a></li>
        </ul>

        <div class="row">
            <div id="content" class="col-sm-12">
                <h2 class="title">Register Account</h2>
                <p>If you already have an account with us, please login at the <a href="Login.aspx">login page</a>.</p>
                <div>
                    <fieldset id="account">
                        <legend>Your Personal Details</legend>
                        <div class="form-group required" style="display: none;">
                            <label class="col-sm-2 control-label">Customer Group</label>
                            <div class="col-sm-10">
                                <div class="radio">
                                    <label>
                                        <input type="radio" name="customer_group_id" value="1" checked="checked">
                                        Default
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group required">
                            <label class="col-sm-2 control-label" for="input-firstname">Full Name</label>
                            <div class="col-sm-10">
                                <input runat="server" type="text" name="firstname" value="" placeholder="First Name" id="tbxFullName" class="form-control">
                            </div>
                        </div>
                        <br />

                        <div class="form-group required">
                            <label class="col-sm-2 control-label" for="input-email">E-mail</label>
                            <div class="col-sm-10">
                                <input runat="server" type="email" name="email" value="" placeholder="E-mail" id="tbxEmail" class="form-control">
                            </div>
                        </div>
                        <br />

                        <div class="form-group required">
                            <label class="col-sm-2 control-label" for="input-email">Date Of Birth</label>
                            <div class="col-sm-10">
                                <input type="date" name="date" runat="server" value="" placeholder="Date of Birth" id="tbxDOB" class="form-control">
                            </div>
                        </div>
                        <br />

                        <div class="form-group">
                            <label class="col-sm-2 control-label">Gender</label>
                            <div class="col-sm-10">
                                <asp:RadioButton CssClass="radio-inline" ID="rbtnMale" Text="Male" Checked GroupName="gender" runat="server" />
                                <asp:RadioButton CssClass="radio-inline" ID="rbtnFemale" Text="Female" GroupName="gender" runat="server" />

                            </div>
                        </div>
                    </fieldset>
                    <fieldset id="address">
                        <legend>Your Address</legend>
                        <div class="form-group required">
                            <label class="col-sm-2 control-label" for="input-address-1">Address</label>
                            <div class="col-sm-10">
                                <input type="text" runat="server" name="address_1" value="" placeholder="Address" id="tbxAddress" class="form-control">
                            </div>
                        </div>
                        <br />

                        <div class="form-group required">
                            <label class="col-sm-2 control-label" for="input-postcode">Post Code</label>
                            <div class="col-sm-10">
                                <input type="number" runat="server" name="postcode" value="" placeholder="Post Code" id="tbxPostCode" class="form-control">
                            </div>
                        </div>
                    </fieldset>
                    <fieldset>
                        <legend>Your Password</legend>
                        <div class="form-group required">
                            <label class="col-sm-2 control-label" for="input-password">Password</label>
                            <div class="col-sm-10">
                                <input type="password" runat="server" name="password" value="" placeholder="Password" id="tbxPassword" class="form-control">
                            </div>
                        </div>
                        <br />

                        <div class="form-group required">
                            <label class="col-sm-2 control-label" for="input-confirm">Password Confirm</label>
                            <div class="col-sm-10">
                                <input type="password" runat="server" name="confirm" value="" placeholder="Password Confirm" id="tbxPasswordConfirm" class="form-control">
                            </div>
                        </div>
                    </fieldset>
                    <fieldset>
                        <legend>Mobile Phone</legend>
                        <div class="form-group required">
                            <label class="col-sm-2 control-label" for="input-password">+65</label>
                            <div class="col-sm-10">
                                <input type="number" runat="server" name="password" value="" placeholder="Phone" id="tbxPhone" class="form-control">
                                <br>
                                <asp:Button ID="btnVerifyPhone" OnClick="btnVerifyPhone_Click" CssClass="btn btn-primary" runat="server" Text="Verify" />
                                <asp:Label ID="lblPhoneStatus" runat="server" Text=""></asp:Label>

                            </div>

                        </div>

                        <asp:Panel Visible="false" ID="pnlPhone" runat="server">
                            <div class="form-group required">
                                <label class="col-sm-2 control-label" for="input-password">Enter OTP</label>
                                <div class="col-sm-10">
                                    <input type="number" runat="server" name="" value="" placeholder="Enter OTP" id="tbxOTP" class="form-control">
                                    <br>
                                    <asp:Button ID="btnSubmitOTP" OnClick="btnSubmitOTP_Click" CssClass="btn btn-primary" runat="server" Text="Verify OTP" />
                                </div>

                            </div>
                        </asp:Panel>

                    </fieldset>
                    <fieldset>
                        <legend></legend>
                        <asp:Panel Visible="false" ID="pnlMessageOutput" runat="server">
                            <div class="alert alert-warning">
                                <i class="fa fa-warning"></i>

                                <asp:Label ID="lblOutput" runat="server" Text="Label"></asp:Label>
                            </div>
                        </asp:Panel>

                    </fieldset>
                    <div class="buttons">
                        <div class="pull-right">
                            I have read and agree to the <a href="#" class="agree"><b>Term of Conditions</b></a>
                            <input class="box-checkbox" type="checkbox" name="agree" value="1">
                            &nbsp;
                                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" runat="server" Text="Register" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- //Main Container -->

</asp:Content>

