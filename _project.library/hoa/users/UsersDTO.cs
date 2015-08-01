using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _project.library.hoa
{
    public static class UsersDTO
    {
        #region Private Methods
        public static Users PopulateFromReader(IDataReader reader)
        {
            Users item = new Users();
            try
            {
                if (reader.Read())
                {

                    try
                    {
                        item.UserId = Int32.Parse(reader["UserId"].ToString());
                    }
                    catch (Exception) { }

                    item.FullName = reader["FullName"].ToString();

                    item.UserName = reader["UserName"].ToString();

                    //item.Password = reader["Password"].ToString();
                    item.DiaChi = reader["DiaChi"].ToString();
                    item.DienThoai = reader["DienThoai"].ToString();
                    item.DienThoai = reader["AvatarExt"].ToString();

                    try
                    {
                        item.CreatedUser = new Guid(reader["CreatedUser"].ToString());
                    }
                    catch (Exception) { }

                    try
                    {
                        item.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    }
                    catch (Exception) { }

                    try
                    {
                        item.NgaySinh = Convert.ToDateTime(reader["NgaySinh"]);
                    }
                    catch (Exception) { }

                    try
                    {
                        item.UpdatedUser = new Guid(reader["UpdatedUser"].ToString());
                    }
                    catch (Exception) { }

                    try
                    {
                        item.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    }
                    catch (Exception) { }
                }
            }
            catch { }
            return item;
        }
        public static List<Users> LoadListFromReader(IDataReader reader)
        {
            List<Users> items = new List<Users>();
            try
            {
                while (reader.Read())
                {
                    Users item = new Users();
                    try
                    {
                        item.UserId = Int32.Parse(reader["UserId"].ToString());
                    }
                    catch (Exception) { }
                    item.FullName = reader["FullName"].ToString();
                    item.UserName = reader["UserName"].ToString();
                    //item.Password = reader["Password"].ToString();
                    item.DiaChi = reader["DiaChi"].ToString();
                    item.DienThoai = reader["DienThoai"].ToString();
                    item.DienThoai = reader["AvatarExt"].ToString();
                    try
                    {
                        item.NgaySinh = Convert.ToDateTime(reader["NgaySinh"]);
                    }
                    catch (Exception) { }
                    try
                    {
                        item.CreatedUser = new Guid(reader["CreatedUser"].ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        item.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    }
                    catch (Exception) { }
                    try
                    {
                        item.UpdatedUser = new Guid(reader["UpdatedUser"].ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        item.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    }
                    catch (Exception) { }
                    items.Add(item);
                }
            }
            catch
            { }
            finally
            {
                reader.Close();
            }
            return items;
        }
        #endregion

    }
}
