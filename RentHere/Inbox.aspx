<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inbox.aspx.cs" Inherits="Inbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Order History</a></li>
        </ul>

        <div class="row">
            <!--Middle Part Start-->
            <div id="content" class="col-sm-9">
                <h2 class="title">Order History</h2>
                <div class="table-responsive">
                    <table class="table table-bordered table-hover">
                        <thead>
                            <tr>
                                <td class="text-center">Image</td>
                                <td class="text-center">Renter Name</td>
                                <td class="text-center">Message</td>
                                <td></td>
                            </tr>
                        </thead>
                        <asp:ListView ID="lsvInboxMessage" runat="server">
                            <LayoutTemplate>
                                <asp:PlaceHolder ID="groupPlaceHolder" runat="server"></asp:PlaceHolder>
                                </table>
                            </LayoutTemplate>
                            <GroupTemplate>
                                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                            </GroupTemplate>
                            <ItemTemplate>

                                <tbody>
                                    <tr>
                                        <td class="text-center">
                                            <a href="product.html">
                                                <img width="85" class="img-thumbnail" src="/image/item/<%# DataBinder.Eval(Container.DataItem, "Item.img1") %>">
                                            </a>
                                        &nbsp;</td>
                                        <td class="text-center"><a href="product.html">
                                            <asp:Label ID="Label2"  runat="server" Text='<%# "" + Eval("Item.Renter.Name") %>'></asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="Label1" runat="server" Text='<%# ""+ String.Format("{0:dd MMM yy   HH:mm}", Eval("Date")) %>'></asp:Label></a>
                                        </td>
                                        <td class="text-center"><a class="btn btn-info" title="" data-toggle="tooltip" href="order-information.html" data-original-title="View"><i class="fa fa-eye"></i></a>
                                        </td>
                                    </tr>

                                </tbody>

                            </ItemTemplate>
                        </asp:ListView>

                    </table>
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

