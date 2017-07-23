<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ItemRental.aspx.cs" Inherits="ItemRental" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    	<link rel="stylesheet" href="dist/hotel-datepicker.css">
	
		<script type="text/javascript" src="dist/fecha.min.js"></script>
	    <script type="text/javascript" src="dist/hotel-datepicker.js"></script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    	<div class="main-container container">
		<ul class="breadcrumb">
			<li><a href="#"><i class="fa fa-home"></i></a></li>
			<li><a href="#">Checkout</a></li>
			
		</ul>
		
		<div class="row">
			<!--Middle Part Start-->
			<div id="content" class="col-lg-12">
			  <h2 class="title">Checkout</h2>
			  <div class="so-onepagecheckout ">
				
				
				
				<div class="col-lg-12">
				  <div class="row">
					<div class="col-sm-12">
						<div class="panel panel-default no-padding">
							<div class="col-sm-6 checkout-shipping-methods">
								<div class="panel-heading">
								  <h4 class="panel-title"><i class="fa fa-quotes"></i> Personal Info</h4>
								</div>
					  <div class="panel-body">
							<fieldset id="account">
							  <div class="form-group required">
								<label for="input-payment-firstname" class="control-label">Full Name</label>
								<input type="text" class="form-control" id="input-payment-firstname" placeholder="Full Name" value="" name="firstname">
							  </div>
							  <div class="form-group required">
								<label for="input-payment-email" class="control-label">E-mail</label>
								<input type="text" class="form-control" id="input-payment-email" placeholder="E-mail" value="" name="email">
							  </div>
							  <div class="form-group required">
								<label for="input-payment-telephone" class="control-label">Mobile Number</label>
								<input type="text" class="form-control" id="input-payment-telephone" placeholder="Mobile Number" value="" name="telephone">
							  </div>
							</fieldset>
						  </div>
							</div>
							<div class="col-sm-6  checkout-payment-methods">
								<div class="panel-heading">
								  <h4 class="panel-title"><i class="fa fa-truck"></i> Delivery Info</h4>
								</div>
					  <div class="panel-body">
							<fieldset id="address" class="required">
							  <div class="form-group required">
								<label for="input-payment-address-1" class="control-label">Address 1</label>
								<input type="text" class="form-control" id="input-payment-address-1" placeholder="Address 1">
							  </div>
							  <div class="form-group required">
								<label for="input-payment-address-2" class="control-label">IC Number</label>
								<input type="text" class="form-control" id="input-payment-address-2" placeholder="IC Number">
							  </div>
							  <div class="form-group required">
								<label for="input-payment-city" class="control-label">City</label>
								<input type="text" class="form-control" id="input-payment-city" placeholder="City" value="" name="city">
							  </div>
							  <div class="form-group required">
								<label for="input-payment-postcode" class="control-label">Post Code</label>
								<input type="text" class="form-control" id="input-payment-postcode" placeholder="Post Code" value="" name="postcode">
							  </div>

							  <div class="checkbox">
								<label>
								  <input type="checkbox" checked="checked" value="1" name="shipping_address">
								  My delivery and billing addresses are the same.</label>
							  </div>
							</fieldset>
						  </div>
							</div>
						</div>
						
						
							
						</div>
					
					
					
					
					<div class="col-sm-12">
					  <div class="panel panel-default">
						<div class="panel-heading">
						  <h4 class="panel-title"><i class="fa fa-shopping-cart"></i> Shopping cart</h4>
						</div>
						  <div class="panel-body">
							<div class="table-responsive">
							  <table class="table table-bordered">
								<thead>
								  <tr>
								  
								  
								  
								  									<td class="text-center"></td>
									<td class="text-center">Image</td>
									<td class="text-left">Product Name</td>
									<td class="text-left">Rental Period</td>
									<td class="text-left">Rental Rate</td>

									<td class="text-left">Deposit Amount</td>
									<td class="text-right">Total</td>
								  </tr>
								</thead>
								<tbody>
								  <tr>
								  	<td class="text-center"><p></p><button type="button" data-toggle="tooltip" title="Remove" class="btn btn-danger" onClick=""><i class="fa fa-times-circle"></i></button></td>

									<td class="text-center"><a href="product.html"><img width="60px" src="image/demo/shop/product/E4.jpg" alt="Xitefun Causal Wear Fancy Shoes" title="Xitefun Causal Wear Fancy Shoes" class="img-thumbnail"></a></td>
									<td class="text-left"><a href="product.html">Emasa rumas gacem</a></td>
									<td class="text-left"><div class="input-group btn-block" style="min-width: 100px;">
									
		<form method="POST" action="checkout.html">

        <input style="table-layout:fixed;" type="text" name="input-id" id="input-id" value="" class="form-control">

        </form>

										
										
										<span class="input-group-btn">
										<button type="submit" data-toggle="tooltip" title="Update" class="btn btn-primary"><i class="fa fa-refresh"></i></button>
										</span></div></td>
									<td class="text-right">$114.35</td>
									<td class="text-right">$114.35</td>
									<td class="text-right">$114.35</td>									
								  </tr>
								  

								  
								  
								</tbody>
								<tfoot>
								  <tr>
									<td class="text-right" colspan="1"><strong>Meeting Location:</strong></td>
									<td class="text-left" colspan="6">$93.73</td>
									
								  </tr>
								  <tr>
									<td class="text-right" colspan="6"><strong>Total Amount Payable:</strong></td>
									<td class="text-right">$121.85</td>
								  </tr>
								</tfoot>
							  </table>
							  							<label class="control-label" for="confirm_agree">
							  <input type="checkbox" checked="checked" value="1" required="" class="validate required" id="confirm_agree" name="confirm agree">
							  <span>I have read and agree to the <a class="agree" href="#"><b>Terms &amp; Conditions</b></a></span> </label>
							<div class="buttons">
							  <div class="pull-right">
								<input type="button" class="btn btn-primary" id="button-confirm" value="Confirm Order">
							  </div>
							</div>
							</div>
						  </div>
					  </div>
					</div>
				  </div>
				</div>
			  </div>
			</div>
			<!--Middle Part End -->
			
		</div>
	</div>
	<!-- //Main Container -->

    	<script type="text/javascript">
		(function() {
			// ------------------- DEMO 1 ------------------- //

			var today = new Date();
			var tomorrow = new Date();
			tomorrow.setDate(tomorrow.getDate() + 1);
			var input1 = document.getElementById('input-id');
			input1.value = fecha.format(today, 'YYYY-MM-DD') + ' - ' + fecha.format(tomorrow, 'YYYY-MM-DD');

			var demo1 = 
			
			new HotelDatepicker(document.getElementById('input-id'), {
				disabledDates: [
					'2017-07-13', '2017-07-18'
				]
			});
		})();
</script>	
</asp:Content>

