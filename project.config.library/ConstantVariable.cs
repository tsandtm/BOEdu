using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nvn.Library.Patterns;

namespace project.config.library.Utilities
{
    public static class ConstantVariable
    {
        public static string ToBinary(Int64 Decimal)
        {
            // Declare a few variables we're going to need
            Int64 BinaryHolder;
            char[] BinaryArray;
            string BinaryResult = "";

            while (Decimal > 0)
            {
                BinaryHolder = Decimal % 2;
                BinaryResult += BinaryHolder;
                Decimal = Decimal / 2;
            }

            //chi bieu dien cac so 16 bit
            //toi da den so 9999
            int count = BinaryResult.Length;
            while (count < 16)
            {
                BinaryResult += "0";
                count++;
            }


            // The algoritm gives us the binary number in reverse order (mirrored)
            // We store it in an array so that we can reverse it back to normal
            BinaryArray = BinaryResult.ToCharArray();

            Array.Reverse(BinaryArray);
            BinaryResult = new string(BinaryArray);

            return BinaryResult;
        }
        // ch them
        public static string FORMAT_DATETIME { get { return "dd/MM/yyyy"; } }

        /// <summary>
        /// Chuongtv chuyen doi kieu tien te decimal sang string
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string FormatPrices(object o)
        {
            if (o == null || o.ToString() == String.Empty)
                return string.Empty;
            if (Convert.ToDecimal(o.ToString()) == 0)
            {
                return "0";
            }
            return String.Format("{0:0,0}", Convert.ToDecimal(o.ToString()));
        }

        public static string FormatDiem(object o)
        {
            if (o == null || o.ToString() == String.Empty)
                return string.Empty;
            if (Convert.ToDecimal(o.ToString()) == 0)
            {
                return "0";
            }
            return String.Format("{0:0.#}", Convert.ToDecimal(o.ToString()));
        }

        #region Method

        public static List<TowTypeParameters<string, string>> PaperNumbers()
        {
            List<TowTypeParameters<string, string>> Groups = new List<TowTypeParameters<string, string>>();

            //Groups.Add(new TowTypeParameters<string, string>("15 trang", "15"));
            //Groups.Add(new TowTypeParameters<string, string>("20 trang", "20"));
            //Groups.Add(new TowTypeParameters<string, string>("30 trang", "30"));
            //Groups.Add(new TowTypeParameters<string, string>("60 trang", "60"));
            //Groups.Add(new TowTypeParameters<string, string>("100 trang", "100"));
            //Groups.Add(new TowTypeParameters<string, string>("200 trang", "200"));

            // Groups.Add(new TowTypeParameters<string, string>("5 record", "5"));
            Groups.Add(new TowTypeParameters<string, string>("15 record", "15"));
            Groups.Add(new TowTypeParameters<string, string>("30 record", "30"));
            Groups.Add(new TowTypeParameters<string, string>("60 record", "60"));
            Groups.Add(new TowTypeParameters<string, string>("100 record", "100"));
            Groups.Add(new TowTypeParameters<string, string>("200 record", "200"));

            //Groups.Insert(0, new TowTypeParameters<Guid, string>(Guid.Empty, "------ Root ------"));
            return Groups;
        }

