
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using nvn.Library.Patterns.MVP;
using project.config.library;

namespace chuongtv01082015.library.chuong
{
    public class MonHocDAL
    {
        /// <summary>
        /// Inserts a row in the gv_MonHoc table. Returns rows affected count.
        /// </summary>
        /// <returns>int</returns>
        public int Create(MonHoc item)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "gv_MonHoc_Chuongtv31072015_Insert", 5);
            sph.DefineSqlParameter("@MonHocGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.MonHocGuid);
            sph.DefineSqlParameter("@MonHocName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.MonHocName);
            sph.DefineSqlParameter("@MonHocID", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.MonHocID);
            sph.DefineSqlParameter("@GiangVienGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.GiangVienGuid);
            sph.DefineSqlParameter("@SoBuoiGiangDay", SqlDbType.Int, ParameterDirection.Input, item.SoBuoiGiangDay);
            int rowsAffected = sph.ExecuteNonQuery();
            return rowsAffected;
        }

        /// <summary>
        /// Updates a row in the gv_MonHoc table. Returns true if row updated.
        /// </summary>
        /// <returns>bool</returns>
        public bool Update(MonHoc item)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "gv_MonHoc_Chuongtv31072015_Update", 5);
            sph.DefineSqlParameter("@MonHocGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.MonHocGuid);
            sph.DefineSqlParameter("@MonHocName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.MonHocName);
            sph.DefineSqlParameter("@MonHocID", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.MonHocID);
            sph.DefineSqlParameter("@GiangVienGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.GiangVienGuid);
            sph.DefineSqlParameter("@SoBuoiGiangDay", SqlDbType.Int, ParameterDirection.Input, item.SoBuoiGiangDay);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);
        }

        /// <summary>
        /// Deletes a row from the gv_MonHoc table. Returns true if row deleted.
        /// </summary>
        /// <param name="monHocGuid"> monHocGuid </param>
        /// <returns>bool</returns>
        public bool Delete(
            Guid monHocGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "gv_MonHoc_Chuongtv01082015_Delete", 1);
            sph.DefineSqlParameter("@MonHocGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, monHocGuid);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);
        }

        /// <summary>
        /// Gets an IDataReader with one row from the gv_MonHoc table.
        /// </summary>
        /// <param name="monHocGuid"> monHocGuid </param>
        public IDataReader GetOne(
            Guid monHocGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "gv_MonHoc_Chuongtv31072015_GetOne", 1);
            sph.DefineSqlParameter("@MonHocGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, monHocGuid);
            return sph.ExecuteReader();
        }

        /// <summary>
        /// Gets a count of rows in the gv_MonHoc table.
        /// </summary>
        public int GetCount()
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                ConnectionStringStatic.GetReadConnectionString(),
                CommandType.StoredProcedure,
                "gv_MonHoc_GetCount",
                null));
        }

        /// <summary>
        /// Gets an IDataReader with all rows in the gv_MonHoc table.
        /// </summary>
        public IDataReader GetAll()
        {
            return SqlHelper.ExecuteReader(
                ConnectionStringStatic.GetReadConnectionString(),
                CommandType.StoredProcedure,
                "gv_MonHoc_SelectAll",
                null);
        }

        /// <summary>
        /// Gets a page of data from the gv_MonHoc table.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public IDataReader GetPage(
            int pageNumber,
            int pageSize,
            out int totalrow
            )
        {
            totalrow = GetCount();
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "gv_MonHoc_SelectPage", 2);
            sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
            sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
            return sph.ExecuteReader();
        }

        internal IDataReader GetAllMonHocTheoGiangVien(Guid GiangVienGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "gv_MonHoc_Chuongtv31072015_GetAllMonHocTheoGiangVien", 1);
            sph.DefineSqlParameter("@GiangVienGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, GiangVienGuid);
            return sph.ExecuteReader();
        }

        internal bool DeleteLinkURL(Guid monhoc)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "gv_MonHoc_Chuongtv01082015_DeleteLinkURL", 1);
            sph.DefineSqlParameter("@BuoiGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, monhoc);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);
        }
    }
}
