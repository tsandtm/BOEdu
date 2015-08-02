using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using nvn.Library.Helpers;

namespace chuongtv01082015.library.chuong
{
    public class UsersBAL : IUsersBAL
    {

        #region Private Methods
        private int Create(Users item)
        {
            int rowsAffected = UsersDAL.Create(item);
            item.UserId = rowsAffected;
            return rowsAffected > 0 ? item.UserId : 0;
        }
        private int Update(Users item)
        {
            return UsersDAL.Update(item) ? item.UserId : 0;
        }
        #endregion

        #region public Methods

        /// <summary>
        /// Deletes an instance of Users. Returns true on success.
        public bool Delete(int userID)
        {
            return UsersDAL.Delete(userID);
        }

        // <summary>
        /// Saves this instance of Users. Returns a new Guid on success.
        /// </summary>
        public int Save(Users item)
        {
            if (item.UserId == 0)
                return Create(item);
            return Update(item);
        }

        /// <summary>
        /// Gets an instance of Users.
        /// </summary>
        /// <param name="userGuid"> userGuid </param>
        public Users GetUsers(int userID)
        {
            using (IDataReader reader = UsersDAL.GetOne(userID))
            {
                return UsersDTO.PopulateFromReader(reader);
            }
        }

        /// <summary>
        /// Gets an IList with page of instances of Users.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</par
        public List<Users> GetPage(int pageNumber, int pageSize, out int totalPages, string q)
        {
            totalPages = 1;
            IDataReader reader = UsersDAL.GetPage(pageNumber, pageSize, out totalPages, q);
            return UsersDTO.LoadListFromReader(reader);
        }
        public int GetCount(string q)
        {
            return UsersDAL.GetCount(q);
        }

        /// <summary>
        /// Gets an IList with all instances of Users.
        /// </summary>
        public List<Users> GetAll(string q)
        {
            IDataReader reader = UsersDAL.GetAll(q);
            return UsersDTO.LoadListFromReader(reader);
        }
        #endregion

        public bool ResetPass(int userID, string p)
        {
            return UsersDAL.ResetPass(userID, p);
        }

        public List<Users> GetListUserByKeysearch(string keysearch)
        {
            IDataReader reader = UsersDAL.GetListUserByKeysearch(keysearch);
            return UsersDTO.LoadListFromReader(reader);
        }

        public List<Users> GetListFollowerById(int userlogin)
        {
            IDataReader reader = UsersDAL.GetListFollowerById(userlogin);
            return UsersDTO.LoadListFromReaderFollowlist(reader);
        }
        public bool CapNhapDanhSachFollower(int userlogin, int id)
        {
            return UsersDAL.CapNhapDanhSachFollower(userlogin, id);
        }
    }
}


