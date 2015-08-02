

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
		/// Deletes a row from the doc_FileSystem table. Returns true if row deleted.
		/// </summary>
		/// <param name="fileSystemGuid"> fileSystemGuid </param>
		/// <returns>bool</returns>
        //doanh nghiep
        public static bool Delete(
			Guid fileSystemGuid) 
		{
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetWriteConnectionString(), "doc_FileSystem_DN_Delete", 1);
			sph.DefineSqlParameter("@FileSystemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, fileSystemGuid);
			int rowsAffected = sph.ExecuteNonQuery();
			return (rowsAffected > 0);
		}
        
        /// <summary>
		/// Gets an IDataReader with one row from the doc_FileSystem table.
		/// </summary>
		/// <param name="fileSystemGuid"> fileSystemGuid </param>
        //doanh nghiep
        public static IDataReader GetOne(
			Guid  fileSystemGuid)  
		{
			SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_DN_SelectOne", 1);
            sph.DefineSqlParameter("@FileSystemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, fileSystemGuid);
			return sph.ExecuteReader();
		}
		
		
        /// <summary>
        /// Chuong
        /// </summary>
        /// <param name="itemGuid"></param>
        /// <returns></returns>
        //doanh nghiep
        internal static bool DeleteByItemGuid(Guid itemGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_DN_DeleteByItemGuid", 1);
            sph.DefineSqlParameter("@ItemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, itemGuid);
            int row = sph.ExecuteNonQuery();
            return (row > 0);
        }

        

        //doanh nghiep
        public static IDataReader GetAllByItemGuid(Guid itemGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_DN_SelectAllByItemGuid", 1);
            sph.DefineSqlParameter("@ItemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, itemGuid);
            return sph.ExecuteReader();
        }



        internal static bool SaveFiles(string sql)
        {
            return SqlHelper.ExecuteNonQuery(
                ConnectionStringStatic.GetReadConnectionString(),
                CommandType.Text,
                sql,
                null)>0;
        }

        internal static bool RemoveBookInBag(Guid FileGuid)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_RemoveBookInBag", 1);
            sph.DefineSqlParameter("@FileGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, FileGuid);
            int row = sph.ExecuteNonQuery();
            return (row > 0);
        }
        public static IDataReader GetPageByItemGuid(int pageNumber, int pageSize, out int totalRows, Guid catGuid, string q)
        {
            totalRows = 0;
            totalRows = GetCountByItemGuid(catGuid, q);

            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_DN_SelectPageByItemGuid", 4);
            sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
            sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
            sph.DefineSqlParameter("@ItemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, catGuid);
            sph.DefineSqlParameter("@KeySearch", SqlDbType.NVarChar, 256, ParameterDirection.Input, q);

            return sph.ExecuteReader();
        }

        public static int GetCountByItemGuid(Guid catGuid, string q)
        {
            SqlParameterHelper sph = new SqlParameterHelper(ConnectionStringStatic.GetReadConnectionString(), "doc_FileSystem_DN_GetCountByItemGuid", 2);
            sph.DefineSqlParameter("@ItemGuid", SqlDbType.UniqueIdentifier, ParameterDirection.Input, catGuid);
            sph.DefineSqlParameter("@KeySearch", SqlDbType.NVarChar, 256, ParameterDirection.Input, q);

            return Convert.ToInt32(sph.ExecuteScalar());
        }
    }
}

