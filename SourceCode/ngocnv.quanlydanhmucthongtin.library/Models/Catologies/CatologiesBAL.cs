

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using project.config.library;
using project.config.library.Utilities;

namespace ngocnv10052014.catology.library.Models
{
    public class CatologieBAL : ICatologieBAL
    {
        #region Private Methods
        private Catologie PopulateFromReader(IDataReader reader)
        {
            Catologie item = new Catologie();
            if (reader.Read())
            {

                item.CatologyGuid = new Guid(reader["CatologyGuid"].ToString());
                item.CatologyID = Convert.ToInt32(reader["CatologyID"]);
                item.CatologyName = reader["CatologyName"].ToString();
                item.Description = reader["Description"].ToString();
                item.KindCatologyGuid = new Guid(reader["KindCatologyGuid"].ToString());
                item.KindCatologyName = reader["KindCatologyName"].ToString();
                item.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                item.UrlHinhanh = reader["UrlHinhanh"].ToString();

                item.ListPlacementName = reader["ListPlacementName"].ToString();
                item.Levels = Convert.ToInt32(reader["Levels"]);
                item.Position = Convert.ToInt32(reader["Position"]);
                try
                {
                    item.IsNotDelete = Convert.ToBoolean(reader["IsNotDelete"].ToString());
                }
                catch { }
                try
                {
                    item.UserID=Convert.ToInt32(reader["UserID"]);
                }
                catch { }
            }
            return item;
        }
        private List<Catologie> LoadListFromReader(IDataReader reader)
        {
            List<Catologie> items = new List<Catologie>();
            try
            {
                while (reader.Read())
                {
                    Catologie item = new Catologie();
                    item.CatologyGuid = new Guid(reader["CatologyGuid"].ToString());
                    item.CatologyID = Convert.ToInt32(reader["CatologyID"]);
                    item.CatologyName = reader["CatologyName"].ToString();
                    item.Description = reader["Description"].ToString();
                    item.KindCatologyGuid = new Guid(reader["KindCatologyGuid"].ToString());
                    item.KindCatologyName = reader["KindCatologyName"].ToString();
                    item.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                    item.UrlHinhanh = reader["UrlHinhanh"].ToString();

                    item.ListPlacementName = reader["ListPlacementName"].ToString();
                    item.Levels = Convert.ToInt32(reader["Levels"]);
                    item.Position = Convert.ToInt32(reader["Position"]);
                    try
                    {
                        item.IsNotDelete = Convert.ToBoolean(reader["IsNotDelete"].ToString());
                    }
                    catch { }
                    try
                    {
                        item.UserID = Convert.ToInt32(reader["UserID"]);
                    }
                    catch { }
                    items.Add(item);
                }
            }
            finally
            {
                reader.Close();
            }
            return items;
        }

