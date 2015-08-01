<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftMenuControl.ascx.cs"
    Inherits="project.web.Controls.FolderMain.LeftMenuControl" %>
<link href="<%=ResolveUrl("~/") %>Resources/plugins/menu-left/css/dcaccordion.css"
    rel="stylesheet" type="text/css" />
<link href="<%=ResolveUrl("~/") %>Resources/plugins/menu-left/css/skins/blue.css"
    rel="stylesheet" type="text/css" />
<div class="blue ">
    <ul class="accordion nav" id="accordion-3">
        <li id="Dashboard" runat="server"><a href="<%=ResolveUrl("~/") %>Default.aspx"><i
            class="fa fa-th-large"></i><span class="nav-label">Dashboard</span></a> </li>
        <li id="DoanhNghiep" runat="server"><a href="<%=ResolveUrl("~/") %>Page/10042014_HDHTDoanhNghiep/FolderDoanhNghiep/PageQuanLyThongTinDoanhNghiep.aspx">
            <i class="fa fa-cubes"></i><span class="nav-label">Doanh nghiệp</span></a> </li>
        <li id="BaoCaoThongKe" runat="server"><a href="#"><i class="fa fa-area-chart"></i><span
            class="nav-label">Báo cáo thống kê </span><span class="fa arrow"></span></a>
            <ul class="nav nav-second-level">
                <li id="Tk_HoatDongDoanhNghiep" runat="server"><a href="<%=ResolveUrl("~/") %>Page/10042014_HDHTDoanhNghiep/FolderBaoCaoThongKe/ThongKeMucDoHoatDongPage.aspx">
                    Thống kê mức độ hợp tác</a></li>
                <li id="Tk_DoanhNghiepThieuThongTin" runat="server"><a href="<%=ResolveUrl("~/") %>Page/10042014_HDHTDoanhNghiep/FolderBaoCaoThongKe/ThongKeDoanhNghiepEmptyDBPage.aspx">
                    Doanh nghiệp thiếu thông tin</a></li>
                <li id="Tk_PhanLoaiDoanhNghiep" runat="server"><a href="<%=ResolveUrl("~/") %>Page/10042014_HDHTDoanhNghiep/FolderBaoCaoThongKe/ThongKeDoanhNghiepAdvancePage.aspx">
                    Phân loại doanh nghiệp</a></li>
                <li id="Tk_DoanhNghiepMoi" runat="server"><a href="<%=ResolveUrl("~/") %>Page/10042014_HDHTDoanhNghiep/FolderBaoCaoThongKe/ThongKeDoanhNghiepMoiPage.aspx">
                    Doanh nghiệp mới</a></li>
                <%-- <li id="MM_TongHopTheoMonHoc" runat="server"><a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderBaoCaoThongKe/TongHopTheoMonHocPage.aspx">
                    Tổng hợp theo môn học</a></li>
                <li id="MM_TongHopTheoLop" runat="server"><a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderBaoCaoThongKe/TongHopTheoLopPage.aspx">
                    Tổng hợp theo lớp</a></li>
                <li id="MM_TongHopTheoNganh" runat="server"><a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderBaoCaoThongKe/TongHopTheoNganhPage.aspx">
                    Tổng hợp theo ngành</a></li>--%>
            </ul>
        </li>
        <li id="TimKiemVanBan" runat="server"><a href="<%=ResolveUrl("~/") %>Page/10042014_HDHTDoanhNghiep/ForderTimKiemVanBan/PageTimKiemVanBan.aspx">
            <i class="fa fa-files-o"></i><span class="nav-label">Tìm kiếm văn bản</span></a>
        </li>
        <li id="MM_QuanLyMienMon" visible="false" runat="server"><a href="#"><i class="fa fa-area-chart"></i>
            <span class="nav-label">Quản lý miễn môn </span><span class="fa arrow"></span></a>
            <ul class="nav nav-second-level">
                <li id="MM_subBaoCaoThongKe" runat="server"><a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderBaoCaoThongKe/BaoCaoThongKePage.aspx">
                    Báo cáo thống kê</a></li>
                <li id="MM_subQuanLySinhVien" runat="server"><a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderSinhVienTimKiemMonHoc/PageQuanLyXemMonHocMienGiamTheoSinhVien.aspx">
                    Quản lý sinh viên</a></li>
                <li id="MM_subXetMienMon" runat="server"><a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderXetMienGiamHocPhan/PageXetMienTruHocPhan.aspx">
                    Xét miễn môn</a></li>
                <li id="MM_subxemlogsthaotac" runat="server"><a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderLogs/PageShowLogs.aspx">
                    Xem logs thao tác</a></li>
            </ul>
        </li>
        <%--<li id="MM_SinhVienParent" runat="server"><a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderSinhVienTimKiemMonHoc/PageQuanLyXemMonHocMienGiamTheoSinhVien.aspx">
            <i class="fa fa-group"></i><span class="nav-label">Quản lý sinh viên </span></a>
        </li>--%>
        <%--<li id="mm_xetmiengiammon" runat="server"><a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderXetMienGiamHocPhan/PageXetMienTruHocPhan.aspx">
            <i class="fa fa-check-square-o"></i><span class="nav-label">Xét miễn môn</a></li>--%>



        <li id="CauHinhHeThong" runat="server"><a href="#"><i class="fa fa-gears"></i><span
            class="nav-label">Cấu hình</span><span class="fa arrow"></span></a>
            <ul class="nav nav-second-level">
                <li id="Ch_DanhMucThongTin" runat="server"><a href="<%=ResolveUrl("~/") %>Page/FolderCatologies/QuanLyDanhMucThongTinPage.aspx">
                    Danh mục thông tin</a></li>
                <li id="Ch_ThongTinCoBan" runat="server"><a href="<%=ResolveUrl("~/") %>Page/10042014_HDHTDoanhNghiep/FolderCauHinhCoBan/CauHinhCoBan.aspx">
                    Thông tin cơ bản</a></li>
            </ul>
        </li>
        <li id="QuanLyPhanQuyen" runat="server"><a href="#"><i class="fa fa-group"></i><span
            class="nav-label">Quản lý phân quyền </span><span class="fa arrow"></span></a>
            <ul class="nav nav-second-level">
                  <li id="PQ_PhanQuyenDonVi" runat="server"><a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderCTQuanLyDonVi/PageCTQuanLyDonVi.aspx">
                    Phân quyền đơn vị</a></li>
                <li id="PQ_PhanQuyenNhanVien" runat="server"><a href="<%=ResolveUrl("~/") %>Page/10042014_HDHTDoanhNghiep/FolderPhanQuyenNhanVien/QuanLyPhanQuyenNhanVienPage.aspx">
                    Phân quyền nhân viên</a></li>
            </ul>
        </li>
        <li id="QuanLyLoi" runat="server" runat="server"><a href="<%=ResolveUrl("~/") %>Page/FolderError/PageListLoiCaNhan.aspx">
            <i class="fa fa-exclamation-triangle"></i><span class="nav-label">Danh sách lỗi</span></a>
        </li>
    </ul>
</div>
