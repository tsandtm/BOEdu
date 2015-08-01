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

        public static string GetPathUpload(string id)
        {
            switch (id)
            {
                case "1":
                    return "Data/ThongTinDoanhNghiep/Image/";
                case "2":
                    return "Data/ThongTinDoanhNghiep/Doc/";
                case "3":
                    return "Data/ThongTinDoanhNghiep/Logo/";
                case "4":
                    return "Data/ThongTinHocBong/Image/";
                case "5":
                    return "Data/ThongTinHocBong/Doc/";
                case "6":
                    return "Data/ThongTinLoi/Doc/";
                default:
                    return "";
            }
        }


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
        #endregion

        public static int[] sizeImage_W = { 50, 110, 250 };
        public static int[] sizeImage_H = { 59, 150, 300 };
        public static int[] sizeImage_Q = { 100, 100, 100 };

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
        public static Guid Catology_QuocGia { get { return new Guid("FA28021A-8DD4-42E5-A037-6CC029337FDB"); } }     //Nam add 16042015
        public static Guid Catology_QuyMo { get { return new Guid("9B1493BC-32E6-42CB-880F-4B7A3D8F0563"); } }       //Nam add 16042015
        public static Guid Catology_DoiTuong { get { return new Guid("a38c6e6a-09a7-4bd3-a5b4-46c76d4d3056"); } }       //Nam add 20042015 

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

        public static Guid Catologys_Root_Value { get { return new Guid("0c7874c2-5221-4753-a533-ba5069b1d37a"); } }
    }
}