using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using project.web.Components;

namespace project.web.Controls.FolderMain
{
    public partial class LeftMenuControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
               // LoadViewByPermission();
        }

        //private void LoadViewByPermission()
        //{   //MIỄN MÔN
        //    bool MM_VIEW_QL_MienGiamHocPhan = SiteUtils.GetPermuission(StaticValuePermission.VALUE_PERMISSION_MM_VIEW_QL_MienGiamHocPhan);
        //    bool MM_VIEW_QL_SinhVien = SiteUtils.GetPermuission(StaticValuePermission.VALUE_PERMISSION_MM_VIEW_QL_SinhVien);
        //    bool MM_VIEW_BaoCaoThongKe = SiteUtils.GetPermuission(StaticValuePermission.VALUE_PERMISSION_MM_VIEW_BaoCaoThongKe);
        //    bool MM_VIEW_XemLogsThaoTac = SiteUtils.GetPermuission(StaticValuePermission.VALUE_PERMISSION_MM_VIEW_LogsThaoTac);


        //    if (MM_VIEW_QL_MienGiamHocPhan ||
        //           MM_VIEW_QL_SinhVien ||
        //           MM_VIEW_BaoCaoThongKe || 
        //           MM_VIEW_XemLogsThaoTac)
        //        MM_QuanLyMienMon.Visible = true;

        //    MM_subBaoCaoThongKe.Visible = MM_VIEW_BaoCaoThongKe;
        //    MM_subQuanLySinhVien.Visible = MM_VIEW_QL_SinhVien;
        //    MM_subXetMienMon.Visible = MM_VIEW_QL_MienGiamHocPhan;
        //    MM_subxemlogsthaotac.Visible = MM_VIEW_XemLogsThaoTac;


        //    //DOANH NGHIEP
        //    bool timKiemVanBan = SiteUtils.GetPermuission(StaticValuePermission.VALUE_PERMISSION_VIEW_REPORT_TKVBHT);
        //    bool chinhSuaDoanhNghiep = SiteUtils.GetPermuission(StaticValuePermission.VALUE_PERMISSION_EDIT_PHANQUYEN_TTDN);
        //    bool re_HoatDongDoanhNghiep = SiteUtils.GetPermuission(StaticValuePermission.VALUE_PERMISSION_VIEW_REPORT_HDDN);
        //    bool re_DoanhNghiepThieuThongTinh = SiteUtils.GetPermuission(StaticValuePermission.VALUE_PERMISSION_VIEW_REPORT_DNTHIEUTT);
        //    bool set_DanhMucThongTin = SiteUtils.GetPermuission(StaticValuePermission.VALUE_PERMISSION_SET_DANHMUCTHONGTIN);
        //    bool set_ThongTinCoBan = SiteUtils.GetPermuission(StaticValuePermission.VALUE_PERMISSION_SET_THONGTINCOBAN) || SiteUtils.GetPermuission(StaticValuePermission.VALUE_PERMISSION_MM_SET_CauHinhDaoTao);
        //    bool re_PhanLoaiDoanhNghiep = SiteUtils.GetPermuission(StaticValuePermission.VALUE_PERMISSION_VIEW_REPORT_PLDN);
        //    bool re_DoanhnghiepMoi = SiteUtils.GetPermuission(StaticValuePermission.VALUE_PERMISSION_VIEW_REPORT_DNMOI);
        //    bool per_PhanQuyenNhanVien = SiteUtils.GetPermuission(StaticValuePermission.VALUE_PERMISSION_VIEW_PHANQUYEN_QLNV);
        //    bool per_PhanQuyenDonVi = SiteUtils.GetPermuission(StaticValuePermission.VALUE_PERMISSION_SET_DANHMUCTHONGTIN);

        //    BaoCaoThongKe.Visible = false;
        //    CauHinhHeThong.Visible = false;
        //    QuanLyPhanQuyen.Visible = false;

        //    TimKiemVanBan.Visible = timKiemVanBan;
        //    DoanhNghiep.Visible = chinhSuaDoanhNghiep;

        //    if (re_HoatDongDoanhNghiep || re_DoanhNghiepThieuThongTinh || re_PhanLoaiDoanhNghiep || re_DoanhnghiepMoi)
        //        BaoCaoThongKe.Visible = true;
        //    Tk_HoatDongDoanhNghiep.Visible = re_HoatDongDoanhNghiep;
        //    Tk_DoanhNghiepThieuThongTin.Visible = re_DoanhNghiepThieuThongTinh;
        //    Tk_PhanLoaiDoanhNghiep.Visible = re_PhanLoaiDoanhNghiep;
        //    Tk_DoanhNghiepMoi.Visible = re_DoanhnghiepMoi;

        //    if (set_DanhMucThongTin || set_ThongTinCoBan)
        //        CauHinhHeThong.Visible = true;
        //    Ch_DanhMucThongTin.Visible = set_DanhMucThongTin;
        //    Ch_ThongTinCoBan.Visible = set_ThongTinCoBan;

        //    if (per_PhanQuyenDonVi || per_PhanQuyenNhanVien)
        //        QuanLyPhanQuyen.Visible = true;
        //    PQ_PhanQuyenDonVi.Visible = per_PhanQuyenDonVi;
        //    PQ_PhanQuyenNhanVien.Visible = per_PhanQuyenNhanVien;


        //}
    }
}