        /// <summary>
        /// tham so thu 2 la id. chu y ko dc sua id nay
        /// </summary>
        /// <returns></returns>
        public static List<ThreeTypeParameters<string, string, string>> TaskStatus()
        {
            List<ThreeTypeParameters<string, string, string>> Groups = new List<ThreeTypeParameters<string, string, string>>();
            Groups.Add(new ThreeTypeParameters<string, string, string>("Nomal", "4", "text-nomal"));
            Groups.Add(new ThreeTypeParameters<string, string, string>("Done", "5", "text-primary"));
            Groups.Add(new ThreeTypeParameters<string, string, string>("Late", "6", "text-warning"));
            Groups.Add(new ThreeTypeParameters<string, string, string>("In progress", "7", "text-info"));
            Groups.Add(new ThreeTypeParameters<string, string, string>("Not responding", "8", "text-danger"));
            Groups.Add(new ThreeTypeParameters<string, string, string>("Cancel", "9", "text-cancle"));
            Groups.Add(new ThreeTypeParameters<string, string, string>("Lock", "10", "text-cancle"));
            return Groups;
        }
        public static List<ThreeTypeParameters<string, string, string>> TaskKind()
        {
            List<ThreeTypeParameters<string, string, string>> Groups = new List<ThreeTypeParameters<string, string, string>>();
            Groups.Add(new ThreeTypeParameters<string, string, string>("Other", "15", "fa-question text-warning"));
            Groups.Add(new ThreeTypeParameters<string, string, string>("Bug", "16", "fa-bug text-navy"));
            //Groups.Add(new ThreeTypeParameters<string, string, string>("BugCode", "2", "fa-bug text-danger"));
            //Groups.Add(new ThreeTypeParameters<string, string, string>("BugDB", "3", "fa-bug text-primary"));
            return Groups;
        }
        public static List<ThreeTypeParameters<string, string, string>> TaskPriority()
        {
            List<ThreeTypeParameters<string, string, string>> Groups = new List<ThreeTypeParameters<string, string, string>>();
            Groups.Add(new ThreeTypeParameters<string, string, string>("Priority 1", "11", "text-navy"));
            Groups.Add(new ThreeTypeParameters<string, string, string>("Priority 2", "12", "text-danger"));
            Groups.Add(new ThreeTypeParameters<string, string, string>("Priority 3", "13", "text-primary"));
            Groups.Add(new ThreeTypeParameters<string, string, string>("Priority 4", "14", "text-warning"));
            return Groups;
        }
        public static List<ThreeTypeParameters<string, string, string>> TaskActive()
        {
            List<ThreeTypeParameters<string, string, string>> Groups = new List<ThreeTypeParameters<string, string, string>>();
            Groups.Add(new ThreeTypeParameters<string, string, string>("Unactive", "0", "text-danger"));
            Groups.Add(new ThreeTypeParameters<string, string, string>("Active", "1", "text-navy"));
            return Groups;
        }
        public static List<ThreeTypeParameters<string, string, string>> ProjectStatus()
        {
            List<ThreeTypeParameters<string, string, string>> Groups = new List<ThreeTypeParameters<string, string, string>>();
            Groups.Add(new ThreeTypeParameters<string, string, string>("Tình trạng 1", "1", "text-navy"));
            Groups.Add(new ThreeTypeParameters<string, string, string>("Tình trạng 2", "2", "text-danger"));
            Groups.Add(new ThreeTypeParameters<string, string, string>("Tình trạng 3", "3", "text-primary"));
            Groups.Add(new ThreeTypeParameters<string, string, string>("Tình trạng 4", "4", "text-warning"));
            return Groups;
        }
        #endregion

        #region image
        public static string[] url_GetPathUploadList
        {
            get
            {
                return new string[] { GetPathUpload("1"), GetPathUpload("3"), GetPathUpload("2"), GetPathUpload("4"), GetPathUpload("5") };
            }
        }
        public static string GetPathUpload(string id)
        {
            switch (id)
            {
                case "7":
                    return "Data/UploadTest";

                case "1":
                    return "Data/ThongTinDoanhNghiep/Image/";
                case "2":
                    return "Data/ThongTinDoanhNghiep/Doc/";
                case "3":
                    return "Data/ThongTinDoanhNghiep/Logo/";
                case "4":
                    return "Data/ThongTinHopTac/Image/";
                case "5":
                    return "Data/ThongTinHopTac/Doc/";
                case "6":
                    return "Data/ThongTinLoi/Doc/";

                case "bug":
                    return "~/Data/bug";
                case "othertask":
                    return "~/Data/othertask";
                default:
                    return "";
            }
        }
        public static string[] url_Image = new string[] { GetPathUpload("bug") + "/" + sizeImage_W[0] + "-" + sizeImage_H[0] + "/" };
        public static int[] sizeImage_W { get { return new int[] { 250 }; } }
        public static int[] sizeImage_H { get { return new int[] { 300 }; } }
        public static int[] sizeImage_Q { get { return new int[] { 100 }; } }
        #endregion

