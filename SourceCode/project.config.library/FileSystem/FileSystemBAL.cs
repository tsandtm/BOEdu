

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace project.config.library
{
    public class FileSystemBAL : IFileSystemBAL
    {
        #region Private Methods
        private FileSystem PopulateFromReader(IDataReader reader)
        {
            FileSystem item = new FileSystem();
            if (reader.Read())
            {

                item.FileSystemGuid = new Guid(reader["FileSystemGuid"].ToString());

                item.FileSystemID = reader["FileSystemID"].ToString();

                item.FileType = reader["FileType"].ToString();

                item.FileSize = Convert.ToDecimal(reader["FileSize"]);

                item.ClientFileName = reader["ClientFileName"].ToString();

                item.ServerFileName = reader["ServerFileName"].ToString();

                try
                {
                    item.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                }
                catch (Exception) { }

                item.UpdatedUser = new Guid(reader["UpdatedUser"].ToString());

                item.ItemGuid = new Guid(reader["ItemGuid"].ToString());

                item.TableName = reader["TableName"].ToString();
            }
            return item;
        }
        private List<FileSystem> LoadListFromReader(IDataReader reader)
        {
            List<FileSystem> items = new List<FileSystem>();
            try
            {
                while (reader.Read())
                {
                    FileSystem item = new FileSystem();
                    item.FileSystemGuid = new Guid(reader["FileSystemGuid"].ToString());
                    item.FileSystemID = reader["FileSystemID"].ToString();
                    item.FileType = reader["FileType"].ToString();
                    item.FileSize = Convert.ToDecimal(reader["FileSize"]);
                    item.ClientFileName = reader["ClientFileName"].ToString();
                    item.ServerFileName = reader["ServerFileName"].ToString();
                    try
                    {
                        item.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    }
                    catch (Exception) { }
                    item.UpdatedUser = new Guid(reader["UpdatedUser"].ToString());
                    item.ItemGuid = new Guid(reader["ItemGuid"].ToString());
                    item.TableName = reader["TableName"].ToString();
                    items.Add(item);
                }
            }
            finally
            {
                reader.Close();
            }
            return items;
        }

        private Guid Create(FileSystem item)
        {
            item.FileSystemGuid = Guid.NewGuid();
            int rowsAffected = FileSystemDAL.Create(item);
            return rowsAffected > 0 ? item.FileSystemGuid : Guid.Empty;
        }
        private Guid Update(FileSystem item)
        {
            return FileSystemDAL.Update(item) ? item.FileSystemGuid : Guid.Empty;
        }
        #endregion

        #region public Methods

        /// <summary>
        /// Deletes an instance of FileSystem. Returns true on success.
        public bool Delete(Guid fileSystemGuid)
        {
            return FileSystemDAL.Delete(fileSystemGuid);
        }

        // <summary>
        /// Saves this instance of FileSystem. Returns a new Guid on success.
        /// </summary>
        public Guid Save(FileSystem item)
        {
            if (item.FileSystemGuid == Guid.Empty)
                return Create(item);
            return Update(item);
        }

        /// <summary>
        /// Gets an instance of FileSystem.
        /// </summary>
        /// <param name="fileSystemGuid"> fileSystemGuid </param>
        public FileSystem GetFileSystem(Guid fileSystemGuid)
        {
            using (IDataReader reader = FileSystemDAL.GetOne(fileSystemGuid))
            {
                return PopulateFromReader(reader);
            }
        }

        /// <summary>
        /// Gets an IList with page of instances of FileSystem.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public List<FileSystem> GetPage(int pageNumber, int pageSize, out int totalPages)
        {
            totalPages = 1;
            IDataReader reader = FileSystemDAL.GetPage(pageNumber, pageSize, out totalPages);
            return LoadListFromReader(reader);
        }

        /// <summary>
        /// Gets an IList with all instances of FileSystem.
        /// </summary>
        public List<FileSystem> GetAll()
        {
            IDataReader reader = FileSystemDAL.GetAll();
            return LoadListFromReader(reader);
        }

        public List<FileSystem> GetByItemGuid(Guid itemGuid,Guid userGuid,string controlID)
        {
            IDataReader reader = FileSystemDAL.GetByItemGuid(itemGuid, userGuid, controlID);
            return LoadListFromReader(reader);
        }
        public List<FileSystem> GetAllByItemGuid(Guid itemGuid)
        {
            IDataReader reader = FileSystemDAL.GetAllByItemGuid(itemGuid);
            return LoadListFromReader(reader);
        }
        public bool UpdateItemGuid(Guid itemGuid, string ControlID, Guid UserGuid, Guid itemGuidTam)
        {
            return FileSystemDAL.UpdateItemGuid(itemGuid, ControlID, UserGuid, itemGuidTam);
        }
        public bool DeleteByItemGuid(Guid itemGuid)
        {
            return FileSystemDAL.DeleteByItemGuid(itemGuid);
        }
        #endregion
		 #region Nam Thêm
        public bool CheckExistByItemGuid(Guid guid)
        {
            return FileSystemDAL.CheckExistByItemGuid(guid);
        }

        #endregion



        public List<FileSystem> GetAllByItemGuidAndTableName(Guid guidFile, string tableName)
        {
            IDataReader reader = FileSystemDAL.GetAllByItemGuidAndTableName(guidFile, tableName);
            return LoadListFromReader(reader);
        }


        public List<FileSystem> GetAllByItemGuidAndTableNameWithAttach(Guid guidFile, string tableName)
        {
            IDataReader reader = FileSystemDAL.GetAllByItemGuidAndTableNameWithAttach(guidFile, tableName);
            return LoadListFromReader(reader);
        }


        public List<FileSystem> GetTrashFileByUserGuid(Guid userguid, string tablename)
        {
            IDataReader reader = FileSystemDAL.GetTrashFileByUserGuid(userguid, tablename);
            return LoadListFromReader(reader);
        }

        public List<FileSystem> GetTrashFileByUserGuidLogError(Guid userguid, string tablename)
        {
            IDataReader reader = FileSystemDAL.GetTrashFileByUserGuidLogError(userguid, tablename);
            return LoadListFromReader(reader);
        }


        public bool DeleteByItemGuid(Guid itemGuid, string tablename)
        {
            return FileSystemDAL.DeleteByItemGuid(itemGuid, tablename);
        }


        public bool UpdateLogLoi(Guid userGuid, string tableName, Guid itemGuid)
        {
            return FileSystemDAL.UpdateLogLoi(userGuid, tableName, itemGuid);
        }


        public List<FileSystem> GetAllByDoanhNghiepFull(Guid doanhNghiepGuid)
        {
            IDataReader reader = FileSystemDAL.GetAllByDoanhNghiepFull(doanhNghiepGuid);
            return LoadListFromReader(reader);
        }
    }
}


