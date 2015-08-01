
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nvn.Library.Patterns.MVP;

namespace chuongtv01082015.library.chuong
{
    public interface IGiangVienBAL : IBaseBAL
    {
        bool Delete(Guid giangVienGuid);
        Guid Save(GiangVien item);
        GiangVien GetGiangVien(Guid giangVienGuid);
        List<GiangVien> GetPage(int pageNumber, int pageSize, out int totalrow);
        List<GiangVien> GetAll();
        int GetCount();
    }
}


