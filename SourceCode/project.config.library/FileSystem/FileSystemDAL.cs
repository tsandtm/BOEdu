

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using nvn.Library.Patterns.MVP;

namespace project.config.library
{
	public static class FileSystemDAL
    {
        /// <summary>
        /// Inserts a row in the doc_FileSystem table. Returns rows affected count.
        /// </summary>
        /// <returns>int</returns>
        public static int Create(FileSystem item)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "doc_FileSystem_Insert", 10);
			sph.DefineSqlParameter("@FileSystemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.FileSystemGuid);
			sph.DefineSqlParameter("@FileSystemID", SqlDbType.NVarChar, 25, ParameterDirection.Input, item.FileSystemID);
			sph.DefineSqlParameter("@FileType", SqlDbType.NVarChar, 25, ParameterDirection.Input, item.FileType);
			sph.DefineSqlParameter("@FileSize", SqlDbType.Decimal, ParameterDirection.Input, item.FileSize);
			sph.DefineSqlParameter("@ClientFileName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.ClientFileName);
			sph.DefineSqlParameter("@ServerFileName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.ServerFileName);
            sph.DefineSqlParameter("@TableName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.TableName);
			sph.DefineSqlParameter("@UpdatedDate", SqlDbType.DateTime, ParameterDirection.Input, item.UpdatedDate);
			sph.DefineSqlParameter("@UpdatedUser", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.UpdatedUser);
			sph.DefineSqlParameter("@ItemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.ItemGuid);
          
            int rowsAffected = sph.ExecuteNonQuery();
            return rowsAffected;
        }
        
        /// <summary>
        /// Updates a row in the doc_FileSystem table. Returns true if row updated.
        /// </summary>
        /// <returns>bool</returns>
        public static bool Update(FileSystem item)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "doc_FileSystem_Update", 9);
			sph.DefineSqlParameter("@FileSystemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.FileSystemGuid);
			sph.DefineSqlParameter("@FileSystemID", SqlDbType.NVarChar, 25, ParameterDirection.Input, item.FileSystemID);
			sph.DefineSqlParameter("@FileType", SqlDbType.NVarChar, 25, ParameterDirection.Input, item.FileType);
			sph.DefineSqlParameter("@FileSize", SqlDbType.Decimal, ParameterDirection.Input, item.FileSize);
			sph.DefineSqlParameter("@ClientFileName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.ClientFileName);
			sph.DefineSqlParameter("@ServerFileName", SqlDbType.NVarChar, 256, ParameterDirection.Input, item.ServerFileName);
			sph.DefineSqlParameter("@UpdatedDate", SqlDbType.DateTime, ParameterDirection.Input, item.UpdatedDate);
			sph.DefineSqlParameter("@UpdatedUser", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.UpdatedUser);
			sph.DefineSqlParameter("@ItemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, item.ItemGuid);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);
        }
        
        /// <summary>
		/// Deletes a row from the doc_FileSystem table. Returns true if row deleted.
		/// </summary>
		/// <param name="fileSystemGuid"> fileSystemGuid </param>
		/// <returns>bool</returns>
		public static bool Delete(
			Guid fileSystemGuid) 
		{
			SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "doc_FileSystem_Delete", 1);
			sph.DefineSqlParameter("@FileSystemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, fileSystemGuid);
			int rowsAffected = sph.ExecuteNonQuery();
			return (rowsAffected > 0);
		}
        
        /// <summary>
		/// Gets an IDataReader with one row from the doc_FileSystem table.
		/// </summary>
		/// <param name="fileSystemGuid"> fileSystemGuid </param>
		public static IDataReader GetOne(
			Guid  fileSystemGuid)  
		{
			SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_SelectOne", 1);
            sph.DefineSqlParameter("@FileSystemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, fileSystemGuid);
			return sph.ExecuteReader();
		}
		
		/// <summary>
		/// Gets a count of rows in the doc_FileSystem table.
		/// </summary>
		public static int GetCount()
		{
			return Convert.ToInt32(SqlHelper.ExecuteScalar(
				ConnectionStringStatic.GetReadConnectionString(),
				CommandType.StoredProcedure,
				"doc_FileSystem_GetCount",
				null));
		}
        
        /// <summary>
		/// Gets an IDataReader with all rows in the doc_FileSystem table.
		/// </summary>
		public static IDataReader GetAll()
		{
			return SqlHelper.ExecuteReader(
				ConnectionStringStatic.GetReadConnectionString(),
				CommandType.StoredProcedure,
				"doc_FileSystem_SelectAll",
				null);
		}
		
		/// <summary>
		/// Gets a page of data from the doc_FileSystem table.
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
			
			SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_SelectPage", 2);
			sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
			sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
			return sph.ExecuteReader();
		}

        public static IDataReader GetByItemGuid(Guid itemGuid,Guid userGuid,string controlID)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_SelectByItemGuid",3);
            sph.DefineSqlParameter("@ItemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, itemGuid);
            sph.DefineSqlParameter("@UserGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userGuid);
            sph.DefineSqlParameter("@ControlID", SqlDbType.NVarChar, 256, ParameterDirection.Input, controlID);
            return sph.ExecuteReader();
        }

        /// <summary>
        /// Chuong
        /// </summary>
        /// <param name="itemGuid"></param>
        /// <returns></returns>
        internal static bool DeleteByItemGuid(Guid itemGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_DeleteByItemGuid", 1);
            sph.DefineSqlParameter("@ItemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, itemGuid);
            int row = sph.ExecuteNonQuery();
            return (row > 0);
        }

        /// <summary>
        /// Chuong
        /// </summary>
        /// <param name="itemGuid"></param>
        /// <returns></returns>
        public static bool KiemTraTonTaiFileDinhKem(Guid itemGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_KiemTraTonTaiFileDinhKem", 1);
            sph.DefineSqlParameter("@ItemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, itemGuid);
            int row = Convert.ToInt32(sph.ExecuteScalar());
            return (row > 0);
        }
		 #region Nam thêm
        internal static bool CheckExistByItemGuid(Guid itemguid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "doc_FileSystem_CheckExistByItemGuid", 1);
            sph.DefineSqlParameter("@ItemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, itemguid);
            int rowsAffected = Convert.ToInt32(sph.ExecuteScalar());
            return (rowsAffected > 0);
        }
        #endregion

        public static IDataReader GetAllByItemGuid(Guid itemGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_SelectAllByItemGuid", 1);
            sph.DefineSqlParameter("@ItemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, itemGuid);
            return sph.ExecuteReader();
        }

        internal static bool UpdateItemGuid(Guid itemGuid, string ControlID, Guid UserGuid, Guid itemGuidTam)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "doc_FileSystem_UpdateItemGuid", 4);
            sph.DefineSqlParameter("@ItemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, itemGuid);
            sph.DefineSqlParameter("@ControlID", SqlDbType.NVarChar, 256, ParameterDirection.Input, ControlID);
            sph.DefineSqlParameter("@UpdatedUser", SqlDbType.UniqueIdentifier, ParameterDirection.Input, UserGuid);
            sph.DefineSqlParameter("@ItemGuidTam", SqlDbType.UniqueIdentifier, ParameterDirection.Input, itemGuidTam);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);
        }

        internal static IDataReader GetAllByItemGuidAndTableName(Guid guidFile, string tableName)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_SelectAllByItemGuidAndTableName", 2);
            sph.DefineSqlParameter("@ItemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, guidFile);
            sph.DefineSqlParameter("@TableName", SqlDbType.NVarChar,256, ParameterDirection.Input, tableName);
            return sph.ExecuteReader();
        }

        internal static IDataReader GetAllByItemGuidAndTableNameWithAttach(Guid guidFile, string tableName)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_SelectAllByItemGuidAndTableNameWithAttach", 2);
            sph.DefineSqlParameter("@ItemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, guidFile);
            sph.DefineSqlParameter("@TableName", SqlDbType.NVarChar, 256, ParameterDirection.Input, tableName);
            return sph.ExecuteReader();
        }

        internal static IDataReader GetTrashFileByUserGuid(Guid userguid, string tableName)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_SelectAllTrashFileByUserGuid", 2);
            sph.DefineSqlParameter("@UserGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userguid);
            sph.DefineSqlParameter("@TableName", SqlDbType.NVarChar, 256, ParameterDirection.Input,  tableName);
            return sph.ExecuteReader();
        }

        internal static bool DeleteByItemGuid(Guid itemGuid, string tablename)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_Nam_DeleteByItemGuidAndTableName", 2);
            sph.DefineSqlParameter("@ItemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, itemGuid);
            sph.DefineSqlParameter("@TableName", SqlDbType.NVarChar,256, ParameterDirection.Input, tablename);
            int row = sph.ExecuteNonQuery();
            return (row > 0);
        }

        internal static IDataReader GetTrashFileByUserGuidLogError(Guid userguid, string tableName)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_SelectAllTrashFileByUserGuidLogLoi", 2);
            sph.DefineSqlParameter("@UserGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userguid);
            sph.DefineSqlParameter("@TableName", SqlDbType.NVarChar, 256, ParameterDirection.Input, tableName);
            return sph.ExecuteReader();
        }

        internal static bool UpdateLogLoi(Guid userGuid, string tableName, Guid itemGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_UpdateItemGuidFileLogLoi", 3);
            sph.DefineSqlParameter("@UserGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, userGuid);
            sph.DefineSqlParameter("@TableName", SqlDbType.NVarChar, 256, ParameterDirection.Input, tableName);
            sph.DefineSqlParameter("@ItemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, itemGuid);
            int row = sph.ExecuteNonQuery();
            return (row > 0);
        }

        internal static IDataReader GetAllByDoanhNghiepFull(Guid doanhNghiepGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_nam051815_FileSystem_SelectAllFileByDoanhNghiepFull", 1);
            sph.DefineSqlParameter("@DoanhNghiepGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, doanhNghiepGuid);
            return sph.ExecuteReader();
        }
    }
}

