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
        public ActionResult Index(int? id)
        {
            IUsersBAL itemUserBAL = new UsersBAL();
            int Userid = id == null ? WebSecurity.CurrentUserId : Convert.ToInt32(id);
            Users item = itemUserBAL.GetUsers(Userid);
            return View(item);
        }
        public ActionResult CreateChuongTrinhGiangDay(MonHoc item)
        {
            var flagCreate = false;
            if (item.MonHocGuid == null || item.MonHocGuid == Guid.Empty)
            {
                item.MonHocGuid = Guid.Empty;
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

        public ActionResult LoadDanhSachMon(int? id)
        {
            int Userid = id == null ? WebSecurity.CurrentUserId : Convert.ToInt32(id);
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
        public ActionResult CreateMon_View(int? id)
        {
            MonHoc item = new MonHoc();
            item.Userid = id == null ? 0 : Convert.ToInt32(id);
            return PartialView("_PartialThemMoiMonGiangDay", item);
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

            return View();
            //if (trangThai)
            //    return JavaScript("ReloadDanhSachMon('Thực hiện thành công')");
            //else
            //    return JavaScript("ReloadDanhSachMon('Thực hiện Thất bại')");
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
