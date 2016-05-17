<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlaceOrder.aspx.cs" Inherits="WebPages.PlaceOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>我要下单</title>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=q6P5QgqiGo7d3hYanna6uAQnYVB4nLf6"></script>
    <style type="text/css"">
				    body,html,#map
				    {
				        width:100%;
				        height:100%;
				        overflow:hidden;
				        margin:0;
				        background-color:#fff;
				        font-family:@微软雅黑;
                        color:#101010;
				    }
		</style>
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" media="all">
<link href="Styles/mapstyle.css" rel="stylesheet" type="text/css" media="all" />
<script src="js/jquery.min.js"></script>
<script src="js/jquery.easydropdown.js"></script>
<!-- Mega Menu -->
<link href="Styles/megamenu.css" rel="stylesheet" type="text/css" media="all" />
<script type="text/javascript" src="js/megamenu.js"></script>
<script>    $(document).ready(function () { $(".megamenu").megamenu(); });</script>
<%--窗口--%>
<style>
.black_overlay{
display: none;
position: absolute;
top: 0%;
left: 0%;
width: 100%;
height: 100%;
background-color: black;
z-index:1001;
-moz-opacity: 0.8;
<%--opacity:.80;
filter: alpha(opacity=80);--%>
}
.white_content {
display: none;
position: absolute;
top: 10%;
left: 10%;
width: 80%;
height: 80%;
border: 16px solid lightblue;
background-color: white;
z-index:1002;
overflow: auto;
}
.white_content_small {
display: none;
position: absolute;
top: 20%;
left: 30%;
width: 40%;
height: 50%;
border: 16px solid lightblue;
background-color: white;
z-index:1002;
overflow: auto;
}
</style>
<script type="text/javascript">
    //弹出隐藏层
    function ShowDiv(show_div, bg_div) {
        document.getElementById(show_div).style.display = 'block';
        document.getElementById(bg_div).style.display = 'block';
        var bgdiv = document.getElementById(bg_div);
        bgdiv.style.width = document.body.scrollWidth;
        // bgdiv.style.height = $(document).height();
        $("#" + bg_div).height($(document).height());
    };
    //关闭弹出层
    function CloseDiv(show_div, bg_div) {
        document.getElementById(show_div).style.display = 'none';
        document.getElementById(bg_div).style.display = 'none';
    };
</script>

<%--窗口--%>
<!-- Mega Menu -->
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 138px;
        }
        .style2
        {
            width: 95px;
        }
        .style3
        {
            width: 449px;
        }
    </style>
    </head>
<body onload="setvalue()">
    <form id="form1" runat="server">
<!-- banner -->
	<div class="header">
		<div class="container">
			<div class="logo">
				<a href="PlaceOrder.aspx"><img src="images/logo.png" class="img-responsive" alt=""></a><%--此图片可以自己创作，用以新的“location find”--%>
			</div>
            <div class="header-left">
				<a href="Login.aspx" > 重新登录</a>
			</div>
			<div class="header-left">
				<li a="" href="#"><div class="drop-down">
							
								</div></li>
			</div>
				<div class="clearfix"></div>
		</div>
	</div>
<div class="header-bottom">
		<div class="container">
			<div class="top-nav">
				<span class="menu"> </span>
					<ul class="navig megamenu skyblue">
						<li><a href="PlaceOrder.aspx" > 下单界面</a>
							<div class="megapanel">
								<div class="na-left">
									<ul class="grid-img-list">
										<li><a href="PlaceOrder.aspx">去下单  </a></li> |
										<li><a href="MyOrders.aspx">我下的单</a></li> |
										<li><a href="MyCompletedOrders.aspx"> 下单历史 </a></li> 
										<div class="clearfix"> </div>	
									</ul>
								</div>
								
								<div class="clearfix"> </div>	
		    				</div>
                            <div class="clearfix"> </div>	
						</li>
						<li><a href="TakeOrder.aspx" > 接单界面</a>
                            <div class="megapanel">
								<div class="na-left">
									<ul class="grid-img-list">
										<li><a href="TakeOrder.aspx">来接单  </a></li> |
										<li><a href="MyTakingOrder.aspx">我接的单</a></li> |
										<li><a href="MyCompletedTakingOrder.aspx"> 接单历史 </a></li> 
										<div class="clearfix"> </div>	
									</ul>
								</div>
								
								<div class="clearfix"> </div>	
		    				</div>
                        </li>	

						<div class="clearfix"></div>
					</ul>
					<script>
					    $("span.menu").click(function () {
					        $(".top-nav ul").slideToggle(300, function () {
					        });
					    });
				</script>
			</div>
			
			<div class="clearfix"> </div>	
		</div>
	</div>