        private Guid Create(Catologie item)
        {
            item.CatologyGuid = Guid.NewGuid();
            int rowsAffected = CatologieDAL.Create(item);
            return rowsAffected > 0 ? item.CatologyGuid : Guid.Empty;
        }
        private Guid Update(Catologie item)
        {
            string query = string.Empty;
            //1 build query update of main item
            //2 build list query update of sub item
            //3 run sql query

            //--load data
            List<Catologie> listCatologies = new List<Catologie>();
            listCatologies = LoadListFromReader(CatologieDAL.GetAllCatologies(item.CatologyGuid, -1));

            if (listCatologies.Count < 1)
                return item.CatologyGuid;

            //--buid query
            query += @"SET XACT_ABORT ON
                     BEGIN TRANSACTION ";


            //lay then [0] lam truoc.
            //chay auto cac then con lai.
            query += @"UPDATE 		[dbo].[cont_Catologies] 

                        SET
			                        [CatologyName] = N'" + item.CatologyName + @"',
			                        [Description] = N'" + item.Description + @"',
			                        [KindCatologyGuid] = '" + item.KindCatologyGuid + @"',
			                        [KindCatologyName] = N'" + item.KindCatologyName + @"',
			                        IsActive='" + item.IsActive + @"',
                                    ListStringToSort=(select ListStringToSort from cont_Catologies where CatologyGuid='" + item.KindCatologyGuid + @"') + '" + item.ListStringToSort + @"',
				                    ListPlacementGuid=(select ListPlacementGuid from cont_Catologies where CatologyGuid='" + item.KindCatologyGuid + @"') + ';' + convert(nvarchar(256),'" + item.KindCatologyGuid + @"'),
				                    ListPlacementName=(select ListPlacementName from cont_Catologies where CatologyGuid='" + item.KindCatologyGuid + @"') + '\' + (select CatologyName from cont_Catologies where CatologyGuid='" + item.KindCatologyGuid + @"'),
				                    Levels=(select Levels from cont_Catologies where CatologyGuid='" + item.KindCatologyGuid + @"') + 1,
                                    ListPlacementID=convert(nvarchar(18),(select ListPlacementID from cont_Catologies where CatologyGuid='" + item.KindCatologyGuid + @"')) + '\' + convert(nvarchar(18),(select CatologyID from cont_Catologies where CatologyGuid='" + item.KindCatologyGuid + @"')),
				                    Position=" + item.Position + @",
                                    UserID="+item.UserID+@"
                                    IsNotDelete='"+item.IsNotDelete+@"'
			
                        WHERE
			                        [CatologyGuid] = '" + listCatologies[0].CatologyGuid + @"'";
            //cap nhat du lieu item dau tien trong list
            //listCatologies[0].ListStringToSort


            //update cac subItem
            for (int i = 1; i < listCatologies.Count; i++)
            {
                query += @"
                        UPDATE 		[dbo].[cont_Catologies] 
                        SET
                                    ListStringToSort=(select ListStringToSort from cont_Catologies where CatologyGuid='" + listCatologies[i].KindCatologyGuid + @"') + '" + ConstantVariable.ToBinary(listCatologies[i].Position) + @"',
				                    ListPlacementGuid=(select ListPlacementGuid from cont_Catologies where CatologyGuid='" + listCatologies[i].KindCatologyGuid + @"') + ';' + convert(nvarchar(256),'" + listCatologies[i].KindCatologyGuid + @"'),
				                    ListPlacementName=(select ListPlacementName from cont_Catologies where CatologyGuid='" + listCatologies[i].KindCatologyGuid + @"') + '\' + (select CatologyName from cont_Catologies where CatologyGuid='" + listCatologies[i].KindCatologyGuid + @"'),
                                    ListPlacementID=convert(nvarchar(18),(select ListPlacementID from cont_Catologies where CatologyGuid='" + listCatologies[i].KindCatologyGuid + @"')) + '\' + convert(nvarchar(18),(select CatologyID from cont_Catologies where CatologyGuid='" + listCatologies[i].KindCatologyGuid + @"')),
				                    Levels=(select Levels from cont_Catologies where CatologyGuid='" + listCatologies[i].KindCatologyGuid + @"') + 1
                        WHERE
			                        [CatologyGuid] = '" + listCatologies[i].CatologyGuid + @"'";
            }

            query += @" COMMIT TRANSACTION";

            return CatologieDAL.Update(query) ? item.CatologyGuid : Guid.Empty;

        }
        #endregion

        #region public Methods

        /// <summary>
        /// Deletes an instance of Catologie. Returns true on success.
        public bool Delete(Guid catologyGuid)
        {
            return CatologieDAL.Delete(catologyGuid);
        }

        // <summary>
        /// Saves this instance of Catologie. Returns a new Guid on success.
        /// </summary>
        public Guid Save(Catologie item)
        {
            if (item.CatologyGuid == Guid.Empty)
                return Create(item);
            return Update(item);
        }

        /// <summary>
        /// Gets an instance of Catologie.
        /// </summary>
        /// <param name="catologyGuid"> catologyGuid </param>
        public Catologie GetCatologie(Guid catologyGuid)
        {
            using (IDataReader reader = CatologieDAL.GetOne(catologyGuid))
            {
                return PopulateFromReader(reader);
            }
        }

        /// <summary>
        /// Gets an IList with page of instances of Catologie.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public List<Catologie> GetPage(int pageNumber, int pageSize, out int totalPages)
        {
            totalPages = 1;
            IDataReader reader = CatologieDAL.GetPage(pageNumber, pageSize, out totalPages);
            return LoadListFromReader(reader);
        }

