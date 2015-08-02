using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
	
namespace chuongtv01082015.library.chuong
{
	public class BuoiGiangDay
    {
        public BuoiGiangDay()
        {
            ListMonHoc = new List<MonHoc>();
        }

        public BuoiGiangDay(Guid MonHocGuid, string MonHocName)
        {
            this.MonHocGuid = MonHocGuid;
            this.MonHocName = MonHocName;
        }

        #region Public Properties
        public  Guid  BuoiGiangGuid { get ; set ;}
        public  string  BuoiGiangID { get ; set ;}
        public  string  BuoiGiangName { get ; set ;}
        public  Guid  MonHocGuid { get ; set ;}
        public string MonHocName { get; set; }

        public string ClientFileName { get; set; }
        public string ServerFileName { get; set; }
        public string FileSize { get; set; }
        public Guid FileSystemGuid { get; set; }

        public List<MonHoc> ListMonHoc { get; set; }
        #endregion
    }
}
