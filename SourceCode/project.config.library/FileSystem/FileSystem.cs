using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project.config.library
{
	public class FileSystem
    {
        #region Constructors
	    public FileSystem(){}
        #endregion
        
        #region Private Properties
		private  Guid  fileSystemGuid = Guid.Empty;
		private  string  fileSystemID = string.Empty;
		private  string  fileType = string.Empty;
		private  decimal  fileSize;
		private  string  clientFileName = string.Empty;
		private  string  serverFileName = string.Empty;
		private  DateTime?  updatedDate;
		private  Guid  updatedUser = Guid.Empty;
		private  Guid  itemGuid = Guid.Empty;
        private string tableName = string.Empty;

        #endregion

        #region Public Properties
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        public  Guid  FileSystemGuid 
        {
            get { return fileSystemGuid; }
            set { fileSystemGuid = value; }
        }
        public  string  FileSystemID 
        {
            get { return fileSystemID; }
            set { fileSystemID = value; }
        }
        public  string  FileType 
        {
            get { return fileType; }
            set { fileType = value; }
        }
        public  decimal  FileSize 
        {
            get { return fileSize; }
            set { fileSize = value; }
        }
        public  string  ClientFileName 
        {
            get { return clientFileName; }
            set { clientFileName = value; }
        }
        public  string  ServerFileName 
        {
            get { return serverFileName; }
            set { serverFileName = value; }
        }
        public  DateTime?  UpdatedDate 
        {
            get { return updatedDate; }
            set { updatedDate = value; }
        }
        public  Guid  UpdatedUser 
        {
            get { return updatedUser; }
            set { updatedUser = value; }
        }
        public  Guid  ItemGuid 
        {
            get { return itemGuid; }
            set { itemGuid = value; }
        }
        #endregion

        #region Nam them
        private string serverFileName200300 = string.Empty;

        public string ServerFileName200300
        {
            get { return serverFileName200300; }
            set { serverFileName200300 = value; }
        }
        #endregion
    }
}

