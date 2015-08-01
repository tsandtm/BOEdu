
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;

	
namespace chuongtv01082015.library.chuong  
{
	public  static class GiangVienDTO
    {
        public static GiangVien PopulateFromReader(IDataReader reader)
        {
             GiangVien item = new GiangVien();
            if(reader.Read())
			{
                  try{item.GiangVienGuid = new Guid(reader["GiangVienGuid"].ToString());}catch{}
                      item.GiangvienName = reader["GiangvienName"].ToString();
                      item.GiangVienID = reader["GiangVienID"].ToString();
			}
           
            return item;
        }
        public static List<GiangVien> LoadListFromReader(IDataReader reader)
        {
            List<GiangVien> items = new List<GiangVien>();
            try
            {
                while (reader.Read())
                {
                    GiangVien item = new GiangVien();
                        try{item.GiangVienGuid = new Guid(reader["GiangVienGuid"].ToString());}catch{}
                            item.GiangvienName = reader["GiangvienName"].ToString();
                            item.GiangVienID = reader["GiangVienID"].ToString();
                    items.Add(item);
                }
            }
            catch
            {}
            finally
            {
                reader.Close();
            }
            return items;
        }
    }
}