<!-- 404 -->
	<div class="location">
		<div class="container">
				<div class="locat-left">
					
				    
					
				    <table class="style1">
                        <tr>
                            <td class="style2">
                                寄送信息：</td>
                            <td class="style3">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style2">
                                物品名称：</td>
                            <td class="style3">
                                <asp:TextBox ID="TextBox11" runat="server" Width="212px" MaxLength="15"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style2">
                                物品重量：</td>
                            <td class="style3">
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="210px">
                                    <asp:ListItem>1公斤</asp:ListItem>
                                    <asp:ListItem>2公斤</asp:ListItem>
                                    <asp:ListItem>3公斤</asp:ListItem>
                                    <asp:ListItem>4公斤</asp:ListItem>
                                    <asp:ListItem>5公斤</asp:ListItem>
                                    <asp:ListItem>6公斤</asp:ListItem>
                                    <asp:ListItem>7公斤</asp:ListItem>
                                    <asp:ListItem>8公斤</asp:ListItem>
                                    <asp:ListItem>9公斤</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style2">
                                备注：</td>
                            <td class="style3">
                                <asp:TextBox ID="TextBox13" runat="server" Width="211px" MaxLength="15"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
					
				    
					
				</div>
                <div class="locat-left">
					
				</div>
                <div class="locat-right">
					
				    
					
				    <table class="style13">
                        <tr>
                            <td class="style15">
                                寄件人信息</td>
                            <td class="style19">
                                &nbsp;</td>
                            <td class="style17">
                                收件人信息</td>
                            <td class="style16">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style14">
                                寄件人：</td>
                            <td class="style20">
                                <asp:TextBox ID="TextBox6" runat="server" Height="33px" Width="381px" 
                                    MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="style18">
                                收件人：</td>
                            <td>
                                <asp:TextBox ID="TextBox7" runat="server" Height="33px" Width="381px" 
                                    MaxLength="15"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style14">
                                手机号码：</td>
                            <td class="style20">
                                <asp:TextBox ID="TextBox8" runat="server" Height="33px" Width="381px" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))) {event.returnValue=true;} else{event.returnValue=false;}" 
                                    MaxLength="11"></asp:TextBox>
                            </td>
                            <td class="style18">
                                手机号码：</td>
                            <td>
                                <asp:TextBox ID="TextBox9" runat="server" Height="33px" Width="381px" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))) {event.returnValue=true;} else{event.returnValue=false;}" 
                                    MaxLength="11"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style14">
                                寄件地址：</td>
                            <td class="style20">
                                <asp:TextBox ID="TextBox14" runat="server" Height="33px" Width="381px" 
                                    ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="style18">
                                收件地址：</td>
                            <td>
                                <asp:TextBox ID="TextBox15" runat="server" Height="33px" Width="381px" 
                                    ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                </td>
                            <td>
					
				    <input id="SAddress" type="button" value="选取寄件地址" onclick="ShowDiv('MyDiv','fade')" /></td>
                            <td>
                                </td>
                            <td>
                <input id="RAddress" type="button" value="选取收件地址" onclick="ShowDiv('MyDiv2','fade2')" /></td>
                        </tr>
                    </table>
					
				    &nbsp;<!--弹出层时背景层DIV-->
<div id="fade" class="black_overlay">
</div>
<div id="MyDiv" class="white_content">
<div style="text-align: right; cursor: default; height: 16px;">
<span style="font-size: 16px;" onclick="CloseDiv('MyDiv','fade')">关闭</span>
</div>
<table class="nav-justified">
                        <tr>
                            <td>
                               <div style="width:700px;height:550px;border:#ccc solid 1px;font-size:12px" id="map"></div></td>
                            <td>
                                <asp:TextBox ID="ReadSAddress" runat="server" ReadOnly="True"  Height="30px" Width="381px"></asp:TextBox>
                                <asp:Button ID="Sure" runat="server" onclick="Sure_Click" Text="确定选取此地址" />
                                <%--<input id="Sure" type="button" value="确定选取此地址" onclick="Sure_Click" />--%>
                                <asp:TextBox ID="HideTextBox1" runat="server"  Height="30px" Width="30px"   ></asp:TextBox>
                                </td>
                                
                        </tr>
                    </table>

</div>
					
				    
<!--弹出层时背景层DIV-->
<div id="fade2" class="black_overlay">
</div>
<div id="MyDiv2" class="white_content">
<div style="text-align: right; cursor: default; height: 16px;">
<span style="font-size: 16px;" onclick="CloseDiv('MyDiv2','fade2')">关闭</span>
</div>
<table class="nav-justified">
                        <tr>
                            <td>
                               <div style="width:700px;height:550px;border:#ccc solid 1px;font-size:12px" id="map2"></div></td>
                            <td>
                                <asp:TextBox ID="ReadRAddress2" runat="server" ReadOnly="True"  Height="30px" Width="381px"></asp:TextBox>
                                <asp:Button ID="Sure2" runat="server" onclick="Sure2_Click2" Text="确定选取此地址" />
                                <asp:TextBox ID="HideTextBox2" runat="server"  Height="30px" Width="30px"   ></asp:TextBox>
                                </td>
                                
                        </tr>
                    </table>
