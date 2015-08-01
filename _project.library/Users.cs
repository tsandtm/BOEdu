using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _project.library
{
    public class Users
    {
        #region Public Properties
        public int UserId
        {
            get;
            set;
        }
        public string FullName
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public Guid CreatedUser
        {
            get;
            set;
        }
        public DateTime? CreatedDate
        {
            get;
            set;
        }
        public Guid UpdatedUser
        {
            get;
            set;
        }
        public DateTime? UpdatedDate
        {
            get;
            set;
        }
        public DateTime? NgaySinh
        {
            get;
            set;
        }
        public string DienThoai
        {
            get;
            set;
        }
        public string DiaChi
        {
            get;
            set;
        }

        public string AvatarExt
        {
            get;
            set;
        }
        #endregion
    }
}
