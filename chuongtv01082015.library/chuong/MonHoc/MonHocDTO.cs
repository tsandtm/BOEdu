
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;


namespace chuongtv01082015.library.chuong
{
    public static class MonHocDTO
    {
        public static MonHoc PopulateFromReader(IDataReader reader)
        {
            MonHoc item = new MonHoc();
            if (reader.Read())
            {
                try { item.MonHocGuid = new Guid(reader["MonHocGuid"].ToString()); }
                catch { }
                item.MonHocName = reader["MonHocName"].ToString();
                item.MonHocID = reader["MonHocID"].ToString();
                try { item.Userid = Convert.ToInt32(reader["Userid"].ToString()); }
                catch { }
                try
                {
                    item.SoBuoiGiangDay = Convert.ToInt32(reader["SoBuoiGiangDay"].ToString());

                }
                catch { }
            }

            return item;
        }
        public static List<MonHoc> LoadListFromReader(IDataReader reader)
        {
            List<MonHoc> items = new List<MonHoc>();
            try
            {
                while (reader.Read())
                {
                    MonHoc item = new MonHoc();
                    try { item.MonHocGuid = new Guid(reader["MonHocGuid"].ToString()); }
                    catch { }
                    item.MonHocName = reader["MonHocName"].ToString();
                    item.MonHocID = reader["MonHocID"].ToString();
                    try { item.Userid = Convert.ToInt32(reader["Userid"].ToString()); }
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
        internal static List<MonHoc> LoadListFromReaderForList(IDataReader reader)
        {
            List<MonHoc> items = new List<MonHoc>();
            try
            {
                while (reader.Read())
                {
                    MonHoc item = new MonHoc();
                    try { item.MonHocGuid = new Guid(reader["MonHocGuid"].ToString()); }
                    catch { }
                    item.MonHocName = reader["MonHocName"].ToString();
                    item.MonHocID = reader["MonHocID"].ToString();
                    try { item.Userid = Convert.ToInt32(reader["Userid"].ToString()); }
                    catch { }
                    try { item.BuoiGiangGuid = new Guid(reader["BuoiGiangGuid"].ToString()); }
                    catch { }
                    item.BuoiGiangID = reader["BuoiGiangID"].ToString();
                    item.BuoiGiangName = reader["BuoiGiangName"].ToString();
                    item.ClientFileName = reader["ClientFileName"].ToString();
                    item.ServerFileName = reader["ServerFileName"].ToString();
                    item.FileSize = reader["FileSize"].ToString();
                    try { item.FileSystemGuid = new Guid(reader["FileSystemGuid"].ToString()); }
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
            List<MonHoc> Returnitems = new List<MonHoc>();
            int i = 0;
            bool flag = false;
            int count = items.Count;
            if (count > 0)
            {
                MonHoc m = new MonHoc();
                BuoiGiangDay b;
                while (i < count)
                {
                    if (flag == false)
                    {
                        m = new MonHoc();
                        m.MonHocGuid = items[i].MonHocGuid;
                        m.MonHocName = items[i].MonHocName;
                        m.MonHocID = items[i].MonHocID;
                        m.DanhSachBuoiGiangDay = new List<BuoiGiangDay>();

                        b = new BuoiGiangDay();
                        b.BuoiGiangGuid = items[i].BuoiGiangGuid;
                        b.BuoiGiangID = items[i].BuoiGiangID;
                        b.BuoiGiangName = items[i].BuoiGiangName;
                        b.ClientFileName = items[i].ClientFileName;
                        b.ServerFileName = items[i].ServerFileName;
                        b.FileSize = items[i].FileSize;
                        b.FileSystemGuid = items[i].FileSystemGuid;

                        m.DanhSachBuoiGiangDay.Add(b);
                        i++;
                        if (i >= count)
                        {
                            Returnitems.Add(m);
                            break;
                        }
                    }
                    if (items[i].MonHocGuid == items[i - 1].MonHocGuid)
                    {
                        b = new BuoiGiangDay();
                        b.BuoiGiangGuid = items[i].BuoiGiangGuid;
                        b.BuoiGiangID = items[i].BuoiGiangID;
                        b.BuoiGiangName = items[i].BuoiGiangName;
                        b.ClientFileName = items[i].ClientFileName;
                        b.ServerFileName = items[i].ServerFileName;
                        b.FileSize = items[i].FileSize;
                        b.FileSystemGuid = items[i].FileSystemGuid;
                        m.DanhSachBuoiGiangDay.Add(b);
                        flag = true;
                        i++;
                        if (i >= count)
                            Returnitems.Add(m);
                    }
                    else
                    {
                        flag = false;
                    }

                    if (flag == false)
                        Returnitems.Add(m);

                }
            }
            return Returnitems;
        }
    }
}
