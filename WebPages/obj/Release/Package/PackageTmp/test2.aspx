<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test2.aspx.cs" Inherits="WebPages.test2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我要下单</title>
    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="css/main.css" rel="stylesheet">
    <link rel="stylesheet" href="http://api.map.baidu.com/library/SearchInfoWindow/1.5/src/SearchInfoWindow_min.css" />
</head>
<body>
    
    <div id="pageHeader">
        <div class="container">
            <h1>老子要下单</h1>
            
        </div>
    </div>

    <div id="pageMiddle">
        <div class="container" id = "header">
            <%--<div id="filterBox">
            </div>--%>
            <div id="toolsBar" class="clearfix">
                
                <%--<div class="row-fluid show-grid pull-left" id="selectedValue">
                </div>--%>
                <div class="pull-right">
                    
                    <span class="btn" id="chgMode">列表/地图</span>
                </div>
            </div>
        </div> <!-- /container -->
    </div>

    <div class="container" id="mainContainer">
        <div class="bs-docs-example" id="listBox">
            <div id="listWrap">
                <table class="table table-hover table-striped">
                    <tbody id="listBoby">
                    </tbody>
                </table>
            </div>
            <div id="pager" class="pagination text-center"></div>
        </div>
    </div> <!-- /container -->

    <div id="mapBox" style="display:none;">
        <div id="map" class="pull-left"></div>
        <div id="mapPanel" class="pull-right">
            <div id="mapListWrap">
                <table class="table table-hover">
                    <tbody id="mapList">
                    </tbody>
                </table>
            </div>
            <div id="mapPager" class="pagination text-center"></div>
        </div>
    </div>

    <script src="http://api.map.baidu.com/api?v=2.0&ak=q6P5QgqiGo7d3hYanna6uAQnYVB4nLf6" type="text/javascript"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/library/SearchInfoWindow/1.5/src/SearchInfoWindow_min.js"></script>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script src="js/jquery.pager.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/bootstrap.js"></script>
    <script type="text/javascript" src="js/main.js"></script>
    <script type="text/javascript">
        var _bdhmProtocol = (("https:" == document.location.protocol) ? " https://" : " http://");
        document.write(unescape("%3Cscript src='" + _bdhmProtocol + "hm.baidu.com/h.js%3F59df2806844f63df2dca6881f0f4b7a1' type='text/javascript'%3E%3C/script%3E"));
    </script>
    
</body>
</html>
