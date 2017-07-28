<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RentalHistory.aspx.cs" Inherits="RentalHistory" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
                                <td class="text-left">Item Name</td>
                                <td class="text-center">Rental ID</td>
                                <td class="text-center">Rental Period</td>
                                <td class="text-center">Status</td>
                                <td class="text-center"></td>
                                <td class="text-center"></td>

                                <td></td>
                            </tr>
                        </thead>
                        <asp:ListView ID="lsvRentView" GroupItemCount="8" OnPagePropertiesChanging="lsvRentView_PagePropertiesChanging" OnSelectedIndexChanging="lsvRentView_SelectedIndexChanging" runat="server">
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
                                        <td class="text-left"><a href="product.html">
                                            <asp:Label ID="lblItemName" runat="server" Text='<%# "" + Eval("Item.Name") %>'></asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblRentalID" runat="server" Text='<%# ""+Eval("RentalID") %>'></asp:Label></a>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblStartDate" runat="server" Text='<%# "" + String.Format("{0:dd/MM/yyyy}",Eval("StartDate")) + "-" + String.Format("{0:dd/MM/yyyy}",Eval("EndDate")) %>'></asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# "" + Eval("Status") %>'></asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:LinkButton ID="lbtnDispute" runat="server" CommandName="Select" OnClick="lbtnDispute_Click" Text='<%# isDisputeorDisputed("" + Eval("RentalID")) %>'></asp:LinkButton>                                            
                                        </td>
                                        <td class="text-center">
                                            <asp:LinkButton ID="lbtnFeedback" runat="server" CommandName="Select" OnClick="lbtnFeedback_Click" Text='<%# isGiveorReceiveFeedback("" + Eval("RentalID"), "" + Eval("Rentee.MemberID"), "" + Eval("Status")) %>'></asp:LinkButton>
                                        </td>
                                        <td class="text-center"><a class="btn btn-info" title="" data-toggle="tooltip" href="RentalDetails.aspx?rentalID=<%#Eval("rentalID") %>" data-original-title="View"><i class="fa fa-eye"></i></a>
                                        </td>
                                    </tr>

                                </tbody>

                            </ItemTemplate>
                        </asp:ListView> 


                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lsvRentView" PageSize="6">
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