</div>
					
				    
					
				</div>
			<div class="locat-bottm">
				<div class="contact-details">				 
					&nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="我要下单" />
		  </div>
					<div class="clearfix"> </div>
			</div>
		</div>
	</div>
<!-- 404 -->
	<div class="footer">
		<div class="container">
			
				<div class="clearfix"></div>
			<div class="footer-bottom">
				<p>版权所有</p>
			</div>
		</div>
	</div>
    </form>
</body>
<script type="text/javascript">
    //创建和初始化地图函数：
    function initMap() {
        createMap(); //创建地图
        setMapEvent(); //设置地图事件
        addMapControl(); //向地图添加控件
        addMapOverlay(); //向地图添加覆盖物
        //        searchByStationName();
    }
    function createMap() {
        map = new BMap.Map("map");
        map.centerAndZoom(new BMap.Point(121.638039, 29.922469), 17);

    }
    function setMapEvent() {
        map.enableScrollWheelZoom();
        map.enableKeyboard();
        map.enableDragging();
        map.enableDoubleClickZoom();
    }
    //    function addClickHandler(target, window) {
    //        target.addEventListener("click", function () {
    //            target.openInfoWindow(window);
    //        });
    //    }
    function addMapOverlay() {
    }
    //向地图添加控件
    function addMapControl() {
        var scaleControl = new BMap.ScaleControl({ anchor: BMAP_ANCHOR_BOTTOM_LEFT });
        scaleControl.setUnit(BMAP_UNIT_IMPERIAL);
        map.addControl(scaleControl);
        var navControl = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_LEFT, type: BMAP_NAVIGATION_CONTROL_LARGE });
        map.addControl(navControl);
        var overviewControl = new BMap.OverviewMapControl({ anchor: BMAP_ANCHOR_BOTTOM_RIGHT, isOpen: true });
        map.addControl(overviewControl);
    }


    //=================地址反解析(根据坐标点获取地址)==========================\\  

    //=======================================================================\\  

    function setvalue() {
        map.addEventListener("click", function (e) {
            //            + e.point.lng + ", " + e.point.lat; 
            //            posName = URLEncoder.encode("39.983424,116.322987", "UTF-8");
            var rejson = new URL("http://api.map.baidu.com/geocoder/v2/?ak=q6P5QgqiGo7d3hYanna6uAQnYVB4nLf6&callback=renderReverse&location=39.983424,116.322987&output=json&pois=1");

            document.getElementById("HideTextBox1").value = e.point.lat + "," + e.point.lng;
        });

    };

    var map;
    initMap(); setvalue();
  </script>

<%--**********************************************************************--%>
<script type="text/javascript">
    //创建和初始化地图函数：
    function initMap2() {
        createMap2(); //创建地图
        setMapEvent2(); //设置地图事件
        addMapControl2(); //向地图添加控件
        addMapOverlay2(); //向地图添加覆盖物
        //        searchByStationName();
    }
    function createMap2() {
        map2 = new BMap.Map("map2");
        map2.centerAndZoom(new BMap.Point(121.638039, 29.922469), 17);

    }
    function setMapEvent2() {
        map2.enableScrollWheelZoom();
        map2.enableKeyboard();
        map2.enableDragging();
        map2.enableDoubleClickZoom();
    }
    //    function addClickHandler(target, window) {
    //        target.addEventListener("click", function () {
    //            target.openInfoWindow(window);
    //        });
    //    }
    function addMapOverlay2() {
    }
    //向地图添加控件
    function addMapControl2() {
        var scaleControl2 = new BMap.ScaleControl({ anchor: BMAP_ANCHOR_BOTTOM_LEFT });
        scaleControl2.setUnit(BMAP_UNIT_IMPERIAL);
        map2.addControl(scaleControl2);
        var navControl2 = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_LEFT, type: BMAP_NAVIGATION_CONTROL_LARGE });
        map2.addControl(navControl2);
        var overviewControl2 = new BMap.OverviewMapControl({ anchor: BMAP_ANCHOR_BOTTOM_RIGHT, isOpen: true });
        map2.addControl(overviewControl2);
    }


    //=================地址反解析(根据坐标点获取地址)==========================\\  

    //=======================================================================\\  

    function setvalue2() {
        map2.addEventListener("click", function (e) {
            //            + e.point.lng + ", " + e.point.lat; 
            //            posName = URLEncoder.encode("39.983424,116.322987", "UTF-8");
            var rejson = new URL("http://api.map.baidu.com/geocoder/v2/?ak=q6P5QgqiGo7d3hYanna6uAQnYVB4nLf6&callback=renderReverse&location=39.983424,116.322987&output=json&pois=1");

            document.getElementById("HideTextBox2").value = e.point.lat + "," + e.point.lng;
        });

    };

    var map2;
    initMap2(); setvalue2();
  </script>
<%--**********************************************************************--%>
</html>
