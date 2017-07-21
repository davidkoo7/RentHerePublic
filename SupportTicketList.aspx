<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SupportTicketList.aspx.cs" Inherits="SupportTicketList" %>

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
                                <td class="text-center">Ticket ID</td>
                                <td class="text-left">
                                Date Created/td>
                                <td class="text-center">Status</td>
                                <td class="text-center">Urgency</td>
                                <td class="text-center">Title</td>
                                <td class="text-center"></td>
                                <td></td>
                            </tr>
                        </thead>
                        <asp:ListView ID="lsvTicketView" runat="server">
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
                                        <td class="text-center"><a href="product.html">
                                            <asp:Label ID="lblTicketID" runat="server" Text='<%# "" + Eval("TicketID") %>'></asp:Label>
                                        </td>

                                        <td class="text-center">
                                            <asp:Label ID="lblDate" runat="server" Text='<%# "" + String.Format("{0:dd/MM/yyyy}",Eval("date")) %>'></asp:Label>
                                        </td>
                                                                                <td class="text-center">
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# ""+Eval("status") %>'></asp:Label></a>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblUrgency" runat="server" Text='<%# "" + Eval("urgency") %>'></asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblTitle" runat="server" Text='<%# "" + Eval("title") %>'></asp:Label>
                                        </td>
                                        <td class="text-center"><a class="btn btn-info" title="" data-toggle="tooltip" href="ViewSupportTicket.aspx?ticketID=<%#Eval("ticketID") %>" data-original-title="View"><i class="fa fa-eye"></i></a>
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


</asp:Content>

