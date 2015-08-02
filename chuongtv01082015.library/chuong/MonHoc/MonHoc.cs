using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chuongtv01082015.library.chuong
{
    public class MonHoc
    {
        public MonHoc() { }
        public MonHoc(Guid m,string i) {
            MonHocGuid = m;
            MonHocName = i;
        }

        #region Public Properties
        public Guid MonHocGuid { get; set; }
        public string MonHocName { get; set; }
        public string MonHocID { get; set; }
        public int Userid { get; set; }
        public int SoBuoiGiangDay { get; set; }

        // them danh sach giang day
        public List<BuoiGiangDay> DanhSachBuoiGiangDay { get; set; }
        public Guid BuoiGiangGuid { get; set; }
        public string BuoiGiangID { get; set; }
        public string BuoiGiangName { get; set; }

        public string ClientFileName { get; set; }
        public string ServerFileName { get; set; }
        public string FileSize { get; set; }
        public Guid FileSystemGuid { get; set; }

        #endregion
    }
}
