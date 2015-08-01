<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;
using System.IO;
using ngocnv24052014.ecommerce.library.Presenters;
using ngocnv24052014.ecommerce.library.Models;

public class Upload : IHttpHandler,
System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.ContentType = "*";
        string TacVu = context.Request.Form["TacVu"];
        string Group = context.Request.Form["Group"];
        string UserGuid = context.Request.Form["UserGuid"];
        if (Group != "")
            Group = "_" + Group;
        else
            Group = "";

        HttpPostedFile fileToUpload = context.Request.Files["Filedata"];
        if (fileToUpload != null)
        {
            //nhận dữ liệu file để lưu
            string fileName = fileToUpload.FileName;
            byte[] buffer = new byte[fileToUpload.ContentLength];
            fileToUpload.InputStream.Read(buffer, 0, fileToUpload.ContentLength);
            string fileExt = System.IO.Path.GetExtension(fileToUpload.FileName);
            Guid name = System.Guid.NewGuid();
            string pathToSave = HttpContext.Current.Server.MapPath("~/Data/File/") + UserGuid.ToString() + Group + "_" + name.ToString() + fileExt;

            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Data/File/")))
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Data/File/"));
            
            fileToUpload.SaveAs(pathToSave);




            //băm hình theo chất lượng
            try
            {
                int[] W = { 40, 110, 276 };
                int[] H = { 40, 150, 245 };
                int[] Q = { 100, 100, 100 };
                string[] E = { HttpContext.Current.Server.MapPath("~/Data/File/59x50/"), HttpContext.Current.Server.MapPath("~/Data/File/150x110/"), HttpContext.Current.Server.MapPath("~/Data/File/300x250/") };
                foreach (string itemurl in E)
                    if (!Directory.Exists(itemurl))
                        Directory.CreateDirectory(itemurl);
                ngocnv24052014.ecommerce.library.Utilities.ImageHandler ImageHandler = new ngocnv24052014.ecommerce.library.Utilities.ImageHandler();
                ImageHandler.SaveImage(W, H, Q, E, HttpContext.Current.Server.MapPath("~/Data/File/"), UserGuid.ToString() + Group + "_" + name.ToString() + fileExt, buffer);
            }
            catch { }


            try
            {
                // save to database 
                IFileSystemBAL itemBAL = new FileSystemBAL();
                FileSystem item = new FileSystem();
                item.ClientFileName = fileName;
                item.FileType = fileExt;
                item.ItemGuid = Guid.Empty;
                item.ServerFileName = UserGuid.ToString() + Group + "_" + name.ToString() + fileExt;
                item.UpdatedDate = DateTime.Now;
                try
                {
                    item.UpdatedUser = new Guid(UserGuid);
                }
                catch { }
                item.TableName = TacVu;
                item.FileSystemGuid = Guid.Empty;
                item.FileSize = Convert.ToDecimal(fileToUpload.ContentLength) / Convert.ToDecimal(1024);
                itemBAL.Save(item);
            }
            catch { }


        }
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}