        /// <summary>
        /// Gets an IList with all instances of Catologie.
        /// </summary>
        public List<Catologie> GetAll()
        {
            IDataReader reader = CatologieDAL.GetAll();
            return LoadListFromReader(reader);
        }
        #endregion

        #region add by tsandtm 11/3/2014
        public List<Catologie> GetPage(Guid rootGuid, int isActive, int pageNumber, int pageSize, out int totalPages)
        {
            totalPages = 1;
            IDataReader reader = CatologieDAL.GetPage(rootGuid, isActive, pageNumber, pageSize, out totalPages);
            return LoadListFromReader(reader);
        }
        public List<Catologie> GetAllCatologies(Guid valueGuid, int active)
        {
            return LoadListFromReader(CatologieDAL.GetAllCatologies(valueGuid, active));
        }
        public List<Catologie> GetAllDanhMuc_TheoDanhMucCha(Guid ValueGuid, int IsActive)
        {
            IDataReader reader = CatologieDAL.GetAllDanhMuc_TheoDanhMucCha(ValueGuid, IsActive);
            return LoadListFromReader(reader);
        }

        //public Guid GetDanhMucGuid_ByLoaiDanhMucGuid(Guid ValueGuid)
        //{
        //    using (IDataReader reader = CatologieDAL.GetDanhMucGuid_ByLoaiDanhMucGuid(ValueGuid))
        //    {
        //        if (reader.Read())
        //            return new Guid(reader["CatologyGuid"].ToString());
        //        return Guid.Empty;
        //    }
        //}
        //public bool Delete_ByLoaiDanhMucGuid(Guid ValueGuid)
        //{
        //    return CatologieDAL.Delete_ByLoaiDanhMucGuid(ValueGuid);
        //}

        ////---------------------------->lay tat ca du lieu danh muc dua vao guid cha<---------------------------//
        //List<Catologie> _items;
        //string valueTree = string.Empty;

        //private void BuidCatologies(string ValueString, Guid ValueGuid, string Symbol)
        //{
        //    ICatologieBAL itemBAL = new CatologieBAL();
        //    //Lay tat ca danh muc cung cap voi danh muc cha, Luon lay nhung gia tri da kich hoat
        //    IDataReader reader = CatologieDAL.GetAllDanhMuc_TheoDanhMucCha(ValueGuid, 1);
        //    List<Catologie> items = LoadListFromReader(reader);

        //    //them ky hieu
        //    if (ValueGuid != Guid.Empty)
        //        valueTree = valueTree + Symbol;

        //    foreach (Catologie item in items)
        //    {
        //        if (item.CatologyGuid != Guid.Empty)
        //            _items.Add(new Catologie(valueTree + item.CatologyName, item.CatologyGuid,item.CatologyID));
        //        BuidCatologies(item.CatologyName, item.CatologyGuid, Symbol); //Load de quy
        //    }
        //    if (ValueGuid != Guid.Empty)
        //        valueTree = valueTree.Remove(valueTree.Length - Symbol.Length, Symbol.Length);
        //}
        //---------------------------->End<---------------------------//
        #endregion


        public bool SaveFileThumbnail(Guid GuidCatology, string FileNameThumbnail)
        {
            return CatologieDAL.SaveFile(GuidCatology, FileNameThumbnail);
        }


        public Catologie GetCatologie(int catologyID)
        {
            using (IDataReader reader = CatologieDAL.GetOne(catologyID))
            {
                return PopulateFromReader(reader);
            }
        }


        public int GetMaxPositionByKindGuid(Guid Kindguid)
        {
           return  CatologieDAL.GetMaxPositionByKindGuid(Kindguid);
        }


        public Guid CreateImport(Catologie item)
        {
            item.CatologyGuid = Guid.NewGuid();
            int rowsAffected = CatologieDAL.CreateImport(item);
            return rowsAffected > 0 ? item.CatologyGuid : Guid.Empty;
        }


        public bool CheckExistUser(Catologie itemSP)
        {
            return CatologieDAL.CheckExistUser(itemSP);
        }
    }
}


