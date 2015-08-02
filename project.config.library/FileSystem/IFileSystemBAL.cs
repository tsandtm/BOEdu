

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

        List<FileSystem> GetAllByItemGuid(Guid itemGuid);

        bool SaveFiles(string query);

        bool RemoveBookInBag(Guid FileGuid);

        List<FileSystem> GetPageByItemGuid(int pageNumber, int pageSize, out int totalRows, Guid catGuid, string q);
    }
}



