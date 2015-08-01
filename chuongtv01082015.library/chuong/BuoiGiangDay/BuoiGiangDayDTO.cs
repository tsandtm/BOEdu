
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;


namespace chuongtv01082015.library.chuong
{
    public static class BuoiGiangDayDTO
    {
        public static BuoiGiangDay PopulateFromReader(IDataReader reader)
        {
            BuoiGiangDay item = new BuoiGiangDay();
            if (reader.Read())
            {
                try { item.BuoiGiangGuid = new Guid(reader["BuoiGiangGuid"].ToString()); }
                catch { }
                item.BuoiGiangID = reader["BuoiGiangID"].ToString();
                item.BuoiGiangName = reader["BuoiGiangName"].ToString();
                try { item.MonHocGuid = new Guid(reader["MonHocGuid"].ToString()); }
                catch { }
            }

            return item;
        }
        public static List<BuoiGiangDay> LoadListFromReader(IDataReader reader)
        {
            List<BuoiGiangDay> items = new List<BuoiGiangDay>();
            try
            {
                while (reader.Read())
                {
                    BuoiGiangDay item = new BuoiGiangDay();
                    try { item.BuoiGiangGuid = new Guid(reader["BuoiGiangGuid"].ToString()); }
                    catch { }
                    item.BuoiGiangID = reader["BuoiGiangID"].ToString();
                    item.BuoiGiangName = reader["BuoiGiangName"].ToString();
                    try { item.MonHocGuid = new Guid(reader["MonHocGuid"].ToString()); }
                    catch { }
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
    }
}
