
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace chuongtv01082015.library.chuong
{
    public class MonHocBAL : IMonHocBAL
    {
        #region Private Methods
        private Guid Create(MonHoc item)
        {
            MonHocDAL itemDAL = new MonHocDAL();
            item.MonHocGuid = Guid.NewGuid();
            int rowsAffected = itemDAL.Create(item);
            return rowsAffected > 0 ? item.MonHocGuid : Guid.Empty;
        }
        private Guid Update(MonHoc item)
        {
            MonHocDAL itemDAL = new MonHocDAL();
            return itemDAL.Update(item) ? item.MonHocGuid : Guid.Empty;
        }
        #endregion

        #region public Methods

        /// <summary>
        /// Deletes an instance of MonHoc. Returns true on success.
        public bool Delete(Guid monHocGuid)
        {
            MonHocDAL itemDAL = new MonHocDAL();
            return itemDAL.Delete(monHocGuid);
        }

        // <summary>
        /// Saves this instance of MonHoc. Returns a new Guid on success.
        /// </summary>
        public Guid Save(MonHoc item)
        {
            if (item.MonHocGuid == Guid.Empty)
                return Create(item);
            return Update(item);
        }

        /// <summary>
        /// Gets an instance of MonHoc.
        /// </summary>
        /// <param name="monHocGuid"> monHocGuid </param>
        public MonHoc GetMonHoc(Guid monHocGuid)
        {
            MonHocDAL itemDAL = new MonHocDAL();
            using (IDataReader reader = itemDAL.GetOne(monHocGuid))
            {
                return MonHocDTO.PopulateFromReader(reader);
            }
        }

        /// <summary>
        /// Gets an IList with page of instances of MonHoc.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public List<MonHoc> GetPage(int pageNumber, int pageSize, out int totalrow)
        {
            totalrow = 0;
            MonHocDAL itemDAL = new MonHocDAL();
            IDataReader reader = itemDAL.GetPage(pageNumber, pageSize, out totalrow);
            return MonHocDTO.LoadListFromReader(reader);
        }
        public int GetCount()
        {
            MonHocDAL itemDAL = new MonHocDAL();
            return itemDAL.GetCount();
        }

        /// <summary>
        /// Gets an IList with all instances of MonHoc.
        /// </summary>
        public List<MonHoc> GetAll()
        {
            MonHocDAL itemDAL = new MonHocDAL();
            IDataReader reader = itemDAL.GetAll();
            return MonHocDTO.LoadListFromReader(reader);
        }
        #endregion


        public List<MonHoc> GetAllMonHocTheoGiangVien(int Userid)
        {
            MonHocDAL itemDAL = new MonHocDAL();
            IDataReader reader = itemDAL.GetAllMonHocTheoGiangVien(Userid);
            return MonHocDTO.LoadListFromReaderForList(reader);
        }


        public bool DeleteLinkURL(Guid monhoc)
        {

            MonHocDAL itemDAL = new MonHocDAL();
            return itemDAL.DeleteLinkURL(monhoc);
        }


        public bool ThemTaiLieuVaoCapDienTu(Guid fileguid, int userlogin)
        {
            MonHocDAL itemDAL = new MonHocDAL();
            return itemDAL.ThemTaiLieuVaoCapDienTu(fileguid, userlogin);
        }
    }
}

