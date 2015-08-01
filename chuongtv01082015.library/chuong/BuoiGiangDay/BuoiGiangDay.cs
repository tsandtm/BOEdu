using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
	
namespace chuongtv01082015.library.chuong
{
	public class BuoiGiangDay
    {
        #region Public Properties
        public  Guid  BuoiGiangGuid { get ; set ;}
        public  string  BuoiGiangID { get ; set ;}
        public  string  BuoiGiangName { get ; set ;}
        public  Guid  MonHocGuid { get ; set ;}

        public string ClientFileName { get; set; }
        public string ServerFileName { get; set; }
        public string FileSize { get; set; }
        public Guid FileSystemGuid { get; set; }

        #endregion
    }
}
