﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintChuongTrinhDaoTaoSinhVienControl.ascx.cs"
    Inherits="project.web.Page.MienGiamMon_21052015.FolderBaoCaoThongKe.PrintChuongTrinhDaoTaoSinhVienControl" %>
<link href="../../../Resources/css/style-print.css" rel="stylesheet" type="text/css" />
<div class="page">
    <asp:Literal ID="LiteralSinhVienGuid" runat="server" Visible="false"></asp:Literal>
    <%--Tiêu đề--%>
    <div class="row-full header-1">
        <div class="col-1">
            <p>
                BỘ GIÁO DỤC VÀ ĐÀO TẠO
            </p>
            <p>
                <b>TRƯỜNG ĐẠI HỌC CÔNG NGHỆ TP. HCM</b>
            </p>
            <div class="line-shape-1">
            </div>
        </div>
        <div class="col-2">
            <p>
                <b>CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</b>
            </p>
            <p>
                <b>Độc lập - Tự do - Hạnh phúc</b>
            </p>
            <div class="line-shape-2">
            </div>
        </div>
    </div>
    <div class="row-full header-2">
        <p class="title-1">
            BẢNG CÔNG NHẬN GIÁ TRỊ CHUYỂN ĐỔI
        </p>
        <p class="title-2">
            KẾT QUẢ HỌC TẬP VÀ CÁC KHỐI LƯỢNG KIẾN THỨC ĐƯỢC MIỄN TRỪ
        </p>
        <p class="title-2">
            CHO NGƯỜI HỌC CHƯƠNG TRÌNH ĐÀO TẠO LIÊN THÔNG
        </p>
        <p class="title-3">
            (Ban hành kèm theo Quyết định số ... ... .../QĐ-ĐKC ngày ..... tháng ..... năm 20...
            của Hiệu trưởng)
        </p>
    </div>
    <%--Thông tin sinh viên--%>
    <div class="row-full header-3">
        <div class="row-full">
            <div class="col-1">
                <div class="label-name">
                    Họ và tên SV:
                </div>
                <div class="label-value">
                    <asp:Label ID="LabelSinhVienName" runat="server" CssClass="t-upper"></asp:Label>
                </div>
            </div>
            <div class="col-2">
                <div class="label-name">
                    Ngày sinh:
                </div>
                <div class="label-value">
                    <asp:Label ID="LabelNgaySinh" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="row-full">
            <div class="col-1">
                <div class="label-name">
                    MSSV:
                </div>
                <div class="label-value">
                    <asp:Label ID="LabelSinhVienID" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-2">
                <div class="label-name">
                    Lớp:
                </div>
                <div class="label-value">
                    <asp:Label ID="LabelLop" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="row-full">
            <div class="col-1">
                <div class="label-name">
                    Ngành:
                </div>
                <div class="label-value">
                    <asp:Label ID="LabelChuyenNganhName" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-2">
                <div class="label-name">
                    Khoa:
                </div>
                <div class="label-value">
                    <asp:Label ID="LabelKhoaName" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="row-full">
            <div class="col-1">
                <div class="label-name">
                    Trình độ đào tạo:
                </div>
                <div class="label-value">
                    <asp:Label ID="LabelTrinhDoDTName" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-2">
                <div class="label-name">
                    Hình thức đào tạo:
                </div>
                <div class="label-value">
                    <asp:Label ID="LabelHinhThucDTName" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <%--Thông tin chương trình đã tốt nghiệp--%>
    <div class="row-full header-4">
        THÔNG TIN VỀ CHƯƠNG TRÌNH ĐÀO TẠO ĐÃ TỐT NGHIỆP
        <div class="row-full">
            <div class="col-1">
                <div class="label-name">
                    Trường đã học:
                </div>
                <div class="label-value">
                    <asp:Label ID="LabelTruongDaDaoTao" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-2">
                <div class="label-name">
                    Trình độ đào tạo:
                </div>
                <div class="label-value">
                    <asp:Label ID="LabelTrinhDoDaDaoTao" runat="server" CssClass="t-tran-low lbl-cap-text"></asp:Label>
                </div>
            </div>
        </div>
        <div class="row-full">
            <div class="col-1">
                <div class="label-name">
                    Ngành:
                </div>
                <div class="label-value">
                    <asp:Label ID="LabelNganhDaDaoTao" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-2">
                <div class="label-name">
                    Hình thức đào tạo:
                </div>
                <div class="label-value">
                    <asp:Label ID="LabelHinhThucDaDaoTao" runat="server" CssClass="t-tran-low lbl-cap-text"></asp:Label>
                </div>
            </div>
        </div>
        <%--Thông tin chương trình đào tạo--%>
        <div class="row-full content">
            <p class="t-indent-30">
                <b>Hiệu trưởng Trường Đại học Công nghệ TP. HCM công nhận giá trị chuyển đổi kết quả
                    học tập và các khối lượng kiến thức được miễn trừ cho sinh viên khi học chương trình
                    đào tạo liên thông như bảng dưới đây:</b>
            </p>
        </div>
        <div class="row-full">
            <asp:Literal ID="LiteralCTDTGuid" Visible="false" runat="server"></asp:Literal>
            <div class="table-mienmon">
                <table>
                    <thead style="display: table-header-group">
                        <tr>
                            <th rowspan="2" class="stt">STT
                            </th>
                            <th rowspan="2" class="mahocphan">Mã HP
                            </th>
                            <th rowspan="2" class="tenhocphan">Tên học phần
                            </th>
                            <th colspan="6" class="nhomtinchi">Số tín chỉ
                            </th>
                            <th rowspan="2" class="mahptruoc">Mã HP trước
                            </th>
                            <th rowspan="2" class="mientru">Miễn trừ
                            </th>
                        </tr>
                        <tr>
                            <th colspan="2">Tổng
                            </th>
                            <th class="sotinchi nhomtinchi">LT
                            </th>
                            <th class="sotinchi nhomtinchi">TH/TT
                            </th>
                            <th class="sotinchi nhomtinchi">ĐA
                            </th>
                            <th class="sotinchi nhomtinchi">ĐATN
                            </th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="RepeaterThongTinDaoTao" runat="server">
                        <ItemTemplate>
                            <%# BuilTR(Container.ItemIndex + 1 
                            ,Eval("ThongTinDaoTaoGuidGuid")
                            ,Eval("MonHocID")
                            ,Eval("MoTa")
                            ,Eval("SoTinChiBatBuoc")
                            ,Eval("Level")
                            ,Eval("SoTCDoAn")
                            ,Eval("SoTCDoAnTN")
                            ,Eval("SoTCLyThuyet")
                            ,Eval("SoTCThucHanh")
                            ,Eval("SoTinChi")
                            ,Eval("MaHocPhanTruoc")
                            ,Eval("MonHocDaHoc")
                            ,Eval("NhomMonHoc")
                        )%>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
        <%--Tổng hợp thống kê--%>
        <div class="row-full footer-thongke">
            <asp:Literal ID="LiteralChuongTrinh" runat="server"></asp:Literal>
            <asp:Literal ID="LiteralMienGiam" runat="server"></asp:Literal>
            <asp:Literal ID="LiteralPhaiHoc" runat="server"></asp:Literal>
        </div>
        <div class="row-full">
            <p class="notes">
                <b><u>Ghi chú:</u></b> X - Học phần được miễn trừ (SV không cần phải học)
            </p>
        </div>
        <div class="row-full footer-signal">
            <div class="col-1">
                <p>
                </p>
                <p>
                    <b>TRƯỞNG KHOA</b>
                </p>
            </div>
            <div class="col-2">
                <p>
                    <i>TP. HCM, ngày ..... tháng ..... năm 20...</i>
                </p>
                <p>
                    <b>KT. HIỆU TRƯỞNG</b>
                </p>
                <p>
                    <b>PHÓ HIỆU TRƯỞNG</b>
                </p>
                <p class="space-sign">
                </p>
                <p>
                    <b>PGS. TS. Bùi Xuân Lâm</b>
                </p>
            </div>
        </div>
    </div>
