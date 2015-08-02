using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ngocnv10052014.catology.library.Models;
using project.config.library.Utilities;
using WallPostByTechBrij.Filters;
using WebMatrix.WebData;
using chuongtv01082015.library.chuong;

namespace WallPostByTechBrij.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class ManageDocController : Controller
    {
        //
        // GET: /ManageDoc/
        ICatologieBAL itemBAL = new CatologieBAL();
        public ActionResult Index()
        {
            ViewBag.ListCat = new List<Catologie>();
           int user=  WebSecurity.CurrentUserId;
           
            List<Catologie> list = itemBAL.GetAllCatologiesByUserID(user);

            ViewBag.ListDanhMuc = list;
            return View();
        }

        public ActionResult LoadListDanhMuc()
        {
            ViewBag.ListCat = new List<Catologie>();
            int user = WebSecurity.CurrentUserId;
            List<Catologie> list = itemBAL.GetAllCatologiesByUserID(user);
            return PartialView("CauHinhCoBan/_PartialListCauHinhCaiDat", list);
        }



        #region ngoc

        [HttpPost]
        [ActionName("ShareDocForStudent")]
        public ActionResult ShareDocForStudent_post(string buoi,string mon)
        {
            IBuoiGiangDayBAL buoigiangdayBAL = new BuoiGiangDayBAL();
            try
            {
                Guid buoiguid = new Guid(buoi);
                Guid monguid = new Guid(mon);
                
                //kiem tra ok hay ko
                buoigiangdayBAL.ShareDocForStudent(buoiguid,monguid);
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //LogError.SaveLogEvent("DoanhNghiep/EditThongTinLienHe", ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [ActionName("EditShare")]
        public ActionResult EditThongTinLienHe_view(string fileguid)
        {
            IBuoiGiangDayBAL buoigiangdayBAL = new BuoiGiangDayBAL();
            try
            {
                //lay len cac mon hoc thay nay day
                Guid fileguida = new Guid(fileguid);
                BuoiGiangDay aaa=new BuoiGiangDay();
                aaa.FileSystemGuid = fileguida;

                IMonHocBAL mm = new MonHocBAL();
                aaa.ListMonHoc = mm.GetAllMonHocTheoGiangVien(WebSecurity.CurrentUserId);
                aaa.ListMonHoc.Insert(0, new MonHoc(Guid.Empty, "---Chọn môn học---"));

                return PartialView("_PartialShare", aaa);
            }
            catch (Exception ex)
            {
                //LogError.SaveLogEvent("DoanhNghiep/EditThongTinLienHe", ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult LoadListBuoi(string MonGuid,string fg)
        {
            ViewData["fileguidsytem"] = fg;
            IBuoiGiangDayBAL buoigiangdayBAL = new BuoiGiangDayBAL();
            try
            {
                Guid MonGuida = new Guid(MonGuid);
                List<BuoiGiangDay> listbuoi = buoigiangdayBAL.GetAllByMonGuidAndUser(MonGuida, 1);

                return PartialView("_PartialListBuoiTheoMon", listbuoi);
            }
            catch (Exception ex)
            {
                //LogError.SaveLogEvent("DoanhNghiep/EditThongTinLienHe", ex.Message);
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region dai
        [HttpGet]
        [ActionName("Add")]
        public ActionResult Add_view(string gr)
        {
            ViewBag.ItemGuid = gr;
            int user = WebSecurity.CurrentUserId;
            List<Catologie> list = itemBAL.GetAllCatologiesByUserID(user);
            string temp;
            foreach (Catologie item in list)
            {
                temp = string.Empty;
                if (item.Levels > 1)
                    temp += "|";
                for (int i = 1; i < item.Levels; i++)
                {
                    temp = temp + "___";
                }
                item.CatologyName = temp + item.CatologyName;
            }
            ViewBag.ListCat = list;

            //neu catology guid rong thi xem nhu tao moi. neu co guild thi load du lieu len
            return PartialView("CauHinhCoBan/_PartialAddCauHinhCaiDat", new Catologie());
        }

        /// <summary>
        /// Luu du lieu sau khi sua
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Edit(Catologie item,Guid r)
        {
            //chi cap nhat cac truong trong danh sach
            //UpdateModel(employee, new string[] { "ID", "Gender", "City", "DateOfBirth" });
            ViewBag.ItemGuid = r;
            item.KindCatologyGuid = r;
            //neu cac rang buoc ok 
            if (ModelState.IsValid)
            {
                int max = itemBAL.GetMaxPositionByKindGuid(item.KindCatologyGuid);
              item.Position = ++max;
                //bo sung du lieu cho doi tuong item
              item.ListStringToSort = ConstantVariable.ToBinary(item.Position);
              item.IsActive = true;
              item.UserID= WebSecurity.CurrentUserId;
               
                //Save data
                item.CatologyGuid = itemBAL.Save(item);
                ViewBag.ItemGuid = item.CatologyGuid;
                if (item.CatologyGuid != Guid.Empty)
                {
                    return Content("<div class='alert alert-info'>Thao tác thành công!</div>", "text/html");
                }
                else
                    Content("<div class='alert alert-danger'>Thao tác thất bại!</div>", "text/html");
            }
            return View();
        }

        /// <summary>
        /// Luu du lieu sau khi sua
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_DM(Catologie item)
        {
            //chi cap nhat cac truong trong danh sach
            //UpdateModel(employee, new string[] { "ID", "Gender", "City", "DateOfBirth" });

            //neu cac rang buoc ok 
            if (ModelState.IsValid)
            {
                //int max = itemBAL.GetMaxPositionByKindGuid(r);
                //item.Position = ++max;
                //bo sung du lieu cho doi tuong item
               //item.ListStringToSort = ConstantVariable.ToBinary(item.Position);
                item.IsActive = true;
              
                item.UserID = WebSecurity.CurrentUserId;

                //Save data
                item.CatologyGuid = itemBAL.Save(item);
                ViewBag.ItemGuid = item.CatologyGuid;
                if (item.CatologyGuid != Guid.Empty)
                {
                    return Content("<div class='alert alert-info'>Thao tác thành công!</div>", "text/html");
                }
                else
                    Content("<div class='alert alert-danger'>Thao tác thất bại!</div>", "text/html");
            }
            return View();
        }


        public ActionResult Delete( string idCat)
        {
            //viết code xóa ở đây
            ICatologieBAL itemBAL = new CatologieBAL();

            try
            {
                itemBAL.Delete(new Guid(idCat));
            }
            catch { return Json("error", JsonRequestBehavior.AllowGet); }
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_view(Guid q)
        {

            ICatologieBAL itemBAL = new CatologieBAL();
            int user = WebSecurity.CurrentUserId;
            //lay len danh sach danh muc
            List<Catologie> list = itemBAL.GetAllCatologiesByUserIDNotChilrend(user,q);
            string temp;
            foreach (Catologie item in list)
            {
                temp = string.Empty;
                if (item.Levels > 1)
                    temp += "|";
                for (int i = 1; i < item.Levels; i++)
                {
                    temp = temp + "____";
                }
                item.CatologyName = temp + " " + item.CatologyName;
            }
            ViewBag.ListCat = list;

            //neu catology guid rong thi xem nhu tao moi. neu co guild thi load du lieu len
            if (q != Guid.Empty)
                return PartialView("CauHinhCoBan/_PartialEditCauHinhCaiDat", itemBAL.GetCatologie(q));
            return PartialView("CauHinhCoBan/_PartialEditCauHinhCaiDat", new Catologie());
        }
        #endregion
    }
}
                                                                                                                              