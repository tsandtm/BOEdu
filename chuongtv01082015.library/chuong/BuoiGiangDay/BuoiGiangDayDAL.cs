
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
	public  class BuoiGiangDayDAL
    {
        /// <summary>
        /// Inserts a row in the gv_BuoiGiangDay table. Returns rows affected count.
        /// </summary>
        /// <returns>int</returns>
        public  int Create(BuoiGiangDay item)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "gv_BuoiGiangDay_Insert", 4);
			sph.DefineSqlParameter("@BuoiGiangGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.BuoiGiangGuid);
			sph.DefineSqlParameter("@BuoiGiangID", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.BuoiGiangID);
			sph.DefineSqlParameter("@BuoiGiangName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.BuoiGiangName);
			sph.DefineSqlParameter("@MonHocGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.MonHocGuid);
          
            int rowsAffected = sph.ExecuteNonQuery();
            return rowsAffected;
        }
        
        /// <summary>
        /// Updates a row in the gv_BuoiGiangDay table. Returns true if row updated.
        /// </summary>
        /// <returns>bool</returns>
        public bool Update(BuoiGiangDay item)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "gv_BuoiGiangDay_Update", 4);
			sph.DefineSqlParameter("@BuoiGiangGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.BuoiGiangGuid);
			sph.DefineSqlParameter("@BuoiGiangID", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.BuoiGiangID);
			sph.DefineSqlParameter("@BuoiGiangName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.BuoiGiangName);
			sph.DefineSqlParameter("@MonHocGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.MonHocGuid);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);
        }
        
        /// <summary>
		/// Deletes a row from the gv_BuoiGiangDay table. Returns true if row deleted.
		/// </summary>
		/// <param name="buoiGiangGuid"> buoiGiangGuid </param>
		/// <returns>bool</returns>
		public bool Delete(
			Guid buoiGiangGuid) 
		{
			SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "gv_BuoiGiangDay_Delete", 1);
			sph.DefineSqlParameter("@BuoiGiangGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, buoiGiangGuid);
			int rowsAffected = sph.ExecuteNonQuery();
			return (rowsAffected > 0);
		}
        
        /// <summary>
		/// Gets an IDataReader with one row from the gv_BuoiGiangDay table.
		/// </summary>
		/// <param name="buoiGiangGuid"> buoiGiangGuid </param>
		public IDataReader GetOne(
			Guid  buoiGiangGuid)  
		{
			SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "gv_BuoiGiangDay_SelectOne", 1);
            sph.DefineSqlParameter("@BuoiGiangGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, buoiGiangGuid);
			return sph.ExecuteReader();
		}
		
		/// <summary>
		/// Gets a count of rows in the gv_BuoiGiangDay table.
		/// </summary>
		public int GetCount()
		{
			return Convert.ToInt32(SqlHelper.ExecuteScalar(
				ConnectionStringStatic.GetReadConnectionString(),
				CommandType.StoredProcedure,
				"gv_BuoiGiangDay_GetCount",
				null));
		}
        
        /// <summary>
		/// Gets an IDataReader with all rows in the gv_BuoiGiangDay table.
		/// </summary>
		public IDataReader GetAll()
		{
			return SqlHelper.ExecuteReader(
				ConnectionStringStatic.GetReadConnectionString(),
				CommandType.StoredProcedure,
				"gv_BuoiGiangDay_SelectAll",
				null);
		}
		
		/// <summary>
		/// Gets a page of data from the gv_BuoiGiangDay table.
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
			SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "gv_BuoiGiangDay_SelectPage", 2);
			sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
			sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
			return sph.ExecuteReader();
		}

        internal IDataReader GetAllByMonGuidAndUser(Guid MonGuida, int UserID)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "gv_BuoiGiangDay_tsandtm_GetAllByMonGuidAndUser", 2);
            sph.DefineSqlParameter("@MonHocGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, MonGuida);
            sph.DefineSqlParameter("@UserID", SqlDbType.Int, ParameterDirection.Input, UserID);
            return sph.ExecuteReader();
        }

        internal bool ShareDocForStudent(Guid buoiguid, Guid monguid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "gv_BuoiGiangDay_tsandtm_ShareDocForStudent", 2);
            sph.DefineSqlParameter("@buoiguid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, buoiguid);
            sph.DefineSqlParameter("@monguid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, monguid);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);
        }
    }
}
