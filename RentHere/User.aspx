<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="main-container container">
		<ul class="breadcrumb">
			<li><a href="#"><i class="fa fa-home"></i></a></li>
			<li><a href="#">Member Profile </a></li>
		</ul>
		
		<div class="row">
			
			<!--Middle Part Start-->
			<div id="content" class="col-md-12 col-sm-12">
				<h3 class="offset_title">Member Profile</h3>
				<div class="products-category">
					<div class="category-derc form-group">
						<div class="row">
							<div class="col-sm-4"><img src="image/demo/shop/category/smartphone-tablets.jpg" alt="Apple Cinema 30&quot;"></div>
							<div class="col-sm-8">
								<p>Mauris accumsan nulla vel diam. Sed in lacus ut enim adipiscing aliquet. Nulla venenatis. In pede mi, aliquet sit amet, euismod in, auctor ut, ligula. Aliquam dapibus tincidunt metus. Praesent justo dolor, lobortis quis, lobortis dignissim, pulvinar ac, lorem. Vestibulum sed ante. Donec sagittis euismod purus. Sed ut perspiciatis sit voluptatem accusantium doloremque laudantium. Vestibulum iaculis lacinia est. Proin dictum elementum velit. Fusce euismod consequat ante. </p>

								<p>Lorem ipsum dolor sit amet, consectetuer adipisMauris accumsan nulla vel diam. Sed in lacus ut enim adipiscing aliquet. Nulla venenatis. In pede mi, aliquet sit amet, euismod in,auctor ut, ligula. Aliquam dapibus tincidunt metus. Praesent justo dolor, lobortis quis, lobortis dignissim, pulvinar ac, lorem. </p>

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
										<button class="btn btn-default grid active " data-view="grid" data-toggle="tooltip"  data-original-title="Grid"><i class="fa fa-th"></i></button>
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
							<div class="box-pagination col-md-3 col-sm-4 col-xs-12 text-right">
								<ul class="pagination">
									<li class="active"><span>1</span></li>
									<li><a href="#">2</a></li><li><a href="">&gt;</a></li>
									<li><a href="#">&gt;|</a></li>
								</ul>
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
                                                <a href="ProductDetails.aspx?itemID=<%#Eval("itemID") %>" ><button class="addToCart" type="button" data-toggle="tooltip" title="View Information"><i class="fa fa-shopping-cart"></i><span class="">View	 Information</span></button></a>
                                            </div>
                                        </div>
                                        <!-- right block -->

                                    </div>
                                </div>
                                <div class="clearfix visible-sm-block"></div>
                                <div class="clearfix visible-xs-block"></div>
                            </ItemTemplate>
                        </asp:Repeater>
	
</div>					<!--// End Changed listings-->
					<!-- Filters -->
					<div class="product-filter product-filter-bottom filters-panel" >
						<div class="row">
							<div class="col-md-2 hidden-sm hidden-xs">
								
							</div>
						   <div class="short-by-show text-center col-md-7 col-sm-8 col-xs-12">
								<div class="form-group" style="margin: 7px 10px">Showing 1 to 9 of 10 (2 Pages)</div>
							</div>
							<div class="box-pagination col-md-3 col-sm-4 text-right"><ul class="pagination"><li class="active"><span>1</span></li><li><a href="http://localhost/ytc_templates/opencart/so_market/index.html?route=product/category&amp;path=33&amp;page=2">2</a></li><li><a href="http://localhost/ytc_templates/opencart/so_market/index.html?route=product/category&amp;path=33&amp;page=2">&gt;</a></li><li><a href="http://localhost/ytc_templates/opencart/so_market/index.html?route=product/category&amp;path=33&amp;page=2">&gt;|</a></li></ul></div>
									
						 </div>
					</div>
					<!-- //end Filters -->
					
				</div>
				
			</div>
			
			
			
		</div>
		<!--Middle Part End-->
	</div>
	<!-- //Main Container -->

</asp:Content>

