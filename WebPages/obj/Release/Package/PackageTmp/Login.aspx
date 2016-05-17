<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebPages.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>跑腿网登录</title>
    <link href="Styles/style2.css" rel='stylesheet' type='text/css' />
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
		<!--webfonts-->
		<link href='http://fonts.googleapis.com/css?family=Lobster|Pacifico:400,700,300|Roboto:400,100,100italic,300,300italic,400italic,500italic,500' ' rel='stylesheet' type='text/css'>
		<link href='http://fonts.googleapis.com/css?family=Raleway:400,100,500,600,700,300' rel='stylesheet' type='text/css'>
		<!--webfonts-->
</head>
<body>
    <div class="main">
        <div class="login-head">
		    <h1>跑腿网登录界面</h1>
	    </div>
        <div  class="wrap">
        <div class="Login">
							<div class="Login-head">
						    	<h3>欢迎登录</h3>
						 	</div>

						    <form id="form1" runat="server">
								<div class="ticker">
									<h4>用户名</h4>
						  			
                                    <asp:TextBox ID="TextBox1" runat="server" value="请输入" onfocus="this.value = '';" ></asp:TextBox><div class="clear"> </div>
                                    </div>
						  		<div>
						  		<h4>密码</h4>
								
								<asp:TextBox ID="TextBox2" runat="server" value="Password" 
                                        onfocus="this.value = '';" 
                                         TextMode="Password"></asp:TextBox><div class="clear"> </div>
								</div>
								<div class="checkbox-grid">
									<div class="inline-group green">
									<div class="clear"> </div>
									</div>

								</div>
												 
								<div class="submit-button">
									<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="<  登录 " />
									&nbsp;<asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text=" 注册  >"  />
                                </div>
									<div class="clear"> </div>
								</form>
								</div>
        	  </form>
		</div>
           
    
    </div>
    <!--//End-login-form-->	
						<div class ="copy-right">
							<p>版权归<a href="http://tieba.baidu.com/f?kw=%D1%F8%D6%ED%B3%A1&fr=ala0&tpl=5">2村养猪场</a> 手机：15757821569</p>
						</div>
</div>
</body>
</html>
