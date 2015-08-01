<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="CauHinhCoBan.aspx.cs" Inherits="project.web.Page._10042014_HDHTDoanhNghiep.FolderCauHinhCoBan.CauHinhCoBan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li class="active">Cấu hình cơ bản</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="row">
       <asp:Panel ID="PanelDoanhNghiep" runat="server">
        <div class="col-sm-12">
            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    <h5>
                        Cấu hình chung</h5>
                    <div class="ibox-tools">
                        <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </div>
                </div>
                <div class="ibox-content">
                    <div class="row">
                        <div class="col-sm-3">
                            <a href="QuanLyQuocGiaPage.aspx" class="text-nodecoration">
                                <div class="panel status panel-success">
                                    <div class="panel-heading">
                                        <h1 class="panel-title text-center">
                                            01</h1>
                                    </div>
                                    <div class="panel-body text-center">
                                        <strong>Quốc gia</strong>
                                    </div>
                                </div>
                            </a>
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
  
        
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>
                            Cấu hình doanh nghiệp</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="row">
                            <div class="col-sm-3">
                                <a href="QuanLyTrangThaiThongTinPage.aspx" class="text-nodecoration">
                                    <div class="panel status panel-primary">
                                        <div class="panel-heading">
                                            <h1 class="panel-title text-center">
                                                01</h1>
                                        </div>
                                        <div class="panel-body text-center">
                                            <strong>Trạng thái doanh nghiệp</strong>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-sm-3">
                                <a href="QuanLyLoaiHinhThongTinPage.aspx" class="text-nodecoration">
                                    <div class="panel status panel-primary">
                                        <div class="panel-heading">
                                            <h1 class="panel-title text-center">
                                                02</h1>
                                        </div>
                                        <div class="panel-body text-center">
                                            <strong>Loại hình doanh nghiệp</strong>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-sm-3">
                                <a href="QuanLyQuyMoDoanhNghiepThongTinPage.aspx" class="text-nodecoration">
                                    <div class="panel status panel-primary">
                                        <div class="panel-heading">
                                            <h1 class="panel-title text-center">
                                                03</h1>
                                        </div>
                                        <div class="panel-body text-center">
                                            <strong>Quy mô doanh nghiệp</strong>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-sm-3">
                                <a href="QuanLyLinhVucThongTinPage.aspx" class="text-nodecoration">
                                    <div class="panel status panel-primary">
                                        <div class="panel-heading">
                                            <h1 class="panel-title text-center">
                                                04</h1>
                                        </div>
                                        <div class="panel-body text-center">
                                            <strong>Lĩnh vực hoạt động</strong>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-sm-3">
                                <a href="QuanLyNganhNgheThongTinPage.aspx" class="text-nodecoration">
                                    <div class="panel status panel-primary">
                                        <div class="panel-heading">
                                            <h1 class="panel-title text-center">
                                                05</h1>
                                        </div>
                                        <div class="panel-body text-center">
                                            <strong>Ngành nghề</strong>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-sm-3">
                                <a href="QuanLyDoiTuongPage.aspx" class="text-nodecoration">
                                    <div class="panel status panel-primary">
                                        <div class="panel-heading">
                                            <h1 class="panel-title text-center">
                                                06</h1>
                                        </div>
                                        <div class="panel-body text-center">
                                            <strong>Đối tượng tài trợ</strong>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-sm-3">
                                <a href="QuanLyHinhThucTaiTroThongTinPage.aspx" class="text-nodecoration">
                                    <div class="panel status panel-primary">
                                        <div class="panel-heading">
                                            <h1 class="panel-title text-center">
                                                07</h1>
                                        </div>
                                        <div class="panel-body text-center">
                                            <strong>Hình thức tài trợ</strong>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-sm-3">
                                <a href="QuanLyDoiTuongThucTapPage.aspx" class="text-nodecoration">
                                    <div class="panel status panel-primary">
                                        <div class="panel-heading">
                                            <h1 class="panel-title text-center">
                                                08</h1>
                                        </div>
                                        <div class="panel-body text-center">
                                            <strong>Đối tượng thực tập</strong>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-sm-3">
                                <a href="QuanLyDoiTuongTuyenDungPage.aspx" class="text-nodecoration">
                                    <div class="panel status panel-primary">
                                        <div class="panel-heading">
                                            <h1 class="panel-title text-center">
                                                09</h1>
                                        </div>
                                        <div class="panel-body text-center">
                                            <strong>Đối tượng tuyển dụng</strong>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="PanelMienMon" runat="server">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>
                            Cấu hình đào tạo</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="row">
                            <div class="col-sm-3">
                                <a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderNienKhoa/PageQuanLyNienKhoaMienGiamMonHoc.aspx"
                                    class="text-nodecoration">
                                    <div class="panel status panel-primary">
                                        <div class="panel-heading">
                                            <h1 class="panel-title text-center">
                                                01</h1>
                                        </div>
                                        <div class="panel-body text-center">
                                            <strong>Niên khóa</strong>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-sm-3">
                                <a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderKhoa/QLKhoa.aspx"
                                    class="text-nodecoration">
                                    <div class="panel status panel-primary">
                                        <div class="panel-heading">
                                            <h1 class="panel-title text-center">
                                                02</h1>
                                        </div>
                                        <div class="panel-body text-center">
                                            <strong>Khoa</strong>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-sm-3">
                                <a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderChuyenNganh/PageQuangLyChuyenNganhMienGiamMonHoc.aspx"
                                    class="text-nodecoration">
                                    <div class="panel status panel-primary">
                                        <div class="panel-heading">
                                            <h1 class="panel-title text-center">
                                                03</h1>
                                        </div>
                                        <div class="panel-body text-center">
                                            <strong>Chuyên ngành đào tạo</strong>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-sm-3">
                                <a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderHuongChuyenSau/PageHuongChuyenSau.aspx"
                                    class="text-nodecoration">
                                    <div class="panel status panel-primary">
                                        <div class="panel-heading">
                                            <h1 class="panel-title text-center">
                                                04</h1>
                                        </div>
                                        <div class="panel-body text-center">
                                            <strong>Hướng chuyên sâu</strong>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-sm-3">
                                <a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderTrinhDoDaoTao/PageTrinhDoDaoTaoMienGiamMonHoc.aspx"
                                    class="text-nodecoration">
                                    <div class="panel status panel-primary">
                                        <div class="panel-heading">
                                            <h1 class="panel-title text-center">
                                                05</h1>
                                        </div>
                                        <div class="panel-body text-center">
                                            <strong>Trình độ đào tạo</strong>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-sm-3">
                                <a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderHinhThucDaoTao/PageQuangLyHinhThucDaoTaoMienGiamMonHoc.aspx"
                                    class="text-nodecoration">
                                    <div class="panel status panel-primary">
                                        <div class="panel-heading">
                                            <h1 class="panel-title text-center">
                                                06</h1>
                                        </div>
                                        <div class="panel-body text-center">
                                            <strong>Hình thức đào tạo</strong>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-sm-3">
                                <a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderMonHoc/QLMonHoc.aspx"
                                    class="text-nodecoration">
                                    <div class="panel status panel-primary">
                                        <div class="panel-heading">
                                            <h1 class="panel-title text-center">
                                                07</h1>
                                        </div>
                                        <div class="panel-body text-center">
                                            <strong>Môn học</strong>
                                        </div>
                                    </div>
                                </a>
                            </div>
                            <div class="col-sm-3">
                                <a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderChuongTrinhDaoTao/QLChuongTrinhDaoTao.aspx"
                                    class="text-nodecoration">
                                    <div class="panel status panel-primary">
                                        <div class="panel-heading">
                                            <h1 class="panel-title text-center">
                                                08</h1>
                                        </div>
                                        <div class="panel-body text-center">
                                            <strong>Chương trình đào tạo</strong>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
