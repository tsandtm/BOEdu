
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nvn.Library.Patterns.MVP;

namespace chuongtv01082015.library.chuong
{
    public interface IBuoiGiangDayBAL : IBaseBAL
    {
        bool Delete(Guid buoiGiangGuid);
        Guid Save(BuoiGiangDay item);
        BuoiGiangDay GetBuoiGiangDay(Guid buoiGiangGuid);
        List<BuoiGiangDay> GetPage(int pageNumber, int pageSize, out int totalrow);
        List<BuoiGiangDay> GetAll();
        int GetCount();

        BuoiGiangDay GetOne(Guid fileguid);

        List<BuoiGiangDay> GetAllByMonGuidAndUser(Guid MonGuida, int p);

        bool ShareDocForStudent(Guid buoiguid, Guid monguid);
    }
}


