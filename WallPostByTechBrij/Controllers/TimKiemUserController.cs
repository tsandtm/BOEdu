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
    public class TimKiemUserController : Controller
    {
        IUsersBAL itemBAL = new UsersBAL();
        //
        // GET: /TimKiemUser/

        public ActionResult Index()
        {
            ViewBag.ListSearch = new List<Users>();
            return View();
        }
        [HttpGet]
        [ActionName("LoadListBySearch")]
        public ActionResult LoadBySearch(string keysearch)
        {
            List<Users> items = itemBAL.GetListUserByKeysearch(keysearch);
            ViewBag.CountResult = items.Count();
            ViewBag.KeysSearch = keysearch;
            return PartialView("_PartialListResults", items);
        }

        [HttpGet]
        [ActionName("GetListFollower")]
        public ActionResult GetDanhSachTheoDoi()
        {
            int userlogin = WebSecurity.CurrentUserId;
            List<Users> items = itemBAL.GetListFollowerById(userlogin);
            return PartialView("_PartialDanhSachTheoDoi", items);
        }


        [HttpGet]
        [ActionName("addusertofollowlist")]
        public ActionResult addusertofollowlist(int id)
        {
            int userlogin = WebSecurity.CurrentUserId;
            bool trangthai = itemBAL.CapNhapDanhSachFollower(userlogin, id);
            //if (trangthai)
            //{
                List<Users> items = itemBAL.GetListFollowerById(userlogin);
                return PartialView("_PartialDanhSachTheoDoi", items);
            //}
            //return View();
        }

    }
}
