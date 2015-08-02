

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using nvn.Library.Patterns.MVP;
using project.config.library;

namespace ngocnv10052014.catology.library.Models
{
    public static class CatologieDAL
    {
        /// <summary>
        /// Inserts a row in the cont_Catologies table. Returns rows affected count.
        /// </summary>
        /// <returns>int</returns>
        public static int Create(Catologie item)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "cont_Catologies_ngocnv10052014_Insert", 10);
            sph.DefineSqlParameter("@CatologyGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.CatologyGuid);
            sph.DefineSqlParameter("@CatologyName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.CatologyName);
            sph.DefineSqlParameter("@Description", SqlDbType.NVarChar, 500, ParameterDirection.Input, item.Description);
            sph.DefineSqlParameter("@KindCatologyGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.KindCatologyGuid);
            sph.DefineSqlParameter("@KindCatologyName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.KindCatologyName);
            sph.DefineSqlParameter("@IsActive", SqlDbType.Bit, ParameterDirection.Input, item.IsActive);
            sph.DefineSqlParameter("@Position", SqlDbType.Int, ParameterDirection.Input, item.Position);
            sph.DefineSqlParameter("@ListStringToSort", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.ListStringToSort);
            sph.DefineSqlParameter("@UserName", SqlDbType.NVarChar,256, ParameterDirection.Input, item.Massv);
            sph.DefineSqlParameter("@IsNotDelete", SqlDbType.Bit, ParameterDirection.Input, item.IsNotDelete);
            int rowsAffected = sph.ExecuteNonQuery();
            return rowsAffected;
        }

        public static int CreateImport(Catologie item)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "cont_Catologies_Import_Insert", 13);
            sph.DefineSqlParameter("@CatologyGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.CatologyGuid);
            sph.DefineSqlParameter("@CatologyName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.CatologyName);
            sph.DefineSqlParameter("@Description", SqlDbType.NVarChar, 500, ParameterDirection.Input, item.Description);
            sph.DefineSqlParameter("@KindCatologyGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.KindCatologyGuid);
            sph.DefineSqlParameter("@KindCatologyName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.KindCatologyName);
            sph.DefineSqlParameter("@IsActive", SqlDbType.Bit, ParameterDirection.Input, item.IsActive);
            sph.DefineSqlParameter("@Position", SqlDbType.Int, ParameterDirection.Input, item.Position);
            sph.DefineSqlParameter("@ListStringToSort", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.ListStringToSort);
            sph.DefineSqlParameter("@UserID", SqlDbType.Int, ParameterDirection.Input, item.UserID);
            sph.DefineSqlParameter("@IsNotDelete", SqlDbType.Bit, ParameterDirection.Input, item.IsNotDelete);

            sph.DefineSqlParameter("@Role", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.Role);
            sph.DefineSqlParameter("@PassWord", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.PassWord);
            sph.DefineSqlParameter("@UsetName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.Massv);
            
            int rowsAffected = sph.ExecuteNonQuery();
            return rowsAffected;
        }
        /// <summary>
        /// Updates a row in the cont_Catologies table. Returns true if row updated.
        /// </summary>
        /// <returns>bool</returns>
        public static bool Update(string query)
        {
            int rowsAffected = SqlHelper.ExecuteNonQuery(
                ConnectionStringStatic.GetReadConnectionString(),
                CommandType.Text,
                query,
                null);

            return (rowsAffected > 0);

            //SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "cont_Catologies_ngocnv10052014_Update", 8);
            //sph.DefineSqlParameter("@CatologyGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.CatologyGuid);
            //sph.DefineSqlParameter("@CatologyName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.CatologyName);
            //sph.DefineSqlParameter("@Description", SqlDbType.NVarChar, 500, ParameterDirection.Input, item.Description);
            //sph.DefineSqlParameter("@KindCatologyGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.KindCatologyGuid);
            //sph.DefineSqlParameter("@KindCatologyName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.KindCatologyName);
            //sph.DefineSqlParameter("@IsActive", SqlDbType.Bit, ParameterDirection.Input, item.IsActive);
            //sph.DefineSqlParameter("@Position", SqlDbType.Int, ParameterDirection.Input, item.Position);
            //sph.DefineSqlParameter("@ListStringToSort", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.ListStringToSort);

            //int rowsAffected = sph.ExecuteNonQuery();
            //return (rowsAffected > 0);
        }

        /// <summary>
        /// Gets an IDataReader with one row from the cont_Catologies table.
        /// </summary>
        /// <param name="catologyGuid"> catologyGuid </param>
        public static IDataReader GetOne(
            Guid catologyGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "cont_Catologies_ngocnv10052014_SelectOne", 1);
            sph.DefineSqlParameter("@CatologyGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, catologyGuid);
            return sph.ExecuteReader();
        }
        public static IDataReader GetOne(
            int catologyID)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "cont_Catologies_ngocnv10052014_SelectOne_ByID", 1);
            sph.DefineSqlParameter("@CatologyID", SqlDbType.UniqueIdentifier, ParameterDirection.Input, catologyID);
            return sph.ExecuteReader();
        }

        /// <summary>
        /// Gets a count of rows in the cont_Catologies table.
        /// </summary>
        public static int GetCount()
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                ConnectionStringStatic.GetReadConnectionString(),
                CommandType.StoredProcedure,
                "cont_Catologies_ngocnv10052014_GetCount",
                null));
        }

        /// <summary>
        /// Gets an IDataReader with all rows in the cont_Catologies table.
        /// </summary>
        public static IDataReader GetAll()
        {
            return SqlHelper.ExecuteReader(
                ConnectionStringStatic.GetReadConnectionString(),
                CommandType.StoredProcedure,
                "cont_Catologies_ngocnv10052014_SelectAll",
                null);
        }

        /// <summary>
        /// Gets a page of data from the cont_Catologies table.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public static IDataReader GetPage(
            int pageNumber,
            int pageSize,
            out int totalPages)
        {
            totalPages = 1;
            int totalRows
                = GetCount();

            if (pageSize > 0) totalPages = totalRows / pageSize;

            if (totalRows <= pageSize)
            {
                totalPages = 1;
            }
            else
            {
                int remainder;
                Math.DivRem(totalRows, pageSize, out remainder);
                if (remainder > 0)
                {
                    totalPages += 1;
                }
            }

            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "cont_Catologies_ngocnv10052014_SelectPage", 2);
            sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
            sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
            return sph.ExecuteReader();
        }


        #region Add by tsandtm 11/3/2014
        /// <summary>
        /// Deletes a row from the cont_Catologies table. Returns true if row deleted.
        /// </summary>
        /// <param name="catologyGuid"> catologyGuid </param>
        /// <returns>bool</returns>
        public static bool Delete(
            Guid catologyGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "cont_Catologies_ngocnv10052014_Delete", 1);
            sph.DefineSqlParameter("@CatologyGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, catologyGuid);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);
        }
        public static int GetCount(Guid rootGuid, int isActive)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "cont_Catologies_ngocnv10052014_GetCount_2para", 2);
            sph.DefineSqlParameter("@RootGuid", SqlDbType.NVarChar, 256, ParameterDirection.Input, rootGuid.ToString());
            sph.DefineSqlParameter("@IsActive", SqlDbType.Int, ParameterDirection.Input, isActive);
            return Convert.ToInt32(sph.ExecuteScalar());
        }
        public static IDataReader GetPage(
            Guid rootGuid, int isActive,
            int pageNumber,
            int pageSize,
            out int totalPages)
        {
            totalPages = 1;
            int totalRows
                = GetCount(rootGuid, isActive);

            if (pageSize > 0) totalPages = totalRows / pageSize;

            if (totalRows <= pageSize)
            {
                totalPages = 1;
            }
            else
            {
                int remainder;
                Math.DivRem(totalRows, pageSize, out remainder);
                if (remainder > 0)
                {
                    totalPages += 1;
                }
            }

            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "cont_Catologies_ngocnv10052014_SelectPage_4para", 4);
            sph.DefineSqlParameter("@RootGuid", SqlDbType.NVarChar, 256, ParameterDirection.Input, rootGuid.ToString());
            sph.DefineSqlParameter("@IsActive", SqlDbType.Int, ParameterDirection.Input, isActive);
            sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
            sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
            return sph.ExecuteReader();
        }

        internal static IDataReader GetAllCatologies(Guid valueGuid, int active)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "cont_Catologies_ngocnv10052014_GetAllCatologies", 2);
            sph.DefineSqlParameter("@ValueGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, valueGuid);
            sph.DefineSqlParameter("@Active", SqlDbType.Int, ParameterDirection.Input, active);
            return sph.ExecuteReader();
        }



        internal static IDataReader GetAllDanhMuc_TheoDanhMucCha(Guid ValueGuid, int IsActive)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "cont_Catologies_ngocnv10052014_GetAllDanhMuc_TheoDanhMucCha", 2);
            sph.DefineSqlParameter("@GuidDanhMucCha", SqlDbType.UniqueIdentifier, ParameterDirection.Input, ValueGuid);
            sph.DefineSqlParameter("@IsActive", SqlDbType.Int, ParameterDirection.Input, IsActive);
            return sph.ExecuteReader();
        }

        internal static IDataReader GetDanhMucGuid_ByLoaiDanhMucGuid(Guid ValueGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "cont_Catologies_ngocnv10052014_GetDanhMucGuid_ByLoaiDanhMucGuid", 1);
            sph.DefineSqlParameter("@KindCatologyGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, ValueGuid);
            return sph.ExecuteReader();
        }

        internal static bool Delete_ByLoaiDanhMucGuid(Guid ValueGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "cont_Catologies_ngocnv10052014_Delete_ByLoaiDanhMucGuid", 1);
            sph.DefineSqlParameter("@KindCatologyGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, ValueGuid);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);
        }
        #endregion

        //tsandtm add save file thumbnail
        internal static bool SaveFile(Guid GuidCatology, string FileNameThumbnail)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "cont_Catologies_ngocnv10052014_UpdateImage", 2);
            sph.DefineSqlParameter("@CatologyGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, GuidCatology);
            sph.DefineSqlParameter("@URLHinhAnh", SqlDbType.NVarChar, 256, ParameterDirection.Input, FileNameThumbnail);
            return Convert.ToInt32(sph.ExecuteNonQuery()) > 0;
        }



        internal static int GetMaxPositionByKindGuid(Guid Kindguid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "cont_Catologies_ngocnv10052014_SelectMaxPosition", 1);
            sph.DefineSqlParameter("@KindCatologyGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, Kindguid);
            return Convert.ToInt32(sph.ExecuteScalar());
        }

        internal static bool CheckExistUser(Catologie itemSP)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "cont_UserProfile_CheckExistUser", 1);
            sph.DefineSqlParameter("@UserName", SqlDbType.NVarChar,256, ParameterDirection.Input, itemSP.Massv);
            return Convert.ToInt32(sph.ExecuteScalar())>0;
        }

        internal static IDataReader GetAllCatologiesByUserID(int user)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "cont_Catologies_GetAllCatologiesByUserID", 1);
            sph.DefineSqlParameter("@UserID", SqlDbType.NVarChar, 256, ParameterDirection.Input, user);
            return sph.ExecuteReader();
        }

        internal static IDataReader GetAllCatologiesByUserIDNotChilrend(int user, Guid q)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "cont_Catologies_GetAllCatologiesByUserIDNotChilrend", 2);
            sph.DefineSqlParameter("@UserID", SqlDbType.Int, ParameterDirection.Input, user);
            sph.DefineSqlParameter("@CatGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, q);
            return sph.ExecuteReader();
        }
    }
}

                                                                                                                                      