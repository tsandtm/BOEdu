
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nvn.Library.Patterns.MVP;

namespace chuongtv01082015.library.chuong
{
    public interface IMonHocBAL : IBaseBAL
    {
        bool Delete(Guid monHocGuid);
        Guid Save(MonHoc item);
        MonHoc GetMonHoc(Guid monHocGuid);
        List<MonHoc> GetPage(int pageNumber, int pageSize, out int totalrow);
        List<MonHoc> GetAll();
        int GetCount();

        List<MonHoc> GetAllMonHocTheoGiangVien(int Userid);

        bool DeleteLinkURL(Guid monhoc);

        bool ThemTaiLieuVaoCapDienTu(Guid fileguid, int userlogin);
    }
}


