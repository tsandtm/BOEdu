
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
	public  class GiangVienDAL
    {
        /// <summary>
        /// Inserts a row in the gv_GiangVien table. Returns rows affected count.
        /// </summary>
        /// <returns>int</returns>
        public  int Create(GiangVien item)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "gv_GiangVien_Insert", 3);
			sph.DefineSqlParameter("@GiangVienGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.GiangVienGuid);
			sph.DefineSqlParameter("@GiangvienName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.GiangvienName);
			sph.DefineSqlParameter("@GiangVienID", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.GiangVienID);
          
            int rowsAffected = sph.ExecuteNonQuery();
            return rowsAffected;
        }
        
        /// <summary>
        /// Updates a row in the gv_GiangVien table. Returns true if row updated.
        /// </summary>
        /// <returns>bool</returns>
        public bool Update(GiangVien item)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "gv_GiangVien_Update", 3);
			sph.DefineSqlParameter("@GiangVienGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.GiangVienGuid);
			sph.DefineSqlParameter("@GiangvienName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.GiangvienName);
			sph.DefineSqlParameter("@GiangVienID", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.GiangVienID);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);
        }
        
        /// <summary>
		/// Deletes a row from the gv_GiangVien table. Returns true if row deleted.
		/// </summary>
		/// <param name="giangVienGuid"> giangVienGuid </param>
		/// <returns>bool</returns>
		public bool Delete(
			Guid giangVienGuid) 
		{
			SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "gv_GiangVien_Delete", 1);
			sph.DefineSqlParameter("@GiangVienGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, giangVienGuid);
			int rowsAffected = sph.ExecuteNonQuery();
			return (rowsAffected > 0);
		}
        
        /// <summary>
		/// Gets an IDataReader with one row from the gv_GiangVien table.
		/// </summary>
		/// <param name="giangVienGuid"> giangVienGuid </param>
		public IDataReader GetOne(
			Guid  giangVienGuid)  
		{
			SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "gv_GiangVien_SelectOne", 1);
            sph.DefineSqlParameter("@GiangVienGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, giangVienGuid);
			return sph.ExecuteReader();
		}
		
		/// <summary>
		/// Gets a count of rows in the gv_GiangVien table.
		/// </summary>
		public int GetCount()
		{
			return Convert.ToInt32(SqlHelper.ExecuteScalar(
				ConnectionStringStatic.GetReadConnectionString(),
				CommandType.StoredProcedure,
				"gv_GiangVien_GetCount",
				null));
		}
        
        /// <summary>
		/// Gets an IDataReader with all rows in the gv_GiangVien table.
		/// </summary>
		public IDataReader GetAll()
		{
			return SqlHelper.ExecuteReader(
				ConnectionStringStatic.GetReadConnectionString(),
				CommandType.StoredProcedure,
				"gv_GiangVien_SelectAll",
				null);
		}
		
		/// <summary>
		/// Gets a page of data from the gv_GiangVien table.
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
			SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "gv_GiangVien_SelectPage", 2);
			sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
			sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
			return sph.ExecuteReader();
		}
    }
}
