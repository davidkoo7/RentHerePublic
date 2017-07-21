<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageTest.aspx.cs" Inherits="MessageTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <link href="http://netdna.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet">
    <style type="text/css">
    	
body{margin-top:20px;}


/* Component: Chat */
.chat .chat-wrapper .chat-list-wrapper {
  border: 1px solid #ddd;
  height: 510px;
  overflow-y: auto;
}
.chat .chat-wrapper .chat-list-wrapper .chat-list {
  padding: 0;
}
.chat .chat-wrapper .chat-list-wrapper .chat-list li {
  display: block;
  padding: 20px 10px;
  clear: both;
  cursor: pointer;
  border-bottom: 1px solid #ddd;
  -webkit-transition: all 0.2s ease-in-out;
  -moz-transition: all 0.2s ease-in-out;
  -ms-transition: all 0.2s ease-in-out;
  -o-transition: all 0.2s ease-in-out;
  transition: all 0.2s ease-in-out;
}
.chat .chat-wrapper .chat-list-wrapper .chat-list li .avatar {
  margin-right: 12px;
  float: left;
}
.chat .chat-wrapper .chat-list-wrapper .chat-list li .avatar img {
  width: 60px;
  height: auto;
  border: 4px solid transparent;
}
.chat .chat-wrapper .chat-list-wrapper .chat-list li .avatar.available img {
  border-color: #2ecc71;
}
.chat .chat-wrapper .chat-list-wrapper .chat-list li .avatar.busy img {
  border-color: #ff530d;
}
.chat .chat-wrapper .chat-list-wrapper .chat-list li .body .header {
  margin-top: 4px;
  margin-bottom: 4px;
}
.chat .chat-wrapper .chat-list-wrapper .chat-list li .body .header .username {
  font-weight: bold;
}
.chat .chat-wrapper .chat-list-wrapper .chat-list li .body .header .timestamp {
  float: right;
  color: #999;
  font-size: 11px;
  line-height: 18px;
  font-style: italic;
}
.chat .chat-wrapper .chat-list-wrapper .chat-list li .body .header .timestamp i {
  margin-right: 4px;
}
.chat .chat-wrapper .chat-list-wrapper .chat-list li .body p {
  font-size: 12px;
  line-height: 16px;
  max-height: 32px;
  overflow: hidden;
}
.chat .chat-wrapper .chat-list-wrapper .chat-list li:hover {
  background-color: #f4f4f4;
}
.chat .chat-wrapper .chat-list-wrapper .chat-list li.active {
  background-color: #eee;
  color: black;
}
.chat .chat-wrapper .chat-list-wrapper .chat-list li.active .body .timestamp {
  color: black;
}
.chat .chat-wrapper .chat-list-wrapper .chat-list li.new {
  border-left: 2px solid #2ecc71;
}
.chat .chat-wrapper .message-list-wrapper {
  border: 1px solid #ddd;
  height: 452px;
  position: relative;
  overflow-y: auto;
}
.chat .chat-wrapper .message-list-wrapper .message-list {
  padding: 0;
}
.chat .chat-wrapper .message-list-wrapper .message-list li {
  display: block;
  padding: 20px 10px;
  clear: both;
  position: relative;
  color: white;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.left .avatar {
  margin-right: 12px;
  display: block;
  float: left;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.left .avatar img {
  width: 60px;
  height: auto;
  border: 2px solid transparent;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.left .avatar.available img {
  border-color: #2ecc71;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.left .avatar.busy img {
  border-color: #ff530d;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.left .username {
  float: left;
  display: none;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.left .timestamp {
  text-align: left;
  display: block;
  color: #999;
  font-size: 11px;
  line-height: 18px;
  font-style: italic;
  margin-bottom: 4px;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.left .timestamp i {
  margin-right: 4px;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.left .body {
  display: block;
  width: 87%;
  float: left;
  position: relative;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.left .body .message {
  font-size: 12px;
  line-height: 16px;
  display: inline-block;
  width: auto;
  background: #2ecc71;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.left .body .message:before {
  content: '';
  display: block;
  position: absolute;
  width: 0;
  height: 0;
  border-style: solid;
  border-width: 9px 9px 9px 0;
  border-color: transparent #2ecc71 transparent transparent;
  left: 0;
  top: 10px;
  margin-left: -8px;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.left .body .message a.white {
  color: white;
  font-weight: bolder;
  text-decoration: underline;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.left .body .message img {
  max-width: 320px;
  max-height: 320px;
  width: 100%;
  height: auto;
  margin-bottom: 5px;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.right .avatar {
  margin-left: 12px;
  display: block;
  float: right;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.right .avatar img {
  width: 60px;
  height: auto;
  border: 2px solid transparent;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.right .avatar.available img {
  border-color: #2ecc71;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.right .avatar.busy img {
  border-color: #ff530d;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.right .username {
  float: right;
  display: none;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.right .timestamp {
  text-align: right;
  display: block;
  color: #999;
  font-size: 11px;
  line-height: 18px;
  font-style: italic;
  margin-bottom: 4px;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.right .timestamp i {
  margin-right: 4px;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.right .body {
  display: block;
  width: 87%;
  float: right;
  position: relative;
  text-align: right;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.right .body .message {
  font-size: 12px;
  line-height: 16px;
  display: inline-block;
  width: auto;
  background: #3498db;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.right .body .message:after {
  content: '';
  display: block;
  position: absolute;
  width: 0;
  height: 0;
  border-style: solid;
  border-width: 9px 9px 9px 0;
  border-color: transparent #3498db transparent transparent;
  right: 0;
  top: 10px;
  margin-right: -7px;
  -moz-transform: rotate(180deg);
  -o-transform: rotate(180deg);
  -webkit-transform: rotate(180deg);
  -ms-transform: rotate(180deg);
  transform: rotate(180deg);
}
.chat .chat-wrapper .message-list-wrapper .message-list li.right .body .message a.white {
  color: white;
  font-weight: bold;
}
.chat .chat-wrapper .message-list-wrapper .message-list li.right .body .message img {
  max-width: 320px;
  max-height: 320px;
  width: 100%;
  height: auto;
  margin-bottom: 5px;
}
.chat .chat-wrapper .compose-area {
  padding: 10px 0;
  text-align: right;
}
.chat .chat-wrapper .compose-box {
  padding: 10px 0;
}
.chat .chat-wrapper .recipient-box {
  padding: 10px 0;
}
.chat .chat-wrapper .recipient-box .bootstrap-tagsinput {
  display: block;
  width: 100%;
  margin-bottom: 0;
}
@media (max-width: 767px) {
  .chat .chat-wrapper .chat-list-wrapper {
    border: 1px solid #ddd;
    height: 300px;
    overflow-y: auto;
  }
  .chat .chat-wrapper .chat-list-wrapper .chat-list {
    padding: 0;
  }
  .chat .chat-wrapper .chat-list-wrapper .chat-list li {
    display: block;
    padding: 20px 10px;
    clear: both;
    border-bottom: 1px solid #ddd;
  }
  .chat .chat-wrapper .chat-list-wrapper .chat-list li .avatar {
    display: none;
  }
  .chat .chat-wrapper .chat-list-wrapper .chat-list li .body .header {
    margin-top: 4px;
    margin-bottom: 4px;
  }
  .chat .chat-wrapper .chat-list-wrapper .chat-list li .body .header .username {
    font-weight: bold;
  }
  .chat .chat-wrapper .chat-list-wrapper .chat-list li .body .header .timestamp {
    float: right;
    color: #999;
    font-size: 11px;
    line-height: 18px;
    font-style: italic;
  }
  .chat .chat-wrapper .chat-list-wrapper .chat-list li .body .header .timestamp i {
    margin-right: 4px;
  }
  .chat .chat-wrapper .chat-list-wrapper .chat-list li .body p {
    display: none;
  }
  .chat .chat-wrapper .chat-list-wrapper .chat-list li.active {
    color: black;
  }
  .chat .chat-wrapper .chat-list-wrapper .chat-list li.active .body .timestamp {
    color: black;
  }
  .chat .chat-wrapper .chat-list-wrapper .chat-list li.new {
    font-weight: bolder;
  }
  .chat .chat-wrapper .chat-list-wrapper .chat-list li.new .body .timestamp {
    font-weight: bolder;
  }
  .chat .chat-wrapper .message-list-wrapper .message-list li.left .avatar {
    display: none;
  }
  .chat .chat-wrapper .message-list-wrapper .message-list li.left .username {
    display: inline-block;
    margin-right: 10px;
  }
  .chat .chat-wrapper .message-list-wrapper .message-list li.left .body {
    width: 100%;
  }
  .chat .chat-wrapper .message-list-wrapper .message-list li.right .avatar {
    display: none;
  }
  .chat .chat-wrapper .message-list-wrapper .message-list li.right .username {
    display: inline-block;
    margin-left: 10px;
  }
  .chat .chat-wrapper .message-list-wrapper .message-list li.right .timestamp {
    text-align: right;
    display: block;
    color: #999;
    font-size: 11px;
    line-height: 18px;
    font-style: italic;
    margin-bottom: 4px;
  }
  .chat .chat-wrapper .message-list-wrapper .message-list li.right .timestamp i {
    margin-right: 4px;
  }
  .chat .chat-wrapper .message-list-wrapper .message-list li.right .body {
    width: 100%;
  }
  .chat .chat-wrapper .recipient-box {
    margin-top: 30px;
  }
}

.btn-green {
    background-color: #2ecc71;
    border-color: #27ae60;
    color: white;
}

.mg-btm-10 {
    margin-bottom: 10px !important;
}

.panel-white {
    border: 1px solid #dddddd;
}
.panel {
    border-radius: 0;
    margin-bottom: 30px;
}
.border-top-green {
    border-top: 4px solid #27ae60 !important;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Rental Infomation	</a></li>
        </ul>

        <div class="row">
            <!--Middle Part Start-->
            <div id="content" class="col-sm-9">
                <h2 class="title">Rental Information</h2>
                <h2 class="title">Status: </h2>
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <td colspan="2" class="text-left">Rental Details</td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style="width: 50%;" class="text-left"><b>Rental ID:</b> #214521
								<br>
                                <b>Date  Created:</b> 20/06/2016
																<br>
                                <b>Pick Up Location:</b> 20/06/2016
								<br>
                                <b>Pick Up Time:</b> 20/06/2016
								<br>
                                <b>Return Location: </b>15/1/12
								<br>
                                <b>Return Time: </b>15/1/12
																

								
								<br>
                            </td>
                            <td style="width: 50%;" class="text-left"><b>Rental Start Date:</b> 123
								<br>
                                <b>Rental End Date:</b> Flat Shipping Rate 
																<br>
                                <b>Deposit:</b>11231
								<br>
                                <b>Rental Fee:</b> Flat Shipping Rate </td>
                        </tr>
                    </tbody>
                </table>

                <div class="chat">
                    <div class="chat-history">
                        <ul class="chat-ul">
                            <asp:Repeater ID="rptMessages" runat="server">
                                <ItemTemplate>
<%--                                    <asp:Label ID="Label3" runat="server" Text='<%# retrieveMessage(Convert.ToString(Eval("Member.MemberID")), Convert.ToString(Eval("Staff.StaffID")), Convert.ToString(Eval("reply")), String.Format("{0:dd MMM yy   HH:mm}", Eval("Date")))%>'></asp:Label>--%>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <!-- end chat-history -->

                </div>
                <!-- end chat -->

                <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet">
<script src="http://91.234.35.26/iwiki-admin/v1.0.0/admin/js/jquery.nicescroll.min.js"></script>
<div class="container">
<div class="row">
        <div class="col-sm-9">
            <div class="panel panel-white border-top-green">
                <div class="panel-body chat"> 
                    <div class="row chat-wrapper">  
                       
                        
                        <div class="col-sm-9">

                            
                            <div>

                                <div class="slimScrollDiv" style="position: relative; overflow: hidden; width: auto; height: 452px;">
                                <div class="message-list-wrapper" style="overflow: hidden; width: auto; height: 452px;">
                                    <ul class="message-list">
                                        <li class="left">
                                            <span class="username">Yanique Robinson</span>
                                            <small class="timestamp">
                                                <i class="fa fa-clock-o"></i>9 mins ago
                                            </small> 
                                            <span class="avatar available tooltips" data-toggle="tooltip " data-placement="right" data-original-title="Yanique Robinson">
                                                <img src="https://bootdey.com/img/Content/avatar/avatar1.png" alt="avatar" class="img-circle">
                                            </span>
                                            <div class="body">   
                                                <div class="message well well-sm">
                                                    Hey, are you busy at the moment?
                                                </div>
                                            </div>
                                        </li>  
                                        <li class="right">
                                            <span class="username">Kevin Mckoy</span>
                                            <small class="timestamp">
                                                <i class="fa fa-clock-o"></i>5 mins ago
                                            </small> 
                                            <span class="avatar tooltips" data-toggle="tooltip " data-placement="left" data-original-title="Kevin Mckoy">
                                                <img src="https://bootdey.com/img/Content/avatar/avatar2.png" alt="avatar" class="img-circle">
                                            </span>
                                            <div class="body">   
                                                <div class="message well well-sm">
                                                    Um, no actually. I've just wrapped up my last project for the day.
                                                </div>
                                                <div class="clearfix"></div>
                                                <div class="message well well-sm">
                                                    Whats up?
                                                </div>
                                            </div>
                                        </li>  
                                        <li class="left">
                                            <span class="username">Yanique Robinson</span>
                                            <small class="timestamp">
                                                <i class="fa fa-clock-o"></i>3 mins ago
                                            </small> 
                                            <span class="avatar available tooltips" data-toggle="tooltip " data-placement="right" data-original-title="Yanique Robinson">
                                                <img src="https://bootdey.com/img/Content/avatar/avatar1.png" alt="avatar" class="img-circle">
                                            </span>
                                            <div class="body">   
                                                <div class="message well well-sm">
                                                    Well, I wanted to find out if you have any plans for tonight.
                                                </div>   
                                                <div class="clearfix"></div>
                                                <div class="message well well-sm">
                                                    <p><a href="#" class="white">Barbara</a> and I are going to this restaurant out of town.</p>
                                                    <img src="https://lorempixel.com/300/200/nature/3" alt="">
                                                </div>
                                            </div>
                                        </li>  
                                        <li class="right">
                                            <span class="username">Kevin Mckoy</span>
                                            <small class="timestamp">
                                                <i class="fa fa-clock-o"></i>2 mins ago
                                            </small> 
                                            <span class="avatar tooltips" data-toggle="tooltip " data-placement="left" data-original-title="Kevin Mckoy">
                                                <img src="https://bootdey.com/img/Content/avatar/avatar2.png" alt="avatar" class="img-circle">
                                            </span>
                                            <div class="body">   
                                                <div class="message well well-sm">
                                                    Wow that sounds great.
                                                </div>
                                            </div>
                                            </li> 
                                        <li class="left">
                                            <span class="username">Yanique Robinson</span>
                                                <small class="timestamp">
                                                    <i class="fa fa-clock-o"></i>56 secs ago
                                                </small> 
                                            <span class="avatar available tooltips" data-toggle="tooltip " data-placement="right" data-original-title="Yanique Robinson">
                                                    <img src="https://bootdey.com/img/Content/avatar/avatar1.png" alt="avatar" class="img-circle">
                                                </span>
                                                <div class="body">   
                                                    <div class="message well well-sm">
                                                        Ok! We'll swing by your office at 5.
                                                    </div>
                                                </div>
                                            </li>  
                                        <li class="right">
                                            <span class="username">Kevin Mckoy</span>
                                                <small class="timestamp">
                                                    <i class="fa fa-clock-o"></i>3 secs ago
                                                </small> 
                                                <span class="avatar tooltips" data-toggle="tooltip " data-placement="left" data-original-title="Kevin Mckoy">
                                                    <img src="https://bootdey.com/img/Content/avatar/avatar2.png" alt="avatar" class="img-circle">
                                                </span>
                                                <div class="body">   
                                                    <div class="message well well-sm">
                                                        Cool. I'l see you guys then.
                                                    </div>
                                                </div>
                                            </li>   
                                    </ul>
                                </div><div class="slimScrollBar" style="width: 7px; position: absolute; top: 265px; opacity: 0.4; display: none; border-radius: 7px; z-index: 99; right: 1px; height: 187.092px; background: rgb(0, 0, 0);"></div><div class="slimScrollRail" style="width: 7px; height: 100%; position: absolute; top: 0px; display: none; border-radius: 7px; opacity: 0.2; z-index: 90; right: 1px; background: rgb(51, 51, 51);"></div></div>

                                <div class="compose-box">
                                    <div class="row">
                                       <div class="col-xs-12 mg-btm-10">
                                           <textarea id="btn-input" class="form-control input-sm" placeholder="Type your message here..."></textarea>
                                        </div>
                                        <div class="col-xs-8">
                                            <button class="btn btn-green btn-sm">
                                                <i class="fa fa-camera"></i>
                                            </button>
                                            <button class="btn btn-green btn-sm">
                                                <i class="fa fa-video-camera"></i>
                                            </button>
                                            <button class="btn btn-green btn-sm">
                                                <i class="fa fa-file"></i>
                                            </button>
                                        </div>
                                        <div class="col-xs-4"> 
                                            <button class="btn btn-green btn-sm pull-right">
                                                <i class="fa fa-location-arrow"></i> Send
                                            </button>
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
</div>


                <div class="buttons clearfix">
                    <div class="pull-right">
                        <a class="btn btn-primary" href="#">Continue</a>
                    </div>
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

    
<script src="http://netdna.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
<script type="text/javascript">
	$(function(){
    $(".chat-list-wrapper, .message-list-wrapper").niceScroll();
})
</script>
    </div>
    </form>
</body>
</html>
