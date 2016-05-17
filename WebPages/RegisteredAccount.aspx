<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisteredAccount.aspx.cs" Inherits="WebPages.RegisteredAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>注册界面</title>
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
					    <h1>欢迎注册</h1>
					</div>
                    <div  class="wrap">
						  <div class="Regisration">
						  	<div class="Regisration-head">
						    	<h2><span></span>请注册</h2>
						 	 </div>
						  	  <form id="form1" runat="server">
						  		<asp:TextBox ID="name" runat="server" value="用户昵称" onfocus="this.value = '';" 
                                     MaxLength="10"></asp:TextBox>

                                <%--<asp:TextBox ID="sex" runat="server" value="性别" onfocus="this.value = '';" 
                                    onblur="if (this.value == '') {this.value = '性别';}"></asp:TextBox>--%>
						  		
                                <asp:TextBox ID="Address" runat="server" value="住址" onfocus="this.value = '';" 
                                     MaxLength="20"></asp:TextBox>

                                <asp:TextBox ID="RealName" runat="server" value="真实姓名" onfocus="this.value = '';" 
                                     MaxLength="10"></asp:TextBox>
						  		
                                <asp:TextBox ID="Phone" runat="server" value="手机号" onfocus="this.value = '';" 
                                    
                                    OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))) {event.returnValue=true;} else{event.returnValue=false;}" 
                                    MaxLength="11" ></asp:TextBox>

								<asp:TextBox ID="p1" runat="server" value="请输入密码" onfocus="this.value = '';" 
                                     OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||((event.keyCode>=65)&&(event.keyCode<=90))||((event.keyCode>=97)&&(event.keyCode<=122))) {event.returnValue=true;} else{event.returnValue=false;}"
                                    MaxLength="8" TextMode="Password"></asp:TextBox>
                                
								<asp:TextBox ID="p2" runat="server" value=" 请重复密码" onfocus="this.value = '';" 
                                     OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||((event.keyCode>=65)&&(event.keyCode<=90))||((event.keyCode>=97)&&(event.keyCode<=122))) {event.returnValue=true;} else{event.returnValue=false;}"
                                    MaxLength="8" TextMode="Password"></asp:TextBox>
                                
								 <div class="Remember-me">
								<div class="p-container">
								
								<div class ="clear"></div>
							</div>
												 
								<div class="submit">
									<asp:Button ID="RegisterButton" runat="server" onclick="Register_Click" Text="点击注册 >" />
									&nbsp;</div>
									<div class="clear"> 
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Login.aspx">返回登录</asp:HyperLink>
                                     </div>
								</div>
											
						      </form>
					</div>
    </div>
    
</body>
</html>
