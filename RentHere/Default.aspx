<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Navbar switcher -->
    <!-- //end Navbar switcher -->
	<!-- //Header Container  -->

    <!-- Block Spotlight1  -->
    <section class="so-spotlight1 ">
        <div class="container">
            <div class="row">
                <div id="yt_header_right" class="col-lg-offset-3 col-lg-9 col-md-12">
                    <div class="slider-container ">

                        <div class="module first-block">
                            <div class="modcontent clearfix">
                                <div id="custom_popular_search" class="clearfix">
                                    <h5 class="so-searchbox-popular-title pull-left">Top Search:</h5>
                                    <div class="so-searchbox-keyword">
                                        <ul class="list-inline">
                                            <li>&nbsp;<a href="#">Acer,</a></li>
                                            <li><a href="#">APPLE,</a></li>
                                            <li><a href="#">Black,</a></li>
                                            <li><a href="#">Canon,</a></li>
                                            <li><a href="#">Cogs,</a></li>
                                            <li><a href="#">Confi,</a></li>
                                            <li><a href="#">Kate,</a></li>
                                            <li><a href="#">Lor,</a></li>
                                            <li><a href="#">Product,</a></li>
                                            <li><a href="#">Zolof The Rock And Roll Destroyer</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="so-slideshow" class="col-lg-8 col-md-8 col-sm-12 col-xs-12 two-block">
                            <div class="module no-margin">
                                <div class="yt-content-slider yt-content-slider--arrow1" data-rtl="yes" data-autoplay="no" data-autoheight="no" data-delay="4" data-speed="0.6" data-margin="0" data-items_column0="1" data-items_column1="1" data-items_column2="1" data-items_column3="1" data-items_column4="1" data-arrows="yes" data-pagination="no" data-lazyload="yes" data-loop="no" data-hoverpause="yes">
                                    <div class="yt-content-slide">
                                        <a href="#">
                                            <img src="image/demo/slider/slider-1.png" alt="slider1" class="img-responsive"></a>
                                    </div>
                                    <div class="yt-content-slide">
                                        <a href="#">
                                            <img src="image/demo/slider/slider-2.png" alt="slider2" class="img-responsive"></a>
                                    </div>
                                    <div class="yt-content-slide">
                                        <a href="#">
                                            <img src="image/demo/slider/slider-3.png" alt="slider3" class="img-responsive"></a>
                                    </div>
                                </div>

                                <div class="loadeding"></div>
                            </div>

                        </div>


                        <div class="module col-md-4  hidden-sm hidden-xs three-block ">
                            <div class="modcontent clearfix">
                                <div class="htmlcontent-block">
                                    <ul class="htmlcontent-home">
                                        <li>
                                            <div class="banners">
                                                <div>
                                                    <a href="#">
                                                        <img src="image/demo/cms/banner1.jpg" alt="banner1"></a>
                                                </div>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="banners">
                                                <div>
                                                    <a href="#">
                                                        <img src="image/demo/cms/banner2.jpg" alt="banner1"></a>
                                                </div>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="banners">
                                                <div>
                                                    <a href="#">
                                                        <img src="image/demo/cms/banner3.jpg" alt="banner1"></a>
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>

                        <div class="module hidden-xs col-sm-12 four-block">
                            <div class="modcontent clearfix">
                                <div class="policy-detail">
                                    <div class="banner-policy">
                                        <div class="policy policy1">
                                            <a href="#"><span class="ico-policy">&nbsp;</span> 90 day
                                            <br>
                                                money back </a>
                                        </div>
                                        <div class="policy policy2"><a href="#"><span class="ico-policy">&nbsp;</span> In-store exchange </a></div>
                                        <div class="policy policy3"><a href="#"><span class="ico-policy">&nbsp;</span> lowest price guarantee </a></div>
                                        <div class="policy policy4"><a href="#"><span class="ico-policy">&nbsp;</span> shopping guarantee </a></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- //Block Spotlight1  -->

    <!-- Main Container  -->
    <div class="main-container container">

        <div class="row">
            <div id="content" class="col-sm-12">

                <div class="module tab-slider titleLine">
                    <h3 class="modtitle">New Products</h3>
                    <div id="so_listing_tabs_1" class="so-listing-tabs first-load module">
                        <div class="loadeding"></div>
                        <div class="ltabs-wrap">
                            <div class="ltabs-tabs-container" data-rtl="yes" data-delay="300" data-duration="600" data-effect="starwars" data-ajaxurl="" data-type_source="0" data-lg="4" data-md="3" data-sm="2" data-xs="1" data-margin="30">
                                <!--Begin Tabs-->
                                <div class="ltabs-tabs-wrap">
                                    <span class="ltabs-tab-selected">Jewelry &amp; Watches	</span><span class="ltabs-tab-arrow">▼</span>
                                    <div class="item-sub-cat">
                                        <ul class="ltabs-tabs cf">
                                            <li class="ltabs-tab tab-sel" data-category-id="20" data-active-content=".items-category-20"></li>
                                        </ul>
                                    </div>
                                </div>
                                <!-- End Tabs-->
                            </div>
                            <div class="ltabs-items-container">
                                <!--Begin Items-->
                                <div class="ltabs-items ltabs-items-selected items-category-20 grid" data-total="10">
                                    <div class="ltabs-items-inner ltabs-slider ">


                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                <div class="ltabs-item product-layout">
                                                    <div class="product-item-container">
                                                        <div class="left-block">
                                                            <div class="product-image-container second_img ">
                                                                <img src="image/demo/shop/resize/m1-270x270.jpg" alt="Apple Cinema 30&quot;" class="img-responsive" />
                                                                <img src="image/demo/shop/resize/m3-270x270.jpg" alt="Apple Cinema 30&quot;" class="img_0 img-responsive" />
                                                            </div>
                                                            <!--New Label-->
                                                            <span class="label label-new">New</span>
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
                                                                    <span class="price-new">
                                                                        <asp:Label ID="pricePerDayLabel" runat="server" Text='<%# Eval("pricePerDay") %>' /></span>
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

                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>

                                </div>
                                <div class="ltabs-items items-category-18 grid" data-total="11">
                                    <div class="ltabs-loading"></div>

                                </div>
                                <div class="ltabs-items  items-category-25 grid" data-total="11">
                                    <div class="ltabs-loading"></div>
                                </div>
                            </div>
                            <!--End Items-->


                        </div>

                    </div>
                </div>
                <div class="module ">
                    <div class="modcontent clearfix">
                        <div class="banner-wraps ">
                            <div class="m-banner row">
                                <div class="banner htmlconten1 col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <div class="banners">
                                        <div>
                                            <a href="#">
                                                <img src="image/demo/cms/banner2-1.png" alt="banner1"></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="htmlconten2 col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <div class="module banners">
                                        <div>
                                            <a href="#">
                                                <img src="image/demo/cms/banner2-2.png" alt="banner1"></a>
                                        </div>
                                    </div>

                                    <div class="banners">
                                        <div>
                                            <a href="#">
                                                <img src="image/demo/cms/banner2-3.png" alt="banner1"></a>
                                        </div>
                                    </div>

                                </div>
                                <div class="banner htmlconten3 hidden-sm col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <div class="banners">
                                        <div>
                                            <a href="#">
                                                <img src="image/demo/cms/banner2-4.png" alt="banner1"></a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>



                <div class="module no-margin titleLine ">
                    <h3 class="modtitle">COLLECTIONS</h3>
                    <div class="modcontent clearfix">
                        <div id="collections_block" class="clearfix  block">
                            <ul class="width6">
                                <li class="collect collection_0">
                                    <div class="color_co"><a href="#">Furniture</a> </div>
                                </li>
                                <li class="collect collection_1">
                                    <div class="color_co"><a href="#">Gift idea</a> </div>
                                </li>
                                <li class="collect collection_2">
                                    <div class="color_co"><a href="#">Cool gadgets</a> </div>
                                </li>
                                <li class="collect collection_3">
                                    <div class="color_co"><a href="#">Outdoor activities</a> </div>
                                </li>
                                <li class="collect collection_4">
                                    <div class="color_co"><a href="#">Accessories for</a> </div>
                                </li>
                                <li class="collect collection_5">
                                    <div class="color_co"><a href="#">Women world</a> </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!-- //Main Container -->
    <!-- Block Spotlight3  -->
    <section class="so-spotlight3">
        <div class="container">
            <div class="row">

                <div id="so_categories_173761471880018" class="so-categories module titleLine preset01-4 preset02-3 preset03-3 preset04-1 preset05-1">
                    <h3 class="modtitle">Hot Categories</h3>

                    <div class="wrap-categories">
                        <div class="cat-wrap theme3">
                            <div class="content-box">
                                <div class="image-cat">
                                    <a href="#" title="Automotive" target="_blank">
                                        <img src="image/demo/shop/category/automotive-motocrycle.jpg" title="Automotive" alt="Automotive">
                                    </a>
                                    <a class="btn-viewmore hidden-xs" href="#" title="View more">View more</a>
                                </div>
                                <div class="inner">
                                    <div class="title-cat"><a href="#" title="Automotive " target="_blank">Automotive</a> </div>
                                    <div class="child-cat">
                                        <div class="child-cat-title"><a title="More Car Accessories" href="#" target="_blank">More Car Accessories		</a></div>
                                        <div class="child-cat-title"><a title="Car Alarms and Security" href="#" target="_blank">Car Alarms and Security		</a></div>
                                        <div class="child-cat-title"><a title="Car Audio &amp; Speakers" href="#" target="_blank">Car Audio &amp; Speakers		</a></div>
                                        <div class="child-cat-title"><a title="Gadgets &amp; Auto Parts" href="#" target="_blank">Gadgets &amp; Auto Parts	</a></div>
                                    </div>
                                </div>
                            </div>
                            <div class="clr1"></div>
                            <div class="content-box">
                                <div class="image-cat">
                                    <a href="#" title="Automotive" target="_blank">
                                        <img src="image/demo/shop/category/health-beauty.jpg" title="Automotive" alt="Automotive">
                                    </a>
                                    <a class="btn-viewmore hidden-xs" href="#" title="View more">View more</a>
                                </div>

                                <div class="inner">
                                    <div class="title-cat"><a href="#" title="Health & Beauty" target="_blank">Health & Beauty</a> </div>
                                    <div class="child-cat">
                                        <div class="child-cat-title"><a title="More Car Accessories" href="#" target="_blank">Salon & Spa Equipment		</a></div>
                                        <div class="child-cat-title"><a title="Car Alarms and Security" href="#" target="_blank">Fragrances		</a></div>
                                        <div class="child-cat-title"><a title="Car Audio &amp; Speakers" href="#" target="_blank">Shaving & Hair Removal..	</a></div>
                                        <div class="child-cat-title"><a title="Gadgets &amp; Auto Parts" href="#" target="_blank">Bath & Body	</a></div>
                                    </div>
                                </div>
                            </div>
                            <div class="clr1 clr2"></div>
                            <div class="content-box">
                                <div class="image-cat">
                                    <a href="#" title="Automotive" target="_blank">
                                        <img src="image/demo/shop/category/bags-holiday-supplies-gifts.jpg" title="Automotive" alt="Automotive">
                                    </a>
                                    <a class="btn-viewmore hidden-xs" href="#" title="View more">View more</a>
                                </div>

                                <div class="inner">
                                    <div class="title-cat"><a href="#" title="Health & Beauty" target="_blank">Bags, Holiday Supplies</a> </div>
                                    <div class="child-cat">
                                        <div class="child-cat-title"><a title="More Car Accessories" href="#" target="_blank">Gift & Lifestyle Gadgets..		</a></div>
                                        <div class="child-cat-title"><a title="Car Alarms and Security" href="#" target="_blank">Lighter & Cigar Supplies..		</a></div>
                                        <div class="child-cat-title"><a title="Car Audio &amp; Speakers" href="#" target="_blank">Gift for Woman	</a></div>
                                        <div class="child-cat-title"><a title="Gadgets &amp; Auto Parts" href="#" target="_blank">Gift for Man	</a></div>
                                    </div>
                                </div>
                            </div>
                            <div class="clr1 clr3"></div>
                            <div class="content-box">
                                <div class="image-cat">
                                    <a href="#" title="Automotive" target="_blank">
                                        <img src="image/demo/shop/category/toys-hobbies.jpg" title="Automotive" alt="Automotive">
                                    </a>
                                    <a class="btn-viewmore hidden-xs" href="#" title="View more">View more</a>
                                </div>

                                <div class="inner">
                                    <div class="title-cat"><a href="#" title="Health & Beauty" target="_blank">Toys & Hobbies</a> </div>
                                    <div class="child-cat">
                                        <div class="child-cat-title"><a title="More Car Accessories" href="#" target="_blank">Helicopters & Parts		</a></div>
                                        <div class="child-cat-title"><a title="Car Alarms and Security" href="#" target="_blank">RC Cars & Parts	</a></div>
                                        <div class="child-cat-title"><a title="Car Audio &amp; Speakers" href="#" target="_blank">FPV System & Parts	</a></div>
                                        <div class="child-cat-title"><a title="Gadgets &amp; Auto Parts" href="#" target="_blank">Walkera	</a></div>
                                    </div>
                                </div>
                            </div>
                            <div class="clr1 clr2 clr4"></div>
                            <div class="content-box">
                                <div class="image-cat">
                                    <a href="#" title="Automotive" target="_blank">
                                        <img src="image/demo/shop/category/electronics.jpg" title="Automotive" alt="Automotive">
                                    </a>
                                    <a class="btn-viewmore hidden-xs" href="#" title="View more">View more</a>
                                </div>

                                <div class="inner">
                                    <div class="title-cat"><a href="#" title="Health & Beauty" target="_blank">Electronics</a> </div>
                                    <div class="child-cat">
                                        <div class="child-cat-title"><a title="More Car Accessories" href="#" target="_blank">Home Audio</a> </div>
                                        <div class="child-cat-title"><a title="Car Alarms and Security" href="#" target="_blank">Mp3 Players & Accessories..	</a></div>
                                        <div class="child-cat-title"><a title="Car Audio &amp; Speakers" href="#" target="_blank">Headphones, Headsets</a> </div>
                                        <div class="child-cat-title"><a title="Gadgets &amp; Auto Parts" href="#" target="_blank">Battereries & Chargers..	</a></div>
                                    </div>
                                </div>
                            </div>
                            <div class="clr1 clr5"></div>
                            <div class="content-box">
                                <div class="image-cat">
                                    <a href="#" title="Automotive" target="_blank">
                                        <img src="image/demo/shop/category/jewelry-watches.jpg" title="Automotive" alt="Automotive">
                                    </a>
                                    <a class="btn-viewmore hidden-xs" href="#" title="View more">View more</a>
                                </div>

                                <div class="inner">
                                    <div class="title-cat"><a href="#" title="Health & Beauty" target="_blank">Jewelry & Watches</a> </div>
                                    <div class="child-cat">
                                        <div class="child-cat-title"><a title="More Car Accessories" href="#" target="_blank">Men Watches	</a></div>
                                        <div class="child-cat-title"><a title="Car Alarms and Security" href="#" target="_blank">Wedding Rings		</a></div>
                                        <div class="child-cat-title"><a title="Car Audio &amp; Speakers" href="#" target="_blank">Earings	</a></div>
                                    </div>
                                </div>
                            </div>
                            <div class="clr1 clr2 clr3 clr6"></div>
                            <div class="content-box">
                                <div class="image-cat">
                                    <a href="#" title="Automotive" target="_blank">
                                        <img src="image/demo/shop/category/sports-outdoors.jpg" title="Automotive" alt="Automotive">
                                    </a>
                                    <a class="btn-viewmore hidden-xs" href="#" title="View more">View more</a>
                                </div>

                                <div class="inner">
                                    <div class="title-cat"><a href="#" title="Health & Beauty" target="_blank">Sports & Outdoors</a> </div>
                                    <div class="child-cat">
                                        <div class="child-cat-title"><a title="More Car Accessories" href="#" target="_blank">Outdoor & Traveling	</a></div>
                                        <div class="child-cat-title"><a title="Car Alarms and Security" href="#" target="_blank">Camping & Hiking		</a></div>
                                        <div class="child-cat-title"><a title="Car Audio &amp; Speakers" href="#" target="_blank">Golf Supplies	</a></div>
                                        <div class="child-cat-title"><a title="Gadgets &amp; Auto Parts" href="#" target="_blank">Fishing	</a></div>
                                    </div>
                                </div>
                            </div>
                            <div class="clr1"></div>
                            <div class="content-box">
                                <div class="image-cat">
                                    <a href="#" title="Automotive" target="_blank">
                                        <img src="image/demo/shop/category/smartphone-tablets.jpg" title="Automotive" alt="Automotive">
                                    </a>
                                    <a class="btn-viewmore hidden-xs" href="#" title="View more">View more</a>
                                </div>

                                <div class="inner">
                                    <div class="title-cat"><a href="#" title="Health & Beauty" target="_blank">Smartphone & Tablets</a> </div>
                                    <div class="child-cat">
                                        <div class="child-cat-title"><a title="More Car Accessories" href="#" target="_blank">Accessories for iPhone		</a></div>
                                        <div class="child-cat-title"><a title="Car Audio &amp; Speakers" href="#" target="_blank">Accessories for i Pad	</a></div>
                                        <div class="child-cat-title"><a title="Gadgets &amp; Auto Parts" href="#" target="_blank">Accessories for Tablet PC	</a></div>
                                    </div>
                                </div>
                            </div>
                            <div class="clr1 clr2 clr4"></div>
                        </div>
                    </div>
                </div>

                <div id="container-module-newletter" class="hidden-md hidden-sm hidden-xs">
                    <div class="so_newletter_custom_popup_bg popup_bg"></div>
                    <div class="module main-newsleter-popup so_newletter_custom_popup so_newletter_oca_popup" id="so_newletter_custom_popup">
                        <div class="so-custom-popup so-custom-oca-popup" style="width: 850px; background: url('image/demo/cms/newletter-bg.jpg') no-repeat white;">
                            <div class="modcontent">
                                <div class="oca_popup" id="test-popup">
                                    <div class="popup-content">
                                        <p class="newsletter_promo">Daily Promotion</p>
                                        <div class="popup-title">SIGN UP FOR NEWSLETTER					</div>
                                        <form method="post" name="signup" class="form-group signup">
                                            <div class="input-control">
                                                <div class="email">
                                                    <input type="email" placeholder="Your email address..." value="" class="form-control" id="txtemail" name="txtemail">
                                                </div>
                                                <button class="btn btn-default" type="submit" onclick="return subscribe_newsletter();" name="submit">Subscribe	</button>
                                            </div>
                                        </form>
                                        <label class="hidden-popup">
                                            <input type="checkbox" value="1" name="hidden-popup">
                                            <span class="inline">&nbsp;&nbsp;Don't show this popup again</span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <!--/.modcontent-->
                            <button title="Close" type="button" class="popup-close">×</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- //Block Spotlight3  -->
    <script type="text/javascript"><!--
    var $typeheader = 'header-home1';
	//-->
    </script>

    <!--Start of Zendesk Chat Script-->

</asp:Content>

