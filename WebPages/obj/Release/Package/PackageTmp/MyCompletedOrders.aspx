<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCompletedOrders.aspx.cs" Inherits="WebPages.MyCompletedOrders" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>下单历史</title>
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
<body>
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
	<div class="location">
		<div class="container">
				<div class="locat-left">
					
				    <asp:Label ID="Label1" runat="server" Text="已经完成的下单订单"></asp:Label>
					
				</div>
                <div class="locat-left">
					
				</div>
                <div class="locat-right">
					
				    
					
				    <asp:GridView ID="GridView1"  runat="server" CellPadding="3" 
                        GridLines="Vertical" AutoGenerateColumns="False" 
                        DataSourceID="ObjectDataSource1" BackColor="White" BorderColor="#999999" 
                        BorderStyle="None" BorderWidth="1px" onrowcommand="GridView1_RowCommand">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>
                            <asp:BoundField DataField="OrderID" HeaderText="订单号" />
                            <asp:BoundField DataField="CreateDateTime" HeaderText="下单时间" />
                            <asp:BoundField DataField="ProductName" HeaderText="货物名" />
                            <asp:BoundField DataField="ProductWeight" HeaderText="货物重量" />
                            <asp:BoundField DataField="SenderAddress" HeaderText="寄件地址" />
                            <asp:BoundField DataField="ReceiverAddress" HeaderText="收件地址" />
                            <asp:BoundField DataField="TakerName" HeaderText="接单人名" />
                            <asp:BoundField DataField="TakeStartDateTime" HeaderText="接单开始时间" />
                            <asp:BoundField DataField="TakeEndDateTime" HeaderText="接单完成时间" />
                            <asp:ButtonField ButtonType="Button" HeaderText="操作" Text="评价" CommandName="Comment"  runat="server"/>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Center"/>
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" HorizontalAlign="Center" ForeColor="Black"/>
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                    </asp:GridView>
					
				    
					
				    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
                    SelectMethod="getDataToGridView4" TypeName="WebPages.GridViewShow4">
                    </asp:ObjectDataSource>
					
				    
					
				</div>
			<div class="locat-bottm">
				<div class="contact-details">				 
					
				    <asp:Label ID="Label2" runat="server" Text="请写下评价（写完后点击相应订单的“评价”按钮即可），最多50字"></asp:Label>
					
					&nbsp;<br />
                    <asp:TextBox ID="TextBox1" runat="server" MaxLength="50" TextMode="MultiLine" 
                        Width="400px"  ></asp:TextBox>
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
</html>
