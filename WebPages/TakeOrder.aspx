<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TakeOrder.aspx.cs" Inherits="WebPages.TakeOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>我要接单</title>
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
		.style1
        {
            width: 874px;
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
<!-- Mega Menu -->
</head>
 <add verb="POST,GET" path="ajaxpro/*.ashx" type="AjaxPro.AjaxHandlerFactory, AjaxPro"/>


<body>
    <form id="form1" method="post" runat="server">
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
				<div class="clearfix">
                    
            </div>
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
	
		<div class="container">
                <table class="nav-justified">
                    <tr>
                        <td class="style1">
                           
                        </td>
                        <td>
                             
                        </td>
                    </tr>

                </table>
                <div>

                    <table class="nav-justified">
                        <tr>
                            <td>
                               <div class="locat-left">
					            <div style="width:700px;height:550px;border:#ccc solid 1px;font-size:12px" id="map">
                                    &nbsp;</div>
				            </div> </td>
                            <td>
                                &nbsp;&nbsp;</td>
                            <td>
                                <div class="locat-right">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">         
                                    </asp:ScriptManager> 
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="True">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                                AutoGenerateColumns="False" CellPadding="3" 
                                                DataSourceID="ObjectDataSource1" GridLines="Vertical" Width="635px" 
                                                onrowcommand="GridView1_RowCommand" PageSize="4" BackColor="White" 
                                                BorderColor="#999999" BorderStyle="None" BorderWidth="1px">
                                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                                <Columns>
                                                    <asp:BoundField DataField="OrderID" HeaderText="订单号" SortExpression="OrderID" />
                                                    <asp:BoundField DataField="ProductName" HeaderText="货物名" 
                                                        SortExpression="ProductName" />
                                                    <asp:BoundField DataField="ProductWeight" HeaderText="货物重量" 
                                                        SortExpression="ProductWeight" />
                                                    <asp:BoundField DataField="Address" HeaderText="始发地" SortExpression="Address" />
                                                    <asp:BoundField DataField="Destination" HeaderText="目的地" 
                                                        SortExpression="Destination" />
                                                    <asp:BoundField DataField="Message" HeaderText="备注信息" 
                                                        SortExpression="Message" />
                                                    <asp:ButtonField  buttontype="Button" HeaderText="操作" CommandName="Select"  runat="server" Text="接单" />
                                                </Columns>
                                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#000065" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                    SelectMethod="getData2" TypeName="WebPages.GridViewShow">
                                </asp:ObjectDataSource>
               </div></td>
                        </tr>
                    </table>

                </div>
		</div>
	
<!-- 404 -->
	<div class="footer">
		<div class="container">
			<div class="footer-bottom">
				<p>版权所有                </div>
		</div>
	
<!-- 404 -->
	<div class="footer">
		<div class="container">
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
        addMarker(); //向地图中添加marker
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

    //创建marker
    function addMarker() {
        var markerArr = WebPages.TakeOrder.getData(TestListStringReturn);

    }
    function TestListStringReturn(res) {
        var list = res.value;

        var infoWindow = new Array();
        var marker = new Array();
        for (var i = 0; i < list.length; i++) {
            var json = list[i];
            var p0 = json.pointx;
            var p1 = json.pointy;
            var point = new BMap.Point(p1, p0);
            marker[i] = new BMap.Marker(point);
            map.addOverlay(marker[i]);
            var str = "";
            str = "货物名称：" + json.ProductName + "，货物重量：" + json.ProductWeight + "，出发地：" + json.Address + "，目的地：" + json.Destination + "，备注信息：" + json.Message;
            infoWindow[i] = new BMap.InfoWindow(str);
            infoWindow[i].setWidth(220);

            //给mark添加鼠标单击事件
//            marker[i].addEventListener("click", function () { this.openInfoWindow(infoWindow[list.length-1]); });

        }
        //给mark添加鼠标单击事件
        //            marker[i].addEventListener("click", function () { this.openInfoWindow(infoWindow[list.length-1]); });

        /*******************************************************************************/
//        var marker1 = new BMap.Marker(new BMap.Point(108.961605,34.238296));  // 创建标注
//map.addOverlay(marker1);              // 将标注添加到地图中
//若要给标注添加信息框，则继续下面的代码：
//var infoWindow1 = new BMap.InfoWindow("普通标注");
////给mark添加鼠标单击事件
//marker1.addEventListener("click", function(){this.openInfoWindow(infoWindow1);});
//百度默认的标注是个红色气球，可以给它换图标：
//var pt = new BMap.Point(116.417, 39.909);
//var myIcon = new BMap.Icon("./png.gif", new BMap.Size(300,157));//自己要添加的路径
//var marker2 = new BMap.Marker(pt,{icon:myIcon});  // 创建标注
//map.addOverlay(marker2);              // 将标注添加到地图中
//最后为信息框加入点击鼠标事件：
//var infoWindow2 = new BMap.InfoWindow("<p style='font-size:14px;'>哈哈，你看见我啦！我可不常出现哦！</p><p style='font-size:14px;'>赶快查看源代码，看看我是如何添加上来的！</p>");
//marker2.addEventListener("click", function(){this.openInfoWindow(infoWindow2);});


        /**************************************************************************/



        marker[0].addEventListener("click", function () { this.openInfoWindow(infoWindow[0]); });
        marker[1].addEventListener("click", function () { this.openInfoWindow(infoWindow[1]); });
        marker[2].addEventListener("click", function () { this.openInfoWindow(infoWindow[2]); });
        marker[3].addEventListener("click", function () { this.openInfoWindow(infoWindow[3]); });
        marker[4].addEventListener("click", function () { this.openInfoWindow(infoWindow[4]); });
        marker[5].addEventListener("click", function () { this.openInfoWindow(infoWindow[5]); });
        marker[6].addEventListener("click", function () { this.openInfoWindow(infoWindow[6]); });
        marker[7].addEventListener("click", function () { this.openInfoWindow(infoWindow[7]); });
        marker[8].addEventListener("click", function () { this.openInfoWindow(infoWindow[8]); });
        marker[9].addEventListener("click", function () { this.openInfoWindow(infoWindow[9]); });
        marker[10].addEventListener("click", function () { this.openInfoWindow(infoWindow[10]); });
        marker[11].addEventListener("click", function () { this.openInfoWindow(infoWindow[11]); });
        marker[12].addEventListener("click", function () { this.openInfoWindow(infoWindow[12]); });
        marker[13].addEventListener("click", function () { this.openInfoWindow(infoWindow[13]); });
        marker[14].addEventListener("click", function () { this.openInfoWindow(infoWindow[14]); });
        marker[15].addEventListener("click", function () { this.openInfoWindow(infoWindow[15]); });
    }

    //创建InfoWindow
    function createInfoWindow(i) {
        var json = markerArr[i];
        var iw = new BMap.InfoWindow("<b class='iw_poi_title' title='" + json.title + "'>" + json.title + "</b><div class='iw_poi_content'>" + json.content + "</div>");
        return iw;
    }


    var map;
    initMap();

   
  </script>
</html>

