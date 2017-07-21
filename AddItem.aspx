<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddItem.aspx.cs" Inherits="AddItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Add Item</a></li>

        </ul>

        <div class="row">
            <!--Middle Part Start-->
            <div id="content" class="col-md-12 col-sm-12">

                <div class="product-view row">
                    <div class="left-content-product col-lg-10 col-xs-12">
                        <div class="row">
                            <div class="content-product-left class-honizol col-sm-6 col-xs-12 ">
                                <div class="large-image  ">
                                    <img itemprop="image" class="product-image-zoom" src="image/demo/shop/product/J9.jpg" data-zoom-image="image/demo/shop/product/J9.jpg" title="Bint Beef" alt="Bint Beef">
                                </div>
                                <a class="thumb-video pull-left" href="https://www.youtube.com/watch?v=HhabgvIIXik"><i class="fa fa-youtube-play"></i></a>
                                <div id="thumb-slider" class="owl-theme owl-loaded owl-drag full_slider">
                                    <a data-index="0" class="img thumbnail " data-image="image/demo/shop/product/J9.jpg" title="Bint Beef">
                                        <img src="image/demo/shop/product/J9.jpg" title="Bint Beef" alt="Bint Beef">
                                    </a>
                                    <a data-index="1" class="img thumbnail " data-image="image/demo/shop/product/J6.jpg" title="Bint Beef">
                                        <img src="image/demo/shop/product/J6.jpg" title="Bint Beef" alt="Bint Beef">
                                    </a>
                                    <a data-index="2" class="img thumbnail " data-image="image/demo/shop/product/J5.jpg" title="Bint Beef">
                                        <img src="image/demo/shop/product/J5.jpg" title="Bint Beef" alt="Bint Beef">
                                    </a>
                                    <a data-index="3" class="img thumbnail " data-image="image/demo/shop/product/J4.jpg" title="Bint Beef">
                                        <img src="image/demo/shop/product/J4.jpg" title="Bint Beef" alt="Bint Beef">
                                    </a>
                                </div>

                            </div>

                            <div class="content-product-right col-sm-6 col-xs-12">
                                <div class="title-product">
                                    <h1>
                                        <asp:TextBox ID="tbxItemName" placeholder="Item Name" runat="server"></asp:TextBox></h1>
                                </div>
                                <!-- Review ---->
                                <div class="box-review form-group">
                                    <div class="ratings">
                                        <div class="rating-box">
                                            <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i></span>
                                            <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i></span>
                                            <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i></span>
                                            <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i></span>
                                            <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i></span>
                                        </div>
                                    </div>

                                    <a class="reviews_button" href="" onclick="$('a[href=\'#tab-review\']').trigger('click'); return false;">0 reviews</a>	| 
									<a class="write_review_button" href="" onclick="$('a[href=\'#tab-review\']').trigger('click'); return false;">Write a review</a>
                                </div>

                                <div class="product-label form-group">
                                    <div class="product_page_price price" itemprop="offerDetails" itemscope="" itemtype="http://data-vocabulary.org/Offer">
                                        <span class="price-new" itemprop="price">S$
                                            <asp:TextBox placeholder="1.5" ID="tbxPricePerDay" type="number" runat="server" Width="200px"></asp:TextBox></span>
                                        <span class="price-old" style="font-size: 20; text-decoration: none;">per day</span>
                                    </div>
                                </div>
                                <div class="product-label form-group">
                                    <div class="product_page_price price" itemprop="offerDetails" itemscope="" itemtype="http://data-vocabulary.org/Offer">
                                        <span class="price-new" itemprop="price">S$
                                            <asp:TextBox ID="tbxPricePerWeek" placeholder="15" type="number" runat="server" Width="200px"></asp:TextBox></span>
                                        <span class="price-old" style="font-size: 20; text-decoration: none;">per week</span>
                                    </div>
                                </div>
                                <div class="product-label form-group">
                                    <div class="product_page_price price" itemprop="offerDetails" itemscope="" itemtype="http://data-vocabulary.org/Offer">
                                        <span class="price-new" itemprop="price">S$
                                            <asp:TextBox placeholder="150" type="number" ID="tbxPricePerMonth" runat="server" Width="200px"></asp:TextBox></span>
                                        <span class="price-old" style="font-size: 20; text-decoration: none;">per month</span>
                                    </div>
                                </div>

                                <div class="product-box-desc">
                                    <div class="inner-box-desc">

                                        <div class="price-tax"><span>Refundable Deposit:</span>
                                            <asp:TextBox placeholder="500" type="number" CssClass="form-control" ID="tbxRefundableDeposit" runat="server"></asp:TextBox></div>
                                    </div>
                                </div>


                                <div class="product-box-desc">
                                    <div class="inner-box-desc">
                                        <div class="renter-info"><span>Meet-Up Location</span></div>

                                        <asp:RadioButton ID="rbtnMRTLocation" runat="server" Text="MRT: " />
                                        <asp:DropDownList ID="ddlMRTLocation" runat="server">
                                        </asp:DropDownList>
                                        <br />
                                        <asp:RadioButton ID="rbtnOther" runat="server" Text="Other" />
                                        &nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div id="product">
                                    <p></p>


                                    <div class="form-group box-info-product">
                                        <div class="cart">
                                            <input type="button" data-toggle="tooltip" title="" value="Submit" data-loading-text="Loading..." id="button-cart" class="btn btn-mega btn-lg" data-original-title="Submit">
                                        </div>
                                        <div class="add-to-links wish_comp">
                                            <ul class="blank list-inline">
                                                <li class="wishlist">
                                                    <a class="icon" data-toggle="tooltip" title=""
                                                        onclick="wishlist.add('50');" data-original-title="Add to Wish List"><i class="fa fa-heart"></i>
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>

                                    </div>






                                </div>
                            </div>
                        </div>
                    </div>

                    <section class="col-lg-2 hidden-sm hidden-md hidden-xs slider-products">
                        <div class="module col-sm-12 four-block">
                            <div class="modcontent clearfix">
                                <div class="policy-detail">
                                    <div class="banner-policy">
                                        <div class="policy policy1">
                                            <a href="#"><span class="ico-policy">&nbsp;</span>	90 day
											<br>
                                                money back </a>
                                        </div>
                                        <div class="policy policy2">
                                            <a href="#"><span class="ico-policy">&nbsp;</span>	In-store exchange </a>
                                        </div>
                                        <div class="policy policy3">
                                            <a href="#"><span class="ico-policy">&nbsp;</span>	lowest price guarantee </a>
                                        </div>
                                        <div class="policy policy4">
                                            <a href="#"><span class="ico-policy">&nbsp;</span>	shopping guarantee </a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>

                <!-- Product Tabs -->
                <div class="producttab ">
                    <div class="tabsslider  vertical-tabs col-xs-12">
                        <ul class="nav nav-tabs col-lg-2 col-sm-3">
                            <li class="active"><a data-toggle="tab" href="#tab-1">Description</a></li>
                            <li class="item_nonactive"><a data-toggle="tab" href="#tab-review">Reviews (1)</a></li>
                            <li class="item_nonactive"><a data-toggle="tab" href="#tab-4">Tags</a></li>
                            <li class="item_nonactive"><a data-toggle="tab" href="#tab-5">Custom Tab</a></li>
                        </ul>
                        <div class="tab-content col-lg-10 col-sm-9 col-xs-12">
                            <div id="tab-1" class="tab-pane fade active in">
                                <p>
                                    The 30-inch Apple Cinema HD Display delivers an amazing 2560 x 1600 pixel resolution. Designed specifically for the creative professional, this display provides more space for easier access to all the tools and palettes needed to edit, format and composite your work. Combine this display with a Mac Pro, MacBook Pro, or PowerMac G5 and there's no limit to what you can achieve.
                                    <br>
                                    <br>
                                    The Cinema HD features an active-matrix liquid crystal display that produces flicker-free images that deliver twice the brightness, twice the sharpness and twice the contrast ratio of a typical CRT display. Unlike other flat panels, it's designed with a pure digital interface to deliver distortion-free images that never need adjusting. With over 4 million digital pixels, the display is uniquely suited for scientific and technical applications such as visualizing molecular structures or analyzing geological data.
                                    <br>
                                    <br>
                                    Offering accurate, brilliant color performance, the Cinema HD delivers up to 16.7 million colors across a wide gamut allowing you to see subtle nuances between colors from soft pastels to rich jewel tones. A wide viewing angle ensures uniform color from edge to edge. Apple's ColorSync technology allows you to create custom profiles to maintain consistent color onscreen and in print. The result: You can confidently use this display in all your color-critical applications.
                                    <br>
                                    <br>
                                    Housed in a new aluminum design, the display has a very thin bezel that enhances visual accuracy. Each display features two FireWire 400 ports and two USB 2.0 ports, making attachment of desktop peripherals, such as iSight, iPod, digital and still cameras, hard drives, printers and scanners, even more accessible and convenient. Taking advantage of the much thinner and lighter footprint of an LCD, the new displays support the VESA (Video Electronics Standards Association) mounting interface standard. Customers with the optional Cinema Display VESA Mount Adapter kit gain the flexibility to mount their display in locations most appropriate for their work environment.
                                    <br>
                                    <br>
                                    The Cinema HD features a single cable design with elegant breakout for the USB 2.0, FireWire 400 and a pure digital connection using the industry standard Digital Video Interface (DVI) interface. The DVI connection allows for a direct pure-digital connection.<br>
                                </p>
                                <h3>Features:</h3>
                                <p>
                                    Unrivaled display performance
                                </p>
                                <ul>
                                    <li>30-inch (viewable) active-matrix liquid crystal display provides breathtaking image quality and vivid, richly saturated color.</li>
                                    <li>Support for 2560-by-1600 pixel resolution for display of high definition still and video imagery.</li>
                                    <li>Wide-format design for simultaneous display of two full pages of text and graphics.</li>
                                    <li>Industry standard DVI connector for direct attachment to Mac- and Windows-based desktops and notebooks</li>
                                    <li>Incredibly wide (170 degree) horizontal and vertical viewing angle for maximum visibility and color performance.</li>
                                    <li>Lightning-fast pixel response for full-motion digital video playback.</li>
                                    <li>Support for 16.7 million saturated colors, for use in all graphics-intensive applications.</li>
                                </ul>
                                <p>
                                    Simple setup and operation
                                </p>
                                <ul>
                                    <li>Single cable with elegant breakout for connection to DVI, USB and FireWire ports</li>
                                    <li>Built-in two-port USB 2.0 hub for easy connection of desktop peripheral devices.</li>
                                    <li>Two FireWire 400 ports to support iSight and other desktop peripherals</li>
                                </ul>
                                <p>
                                    Sleek, elegant design
                                </p>
                                <ul>
                                    <li>Huge virtual workspace, very small footprint.</li>
                                    <li>Narrow Bezel design to minimize visual impact of using dual displays</li>
                                    <li>Unique hinge design for effortless adjustment</li>
                                    <li>Support for VESA mounting solutions (Apple Cinema Display VESA Mount Adapter sold separately)</li>
                                </ul>
                                <h3>Technical specifications</h3>
                                <p>
                                    <b>Screen size (diagonal viewable image size)</b>
                                </p>
                                <ul>
                                    <li>Apple Cinema HD Display: 30 inches (29.7-inch viewable)</li>
                                </ul>
                                <p>
                                    <b>Screen type</b>
                                </p>
                                <ul>
                                    <li>Thin film transistor (TFT) active-matrix liquid crystal display (AMLCD)</li>
                                </ul>
                                <p>
                                    <b>Resolutions</b>
                                </p>
                                <ul>
                                    <li>2560 x 1600 pixels (optimum resolution)</li>
                                    <li>2048 x 1280</li>
                                    <li>1920 x 1200</li>
                                    <li>1280 x 800</li>
                                    <li>1024 x 640</li>
                                </ul>
                                <p>
                                    <b>Display colors (maximum)</b>
                                </p>
                                <ul>
                                    <li>16.7 million</li>
                                </ul>
                                <p>
                                    <b>Viewing angle (typical)</b>
                                </p>
                                <ul>
                                    <li>170° horizontal; 170° vertical</li>
                                </ul>
                                <p>
                                    <b>Brightness (typical)</b>
                                </p>
                                <ul>
                                    <li>30-inch Cinema HD Display: 400 cd/m2</li>
                                </ul>
                                <p>
                                    <b>Contrast ratio (typical)</b>
                                </p>
                                <ul>
                                    <li>700:1</li>
                                </ul>
                                <p>
                                    <b>Response time (typical)</b>
                                </p>
                                <ul>
                                    <li>16 ms</li>
                                </ul>
                                <p>
                                    <b>Pixel pitch</b>
                                </p>
                                <ul>
                                    <li>30-inch Cinema HD Display: 0.250 mm</li>
                                </ul>
                                <p>
                                    <b>Screen treatment</b>
                                </p>
                                <ul>
                                    <li>Antiglare hardcoat</li>
                                </ul>
                                <p>
                                    <b>User controls (hardware and software)</b>
                                </p>
                                <ul>
                                    <li>Display Power,</li>
                                    <li>System sleep, wake</li>
                                    <li>Brightness</li>
                                    <li>Monitor tilt</li>
                                </ul>
                                <p>
                                    <b>Connectors and cables</b><br>
                                    Cable
                                </p>
                                <ul>
                                    <li>DVI (Digital Visual Interface)</li>
                                    <li>FireWire 400</li>
                                    <li>USB 2.0</li>
                                    <li>DC power (24 V)</li>
                                </ul>
                                <p>
                                    Connectors
                                </p>
                                <ul>
                                    <li>Two-port, self-powered USB 2.0 hub</li>
                                    <li>Two FireWire 400 ports</li>
                                    <li>Kensington security port</li>
                                </ul>
                                <p>
                                    <b>VESA mount adapter</b><br>
                                    Requires optional Cinema Display VESA Mount Adapter (M9649G/A)
                                </p>
                                <ul>
                                    <li>Compatible with VESA FDMI (MIS-D, 100, C) compliant mounting solutions</li>
                                </ul>
                                <p>
                                    <b>Electrical requirements</b>
                                </p>
                                <ul>
                                    <li>Input voltage: 100-240 VAC 50-60Hz</li>
                                    <li>Maximum power when operating: 150W</li>
                                    <li>Energy saver mode: 3W or less</li>
                                </ul>
                                <p>
                                    <b>Environmental requirements</b>
                                </p>
                                <ul>
                                    <li>Operating temperature: 50° to 95° F (10° to 35° C)</li>
                                    <li>Storage temperature: -40° to 116° F (-40° to 47° C)</li>
                                    <li>Operating humidity: 20% to 80% noncondensing</li>
                                    <li>Maximum operating altitude: 10,000 feet</li>
                                </ul>
                                <p>
                                    <b>Agency approvals</b>
                                </p>
                                <ul>
                                    <li>FCC Part 15 Class B</li>
                                    <li>EN55022 Class B</li>
                                    <li>EN55024</li>
                                    <li>VCCI Class B</li>
                                    <li>AS/NZS 3548 Class B</li>
                                    <li>CNS 13438 Class B</li>
                                    <li>ICES-003 Class B</li>
                                    <li>ISO 13406 part 2</li>
                                    <li>MPR II</li>
                                    <li>IEC 60950</li>
                                    <li>UL 60950</li>
                                    <li>CSA 60950</li>
                                    <li>EN60950</li>
                                    <li>ENERGY STAR</li>
                                    <li>TCO '03</li>
                                </ul>
                                <p>
                                    <b>Size and weight</b><br>
                                    30-inch Apple Cinema HD Display
                                </p>
                                <ul>
                                    <li>Height: 21.3 inches (54.3 cm)</li>
                                    <li>Width: 27.2 inches (68.8 cm)</li>
                                    <li>Depth: 8.46 inches (21.5 cm)</li>
                                    <li>Weight: 27.5 pounds (12.5 kg)</li>
                                </ul>
                                <p>
                                    <b>System Requirements</b>
                                </p>
                                <ul>
                                    <li>Mac Pro, all graphic options</li>
                                    <li>MacBook Pro</li>
                                    <li>Power Mac G5 (PCI-X) with ATI Radeon 9650 or better or NVIDIA GeForce 6800 GT DDL or better</li>
                                    <li>Power Mac G5 (PCI Express), all graphics options</li>
                                    <li>PowerBook G4 with dual-link DVI support</li>
                                    <li>Windows PC and graphics card that supports DVI ports with dual-link digital bandwidth and VESA DDC standard for plug-and-play setup</li>
                                </ul>


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
                                <h3 class="custom-color">Take a trivial example which of us ever undertakes</h3>
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
                                <ul class="marker-simple-list two-columns">
                                    <li>Nam liberempore</li>
                                    <li>Cumsoluta nobisest</li>
                                    <li>Eligendptio cumque</li>
                                    <li>Nam liberempore</li>
                                    <li>Cumsoluta nobisest</li>
                                    <li>Eligendptio cumque</li>
                                </ul>
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

                <!-- Related Products -->
                <div class="related titleLine products-list grid module ">
                    <h3 class="modtitle">Related Products  </h3>
                    <div class="releate-products ">
                        <div class="product-layout">
                            <div class="product-item-container">
                                <div class="left-block">
                                    <div class="product-image-container second_img ">
                                        <img src="image/demo/shop/product/e11.jpg" title="Apple Cinema 30&quot;" class="img-responsive" />
                                        <img src="image/demo/shop/product/e12.jpg" title="Apple Cinema 30&quot;" class="img_0 img-responsive" />
                                    </div>
                                    <!--Sale Label-->
                                    <span class="label label-sale">Sale</span>
                                    <!--full quick view block-->
                                    <a class="quickview iframe-link visible-lg" data-fancybox-type="iframe" href="quickview.html">Quickview</a>
                                    <!--end full quick view block-->
                                </div>


                                <div class="right-block">
                                    <div class="caption">
                                        <h4><a href="product.html">Apple Cinema 30&quot;</a></h4>
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
                                            <span class="price-new">$74.00</span>
                                            <span class="price-old">$122.00</span>
                                            <span class="label label-percent">-40%</span>
                                        </div>
                                        <div class="description item-desc hidden">
                                            <p>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut l..</p>
                                        </div>
                                    </div>

                                    <div class="button-group">
                                        <button class="addToCart" type="button" data-toggle="tooltip" title="Add to Cart" onclick="cart.add('42', '1');"><i class="fa fa-shopping-cart"></i><span class="hidden-xs">Add to Cart</span></button>
                                        <button class="wishlist" type="button" data-toggle="tooltip" title="Add to Wish List" onclick="wishlist.add('42');"><i class="fa fa-heart"></i></button>
                                        <button class="compare" type="button" data-toggle="tooltip" title="Compare this Product" onclick="compare.add('42');"><i class="fa fa-exchange"></i></button>
                                    </div>
                                </div>
                                <!-- right block -->

                            </div>
                        </div>
                        <div class="product-layout ">
                            <div class="product-item-container">
                                <div class="left-block">
                                    <div class="product-image-container second_img ">
                                        <img src="image/demo/shop/product/11.jpg" title="Apple Cinema 30&quot;" class="img-responsive" />
                                        <img src="image/demo/shop/product/10.jpg" title="Apple Cinema 30&quot;" class="img_0 img-responsive" />

                                    </div>
                                    <!--Sale Label-->
                                    <span class="label label-sale">Sale</span>
                                    <!--full quick view block-->
                                    <a class="quickview iframe-link visible-lg" data-fancybox-type="iframe" href="quickview.html">Quickview</a>
                                    <!--end full quick view block-->
                                </div>


                                <div class="right-block">
                                    <div class="caption">
                                        <h4><a href="product.html">Apple Cinema 30&quot;</a></h4>
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
                                            <span class="price-new">$74.00</span>
                                            <span class="price-old">$122.00</span>
                                            <span class="label label-percent">-40%</span>
                                        </div>
                                        <div class="description item-desc hidden">
                                            <p>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut l..</p>
                                        </div>
                                    </div>

                                    <div class="button-group">
                                        <button class="addToCart" type="button" data-toggle="tooltip" title="Add to Cart" onclick="cart.add('42', '1');"><i class="fa fa-shopping-cart"></i><span class="hidden-xs">Add to Cart</span></button>
                                        <button class="wishlist" type="button" data-toggle="tooltip" title="Add to Wish List" onclick="wishlist.add('42');"><i class="fa fa-heart"></i></button>
                                        <button class="compare" type="button" data-toggle="tooltip" title="Compare this Product" onclick="compare.add('42');"><i class="fa fa-exchange"></i></button>
                                    </div>
                                </div>
                                <!-- right block -->

                            </div>
                        </div>
                        <div class="product-layout ">
                            <div class="product-item-container">
                                <div class="left-block">
                                    <div class="product-image-container second_img ">
                                        <img src="image/demo/shop/product/35.jpg" title="Apple Cinema 30&quot;" class="img-responsive" />
                                        <img src="image/demo/shop/product/34.jpg" title="Apple Cinema 30&quot;" class="img_0 img-responsive" />
                                    </div>
                                    <!--Sale Label-->
                                    <span class="label label-sale">Sale</span>
                                    <!--full quick view block-->
                                    <a class="quickview iframe-link visible-lg" data-fancybox-type="iframe" href="quickview.html">Quickview</a>
                                    <!--end full quick view block-->
                                </div>


                                <div class="right-block">
                                    <div class="caption">
                                        <h4><a href="product.html">Apple Cinema 30&quot;</a></h4>
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
                                            <span class="price-new">$74.00</span>
                                            <span class="price-old">$122.00</span>
                                            <span class="label label-percent">-40%</span>
                                        </div>
                                        <div class="description item-desc hidden">
                                            <p>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut l..</p>
                                        </div>
                                    </div>

                                    <div class="button-group">
                                        <button class="addToCart" type="button" data-toggle="tooltip" title="Add to Cart" onclick="cart.add('42', '1');"><i class="fa fa-shopping-cart"></i><span class="hidden-xs">Add to Cart</span></button>
                                        <button class="wishlist" type="button" data-toggle="tooltip" title="Add to Wish List" onclick="wishlist.add('42');"><i class="fa fa-heart"></i></button>
                                        <button class="compare" type="button" data-toggle="tooltip" title="Compare this Product" onclick="compare.add('42');"><i class="fa fa-exchange"></i></button>
                                    </div>
                                </div>
                                <!-- right block -->

                            </div>
                        </div>
                        <div class="product-layout ">
                            <div class="product-item-container">
                                <div class="left-block">
                                    <div class="product-image-container second_img ">
                                        <img src="image/demo/shop/product/14.jpg" title="Apple Cinema 30&quot;" class="img-responsive" />
                                        <img src="image/demo/shop/product/15.jpg" title="Apple Cinema 30&quot;" class="img_0 img-responsive" />
                                    </div>
                                    <!--Sale Label-->
                                    <span class="label label-sale">Sale</span>
                                    <!--full quick view block-->
                                    <a class="quickview iframe-link visible-lg" data-fancybox-type="iframe" href="quickview.html">Quickview</a>
                                    <!--end full quick view block-->
                                </div>


                                <div class="right-block">
                                    <div class="caption">
                                        <h4><a href="product.html">Apple Cinema 30&quot;</a></h4>
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
                                            <span class="price-new">$74.00</span>
                                            <span class="price-old">$122.00</span>
                                            <span class="label label-percent">-40%</span>
                                        </div>
                                        <div class="description item-desc hidden">
                                            <p>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut l..</p>
                                        </div>
                                    </div>

                                    <div class="button-group">
                                        <button class="addToCart" type="button" data-toggle="tooltip" title="Add to Cart" onclick="cart.add('42', '1');"><i class="fa fa-shopping-cart"></i><span class="hidden-xs">Add to Cart</span></button>
                                        <button class="wishlist" type="button" data-toggle="tooltip" title="Add to Wish List" onclick="wishlist.add('42');"><i class="fa fa-heart"></i></button>
                                        <button class="compare" type="button" data-toggle="tooltip" title="Compare this Product" onclick="compare.add('42');"><i class="fa fa-exchange"></i></button>
                                    </div>
                                </div>
                                <!-- right block -->

                            </div>
                        </div>
                    </div>
                </div>

                <!-- end Related  Products-->


            </div>


        </div>
        <!--Middle Part End-->
    </div>
    <!-- //Main Container -->
</asp:Content>