        #region Cac Tac vu


        public static string TACVU_LOADDULIEU { get { return "LoadDuLieu"; } }
        public static string TACVU_ADD { get { return "ADD"; } }
        public static string TACVU_EDIT { get { return "EDIT"; } }
        public static string TACVU_DEL { get { return "DEL"; } }
        public static string TACVU_REFRESH { get { return "REFRESH"; } }
        public static string TACVU_REFRESH_INSIDETAB { get { return "REFRESHINSIDE"; } }
        public static string TACVU_SHOWMONMIENGIAM { get { return "SHOWMONMIENGIAM"; } } //hoadm add 17062015
        public static string TACVU_SHOWPRINTPREVIEW { get { return "SHOWPRINTPREVIEW"; } } //hoadm add 17062015
        public static string TACVU_SHOWKHOASINHVIEN { get { return "SHOWKHOASINHVIEN"; } }
        public static string TACVU_LOADDULIEU_ITEM { get { return "LoadItem"; } }
        #endregion

        #region Ten cac truong du lieu tuong ung tren table database
        //Dinh dang [SAM]_[FIELDNAME]
        #region Dung chung
        public static string SAM_ISACTIVE { get { return "IsActive"; } }
        public static string SAM_LEVEL { get { return "Level"; } }
        public static string SAM_NGAYAPDUNG { get { return "NgayApDung"; } }
        public static string SAM_UPDATEDDATE { get { return "UpdatedDate"; } }

        public static Guid Catology_NganhNghe { get { return new Guid("273DAFD0-B35B-4636-AEC5-3870A29CB8DB"); } }   //Nam add 16042015
        public static Guid Catology_LinhVuc { get { return new Guid("FE38FD34-E6FD-47EE-B07F-3D7FEF5E2D65"); } }     //Nam add 16042015
        public static Guid Catology_TrangThai { get { return new Guid("B526C783-A439-4CDD-95AC-BAF8EA44BC08"); } }   //Nam add 16042015
        public static Guid Catology_LoaiHinh { get { return new Guid("FED70557-0C3E-4923-9441-7F893A086A89"); } }    //Nam add 16042015
        public static Guid Catology_Tinh { get { return new Guid("FA1EED47-FEF4-4DBA-B794-6E2C32AD63CB"); } }        //Nam add 16042015
        public static Guid Catology_Tinh_TPHCM { get { return new Guid("27a85315-87ea-48f8-bc97-9e5c90385ee1"); } }        //Ngoc add 

        public static Guid Catology_QuocGia { get { return new Guid("FA28021A-8DD4-42E5-A037-6CC029337FDB"); } }     //Nam add 16042015
        public static Guid Catology_QuyMo { get { return new Guid("9B1493BC-32E6-42CB-880F-4B7A3D8F0563"); } }       //Nam add 16042015
        public static Guid Catology_DoiTuong { get { return new Guid("a38c6e6a-09a7-4bd3-a5b4-46c76d4d3056"); } }       //Nam add 20042015 
        public static Guid Catology_Root { get { return new Guid("0c7874c2-5221-4753-a533-ba5069b1d37a"); } }
        //chuongtv 200415
        public static Guid CATOLOGY_HINHTHUCTAITRO { get { return new Guid("194382E5-3494-4427-A340-C8252620D436"); } }
        public static Guid CATOLOGY_HINHTHUCLAMVIEC { get { return new Guid("DA993E17-DC07-45B2-84F1-971F88D9BB22"); } }
        public static Guid CATOLOGY_DOITUONGTAITRO { get { return new Guid("A38C6E6A-09A7-4BD3-A5B4-46C76D4D3056"); } }
        public static Guid CATOLOGY_DOITUONGTUYENDUNG { get { return new Guid("F2D65250-82D0-44F7-9FA5-712C40176F3B"); } } //HoaDM add 08052015
        public static Guid CATOLOGY_DOITUONGTHUCTAP { get { return new Guid("235EC154-4370-48B3-BDC6-7BC09FF5F346"); } } //HoaDM add 08052015


