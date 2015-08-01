

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nvn.Library.Patterns.MVP;

namespace project.config.library
{
    public interface IFileSystemBAL : IBaseBAL
    {
        bool Delete(Guid fileSystemGuid);
        Guid Save(FileSystem item);
        FileSystem GetFileSystem(Guid fileSystemGuid);
        List<FileSystem> GetPage(int pageNumber, int pageSize, out int totalPages);
        List<FileSystem> GetAll();

        List<FileSystem> GetByItemGuid(Guid itemGuid,Guid UserGuid, string controlid);
        List<FileSystem> GetAllByItemGuid(Guid itemGuid);

        bool DeleteByItemGuid(Guid itemGuid, string tablename);
		
		bool CheckExistByItemGuid(Guid guid);// Nam Thêm

        bool UpdateItemGuid(Guid itemGuid, string ControlID, Guid UserGuid, Guid itemGuidTam);


        List<FileSystem> GetAllByItemGuidAndTableName(Guid guidFile, string tableName);

        List<FileSystem> GetAllByItemGuidAndTableNameWithAttach(Guid guidFile, string tableName);

        List<FileSystem> GetTrashFileByUserGuid(Guid userguid, string tablename);


        List<FileSystem> GetTrashFileByUserGuidLogError(Guid userGuid, string tableName);

        bool UpdateLogLoi(Guid userGuid, string tableName, Guid itemGuid);

        List<FileSystem> GetAllByDoanhNghiepFull(Guid doanhNghiepGuid);
    }
}



