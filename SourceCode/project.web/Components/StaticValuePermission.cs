using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.web.Components
{
    public static class StaticValuePermission
    {
        public static int VALUE_PERMISSION_EDIT_PHANQUYEN_TTDN { get { return 0; } }
        public static int VALUE_PERMISSION_VIEW_PHANQUYEN_QLNV { get { return 1; } }
        public static int VALUE_PERMISSION_ADMIN_PHANQUYEN_QLDN { get { return 2; } }
        public static int VALUE_PERMISSION_SET_DANHMUCTHONGTIN { get { return 3; } }
        public static int VALUE_PERMISSION_SET_THONGTINCOBAN { get { return 4; } }
        public static int VALUE_PERMISSION_VIEW_PHANQUYEN_QLDN { get { return 5; } }
        public static int VALUE_PERMISSION_VIEW_REPORT_DNMOI { get { return 6; } }
        public static int VALUE_PERMISSION_VIEW_REPORT_TKVBHT { get { return 7; } }
        public static int VALUE_PERMISSION_VIEW_PHANQUYEN_TTDN { get { return 8; } }
        public static int VALUE_PERMISSION_VIEW_REPORT_HDDN { get { return 9; } }
        public static int VALUE_PERMISSION_VIEW_REPORT_DNTHIEUTT { get { return 10; } }
        public static int VALUE_PERMISSION_VIEW_REPORT_PLDN { get { return 11; } }

        //miễn mOn
        public static int VALUE_PERMISSION_MM_VIEW_Edit_DaoTao     { get { return 12; } }
        public static int VALUE_PERMISSION_MM_SET_CauHinhDaoTao { get { return 13; } }
        public static int VALUE_PERMISSION_MM_VIEW_QL_SinhVien   { get { return 14; } }
        public static int VALUE_PERMISSION_MM_VIEW_QL_MienGiamHocPhan  { get { return 15; } }
        public static int VALUE_PERMISSION_MM_VIEW_BaoCaoThongKe { get { return 16; } }
        public static int VALUE_PERMISSION_MM_VIEW_LogsThaoTac { get { return 17; } }

    }
}