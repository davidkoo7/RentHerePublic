<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
<!-- Navbar switcher -->
<!-- //end Navbar switcher -->
	</header>
	<!-- //Header Container  -->
	<!-- Main Container  -->
	<div class="main-container container">
		<ul class="breadcrumb">
			<li><a href="#"><i class="fa fa-home"></i></a></li>
			<li><a href="#">Page</a></li>
			<li><a href="#">Contact us</a></li>			
		</ul>
		
		<div class="row">
			<div id="content" class="col-sm-12">
				<div class="page-title">
					<h2>Contact Us</h2>
				</div>
				
				
				<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d2586.4240922931103!2d103.82612365256416!3d1.287370370514294!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xf0cc7e9c37d34d23!2sPSB!5e0!3m2!1sen!2ssg!4v1498767833222" width="100%" height="350" frameborder="0" style="border:0" allowfullscreen></iframe>
				<div class="info-contact clearfix">
					<div class="col-lg-4 col-sm-4 col-xs-12 info-store">
						<div class="row">
							<div class="name-store">
								<h3>Your Store</h3>
							</div>
							<address>
								<div class="address clearfix form-group">
									<div class="icon">
										<i class="fa fa-home"></i>
									</div>
									<div class="text">355 Jalan Bukit Ho Swee, 169567</div>
								</div>
								<div class="phone form-group">
									<div class="icon">
										<i class="fa fa-phone"></i>
									</div>
									<div class="text">Phone : 98437047</div>
								</div>
								<div class="comment">             
								Description about RentHere heree
								</div>
							</address>
						</div>
					</div>
					<div class="col-lg-8 col-sm-8 col-xs-12 contact-form">
						<form action="" method="post" enctype="multipart/form-data" class="form-horizontal">
							<fieldset>
								<legend>Contact Form</legend>
								<div class="form-group required">
							<label class="col-sm-2 control-label" for="input-name">Your Name</label>
							<div class="col-sm-10">
								<input type="text" name="name" value="" id="input-name" class="form-control">
								</div>
							</div>
							<div class="form-group required">
								<label class="col-sm-2 control-label" for="input-email">E-Mail Address</label>
								<div class="col-sm-10">
									<input type="text" name="email" value="" id="input-email" class="form-control">
									</div>
								</div>
								<div class="form-group required">
									<label class="col-sm-2 control-label" for="input-enquiry">Enquiry</label>
									<div class="col-sm-10">
										<textarea name="enquiry" rows="10" id="input-enquiry" class="form-control"></textarea>
									</div>
								</div>
							</fieldset>
							<div class="buttons">
								<div class="pull-right">
									<button class="btn btn-default buttonGray" type="submit">
										<span>Submit</span>
									</button>
								</div>
							</div>
						</form>
					</div>
				</div>
			</div>
		</div>
	</div>
	<!-- //Main Container -->



</asp:Content>