        public static Guid CATOLOGY_LOAIHOPTAC_THUCTAP { get { return new Guid("cbfca483-5e44-4a6e-916b-16a45a5c63bf"); } }
        public static Guid CATOLOGY_LOAIHOPTAC_HOTRO { get { return new Guid("7aaf1c69-8a5a-4fef-843f-81c0030b8e7f"); } }
        public static Guid CATOLOGY_LOAIHOPTAC_TUYENDUNG { get { return new Guid("cf1cda6d-273c-4d9a-b944-7c110b5982d2"); } }
        public static Guid CATOLOGY_LOAIHOPTAC_HOCBONG { get { return new Guid("26adf09d-adf6-4882-86c7-b9bc41b19374"); } }

        public static Guid CATOLOGY_LOAI_VANBANMINHCHUNG { get { return new Guid("842D98E2-BDEF-4013-A936-8AD96DE63E67"); } }
        public static Guid CATOLOGIES_LOAI_HINHANHHOATDONG { get { return new Guid("04695870-DED7-4311-8BF9-941E3DF30781"); } }
        public static Guid CATOLOGY_LOAI_VITRITUYENDUNG { get { return new Guid("887ade3b-3901-4625-958b-d2ffea1b2a83"); } }




        public static string URL_REDIRECTTHONGTINHOPTAC { get { return "Page/10042014_HDHTDoanhNghiep/FolderQuanLyHopTac/PageQuanLyThongTinHopTac.aspx"; } }
        public static string URL_REDIRECTCHITIETDOANHNGHIEP { get { return "Page/10042014_HDHTDoanhNghiep/FolderThongTinHopTac/PageThongTinhopTac.aspx"; } }

        public static string URL_REDIRECTHEMTHONGTINCHITIETDN { get { return "Page/10042014_HDHTDoanhNghiep/FolderDoanhNghiep/PageThemDoanhNghiep.aspx"; } }

        public static string DIF_TACVU_THEMFILEDINHKEM { get { return "THEMFILEDINHKEM"; } }
        public static string DIF_TACVU_XOAFILEDINHKEM { get { return "XOAFILEDINHKEM"; } }
        public static string DIF_TACVU_SAVEALL { get { return "SAVEALL"; } }
        public static string DIF_TACVU_LOADCTDT { get { return "LOADCTDT"; } }

        //HoaDM 20042015
        public static Guid Catology_ThongTinHopTac { get { return new Guid("1590EB9F-9A35-4385-9092-2DB377A0D808"); } }
        //thanhdai18ht
        public static Guid PhanQuyenQuanLyDoanhNghiep_Root { get { return new Guid("0c7874c2-5221-4753-a533-ba5069b1d37a"); } }
        //chuongtv
        public static Guid PhanQuyenQuanLyMienGiamHocPhan_Root { get { return new Guid("0c7874c2-5221-4753-a533-ba5069b1d37a"); } }

        //Hình ảnh mặc định
        public static string URL_NOAVATAR { get { return "Resources/img/no-avatar.png"; } }   //HoaDM added 25042015
        public static string URL_NOLOGO { get { return "Resources/img/no-logo.png"; } }       //HoaDM added 25042015
        public static string URL_NOIMAGE { get { return "Resources/img/no-image.png"; } }     //HoaDM added 25042015
        public static string URL_NOFILE { get { return "Resources/img/no-file.png"; } }       //HoaDM added 25042015
        #endregion

