
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace chuongtv01082015.library.chuong
{
    public class GiangVienBAL : IGiangVienBAL
    {
        #region Private Methods
        private Guid Create(GiangVien item)
        {
            GiangVienDAL itemDAL=new GiangVienDAL();
            item.GiangVienGuid = Guid.NewGuid();
            int rowsAffected = itemDAL.Create(item);
            return rowsAffected > 0 ? item.GiangVienGuid : Guid.Empty;
        }
        private Guid Update(GiangVien item)
        {
            GiangVienDAL itemDAL=new GiangVienDAL();
            return itemDAL.Update(item) ? item.GiangVienGuid : Guid.Empty;
        }
        #endregion

        #region public Methods

        /// <summary>
        /// Deletes an instance of GiangVien. Returns true on success.
        public bool Delete(Guid giangVienGuid)
        {
            GiangVienDAL itemDAL=new GiangVienDAL();
            return itemDAL.Delete(giangVienGuid);
        }

        // <summary>
        /// Saves this instance of GiangVien. Returns a new Guid on success.
        /// </summary>
        public Guid Save(GiangVien item)
        {
            if (item.GiangVienGuid == Guid.Empty)
                return Create(item);
            return Update(item);
        }

        /// <summary>
        /// Gets an instance of GiangVien.
        /// </summary>
        /// <param name="giangVienGuid"> giangVienGuid </param>
        public GiangVien GetGiangVien(Guid giangVienGuid)
        {
            GiangVienDAL itemDAL=new GiangVienDAL();
            using (IDataReader reader = itemDAL.GetOne(giangVienGuid))
            {
                return GiangVienDTO.PopulateFromReader(reader);
            }
        }

        /// <summary>
        /// Gets an IList with page of instances of GiangVien.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public List<GiangVien> GetPage(int pageNumber, int pageSize,out int totalrow )
        {
            totalrow = 0;
            GiangVienDAL itemDAL=new GiangVienDAL();
            IDataReader reader = itemDAL.GetPage(pageNumber, pageSize,out totalrow);
            return GiangVienDTO.LoadListFromReader(reader);
        }
        public int GetCount()
        {
            GiangVienDAL itemDAL=new GiangVienDAL();
            return itemDAL.GetCount();
        }

        /// <summary>
        /// Gets an IList with all instances of GiangVien.
        /// </summary>
        public List<GiangVien> GetAll()
        {
            GiangVienDAL itemDAL=new GiangVienDAL();
            IDataReader reader = itemDAL.GetAll();
            return GiangVienDTO.LoadListFromReader(reader);
        }
        #endregion
    }
}

