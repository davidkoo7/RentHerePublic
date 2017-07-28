<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Repeater ID="repeaterItemInformation" OnItemDataBound="repeaterItemInformation_ItemDataBound" runat="server">
        <ItemTemplate>
            <!-- //Header Container  -->
            <!-- Main Container  -->
            <div class="main-container container">
                <ul class="breadcrumb">
                    <li><a href="#"><i class="fa fa-home"></i></a></li>

                </ul>


                <div class="row">
                    <!--Middle Part Start-->
                    <div id="content" class="col-md-9 col-md-push-3 col-sm-12 col-xs-12">

                        <div class="product-view row">
                            <div class="left-content-product col-sm-12 col-xs-12">
                                <div class="row">
                                    <div class="content-product-left  col-sm-6 col-xs-12 ">
                                        <div class="large-image  ">
                                            <img itemprop="image" class="product-image-zoom" src="/image/item/<%# DataBinder.Eval(Container.DataItem, "img1") %>" data-zoom-image="/image/item/<%# DataBinder.Eval(Container.DataItem, "img1") %>">
                                        </div>

                                        <div id="thumb-slider" class="owl-theme owl-loaded owl-drag full_slider">
                                            <a data-index="0" class="img thumbnail " data-image="/image/item/<%# DataBinder.Eval(Container.DataItem, "img1") %>">
                                                <img src="/image/item/<%# DataBinder.Eval(Container.DataItem, "img1") %>">
                                            </a>
                                            &nbsp;&nbsp;<a data-index="1" class="img thumbnail " data-image="/image/item/<%# DataBinder.Eval(Container.DataItem, "img2") %>"><img src="/image/item/<%# DataBinder.Eval(Container.DataItem, "img2") %>">
                                            </a>
                                            &nbsp;&nbsp;<a data-index="02" class="img thumbnail " data-image="/image/item/<%# DataBinder.Eval(Container.DataItem, "img3") %>"><img src="/image/item/<%# DataBinder.Eval(Container.DataItem, "img3") %>">
                                            </a>
                                            &nbsp;&nbsp;<a data-index="03" class="img thumbnail " data-image="/image/item/<%# DataBinder.Eval(Container.DataItem, "img4") %>"><img src="/image/item/<%# DataBinder.Eval(Container.DataItem, "img4") %>">
                                            </a>
                                            &nbsp;&nbsp;
                                        </div>

                                    </div>

                                    <div class="content-product-right col-sm-6 col-xs-12">
                                        <div class="title-product">
                                            <h1>
                                                <h1>
                                                    <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("name") %>' /></h1>
                                            </h1>
                                        </div>
                                        <!-- Review ---->
                                        <br />

                                        <div class="product-label form-group">
                                            <div class="product_page_price price" itemprop="offerDetails" itemscope="" itemtype="http://data-vocabulary.org/Offer">
                                                <span class="price-new" itemprop="price">
                                                    <asp:Label ID="lblPricePerDay" runat="server" Text='<%# String.Format("{0:c}", Eval("pricePerDay")) %>' /></span>
                                                <span class="price-old" style="font-size: 20; text-decoration: none">per day</span>
                                            </div>
                                        </div>
                                        <div class="product-label form-group">
                                            <div class="product_page_price price" itemprop="offerDetails" itemscope="" itemtype="http://data-vocabulary.org/Offer">
                                                <span class="price-new" itemprop="price">
                                                    <asp:Label ID="lblPricePerWeek" runat="server" Text='<%# String.Format("{0:c}", Eval("pricePerWeek")) %>' /></span>
                                                <span class="price-old" style="font-size: 20; text-decoration: none">per week</span>
                                            </div>
                                        </div>
                                        <div class="product-label form-group">
                                            <div class="product_page_price price" itemprop="offerDetails" itemscope="" itemtype="http://data-vocabulary.org/Offer">
                                                <span class="price-new" itemprop="price">
                                                    <asp:Label ID="lblPricePerMonth" runat="server" Text='<%# String.Format("{0:c}", Eval("pricePerMonth")) %>' /></span>
                                                <span class="price-old" style="font-size: 20; text-decoration: none">per month</span>
                                            </div>
                                        </div>
                                        <div class="product-box-desc">
                                            <div class="inner-box-desc">
                                                <div class="price-tax">
                                                    <span>Refundable Deposit: </span>
                                                    <asp:Label ID="lblDeposit" runat="server" Text='<%# Eval("deposit") %>' />
                                                </div>
                                                <div class="stock">
                                                    <span>Availability:</span> <span class="status-stock">
                                                        <asp:Label ID="lblItemStatus" runat="server" Text='<%# Eval("deposit") %>'></asp:Label></span>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="product-box-desc">
                                            <div class="inner-box-desc">

                                                <asp:Button ID="btnRentalProfile" OnClick="btnRenterProfile_Click" CssClass="btn btn-primary" runat="server" Text="View Renter Profile" />

                                                <asp:Button ID="btnContactRenter" OnClick="btnContactRenter_Click" CssClass="btn btn-primary" runat="server" Text="Contact Renter" />
                                            </div>
                                        </div>

                                        <div id="product">
                                            <p></p>


                                            <div class="form-group box-info-product">
                                                <div class="cart">
                                                    <asp:Button ID="btnRent" OnClick="btnRent_Click" CssClass="btn btn-mega btn-lg" runat="server" Text="Rent Now" />
                                                </div>


                                            </div>






                                        </div>

                                        <!-- end box info product -->

                                    </div>
                                </div>
                            </div>

                        </div>

                        <!-- Product Tabs -->
                        <div class="producttab ">
                            <div class="tabsslider  col-xs-12">
                                <ul class="nav nav-tabs">
                                    <li class="active"><a data-toggle="tab" href="#tab-1">Description</a></li>

                                </ul>
                                <div class="tab-content col-xs-12">
                                    <div id="tab-1" class="tab-pane fade active in">
                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("description") %>' />




                                    </div>
                                    <div id="tab-review" class="tab-pane fade">
                                        <form>
                                            <div id="review">
                                                <table class="table table-striped table-bordered">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 50%;"><strong>Super Administrator</strong></td>
                                                            <td class="text-right">29/07/2015</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <p>Best this product opencart</p>
                                                                <div class="ratings">
                                                                    <div class="rating-box">
                                                                        <span class="fa fa-stack"><i class="fa fa-star fa-stack-1x"></i><i class="fa fa-star-o fa-stack-1x"></i></span>
                                                                        <span class="fa fa-stack"><i class="fa fa-star fa-stack-1x"></i><i class="fa fa-star-o fa-stack-1x"></i></span>
                                                                        <span class="fa fa-stack"><i class="fa fa-star fa-stack-1x"></i><i class="fa fa-star-o fa-stack-1x"></i></span>
                                                                        <span class="fa fa-stack"><i class="fa fa-star fa-stack-1x"></i><i class="fa fa-star-o fa-stack-1x"></i></span>
                                                                        <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i></span>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <div class="text-right"></div>
                                            </div>
                                            <h2 id="review-title">Write a review</h2>
                                            <div class="contacts-form">
                                                <div class="form-group">
                                                    <span class="icon icon-user"></span>
                                                    <input type="text" name="name" class="form-control" value="Your Name" onblur="if (this.value == '') {this.value = 'Your Name';}" onfocus="if(this.value == 'Your Name') {this.value = '';}">
                                                </div>
                                                <div class="form-group">
                                                    <span class="icon icon-bubbles-2"></span>
                                                    <textarea class="form-control" name="text" onblur="if (this.value == '') {this.value = 'Your Review';}" onfocus="if(this.value == 'Your Review') {this.value = '';}">Your Review</textarea>
                                                </div>
                                                <span style="font-size: 11px;"><span class="text-danger">Note:</span>						HTML is not translated!</span>

                                                <div class="form-group">
                                                    <b>Rating</b> <span>Bad</span>&nbsp;
						<input type="radio" name="rating" value="1">
                                                    &nbsp;
						<input type="radio" name="rating"
                            value="2">
                                                    &nbsp;
						<input type="radio" name="rating"
                            value="3">
                                                    &nbsp;
						<input type="radio" name="rating"
                            value="4">
                                                    &nbsp;
						<input type="radio" name="rating"
                            value="5">
                                                    &nbsp;<span>Good</span>

                                                </div>
                                                <div class="buttons clearfix"><a id="button-review" class="btn buttonGray">Continue</a></div>
                                            </div>
                                        </form>
                                    </div>
                                    <div id="tab-4" class="tab-pane fade">
                                        <a href="#">Monitor</a>,
				<a href="#">Apple</a>
                                    </div>
                                    <div id="tab-5" class="tab-pane fade">
                                        <p>
                                            Lorem ipsum dolor sit amet, consetetur
					sadipscing elitr, sed diam nonumy eirmod
					tempor invidunt ut labore et dolore
					magna aliquyam erat, sed diam voluptua.
					At vero eos et accusam et justo duo
					dolores et ea rebum. Stet clita kasd
					gubergren, no sea takimata sanctus est
					Lorem ipsum dolor sit amet. Lorem ipsum
					dolor sit amet, consetetur sadipscing
					elitr, sed diam nonumy eirmod tempor
					invidunt ut labore et dolore magna aliquyam
					erat, sed diam voluptua.
                                        </p>
                                        <p>
                                            At vero eos et accusam et justo duo dolores
					et ea rebum. Stet clita kasd gubergren,
					no sea takimata sanctus est Lorem ipsum
					dolor sit amet. Lorem ipsum dolor sit
					amet, consetetur sadipscing elitr.
                                        </p>
                                        <p>
                                            Sed diam nonumy eirmod tempor invidunt
					ut labore et dolore magna aliquyam erat,
					sed diam voluptua. At vero eos et accusam
					et justo duo dolores et ea rebum. Stet
					clita kasd gubergren, no sea takimata
					sanctus est Lorem ipsum dolor sit amet.
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- //Product Tabs -->




                    </div>

                    <aside class="col-md-3 col-md-pull-9 col-sm-12  content-aside left_column">
                        <div class="module">
                            <div class="modcontent">
                                <div class="sidebar-menu ">
                                    <div class="responsive so-megamenu ">
                                        <div class="so-vertical-menu no-gutter compact-hidden">
                                            <nav class="navbar-default">
                                                <div class="container-megamenu vertical open">
                                                    <div id="menuHeading">
                                                        <div class="megamenuToogle-wrapper">
                                                            <div class="megamenuToogle-pattern">
                                                                <div class="container">
                                                                    <div>
                                                                        <span></span>
                                                                        <span></span>
                                                                        <span></span>
                                                                    </div>
                                                                    All Categories							
															<i class="fa pull-right arrow-circle fa-chevron-circle-up"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="navbar-header">
                                                        <button type="button" id="show-verticalmenu" data-toggle="collapse" class="navbar-toggle">
                                                            <span class="icon-bar"></span>
                                                            <span class="icon-bar"></span>
                                                            <span class="icon-bar"></span>
                                                        </button>
                                                        All Categories		
                                                    </div>
                                                    <div class="vertical-wrapper">
                                                        <span id="remove-verticalmenu" class="fa fa-times"></span>
                                                        <div class="megamenu-pattern">
                                                            <div class="container">
                                                                <ul class="megamenu">
                                                                    <li class="item-vertical style1 with-sub-menu hover">
                                                                        <p class="close-menu"></p>
                                                                        <a href="#" class="clearfix">
                                                                            <img src="image/theme/icons/9.png" alt="icon">
                                                                            <span>Automotive &amp; Motocrycle</span>
                                                                            <b class="caret"></b>
                                                                        </a>
                                                                        &nbsp;&nbsp;<div class="sub-menu" data-subwidth="100">
                                                                            <div class="content">
                                                                                <div class="row">
                                                                                    <div class="col-sm-12">
                                                                                        <div class="row">
                                                                                            <div class="col-md-4 static-menu">
                                                                                                <div class="menu">
                                                                                                    <ul>
                                                                                                        <li>
                                                                                                            <a href="#" class="main-menu">Apparel</a>
                                                                                                            <ul>
                                                                                                                <li><a href="#">Accessories for Tablet PC</a></li>
                                                                                                                <li><a href="#">Accessories for i Pad</a></li>
                                                                                                                <li><a href="#">Accessories for iPhone</a></li>
                                                                                                                <li><a href="#">Bags, Holiday Supplies</a></li>
                                                                                                                <li><a href="#">Car Alarms and Security</a></li>
                                                                                                                <li><a href="#">Car Audio &amp; Speakers</a></li>
                                                                                                            </ul>
                                                                                                        </li>
                                                                                                        <li>
                                                                                                            <a href="#" class="main-menu">Cables &amp; Connectors</a>
                                                                                                            <ul>
                                                                                                                <li><a href="#">Cameras &amp; Photo</a></li>
                                                                                                                <li><a href="#">Electronics</a></li>
                                                                                                                <li><a href="#">Outdoor &amp; Traveling</a></li>
                                                                                                            </ul>
                                                                                                        </li>
                                                                                                    </ul>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-4 static-menu">
                                                                                                <div class="menu">
                                                                                                    <ul>
                                                                                                        <li>
                                                                                                            <a href="#" class="main-menu">Camping &amp; Hiking</a>
                                                                                                            <ul>
                                                                                                                <li><a href="#">Earings</a></li>
                                                                                                                <li><a href="#">Shaving &amp; Hair Removal</a></li>
                                                                                                                <li><a href="#">Salon &amp; Spa Equipment</a></li>
                                                                                                            </ul>
                                                                                                        </li>
                                                                                                        <li>
                                                                                                            <a href="#" class="main-menu">Smartphone &amp; Tablets</a>
                                                                                                            <ul>
                                                                                                                <li><a href="#">Sports &amp; Outdoors</a></li>
                                                                                                                <li><a href="#">Bath &amp; Body</a></li>
                                                                                                                <li><a href="#">Gadgets &amp; Auto Parts</a></li>
                                                                                                            </ul>
                                                                                                        </li>
                                                                                                    </ul>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-4 static-menu">
                                                                                                <div class="menu">
                                                                                                    <ul>
                                                                                                        <li>
                                                                                                            <a href="#" class="main-menu">Bags, Holiday Supplies</a>
                                                                                                            <ul>
                                                                                                                <li><a href="#" onclick="window.location = '18_46';">Battereries &amp; Chargers</a></li>
                                                                                                                <li><a href="#" onclick="window.location = '24_64';">Bath &amp; Body</a></li>
                                                                                                                <li><a href="#" onclick="window.location = '18_45';">Headphones, Headsets</a></li>
                                                                                                                <li><a href="#" onclick="window.location = '18_30';">Home Audio</a></li>
                                                                                                            </ul>
                                                                                                        </li>
                                                                                                    </ul>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li class="item-vertical">
                                                                        <p class="close-menu"></p>
                                                                        <a href="#" class="clearfix">
                                                                            <img src="image/theme/icons/10.png" alt="icon">
                                                                            <span>Electronic</span>

                                                                        </a>
                                                                        &nbsp;&nbsp;</li>
                                                                    <li class="item-vertical with-sub-menu hover">
                                                                        <p class="close-menu"></p>
                                                                        <a href="#" class="clearfix">
                                                                            <span class="label"></span>
                                                                            <img src="image/theme/icons/3.png" alt="icon">
                                                                            <span>Sports &amp; Outdoors</span>
                                                                            <b class="caret"></b>
                                                                        </a>
                                                                        &nbsp;&nbsp;<div class="sub-menu" data-subwidth="60">
                                                                            <div class="content">
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <div class="row">
                                                                                            <div class="col-md-12 static-menu">
                                                                                                <div class="menu">
                                                                                                    <ul>
                                                                                                        <li>
                                                                                                            <a href="#" onclick="window.location = '81';" class="main-menu">Mobile Accessories</a>
                                                                                                            <ul>
                                                                                                                <li><a href="#" onclick="window.location = '33_63';">Gadgets &amp; Auto Parts</a></li>
                                                                                                                <li><a href="#" onclick="window.location = '24_64';">Bath &amp; Body</a></li>
                                                                                                                <li><a href="#" onclick="window.location = '17';">Bags, Holiday Supplies</a></li>
                                                                                                            </ul>
                                                                                                        </li>
                                                                                                        <li>
                                                                                                            <a href="#" onclick="window.location = '18_46';" class="main-menu">Battereries &amp; Chargers</a>
                                                                                                            <ul>
                                                                                                                <li><a href="#" onclick="window.location = '25_28';">Outdoor &amp; Traveling</a></li>
                                                                                                                <li><a href="#" onclick="window.location = '80';">Flashlights &amp; Lamps</a></li>
                                                                                                                <li><a href="#" onclick="window.location = '24_66';">Fragrances</a></li>
                                                                                                            </ul>
                                                                                                        </li>
                                                                                                        <li>
                                                                                                            <a href="#" onclick="window.location = '25_31';" class="main-menu">Fishing</a>
                                                                                                            <ul>
                                                                                                                <li><a href="#" onclick="window.location = '57_73';">FPV System &amp; Parts</a></li>
                                                                                                                <li><a href="#" onclick="window.location = '18';">Electronics</a></li>
                                                                                                                <li><a href="#" onclick="window.location = '20_76';">Earings</a></li>
                                                                                                                <li><a href="#" onclick="window.location = '33_60';">More Car Accessories</a></li>
                                                                                                            </ul>
                                                                                                        </li>
                                                                                                    </ul>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <div class="row banner">
                                                                                            <a href="#">
                                                                                                <img src="image/demo/cms/menu_bg2.jpg" alt="banner1">
                                                                                            </a>
                                                                                            &nbsp;&nbsp;
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li class="item-vertical with-sub-menu hover">
                                                                        <p class="close-menu"></p>
                                                                        <a href="#" class="clearfix">
                                                                            <img src="image/theme/icons/2.png" alt="icon">
                                                                            <span>Health &amp; Beauty</span>
                                                                            <b class="caret"></b>
                                                                        </a>
                                                                        &nbsp;&nbsp;<div class="sub-menu" data-subwidth="100">
                                                                            <div class="content">
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <div class="row">
                                                                                            <div class="col-md-4 static-menu">
                                                                                                <div class="menu">
                                                                                                    <ul>
                                                                                                        <li>
                                                                                                            <a href="#" class="main-menu">Car Alarms and Security</a>
                                                                                                            <ul>
                                                                                                                <li><a href="#">Car Audio &amp; Speakers</a></li>
                                                                                                                <li><a href="#">Gadgets &amp; Auto Parts</a></li>
                                                                                                                <li><a href="#">Gadgets &amp; Auto Parts</a></li>
                                                                                                                <li><a href="#">Headphones, Headsets</a></li>
                                                                                                            </ul>
                                                                                                        </li>
                                                                                                        <li>
                                                                                                            <a href="24" onclick="window.location = '24';" class="main-menu">Health &amp; Beauty</a>
                                                                                                            <ul>
                                                                                                                <li>
                                                                                                                    <a href="#">Home Audio</a>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <a href="#">Helicopters &amp; Parts</a>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <a href="#">Outdoor &amp; Traveling</a>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <a href="#">Toys &amp; Hobbies</a>
                                                                                                                </li>
                                                                                                            </ul>
                                                                                                        </li>
                                                                                                    </ul>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-4 static-menu">
                                                                                                <div class="menu">
                                                                                                    <ul>
                                                                                                        <li>
                                                                                                            <a href="#" class="main-menu">Electronics</a>
                                                                                                            <ul>
                                                                                                                <li>
                                                                                                                    <a href="#">Earings</a>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <a href="#">Salon &amp; Spa Equipment</a>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <a href="#">Shaving &amp; Hair Removal</a>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <a href="#">Smartphone &amp; Tablets</a>
                                                                                                                </li>
                                                                                                            </ul>
                                                                                                        </li>
                                                                                                        <li>
                                                                                                            <a href="#" class="main-menu">Sports &amp; Outdoors</a>
                                                                                                            <ul>
                                                                                                                <li>
                                                                                                                    <a href="#">Flashlights &amp; Lamps</a>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <a href="#">Fragrances</a>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <a href="#">Fishing</a>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <a href="#">FPV System &amp; Parts</a>
                                                                                                                </li>
                                                                                                            </ul>
                                                                                                        </li>
                                                                                                    </ul>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-4 static-menu">
                                                                                                <div class="menu">
                                                                                                    <ul>
                                                                                                        <li>
                                                                                                            <a href="#" class="main-menu">More Car Accessories</a>
                                                                                                            <ul>
                                                                                                                <li>
                                                                                                                    <a href="#">Lighter &amp; Cigar Supplies</a>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <a href="#">Mp3 Players &amp; Accessories</a>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <a href="#">Men Watches</a>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <a href="#">Mobile Accessories</a>
                                                                                                                </li>
                                                                                                            </ul>
                                                                                                        </li>
                                                                                                        <li>
                                                                                                            <a href="#" class="main-menu">Gadgets &amp; Auto Parts</a>
                                                                                                            <ul>
                                                                                                                <li>
                                                                                                                    <a href="#">Gift &amp; Lifestyle Gadgets</a>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <a href="#">Gift for Man</a>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <a href="#">Gift for Woman</a>
                                                                                                                </li>
                                                                                                                <li>
                                                                                                                    <a href="#">Gift for Woman</a>
                                                                                                                </li>
                                                                                                            </ul>
                                                                                                        </li>
                                                                                                    </ul>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li class="item-vertical css-menu with-sub-menu hover">
                                                                        <p class="close-menu"></p>
                                                                        <a href="#" class="clearfix">

                                                                            <img src="image/theme/icons/2.png" alt="icon">
                                                                            <span>Smartphone &amp; Tablets</span>
                                                                            <b class="caret"></b>
                                                                        </a>
                                                                        &nbsp;&nbsp;<div class="sub-menu" data-subwidth="30" style="width: 270px; display: none; right: 0px;">
                                                                            <div class="content" style="display: none;">
                                                                                <div class="row">
                                                                                    <div class="col-sm-12">
                                                                                        <div class="row">
                                                                                            <div class="col-sm-12 hover-menu">
                                                                                                <div class="menu">
                                                                                                    <ul>
                                                                                                        <li>
                                                                                                            <a href="#" class="main-menu">Headphones, Headsets</a>
                                                                                                        </li>
                                                                                                        <li>
                                                                                                            <a href="#" class="main-menu">Home Audio</a>
                                                                                                        </li>
                                                                                                        <li>
                                                                                                            <a href="#" class="main-menu">Health &amp; Beauty</a>
                                                                                                        </li>
                                                                                                        <li>
                                                                                                            <a href="#" class="main-menu">Helicopters &amp; Parts</a>
                                                                                                        </li>
                                                                                                        <li>
                                                                                                            <a href="#" class="main-menu">Helicopters &amp; Parts</a>
                                                                                                        </li>
                                                                                                    </ul>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li class="item-vertical">
                                                                        <p class="close-menu"></p>
                                                                        <a href="#" class="clearfix">
                                                                            <img src="image/theme/icons/11.png" alt="icon">
                                                                            <span>Flashlights &amp; Lamps</span>

                                                                        </a>
                                                                        &nbsp;&nbsp;</li>
                                                                    <li class="item-vertical">
                                                                        <p class="close-menu"></p>
                                                                        <a href="#" class="clearfix">
                                                                            <img src="image/theme/icons/4.png" alt="icon">
                                                                            <span>Camera &amp; Photo</span>
                                                                        </a>
                                                                        &nbsp;&nbsp;</li>
                                                                    <li class="item-vertical">
                                                                        <p class="close-menu"></p>
                                                                        <a href="#" class="clearfix">
                                                                            <img src="image/theme/icons/5.png" alt="icon">
                                                                            <span>Smartphone &amp; Tablets</span>
                                                                        </a>
                                                                        &nbsp;&nbsp;</li>
                                                                    <li class="item-vertical" style="display: none;">
                                                                        <p class="close-menu"></p>
                                                                        <a href="#" class="clearfix">
                                                                            <img src="image/theme/icons/7.png" alt="icon">
                                                                            <span>Outdoor &amp; Traveling Supplies</span>
                                                                        </a>
                                                                        &nbsp;&nbsp;</li>
                                                                    <li class="item-vertical" style="display: none;">
                                                                        <p class="close-menu"></p>

                                                                        <a href="#" class="clearfix">
                                                                            <img src="image/theme/icons/6.png" alt="icon">
                                                                            <span>Health &amp; Beauty</span>
                                                                        </a>
                                                                        &nbsp;&nbsp;</li>
                                                                    <li class="item-vertical" style="display: none;">
                                                                        <p class="close-menu"></p>
                                                                        <a href="#" class="clearfix">
                                                                            <img src="image/theme/icons/8.png" alt="icon">
                                                                            <span>Toys &amp; Hobbies </span>
                                                                        </a>
                                                                        &nbsp;&nbsp;</li>
                                                                    <li class="item-vertical" style="display: none;">
                                                                        <p class="close-menu"></p>
                                                                        <a href="#" class="clearfix">
                                                                            <img src="image/theme/icons/12.png" alt="icon">
                                                                            <span>Jewelry &amp; Watches</span>
                                                                        </a>
                                                                        &nbsp;&nbsp;</li>
                                                                    <li class="item-vertical" style="display: none;">
                                                                        <p class="close-menu"></p>
                                                                        <a href="#" class="clearfix">
                                                                            <img src="image/theme/icons/13.png" alt="icon">
                                                                            <span>Bags, Holiday Supplies</span>
                                                                        </a>
                                                                        &nbsp;&nbsp;</li>
                                                                    <li class="item-vertical" style="display: none;">
                                                                        <p class="close-menu"></p>

                                                                        <a href="#" class="clearfix">
                                                                            <img src="image/theme/icons/13.png" alt="icon">
                                                                            <span>More Car Accessories</span>
                                                                        </a>
                                                                        &nbsp;&nbsp;</li>
                                                                    <li class="loadmore">
                                                                        <i class="fa fa-plus-square-o"></i>
                                                                        <span class="more-view">More Categories</span>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </nav>
                                        </div>
                                    </div>

                                </div>

                            </div>
                        </div>

                        <div class="module titleLine">
                            <h3 class="modtitle">Clients say</h3>
                            <div class="modcontent">
                                <div class="block-clientsay block ">

                                    <div class="yt-content-slider slider-clients-say" data-rtl="yes" data-autoplay="no" data-autoheight="no" data-delay="4" data-speed="0.6" data-margin="0" data-items_column0="1" data-items_column1="1" data-items_column2="1" data-items_column3="1" data-items_column4="1" data-arrows="yes" data-pagination="no" data-lazyload="yes" data-loop="no" data-hoverpause="yes">
                                        <div class="yt-content-slide">
                                            <div class="client-cont">We will put some review here later</div>
                                            <div class="client-info">
                                                <img src="image/demo/cms/client-img1.jpg" alt="">
                                                <div class="inner">
                                                    David
											<p>RentHere</p>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="yt-content-slide">
                                            <div class="client-cont">Aliquam ut tellus dignissim, cursus erat ultricies tellus. Nulla tempus sollicitudin mauris cursus dictum. Etiam id diam diam.</div>
                                            <div class="client-info">
                                                <img src="image/demo/cms/client-img1.jpg" alt="">
                                                <div class="inner">
                                                    Aliquam Tellus
											<p>Vitae Ornare Mauris</p>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="yt-content-slide">
                                            <div class="client-cont">Aliquam ut tellus dignissim, cursus erat ultricies tellus. Nulla tempus sollicitudin mauris cursus dictum. Etiam id diam diam.</div>
                                            <div class="client-info">
                                                <img src="image/demo/cms/client-img1.jpg" alt="">
                                                <div class="inner">
                                                    Aliquam Tellus
											<p>Vitae Ornare Mauris</p>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="module banners-effect-7">
                            <div class="modcontent clearfix">
                                <div class="banners">
                                    <div>
                                        <a href="#">
                                            <img src="image/demo/cms/v3-banner-home-left.jpg" alt="banner1"></a>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </aside>
                </div>
                <!--Middle Part End-->
            </div>
            <!-- //Main Container -->
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