        #region Thong bao

        /// <summary>
        /// phat sinh ra do chuyen doi convert bi loi dinh dang truyen vao
        /// </summary>
        public static string THONGBAO_LOICHUYENDOIDINHDANG { get { return "Lỗi! chuyển đổi định dạng thất bại, vui lòng load lại trang"; } }    //chuongtv 2004
        /// <summary>
        /// thong bao thanh cong cho lan luu data
        /// </summary>
        public static string THONGBAO_LUUDATATHANHCONG { get { return "Thành công! hoàn tất thực hiện lưu dữ liệu"; } }                         //chuongtv 2004
        /// <summary>
        /// Loi phat sinh ra khi luu data xuong that bai
        /// </summary>
        public static string THONGBAO_LUUDATATHATBAI { get { return "Thất bại! không thêm được dữ liệu vào cơ sở dữ liệu"; } }                  //chuongtv 2004
        /// <summary>
        /// Loi nay phat sinh ra khi luu thanh cong nhung bi mat queryString
        /// </summary>
        public static string THONGBAO_LOILIENHEQUANTRI { get { return "Lỗi! lưu thành công nhưng chuyển trang thất bại, vui lòng liên hệ quản trị"; } }

        /// <summary>
        /// thong bao khi thuc hien tim kiem van ban nhung khong nhap tu khoa tim kiem
        /// </summary>
        public static string THONGBAO_CHUACOTUKHOATIMKIEM { get { return "Vui lòng nhập vào từ khóa bạn muốn tìm"; } }

        /// <summary>
        /// thong bao khi chua du 3 tu khoa
        /// </summary>
        public static string THONGBAO_SOKYTUTIMKIEMKHONGDU { get { return "Vui lòng nhập nhiều hơn 3 ký tự để tìm kiếm"; } }

        /// <summary>
        /// xoa file thanh cong
        /// </summary>
        public static string THONGBAO_XOAFILETHANHCONG { get { return "Xóa file thành công"; } }

        /// <summary>
        /// xoa file that bai
        /// </summary>
        public static string THONGBAO_XOAFILETHATBAI { get { return "Xóa file thất bại"; } }


        public static string THONGBAO_KHONGCOCHUYENNGANHCHUYENSAU { get { return "Không có chuyên ngành chuyên sâu"; } }

        #endregion

        //Dinh dang [DIF]_[TABLE]_[FIELDNAME]
        #region table name...

        public static string DIF_CATOLOGY_CATOLOGYNAME { get { return "CatologyName"; } }                  //chuongtv 2004
        public static string DIF_CATOLOGY_CATOLOGYGUID { get { return "CatologyGuid"; } }                  //chuongtv 2004

        #endregion

        #endregion


        public static string CACHE_CHUONGTRINHDAOTAO { get { return "CHUONGTV_CACHE_CHUONGTRINHDAOTAO"; } }


        #region MVC task
        public static string CHUONGTV_VALUE_BOLOC_NGAYMAI { get { return "NgayMai"; } }
        public static string CHUONGTV_VALUE_BOLOC_HOMNAY { get { return "HomNay"; } }
        public static string CHUONGTV_VALUE_BOLOC_HOMQUA { get { return "HomQua"; } }
        public static string CHUONGTV_VALUE_BOLOC_TUANNAY { get { return "TuanNay"; } }
        public static string CHUONGTV_VALUE_BOLOC_THANGNAY { get { return "ThangNay"; } }
        public static string CHUONGTV_VALUE_BOLOC_THANGTRUOC { get { return "ThangTruoc"; } }
        public static string CHUONGTV_VALUE_BOLOC_NAM { get { return "BaoCaoNam"; } }
        public static string CHUONGTV_VALUE_BOLOC_THANG { get { return "BaoCaoThang"; } }

