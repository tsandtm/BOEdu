<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="project.web.Secure.Login" %>

<%@ Register Src="~/Controls/ControlLogin.ascx" TagName="ControlLogin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập hệ thống</title>
    <!-- start: META -->
    <meta charset="utf-8" />
    <!--[if IE]><meta http-equiv='X-UA-Compatible' content="IE=edge,IE=9,IE=8,chrome=1" /><![endif]-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0" />
    <meta name="description" content="Hệ thống phần mềm nội bộ - Trường Đại học Công nghệ TP Hồ Chí Minh. Copyright © 2015 Trung tâm quản lý công nghệ thông tin HUTECH" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta content="Trung tâm quản lý công nghệ thông tin HUTECH" name="author" />
    <!-- end: META -->
    <!-- start: MAIN CSS -->
    <link href="<%=ResolveUrl("~/") %>Resources/plugins/bs3/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="<%=ResolveUrl("~/") %>Resources/plugins/font-awesome/css/font-awesome.css"
        rel="stylesheet" type="text/css" />
    <link href="<%=ResolveUrl("~/") %>Resources/plugins/iCheck/skins/all.css" rel="stylesheet"
        type="text/css" />
    <link href="<%=ResolveUrl("~/") %>Resources/plugins/animate.css/animate.min.css"
        rel="stylesheet" type="text/css" />
    <link href="<%=ResolveUrl("~/") %>Resources/plugins/login/css/styles.css" rel="stylesheet"
        type="text/css" />
    <link href="<%=ResolveUrl("~/") %>Resources/plugins/login/css/styles-responsive.css"
        rel="stylesheet" type="text/css" />
    <!--[if IE 7]>
		<link rel="stylesheet" type="text/css" href="<%=ResolveUrl("~/") %>Resources/plugins/font-awesome/css/font-awesome-ie7.min.css" />
		<![endif]-->
    <!-- end: MAIN CSS -->
    <!-- start: CSS REQUIRED FOR THIS PAGE ONLY -->
    <!-- end: CSS REQUIRED FOR THIS PAGE ONLY -->
</head>
<body class="login">
    <form runat="server" id="form">
    <div class="main-login col-xs-10 col-xs-offset-1 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4">
        <div class="logo">
            <img src="<%=ResolveUrl("~/") %>Resources/img/logo-hutech.png" class="img-responsive" />
        </div>
        <!-- start: LOGIN BOX -->
        <div class="box-login">
            <h3>
                Đăng nhập hệ thống</h3>
            <p>
                Vui lòng nhập Mã nhân viên và mật mã để đăng nhập.
            </p>
            <form class="form-login" action="#">
            <uc1:ControlLogin ID="ControlLogin1" runat="server" />
            </form>
            <br />
            <!-- start: COPYRIGHT -->
            <div class="copyright">
                2014 &copy; Đại học Công nghệ TP. HCM - HUTECH.
            </div>
            <!-- end: COPYRIGHT -->
        </div>
        <!-- end: LOGIN BOX -->
    </div>
    <div class="clear">
    </div>
    <span class="m-b-10"></span>
    <!-- start: MAIN JAVASCRIPTS -->
    <!--[if lt IE 9]>
		</script><script type="text/javascript" src="<%=ResolveUrl("~/") %>Resources/js/respond.min.js"></script>
		<script type="text/javascript" src="<%=ResolveUrl("~/") %>Resources/plugins/flot-chart/excanvas.min.js"></script>
		<script type="text/javascript" src="<%=ResolveUrl("~/") %>Resources/js/jquery-1.11.0.min.js"></script>
		<![endif]-->
    <!--[if gte IE 9]><!-->
    <script src="<%=ResolveUrl("~/") %>Resources/plugins/jQuery/jquery-2.1.1.min.js"
        type="text/javascript"></script>
    <!--<![endif]-->
    <script src="<%=ResolveUrl("~/") %>Resources/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"
        type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/") %>Resources/plugins/bs3/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/") %>Resources/plugins/iCheck/jquery.icheck.min.js"
        type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/") %>Resources/plugins/jquery.transit/jquery.transit.js"
        type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/") %>Resources/plugins/login/js/main.js" type="text/javascript"></script>
    <!-- end: MAIN JAVASCRIPTS -->
    <!-- start: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
    <script src="<%=ResolveUrl("~/") %>Resources/plugins/jquery-validation/dist/jquery.validate.min.js"
        type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/") %>Resources/plugins/login/js/login.js" type="text/javascript"></script>
    <!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
    <script type="text/javascript">
        jQuery(document).ready(function () {
            Main.init();
            Login.init();
        });
    </script>
    </form>
</body>
</html>
