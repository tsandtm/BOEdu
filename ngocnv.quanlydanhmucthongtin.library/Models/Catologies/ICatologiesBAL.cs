

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nvn.Library.Patterns.MVP;

namespace ngocnv10052014.catology.library.Models
{
    public interface ICatologieBAL : IBaseBAL
    {
        bool Delete(Guid catologyGuid);
        Guid Save(Catologie item);
        Catologie GetCatologie(Guid catologyGuid);
        Catologie GetCatologie(int catologyID);
        List<Catologie> GetPage(int pageNumber, int pageSize, out int totalPages);
        List<Catologie> GetPage(Guid rootGuid, int isActive, int pageNumber, int pageSize, out int totalPages);
        List<Catologie> GetAll();

        /// <summary>
        /// Get tat ca cac item 1 cap la con cua guid truyen vao
        /// </summary>
        /// <param name="ValueGuid">guid cha</param>
        /// <param name="IsActive">trang thai get 1 0 -1</param>
        /// <returns></returns>
        //List<Catologie> GetAllDanhMuc_TheoDanhMucCha(Guid ValueGuid,int IsActive);
        //Guid GetDanhMucGuid_ByLoaiDanhMucGuid(Guid ValueGuid);
        //bool Delete_ByLoaiDanhMucGuid(Guid ValueGuid);

        /// <summary>
        /// Get tat ca con dua vao guid cha truyen vao. trang thai get 1 0 -1
        /// </summary>
        /// <returns></returns>
        List<Catologie> GetAllCatologies(Guid ValueGuid,int active);

        bool SaveFileThumbnail(Guid GuidCatology, string FileNameThumbnail);

        int GetMaxPositionByKindGuid(Guid Kindguid);

        Guid CreateImport(Catologie sv);

        bool CheckExistUser(Catologie itemSP);

        List<Catologie> GetAllCatologiesByUserID(int user);

        List<Catologie> GetAllCatologiesByUserIDNotChilrend(int user, Guid q);
    }
}



