using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chuongtv01082015.library.chuong;
using WallPostByTechBrij.Filters;
using WebMatrix.WebData;

namespace WallPostByTechBrij.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class ChuongTrinhGiangDayController : Controller
    {
        IMonHocBAL itemBAL = new MonHocBAL();
        //
        // GET: /ChuongTrinhGiangDay/
        public ActionResult Index()
        {
            //return JavaScript("GetTabDanhSachMonHoc('#thongtindanhsachmonhoc')");
            return View();
        }
        public ActionResult CreateChuongTrinhGiangDay(MonHoc item)
        {
            var flagCreate = false;
            if (item.MonHocGuid == null || item.MonHocGuid == Guid.Empty)
            {
                item.MonHocGuid = Guid.Empty;
                item.Userid = 1;
                flagCreate = true;
            }
            Guid trangThai = itemBAL.Save(item);
            if (trangThai != Guid.Empty)
                if (flagCreate)
                    return JavaScript("ClosePopupAndLoadDataChuong('#modalCreateMon','#thongtindanhsachmonhoc','Thực hiện thành công')");
                else
                    return JavaScript("ClosePopupAndLoadDataEditChuong('#modalEditMon','#thongtindanhsachmonhoc','Thực hiện thành công')");
            return View();
        }

        public ActionResult LoadDanhSachMon()
        {
            int Userid = 1;
            return PartialView("_PartialDanhSachMonHoc", itemBAL.GetAllMonHocTheoGiangVien(Userid));
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

        [HttpPost]
        [ActionName("ThemFileVaoCap")]
        public ActionResult ThemFileVaoCap(Guid fileguid)
        {
            int userlogin = WebSecurity.CurrentUserId;
            bool trangThai = itemBAL.ThemTaiLieuVaoCapDienTu(fileguid, userlogin);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
