using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nvn.Library.Patterns.MVP;

namespace _project.library.hoa
{
    public interface IUsersBAL : IBaseBAL
    {

        bool Delete(int userID);
        int Save(Users item);
        Users GetUsers(int userID);
        List<Users> GetPage(int pageNumber, int pageSize, out int totalRow);
        List<Users> GetAll();

    }
}



