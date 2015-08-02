

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
                try { item.MapPath = reader["MapPath"].ToString(); }
                catch { }
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
                    try { item.MapPath = reader["MapPath"].ToString(); }
                    catch { }
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

        #endregion



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
            return Guid.Empty;
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


        public List<FileSystem> GetAllByItemGuid(Guid itemGuid)
        {
            IDataReader reader = FileSystemDAL.GetAllByItemGuid(itemGuid);
            return LoadListFromReader(reader);
        }

        public bool DeleteByItemGuid(Guid itemGuid)
        {
            return FileSystemDAL.DeleteByItemGuid(itemGuid);
        }


        public bool SaveFiles(string sql)
        {
            return FileSystemDAL.SaveFiles(sql);
        }

        /// <summary>
        /// Gets an IList with page of instances of Users.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</par
        public List<FileSystem> GetPageByItemGuid(int pageNumber, int pageSize, out int totalRows, Guid catGuid, string q)
        {
            totalRows = 1;
            IDataReader reader = FileSystemDAL.GetPageByItemGuid(pageNumber, pageSize, out totalRows, catGuid, q);
            return LoadListFromReader(reader);
        }
        public int GetCountByItemGuid(Guid catGuid, string q)
        {
            return FileSystemDAL.GetCountByItemGuid(catGuid, q);
        }




        public bool RemoveBookInBag(Guid FileGuid)
        {
            return FileSystemDAL.RemoveBookInBag(FileGuid);
        }
    }
}