        public static DateTime GetDateTimeNowDefault()
        {
            DateTime temp = DateTime.Now;
            DateTime temp2 = new DateTime(temp.Year, temp.Month, temp.Day, temp.Hour, temp.Minute, temp.Second);
            return new DateTime(temp.Year, temp.Month, temp.Day, temp.Hour, temp.Minute, temp.Second);
        }
        public static void GetFormAndToDate(string loai, out string fromD, out string toD)
        {
            DateTime templ = GetDateTimeNowDefault();

            if (loai.Equals(CHUONGTV_VALUE_BOLOC_NGAYMAI))
            {
                fromD = toD = templ.AddDays(1).ToString(FORMAT_DATETIME);
                return;
            }
            if (loai.Equals(CHUONGTV_VALUE_BOLOC_HOMNAY))
            {
                fromD = toD = GetDateTimeNowDefault().ToString(FORMAT_DATETIME);
                return;
            }
            if (loai.Equals(CHUONGTV_VALUE_BOLOC_HOMQUA))
            {
                fromD = toD = templ.AddDays(-1).ToString(FORMAT_DATETIME);
                return;
            }
            if (loai.Equals(CHUONGTV_VALUE_BOLOC_TUANNAY))
            {
                int delta = DayOfWeek.Monday - templ.DayOfWeek;
                if (delta > 0)
                    delta -= 7;
                DateTime firstDayOfWeek = templ.AddDays(delta);
                DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6);
                fromD = firstDayOfWeek.ToString(FORMAT_DATETIME);
                toD = lastDayOfWeek.ToString(FORMAT_DATETIME);
                return;
            }
            if (loai.Equals(CHUONGTV_VALUE_BOLOC_THANGNAY))
            {
                DateTime firstDayOfMonth = new DateTime(templ.Year, templ.Month, 1);
                DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                fromD = firstDayOfMonth.ToString(FORMAT_DATETIME);
                toD = lastDayOfMonth.ToString(FORMAT_DATETIME);
                return;
            }
            if (loai.Equals(CHUONGTV_VALUE_BOLOC_THANGTRUOC))
            {
                templ = templ.AddMonths(-1);
                DateTime firstDayOfMonth = new DateTime(templ.Year, templ.Month, 1);
                DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                fromD = firstDayOfMonth.ToString(FORMAT_DATETIME);
                toD = lastDayOfMonth.ToString(FORMAT_DATETIME);
                return;
            }

            fromD = "";
            toD = "";
        }


        #endregion

        public static string GetBug(string p)
        {
            string tem = string.IsNullOrEmpty(p) ? "" : p.ToString().Trim();
            switch (tem)
            {
                case "15": return "fa-question text-warning";
                case "16": return "fa-bug text-navy";
                default:
                    return "";
            }
        }

        public static string GetStatus(string p)
        {
            string tem = string.IsNullOrEmpty(p) ? "" : p.ToString().Trim();
            switch (tem)
            {
                case "4": return "";
                case "5": return "<i class='fa fa-circle text-primary'></i>";
                case "6": return "<i class='fa fa-circle text-warning'></i>";
                case "7": return "<i class='fa fa-circle text-info'></i>";
                case "8": return "<i class='fa fa-circle text-danger'></i>";
                case "9": return "<i class='fa fa-circle text-cancle'></i>";
                case "10": return "<i class='fa fa-circle text-cancle'></i>";
                default:
                    return "";
            }
        }

        public static string GetPriority(string p)
        {

            string tem = string.IsNullOrEmpty(p) ? "" : p.ToString().Trim();
            switch (tem)
            {
                case "11": return "<i class='fa fa-flag text-navy'></i>";
                case "12": return "<i class='fa fa-flag text-danger'></i>";
                case "13": return "<i class='fa fa-flag text-primary'></i>";
                case "14": return "<i class='fa fa-flag text-warning'></i>";
                default:
                    return "";
            }
        }

        #region thanhdai thêm

