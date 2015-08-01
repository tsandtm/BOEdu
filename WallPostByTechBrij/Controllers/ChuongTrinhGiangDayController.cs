using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chuongtv01082015.library.chuong;

namespace WallPostByTechBrij.Controllers
{
    public class ChuongTrinhGiangDayController : Controller
    {
        IMonHocBAL itemBAL = new MonHocBAL();
        //
        // GET: /ChuongTrinhGiangDay/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateChuongTrinhGiangDay(MonHoc item)
        {
            if (item.MonHocGuid == null || item.MonHocGuid == Guid.Empty)
            {
                item.MonHocGuid = Guid.Empty;
                item.GiangVienGuid = new Guid("a66e725d-a10a-452e-8dba-f1b63da67048");
            }
            Guid trangThai = itemBAL.Save(item);
            if (trangThai != Guid.Empty)
                if (item.MonHocGuid == Guid.Empty)
                    return JavaScript("ClosePopupAndLoadDataChuong('#modalCreateMon','#thongtindanhsachmonhoc','Thực hiện thành công')");
                else
                    return JavaScript("ClosePopupAndLoadDataEditChuong('#modalEditLienHe','#thongtindanhsachmonhoc','Thực hiện thành công')");
            return View();
        }

        public ActionResult LoadDanhSachMon()
        {
            Guid GiangVienGuid = new Guid("a66e725d-a10a-452e-8dba-f1b63da67048");
            return PartialView("_PartialDanhSachMonHoc", itemBAL.GetAllMonHocTheoGiangVien(GiangVienGuid));
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult EditMon_View(string monhocguid)
        {
            Guid monhoc;
            try
            {
                monhoc = new Guid(monhocguid);
            }
            catch (Exception)
            {
                monhoc = Guid.Empty;
            }
            return PartialView("_PartialChinhSuaMonHoc", itemBAL.GetMonHoc(monhoc));
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult CreateMon_View()
        {
            return PartialView("_PartialDanhSachMonHoc", new chuongtv01082015.library.chuong.MonHoc());
        }

        [ActionName("Delete")]
        public ActionResult Delete(string monhocguid)
        {
            Guid monhoc;
            try
            {
                monhoc = new Guid(monhocguid);
            }
            catch (Exception)
            {
                monhoc = Guid.Empty;
                return View();
            }
            bool trangThai = itemBAL.Delete(monhoc);
            if (trangThai)
                return JavaScript("ReloadDanhSachMon('Thực hiện thành công')");
            else
                return JavaScript("ReloadDanhSachMon('Thực hiện Thất bại')");
        }

        [HttpPost]
        [ActionName("DeleteLinkURL")]
        public ActionResult DeleteLinkURL(string buoiguid)
        {
            Guid monhoc;
            try
            {
                monhoc = new Guid(buoiguid);
            }
            catch (Exception)
            {
                monhoc = Guid.Empty;
                return View();
            }
            bool trangThai = itemBAL.DeleteLinkURL(monhoc);
            return Json(trangThai, JsonRequestBehavior.AllowGet);
        }
    }
}
