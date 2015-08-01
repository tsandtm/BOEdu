<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationControl.ascx.cs"
    Inherits="project.web.Controls.FolderMain.NavigationControl" %>
<%--<%@ Register Src="LoggedUserControl.ascx" TagName="LoggedUserControl" TagPrefix="uc1" %>--%>
<%@ Register Src="../LoggedUserInfo.ascx" TagName="LoggedUserInfo" TagPrefix="uc2" %>

<script src="<%=ResolveUrl("~/") %>Resources/js/menu/jquery.cookie.js" type="text/javascript"></script>
<script src="<%=ResolveUrl("~/") %>Resources/js/menu/jquery.dcjqaccordion.2.7.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function ($) {
        $('#accordion-2').dcAccordion({
            eventType: 'click',
            autoClose: true,
            saveState: true,
            disableLink: true,
            speed: 'fast',
            classActive: 'selected',
            showCount: false
        });
    });
</script>
<div class="navbar yamm navbar-default navbar-fixed-top b-shadow" role="navigation">
    <div class="container1">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                <span class="sr-only">aothunbb.com<sup>Company</sup></span> <span class="icon-bar"></span>
                <span class="icon-bar"></span><span class="icon-bar"></span>
            </button>
            <a href="<%=ResolveUrl("~/") %>Admin/Home.aspx" class="navbar-brand"><span><b>aothunbb.com</b></span>&nbsp;<sup>Company</sup></a>
        </div>
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav navbar-left" id="accordion-2">
                <li class="dropdown dcjq-parent-li" style="display:none;"><a href="#" class="dropdown-toggle dcjq-parent" data-toggle="dropdown">Quản
                    trị tối cao<span class="caret"></span></a>
                    <ul class="dropdown-menu nav nav-list" role="menu">
                        <li><a href='<%=ResolveUrl("~/") %>Admin/DashboardAdminPage.aspx'>Quản lý phân quyên</span><span
                            class="spanCount"></span> </a></li>
                        <li><a href="<%=ResolveUrl("~/") %>Page/FolderCatologies/QuanLyDanhMucThongTinPage.aspx">
                            Cây danh mục toàn hệ thống</span><span class="spanCount"></span> </a></li>
                    </ul>
                </li>
                <li class="dropdown dropdown-yamm dcjq-parent-li"><a class="dropdown-toggle dcjq-parent" data-toggle="dropdown"
                    href="#">Mega Menu <b class="caret"></b></a>
                    <ul class="dropdown-menu dropdown-menu-yamm nav nav-list">
                        <li>
                            <!-- Content container to add padding -->
                            <div class="yamm-content" id="catology_menu">
                                <div class="col-sm-6">
                                    <a href="<%=ResolveUrl("~/") %>Page/FolderNhaSanXuat/QuanLyNhaSanXuatPage.aspx">Quản
                                        lý Nhà sản xuất</a></div>
                                <div class="col-sm-6">
                                    <a href="<%=ResolveUrl("~/") %>Page/FolderCatologies/QuanLyDanhMucSanPhamPage.aspx">
                                        Quản lý danh mục sản phẩm</a></div>
                                <div class="col-sm-6">
                                    <a href="<%=ResolveUrl("~/") %>Page/FolderPhiGiaoHang/QLPhiGiaoHang.aspx">
                                        Chi phí vận chuyển</a></div>
                            </div>
                        </li>
                    </ul>
                </li>
                <li id="liQuanLyBaiViet" runat="server" class="dropdown dcjq-parent-li"><a href="#" class="dropdown-toggle dcjq-parent"
                    data-toggle="dropdown">Quản lý nội dung <span class="caret"></span></a>
                    <ul class="dropdown-menu nav nav-list" role="menu">
                        <li id="liQuanLyTinTuc" runat="server"><a href="<%=ResolveUrl("~/") %>Page/FolderTinTucs/QuanLyTinTucPage.aspx">
                            Quản lý tin tức<span class="spanCount"></span></a></li>
                        <li id="liQuanLySanPham" runat="server"><a href="<%=ResolveUrl("~/") %>Page/FolderSanPham/QuanLyDanhSachSanPhamPage.aspx">
                            Quản lý sản phẩm<span class="spanCount"></span></a></li>
                        <li id="liQuanLyKhachHang" runat="server"><a href="<%=ResolveUrl("~/") %>Page/FolderKhachHang/QLKhachHang.aspx">
                            Quản lý Khách hàng<span class="spanCount"></span></a></li>
                        <li id="liQuanLyDonDatHang" runat="server"><a href="<%=ResolveUrl("~/") %>Page/FolderDonDatHang/QuanLyDonDatHangPage.aspx">
                            Quản lý Đơn đặt hàng<span class="spanCount"></span></a></li>
                    </ul>
                </li>
            </ul>
            <%--<div class="navbar-form navbar-left" class="box-search" role="search">
                <div class="form-group">
                    <input type="text" id="TextBoxSearch" runat="server" class="form-control text-search"
                        placeholder="Bạn muốn tìm gì? " />
                    <!--<button id="ButtonSearch" runat="server" type="submit" class="btn btn-search" visible="true">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>-->
                </div>
            </div>--%>
            <div class="navbar-form navbar-right">
                <uc2:LoggedUserInfo ID="LoggedUserInfo1" runat="server" />
                <%--  <uc1:LoggedUserControl ID="LoggedUserControl1" runat="server" />--%>
            </div>
            <div class="navbar-form navbar-right">
                <ul class="nav navbar-nav navbar-left">
                    <li class="dropdown"><a target="_blank" href="<%=ResolveUrl("~/") %>default.aspx">aothunbb.com</a>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </div>
