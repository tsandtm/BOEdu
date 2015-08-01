

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using nvn.Library.Patterns.MVP;
using project.config.library;
using nvn.Library.Helpers;

namespace _project.library.hoa
{
    public static class UsersDAL
    {
        /// <summary>
        /// Inserts a row in the UserProfile table. Returns rows affected count.
        /// </summary>
        /// <returns>int</returns>
        public static int Create(Users item)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "UserProfile_hoadm01082015_Insert", 8);
            //sph.DefineSqlParameter("@UserID", SqlDbType.Int, ParameterDirection.Input, item.UserId);
            sph.DefineSqlParameter("@UserName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.UserName);
            sph.DefineSqlParameter("@AvatarExt", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.AvatarExt);
            sph.DefineSqlParameter("@NgaySinh", SqlDbType.DateTime, ParameterDirection.Input, item.NgaySinh);
            sph.DefineSqlParameter("@DienThoai", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.DienThoai);
            sph.DefineSqlParameter("@DiaChi", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.DiaChi);
            //sph.DefineSqlParameter("@Password", SqlDbType.NVarChar, 50, ParameterDirection.Input, item.Password);
            sph.DefineSqlParameter("@CreatedUser", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.CreatedUser);
            sph.DefineSqlParameter("@CreatedDate", SqlDbType.DateTime, ParameterDirection.Input, item.CreatedDate);
            //sph.DefineSqlParameter("@UpdatedUser", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.UpdatedUser);
            //sph.DefineSqlParameter("@UpdatedDate", SqlDbType.DateTime, ParameterDirection.Input, item.UpdatedDate);
            sph.DefineSqlParameter("@FullName", SqlDbType.NVarChar, 25, ParameterDirection.Input, item.FullName);

            int rowsAffected =Convert.ToInt32(sph.ExecuteScalar());
            return rowsAffected;
        }

        /// <summary>
        /// Updates a row in the UserProfile table. Returns true if row updated.
        /// </summary>
        /// <returns>bool</returns>
        public static bool Update(Users item)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "UserProfile_hoadm01082015_Update", 9);
            sph.DefineSqlParameter("@UserID", SqlDbType.Int, ParameterDirection.Input, item.UserId);
            sph.DefineSqlParameter("@UserName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.UserName);
            sph.DefineSqlParameter("@AvatarExt", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.AvatarExt);
            sph.DefineSqlParameter("@NgaySinh", SqlDbType.DateTime, ParameterDirection.Input, item.NgaySinh);
            sph.DefineSqlParameter("@DienThoai", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.DienThoai);
            sph.DefineSqlParameter("@DiaChi", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.DiaChi);
            //sph.DefineSqlParameter("@Password", SqlDbType.NVarChar, 50, ParameterDirection.Input, item.Password);
            sph.DefineSqlParameter("@UpdateUser", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.UpdatedUser);
            sph.DefineSqlParameter("@UpdatedDate", SqlDbType.DateTime, ParameterDirection.Input, item.UpdatedDate);
            sph.DefineSqlParameter("@FullName", SqlDbType.NVarChar, 25, ParameterDirection.Input, item.FullName);

            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);
        }

        /// <summary>
        /// Deletes a row from the UserProfile table. Returns true if row deleted.
        /// </summary>
        /// <param name="userGuid"> userGuid </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int userID)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "UserProfile_hoadm01082015_Delete", 1);
            sph.DefineSqlParameter("@UserID", SqlDbType.Int, ParameterDirection.Input, userID);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);
        }

        /// <summary>
        /// Gets an IDataReader with one row from the UserProfile table.
        /// </summary>
        /// <param name="userGuid"> userGuid </param>
        public static IDataReader GetOne(
            int userID)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "UserProfile_hoadm01082015_SelectOne", 1);
            sph.DefineSqlParameter("@UserID", SqlDbType.Int, ParameterDirection.Input, userID);
            return sph.ExecuteReader();
        }

        /// <summary>
        /// Gets a count of rows in the UserProfile table.
        /// </summary>
        public static int GetCount(string q)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "UserProfile_hoadm01082015_GetCount", 1);
            sph.DefineSqlParameter("@KeySearch", SqlDbType.NVarChar, 256, ParameterDirection.Input, q);

            return Convert.ToInt32(sph.ExecuteScalar());


        }

        /// <summary>
        /// Gets an IDataReader with all rows in the UserProfile table.
        /// </summary>
        public static IDataReader GetAll(string q)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "UserProfile_hoadm01082015_SelectAll", 1);
            sph.DefineSqlParameter("@KeySearch", SqlDbType.NVarChar, 256, ParameterDirection.Input, q);

            return sph.ExecuteReader();
        }

        /// <summary>
        /// Gets a page of data from the UserProfile table.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>      
        public static IDataReader GetPage(
           int pageNumber,
           int pageSize,
           out int totalrow,
            string q)
        {
            totalrow = 0;
            totalrow = GetCount(q);

            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "UserProfile_hoadm01082015_SelectPage", 3);
            sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
            sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
            sph.DefineSqlParameter("@KeySearch", SqlDbType.NVarChar, 256, ParameterDirection.Input, q);

            return sph.ExecuteReader();
        }



        internal static bool ResetPass(int userID, string p)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "UserProfile_hoadm01082015_ResetPass", 1);
            sph.DefineSqlParameter("@UserID", SqlDbType.Int, ParameterDirection.Input, userID);
            sph.DefineSqlParameter("@Text", SqlDbType.NVarChar, 50, ParameterDirection.Input, p);
            
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);
        }
    }

}

