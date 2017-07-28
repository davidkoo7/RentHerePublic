<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        <script>// <![CDATA[
            jQuery(document).ready(function ($) {
                $('.releate-products').owlCarousel2({
                    pagination: false,
                    center: false,
                    nav: true,
                    dots: false,
                    loop: true,
                    margin: 25,
                    navText: ['prev', 'next'],
                    slideBy: 1,
                    autoplay: false,
                    autoplayTimeout: 2500,
                    autoplayHoverPause: true,
                    autoplaySpeed: 800,
                    startPosition: 0,
                    responsive: {
                        0: {
                            items: 1
                        },
                        480: {
                            items: 1
                        },
                        768: {
                            items: 2
                        },
                        1024: {
                            items: 2
                        },
                        1200: {
                            items: 3
                        }
                    }
                });
        });
    </script>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Member Profile </a></li>
        </ul>

        <div class="row">
                                            <asp:Repeater ID="rptMemberInfo" runat="server">
                                    <ItemTemplate>
            <!--Middle Part Start-->
            <div id="content" class="col-md-12 col-sm-12">
                <h3 class="offset_title">Member Profile</h3>
                <div class="products-category">
                    <div class="category-derc form-group">
                        <div class="row">
                            <div class="col-md-3">
                                <img width="250" class="img-thumbnail" src="/image/users/<%# DataBinder.Eval(Container.DataItem, "profilePic") %>">
                            </div>
                            <div class="col-md-9">

                                        <table class="table table-bordered table hover">
                                            <thead>
                                                <tr>
                                                    <td colspan="2" class="text-left">Member Details</td>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td style="width: 100%;" class="text-left"><b>Member ID:</b>
                                                        <asp:Label ID="lblMemberInfo" runat="server" Text='<%# "" + Eval("memberID") %>'></asp:Label>


                                                        <br>
                                                        <b>Member Status:</b>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# "" + Eval("status") %>'></asp:Label>


                                                        <br>
                                                        <b>Member Registration Date:</b>
                                                        <asp:Label ID="lblFeedback" runat="server" Text='<%# "" + Eval("dateJoined") %>'></asp:Label>


                                                        <br>
                                                        <b>IC Verification Status:</b>
                                                        <asp:Label ID="lblVerificationStatus" runat="server" Text='<%# isVerifiedOrNot("" + Eval("memberID")) %>'></asp:Label>


                                                        <br>
                                                        <b></b>
                                                        <br>
                                                    </td>

                                    </ItemTemplate>
                                </asp:Repeater>
                                <td style="width: 50%;" class="text-left">
                                </tbody>
                                        </table>


                            </div>
                            <div class="col-md-12">
                                <div class="module titleLine">
                                    <h3 class="modtitle">Feedback</h3>
                                    <div class="modcontent">
                                        <div class="block-clientsay block ">

                                            <div class="yt-content-slider slider-clients-say" data-rtl="yes" data-autoplay="no" data-autoheight="no" data-delay="2" data-speed="0.6" data-margin="0" data-items_column0="3" data-items_column1="1" data-items_column2="1" data-items_column3="1" data-items_column4="1" data-arrows="yes" data-pagination="no" data-lazyload="yes" data-loop="no" data-hoverpause="yes">
                                                <asp:Repeater ID="rptFeedbackInfo" OnItemDataBound="rptFeedbackInfo_ItemDataBound" runat="server">
                                                    <ItemTemplate>

                                                        <div class="yt-content-slide">

                                                            <div class="client-cont">
                                                                <asp:Label ID="lblFeedback" CssClass="" runat="server" Text='<%# " " + Eval("comments") %>'></asp:Label>

                                                            </div>

                                                            <div class="client-info">
                                                                <img width="50" height="50" src="/image/item/<%# DataBinder.Eval(Container.DataItem, "Rental.Item.img1") %>" alt="">
                                                                <div class="client-cont">
                                                                    Reply:                                            
                                                                    <asp:Label ID="lblReply" runat="server" Text='<%# "" + Eval("replyFeedback") %>'></asp:Label>

                                                                    <br>
                                                                    Member:                                            
                                                                    <asp:Label ID="lblMemberName" runat="server" Text='<%# "" + Eval("feedbackTo.name") %>'></asp:Label>

                                                                </div>
                                                                <br>
                                                            </div>


                                                        </div>

                                                    </ItemTemplate>
                                                </asp:Repeater>

                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>


                    <!--Content Top End -->


                    <!-- Filters -->
                    <div class="product-filter filters-panel">
                        <div class="row">
                            <div class="col-md-2 visible-lg">
                                <div class="view-mode">
                                    <div class="list-view">
                                        <button class="btn btn-default grid active " data-view="grid" data-toggle="tooltip" data-original-title="Grid"><i class="fa fa-th"></i></button>
                                        <button class="btn btn-default list" data-view="list" data-toggle="tooltip" data-original-title="List"><i class="fa fa-th-list"></i></button>
                                    </div>
                                </div>
                            </div>
                            <div class="short-by-show form-inline text-right col-md-7 col-sm-8 col-xs-12">
                                <div class="form-group short-by">
                                    <label class="control-label" for="input-sort">Sort By:</label>
                                    <select id="input-sort" class="form-control"
                                        onchange="location = this.value;">
                                        <option value="" selected="selected">Default</option>
                                        <option value="">Name (A - Z)</option>
                                        <option value="">Name (Z - A)</option>
                                        <option value="">Price (Low &gt; High)</option>
                                        <option value="">Price (High &gt; Low)</option>
                                        <option value="">Rating (Highest)</option>
                                        <option value="">Rating (Lowest)</option>
                                        <option value="">Model (A - Z)</option>
                                        <option value="">Model (Z - A)</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="input-limit">Show:</label>
                                    <select id="input-limit" class="form-control" onchange="location = this.value;">
                                        <option value="" selected="selected">9</option>
                                        <option value="">25</option>
                                        <option value="">50</option>
                                        <option value="">75</option>
                                        <option value="">100</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- //end Filters -->

                    <!--changed listings-->
                    <div class="products-list row grid">
                        <asp:Repeater ID="repeaterItemList" runat="server">
                            <ItemTemplate>
                                <div class="product-layout col-md-4 col-sm-6 col-xs-12 ">
                                    <div class="product-item-container">
                                        <div class="left-block">
                                            <div class="product-image-container lazy second_img ">
                                                <img data-src="/image/item/<%# DataBinder.Eval(Container.DataItem, "img1") %>" src="data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7" class="img-responsive" />

                                            </div>

                                        </div>


                                        <div class="right-block">
                                            <div class="caption">
                                                <h4>
                                                    <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' /></h4>
                                                <div class="ratings">
                                                    <div class="rating-box">
                                                        <span class="fa fa-stack"><i class="fa fa-star fa-stack-1x"></i><i class="fa fa-star-o fa-stack-1x"></i></span>
                                                        <span class="fa fa-stack"><i class="fa fa-star fa-stack-1x"></i><i class="fa fa-star-o fa-stack-1x"></i></span>
                                                        <span class="fa fa-stack"><i class="fa fa-star fa-stack-1x"></i><i class="fa fa-star-o fa-stack-1x"></i></span>
                                                        <span class="fa fa-stack"><i class="fa fa-star fa-stack-1x"></i><i class="fa fa-star-o fa-stack-1x"></i></span>
                                                        <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i></span>
                                                    </div>
                                                </div>

                                                <div class="price">
                                                    <asp:Label CssClass="price-new" ID="pricePerDayLabel" runat="server" Text='<%# String.Format("{0:c}", Eval("pricePerDay")) %>' /></span>
										
                                                    <span class="price-old" style="text-decoration: none">per day</span>

                                                </div>
                                                <div class="description item-desc hidden">
                                                    <asp:Label ID="lblItemDescription" runat="server" Text='<%# Eval("description") %>' /></span>
                                               
                                                </div>
                                            </div>

                                            <div class="button-group">
                                                <a href="ProductDetails.aspx?itemID=<%#Eval("itemID") %>">
                                                    <button class="addToCart" type="button" data-toggle="tooltip" title="View Information"><i class="fa fa-shopping-cart"></i><span class="">View	 Information</span></button></a>
                                            </div>
                                        </div>
                                        <!-- right block -->

                                    </div>
                                </div>
                                <div class="clearfix visible-sm-block"></div>
                                <div class="clearfix visible-xs-block"></div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                    <!--// End Changed listings-->
                    <!-- Filters -->
                    <div class="product-filter product-filter-bottom filters-panel">
                        <div class="row">
                            <div class="col-md-2 hidden-sm hidden-xs">
                            </div>
                            <div class="short-by-show text-center col-md-7 col-sm-8 col-xs-12">
                                <div class="form-group" style="margin: 7px 10px">Showing 1 to 9 of 10 (2 Pages)</div>
                            </div>
                            <div class="box-pagination col-md-3 col-sm-4 text-right">
                                <ul class="pagination">
                                    <li class="active"><span>1</span></li>
                                    <li><a href="http://localhost/ytc_templates/opencart/so_market/index.html?route=product/category&amp;path=33&amp;page=2">2</a></li>
                                    <li><a href="http://localhost/ytc_templates/opencart/so_market/index.html?route=product/category&amp;path=33&amp;page=2">&gt;</a></li>
                                    <li><a href="http://localhost/ytc_templates/opencart/so_market/index.html?route=product/category&amp;path=33&amp;page=2">&gt;|</a></li>
                                </ul>
                            </div>

                        </div>
                    </div>
                    <!-- //end Filters -->

                </div>

            </div>



        </div>
        <!--Middle Part End-->
    </div>
    <!-- //Main Container -->


    <!-- Placed at the end of the document so the pages load faster -->
    <script type="text/javascript" src="js/jquery-2.2.4.min.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/owl-carousel/owl.carousel.js"></script>
    <script type="text/javascript" src="js/themejs/libs.js"></script>
    <script type="text/javascript" src="js/unveil/jquery.unveil.js"></script>
    <script type="text/javascript" src="js/countdown/jquery.countdown.min.js"></script>
    <script type="text/javascript" src="js/dcjqaccordion/jquery.dcjqaccordion.2.8.min.js"></script>
    <script type="text/javascript" src="js/datetimepicker/moment.js"></script>
    <script type="text/javascript" src="js/datetimepicker/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui/jquery-ui.min.js"></script>




</asp:Content>

