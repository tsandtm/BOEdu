using _project.library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using project.config.library.Utilities;


namespace project.web.mvc.Controllers
{
    public class UsersController : Controller
    {
        private const int DefaultPageSize = 20;
        private _project.library.hoa.IUsersBAL itemUserBAL = new _project.library.hoa.UsersBAL();

        //
        // GET: /Users/

        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int totalRows = 0;
            IList<Users> allEmployee = itemUserBAL.GetPage(currentPageIndex, DefaultPageSize, out totalRows);
            var listPaged = allEmployee.ToPagedList(currentPageIndex, DefaultPageSize, totalRows);

            if (listPaged == null)
                return HttpNotFound();

            ViewBag.ListUsers = listPaged;

            return View();
        }

        public ActionResult LoadListUsers(int? page)
        {
            ViewBag.Title = "Browse all products";

            int currentPageIndex = page.HasValue ? page.Value : 1;
            int totalRows = 0;

            // tim kiem theo dieu kien
            IList<Users> allEmployee = itemUserBAL.GetPage(currentPageIndex, DefaultPageSize, out totalRows);
            var listPaged = allEmployee.ToPagedList(currentPageIndex, DefaultPageSize, totalRows);

            if (listPaged == null)
                return HttpNotFound();

            ViewBag.ListUsers = listPaged;

            return PartialView("_PartialListUsers", listPaged);
        }


        //
        // GET: /Users/Create
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create()
        {
            Users item = new Users();

            return PartialView("_PartialPopupCreateUser", item);
        }



        //
        // GET: /Users/Edit/5
        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_view(int? diugresu)
        {
            return PartialView("_PartialPopupEditUser", itemUserBAL.GetUsers(diugresu.Value));
        }

        //
        // POST: /Users/Edit/5

        [HttpPost, ValidateInput(false)]
        [ActionName("Edit")]
        public ActionResult Edit(Users item)
        {
            //neu cac rang buoc ok 
            if (ModelState.IsValid)
            {
                if (item.UserId != 0)
                {
                    item.UpdatedDate = DateTime.Now;
                    item.UpdatedUser = new Guid(ConstantVariable.STRING_GUIDEMPTY);
                }
                else
                {
                    item.CreatedDate = DateTime.Now;
                    item.CreatedUser = new Guid(ConstantVariable.STRING_GUIDEMPTY);
                }
                //Save data
                item.UserId = itemUserBAL.Save(item);


                if (item.UserId != 0)
                {
                    ViewBag.ItemGuid = item.UserId;
                    return JavaScript("DialogAlert('','Cập nhập dữ liệu thành công', 'info');");
                }
                else
                    return JavaScript(" DialogAlert('','Cập nhập dữ liệu thất bại', 'error');");
            }
            return JavaScript("DialogAlert('','Dữ liệu chưa đúng', 'error');");
        }


        //
        // POST: /Users/Delete/5

        [HttpPost]
        public ActionResult Delete(string diugresu)
        {

            try
            {
                itemUserBAL.Delete(Int32.Parse(diugresu));
            }
            catch { return Json("error", JsonRequestBehavior.AllowGet); }
            return Json("ok", JsonRequestBehavior.AllowGet);
        }
    }
}
