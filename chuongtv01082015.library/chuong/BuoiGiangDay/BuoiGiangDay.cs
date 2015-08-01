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

        public string linkTaiLieu { get; set; }
        #endregion
    }
}
