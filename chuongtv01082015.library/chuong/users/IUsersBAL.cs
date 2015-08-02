using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nvn.Library.Patterns.MVP;

namespace chuongtv01082015.library.chuong
{
    public interface IUsersBAL : IBaseBAL
    {

        bool Delete(int userID);
        int Save(Users item);
        Users GetUsers(int userID);
        List<Users> GetPage(int pageNumber, int pageSize, out int totalRow, string q);
        List<Users> GetAll(string q);
        bool ResetPass(int userID, string p);

        List<Users> GetListUserByKeysearch(string keysearch);


        List<Users> GetListFollowerById(int userlogin);
        bool CapNhapDanhSachFollower(int userlogin, int id);
    }
}



