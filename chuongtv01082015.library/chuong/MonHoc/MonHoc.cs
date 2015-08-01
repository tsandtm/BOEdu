using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chuongtv01082015.library.chuong
{
    public class MonHoc
    {
        #region Public Properties
        public Guid MonHocGuid { get; set; }
        public string MonHocName { get; set; }
        public string MonHocID { get; set; }
        public Guid GiangVienGuid { get; set; }
        public int SoBuoiGiangDay { get; set; }

        // them danh sach giang day
        public List<BuoiGiangDay> DanhSachBuoiGiangDay { get; set; }
        public Guid BuoiGiangGuid { get; set; }
        public string BuoiGiangID { get; set; }
        public string BuoiGiangName { get; set; }

        public string LinkUrl { get; set; }
        #endregion
    }
}
