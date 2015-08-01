using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nvn.Library.Helpers;
using project.config.library;
using project.config.library.Utilities;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using WallPostByTechBrij.Filters;
using WallPostByTechBrij.Models;

namespace project.web.mvc.Controllers
{
    public class FileSystemController : Controller
    {
        //
        // GET: /FileSystem/
        IFileSystemBAL itemBAL = new FileSystemBAL();
        public ActionResult Index()
        {
            ViewBag.ListFiles = new List<FileSystem>();
            return View();
        }
        public ActionResult Index2()
        {
            ViewBag.ItemGuid = new Guid("7e55be15-c62e-4f71-803f-3edb93a08fbb");
            ViewBag.ListFiles = new List<FileSystem>();
            return View();
        }
        [HttpGet]
        [ActionName("LoadList")]
        public ActionResult LoadList_view(string catGuid)
        {
            //7e55be15-c62e-4f71-803f-3edb93a08fbb
            ViewBag.ListFiles = itemBAL.GetAllByItemGuid(new Guid(catGuid));

            return PartialView("_PartialListFiles");
        }


        public ActionResult Delete(string q)
        {
            try
            {
                Guid FileGuid = new Guid(q);
                FileSystem item = itemBAL.GetFileSystem(FileGuid);

                if (System.IO.File.Exists(Server.MapPath("~/Data/" + item.ServerFileName)))
                    //tiến hanh xóa file
                    System.IO.File.Delete(Server.MapPath("~/Data/"+item.ServerFileName));
                try
                {
                    itemBAL.Delete(FileGuid);
                }
                catch (Exception ex)
                {
                }
                
               
            }
            catch { return Json("error", JsonRequestBehavior.AllowGet); }
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName("CreateFiles")]
        //BatDauTenFile là IDdoanhnghie_IDthongtinhoptac
            //mục đích để xóa nhanh khi xóa doanh nghiệp
        public ActionResult CreateFiles_add(string catGuid)
        {
            Guid UserCreate = Guid.NewGuid();
            string query = @"SET XACT_ABORT ON
                            BEGIN TRANSACTION
                            ";
            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];
                int fileSizeInBytes = file.ContentLength;
                byte[] buffer = new byte[file.ContentLength];   //get buffer data image to convert
                file.InputStream.Read(buffer, 0, file.ContentLength);
                string fileExt = System.IO.Path.GetExtension(file.FileName);
                try
                {
                    if (file != null)
                    {
                       
                        //var fileNameClient = StringHelper.RemoveSpace(Path.GetFileName(file.FileName));
                        string guidFileNameServer = Guid.NewGuid().ToString();
                        string fileNameServer = guidFileNameServer + fileExt;
                        var path = Path.Combine(Server.MapPath("~/Data"), fileNameServer);
                        if (!System.IO.Directory.Exists(Server.MapPath("~/Data")))
                            System.IO.Directory.CreateDirectory(Server.MapPath("~/Data"));

                        file.SaveAs(path );
                        //dung ham lay ra cautruc noiluu tru dua vao id

                        query += @"
                            INSERT INTO [doc_FileSystem]
                                   ([FileSystemGuid]
                                    ,FileSystemID
                                   ,[FileType]
                                   ,[FileSize]
                                   ,[ClientFileName]
                                   ,[ServerFileName]
                                   ,[UpdatedDate]
                                   ,[UpdatedUser]
                                   ,[ItemGuid]
                                   ,[TableName]
                                   ,[MapPath],ShareNumber,IsDelete)
                             VALUES
                                   (newID()
                                   ,'test'
                                   ,'" + fileExt + @"'
                                   ," + fileSizeInBytes / 1024 + @"
                                   ,N'" + Path.GetFileName(file.FileName) + @"'
                                   ,'" + fileNameServer + @"'
                                   ,getdate()
                                   ,'" +UserCreate+@"'
                                   ,'" + catGuid + @"'
                                   ,'" + 1 + @"'
                                   ,'Data/',0,'false')";

                    }
                }
                catch (Exception ex)
                {
                    return Json(new { Message = "Error in saving file" });
                }
            }

            query += @"COMMIT TRANSACTION";
            itemBAL.SaveFiles(query);
            return Json(new { Message = "File saved" });
        }
        
    
    }
}
