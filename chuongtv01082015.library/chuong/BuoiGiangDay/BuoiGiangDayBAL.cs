
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace chuongtv01082015.library.chuong
{
    public class BuoiGiangDayBAL : IBuoiGiangDayBAL
    {
        #region Private Methods
        private Guid Create(BuoiGiangDay item)
        {
            BuoiGiangDayDAL itemDAL=new BuoiGiangDayDAL();
            item.BuoiGiangGuid = Guid.NewGuid();
            int rowsAffected = itemDAL.Create(item);
            return rowsAffected > 0 ? item.BuoiGiangGuid : Guid.Empty;
        }
        private Guid Update(BuoiGiangDay item)
        {
            BuoiGiangDayDAL itemDAL=new BuoiGiangDayDAL();
            return itemDAL.Update(item) ? item.BuoiGiangGuid : Guid.Empty;
        }
        #endregion

        #region public Methods

        /// <summary>
        /// Deletes an instance of BuoiGiangDay. Returns true on success.
        public bool Delete(Guid buoiGiangGuid)
        {
            BuoiGiangDayDAL itemDAL=new BuoiGiangDayDAL();
            return itemDAL.Delete(buoiGiangGuid);
        }

        // <summary>
        /// Saves this instance of BuoiGiangDay. Returns a new Guid on success.
        /// </summary>
        public Guid Save(BuoiGiangDay item)
        {
            if (item.BuoiGiangGuid == Guid.Empty)
                return Create(item);
            return Update(item);
        }

        /// <summary>
        /// Gets an instance of BuoiGiangDay.
        /// </summary>
        /// <param name="buoiGiangGuid"> buoiGiangGuid </param>
        public BuoiGiangDay GetBuoiGiangDay(Guid buoiGiangGuid)
        {
            BuoiGiangDayDAL itemDAL=new BuoiGiangDayDAL();
            using (IDataReader reader = itemDAL.GetOne(buoiGiangGuid))
            {
                return BuoiGiangDayDTO.PopulateFromReader(reader);
            }
        }

        /// <summary>
        /// Gets an IList with page of instances of BuoiGiangDay.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public List<BuoiGiangDay> GetPage(int pageNumber, int pageSize,out int totalrow )
        {
            totalrow = 0;
            BuoiGiangDayDAL itemDAL=new BuoiGiangDayDAL();
            IDataReader reader = itemDAL.GetPage(pageNumber, pageSize,out totalrow);
            return BuoiGiangDayDTO.LoadListFromReader(reader);
        }
        public int GetCount()
        {
            BuoiGiangDayDAL itemDAL=new BuoiGiangDayDAL();
            return itemDAL.GetCount();
        }

        /// <summary>
        /// Gets an IList with all instances of BuoiGiangDay.
        /// </summary>
        public List<BuoiGiangDay> GetAll()
        {
            BuoiGiangDayDAL itemDAL=new BuoiGiangDayDAL();
            IDataReader reader = itemDAL.GetAll();
            return BuoiGiangDayDTO.LoadListFromReader(reader);
        }
        #endregion
    }
}

