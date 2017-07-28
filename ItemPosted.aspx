<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ItemPosted.aspx.cs" Inherits="ItemPosted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Item Posted List</a></li>
        </ul>

        <div class="row">
            <!--Middle Part Start-->
            <div id="content" class="col-sm-9">
                <h2 class="title">Item Posted List</h2>
                <div class="table-responsive">
                    <table class="table table-bordered table-hover">
                        <thead>
                            <tr>
                                <td class="text-center">Image</td>
                                <td class="text-center">Item Name</td>
                                <td class="text-center">Posted Date</td>
                                <td class="text-center">Deposit</td>
                                <td class="text-center">Price Per Day</td>
                                <td class="text-center">Price Per Week</td>
                                <td class="text-center">Price Per Month</td>
                                <td class="text-center"></td>

                            </tr>
                        </thead>
                        <asp:ListView ID="lsvItemPostedList" GroupItemCount="3" OnPagePropertiesChanging="lsvItemPostedList_PagePropertiesChanging" OnSelectedIndexChanging="lsvItemPostedList_SelectedIndexChanging" runat="server">
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
                                                <img width="85" class="img-thumbnail" src="/image/item/<%# DataBinder.Eval(Container.DataItem, "img1") %>">
                                            </a>
                                            &nbsp;</td>
                                        <td class="text-left"><a href="product.html">
                                            <asp:Label ID="lblItemName" runat="server" Text='<%# "" + Eval("Name") %>'></asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblPostedDate" runat="server" Text='<%# "" + String.Format("{0:dd/MM/yyyy}",Eval("postedDate")) %>'></asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblDeposit" runat="server" Text='<%# "" + Eval("deposit") %>'></asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblPricePerDay" runat="server" Text='<%# "" + Eval("pricePerDay") %>'></asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblPricePerWeek" runat="server" Text='<%# "" + Eval("pricePerWeek") %>'></asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblPricePerMonth" runat="server" Text='<%# "" + Eval("pricePerMonth") %>'></asp:Label>
                                        </td>
                                        <td class="text-center">
                                              <a href="ItemPostedDetails.aspx?itemID=<%#Eval("itemID") %>" >  <button class="btn btn-warning btn-sm" type="button" data-toggle="tooltip" title="View Info"><span class="">View Info</span></button></a>
                                        </td>
                                    </tr>

                                </tbody>

                            </ItemTemplate>
                        </asp:ListView>


                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lsvItemPostedList" PageSize="3">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                <asp:NumericPagerField ButtonType="Button" />
                                <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            </Fields>

                        </asp:DataPager>

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