        public static string TuyenDung_VALUE_EDITORLIENHE_DEFAUL
        {
            get
            {
                return @"<p>Mô tả công việc:</p>
                        <p>Yêu cầu tuyển dụng:</p>
                        <p>Quyền lợi:</p>
                        <p>Hồ sơ:</p>
                        ";
            }
        }
        public static string GetStatusName(string p)
        {
            string tem = string.IsNullOrEmpty(p) ? "" : p.ToString().Trim();
            switch (tem)
            {
                case "4": return "Nomal";
                case "5": return "Done";
                case "6": return "Late";
                case "7": return "In progress";
                case "8": return "Not responding";
                case "9": return "Cancel";
                case "10": return "Lock";
                default:
                    return "";
            }
        }
        public static string GetStatusColor(string p)
        {
            string tem = string.IsNullOrEmpty(p) ? "" : p.ToString().Trim();
            switch (tem)
            {
                case "4": return "";
                case "5": return "primary";
                case "6": return "warning";
                case "7": return "info";
                case "8": return "danger";
                case "9": return "cancle";
                case "10": return "cancle";
                default:
                    return "";
            }
        }


        public static string BuildSymbol(object item)
        {
            int count = 1;
            try
            {
                count = Convert.ToInt32(item);
            }
            catch (Exception)
            {
            }

            string temp = string.Empty;

            if (count > 1)
                temp = "|";
            for (int i = 1; i < count; i++)
                temp = temp + "___";
            return temp = temp + " ";
        }
        #endregion


        #region HoaDM added 07072015
        //public static string HOADM_VALUE_EDITORLIENHE_DEFAUL { get { return "<p>Ph&ograve;ng ban:</p>    <p>Chức danh:</p>    <p>Điện thoại:</p>    <p>Email:</p>    <p>Địa chỉ:</p>    <p>&nbsp;</p>  "; } }
        public static string HOADM_VALUE_EDITORLIENHE_DEFAUL
        {
            get
            {
                return @"<p>Chức danh: </p>

                        <p><strong>Ph&ograve;ng ban: </strong><br />
                        Email: <br />
                        Điện thoại: </p>
                        ";
            }
        }
        public static string GetChiTietLienHe(string thongTinLienHe, string loaiThongTin)
        {
            string showReturn = "";
            string[] str = thongTinLienHe.Split(';');
            for (int i = 0; i < 9; i++)
            {
                if (str[i].ToUpper().Equals("NONE"))
                    str[i] = "";
            }

            switch (loaiThongTin)
            {
                case "name":
                    if (!str[6].ToUpper().Equals(""))
                        showReturn += @"" + str[6] + ". ";
                    else
                        showReturn += @"";
                    showReturn += str[2] + " " + str[1] + @"";
                    break;
                case "email":
                    showReturn += str[3] + @"";
                    break;
                case "phone":
                    showReturn += str[5] + @"";
                    break;
                default:
                    break;
            }
            return showReturn;
        }
        public static string HOADM_VALUE_STRINGFILTER_DEFAUL
        {
            get
            {
                return "________"; //8
                //cập nhật thêm nếu thêm trường tìm kiếm vào hàm GetDataFilter trong hoa.js
                // position 0: textbox key search, id textbox truyen vao
                //quan ly tuyen dung
                //position 1: doanhnghiepguid
                //position 2: tungay
                //position 3: denngay
                //position 5: doituongthamgiaguid
                //position 6: hinhthuclamviecguid
                //position 7: vitrituyendungguid

                //danh sach doanh nghiep
                //position 4: nganhngheguid
            }
        }
        public static string STRING_GUIDEMPTY
        {
            get
            {
                return "00000000-0000-0000-0000-000000000000";               
            }
        }
        public static string PW_DEFAULT
        {
            get
            {
                return "AGarDH0+ygYLmyKQ9sDA+wGwKbWXPvdh9zeC9m1/o0J7aNhe23lGx5uPg2YzkbwS/g==";
            }
        }
        #endregion
    }
}