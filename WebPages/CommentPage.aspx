<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommentPage.aspx.cs" Inherits="WebPages.Admin.CommentPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员页面-评论</title>
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
						
						<li><a href="CommentPage.aspx" > 查看评论</a>
                            
                        </li>	
                        <li><a href="AccountProcessing.aspx" > 账号管理</a>
                            
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
					
				    <asp:Label ID="Label1" runat="server" Text="评论表"></asp:Label>
					
				</div>
                <div class="locat-left">
					
				</div>
                <div class="locat-right">
					
				    
					
				    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" DataSourceID="ObjectDataSource1" PageSize="4" GridLines="Vertical" onrowcommand="GridView1_RowCommand">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>
                            <asp:BoundField DataField="OrderID" HeaderText="订单号" />
                            <asp:BoundField DataField="CreaterID" HeaderText="下单者ID" />
                            <asp:BoundField DataField="TakerID" HeaderText="接单者ID" />
                            <asp:ButtonField HeaderText="评论" CommandName="Search"  runat="server" Text="查看" 
                                ButtonType="Button" />
                            <asp:ButtonField HeaderText="操作" CommandName="Select" runat="server" Text="详情" 
                                ButtonType="Button" />
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
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
                    SelectMethod="getDataToGridView7" TypeName="WebPages.Admin.GridViewShow7">
                    </asp:ObjectDataSource>
					
				    
					
				</div>
			<div class="locat-bottm">
				<div class="contact-details">				 
					&nbsp;</div>
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
    </form>
</body>
</html>
