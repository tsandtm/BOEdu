<%@ WebHandler Language="C#" Class="Download" %>
using System;
using System.IO;
using System.Web;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip;
public class Download : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        // Get the file name from the query string
        string queryFile = context.Request.QueryString["us"];


        // Ensure that we were passed a file name
        if (string.IsNullOrEmpty(queryFile))
            throw new HttpException(404, null);
        //kiểm tra tất cả các file zip
        var thuMucTam = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/Data/TempMienGiamMon/").Trim());
        FileInfo[] allFilesZip = thuMucTam.GetFiles("*.Zip", SearchOption.AllDirectories);
        foreach (FileInfo item in allFilesZip)
        {
            if (item.LastWriteTime.Date <= DateTime.Now.AddDays(-1).Date)
            { File.Delete(item.FullName); 
            }
        }


        var thuMuc = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/Data/TempMienGiamMon/" + queryFile).Trim());
        
        string fileName = string.Format("{0}", queryFile);

        //không tìm thấy thư mục thì tìm file nén 
        if (Directory.Exists(HttpContext.Current.Server.MapPath("~/Data/TempMienGiamMon/" + queryFile)))
        {
            FileInfo[] allFiles = thuMuc.GetFiles("*.*", SearchOption.AllDirectories);
            ZipFiles(allFiles, fileName, HttpContext.Current.Server.MapPath("~/Data/TempMienGiamMon/"));
        }
    
        //if (File.Exists(HttpContext.Current.Server.MapPath("~/Data/TempMienGiamMon/" + queryFile + ".Zip")))
        //        {
        //}
        

        // Generate the server file name        
        string fileurl = Path.Combine(HttpContext.Current.Server.MapPath("~/Data/TempMienGiamMon/"), queryFile.ToString());

        // Ensure that the file exists
        if (!File.Exists(fileurl + ".Zip"))
            throw new HttpException(404, null);

        // Set the content type
        // TODO: set based on extension
        context.Response.ContentType = "*.Zip";
        context.Response.ContentType = "text/plain";

        // Set the filename
        context.Response.AddHeader("content-disposition", "attachment;filename=DataMienGiam" + DateTime.Now.ToString(@"yyyyMMdd") + "_" + DateTime.Now.ToString(@"HHmmss") + ".Zip");

        // Stream the file to the client
        context.Response.WriteFile(fileurl + ".Zip");
    }




    private void ZipFiles(FileInfo[] files, string FileName, string url)
    {
        try
        {
            string zipFile = Path.Combine(url, FileName + ".Zip");

            ZipOutputStream zipOut = new ZipOutputStream(File.Create(zipFile));
            foreach (FileInfo fileInfo in files)
            {
                ZipEntry entry = new ZipEntry(fileInfo.Name);
                FileStream fileStream = File.OpenRead(fileInfo.FullName);
                byte[] buffer = new byte[Convert.ToInt32(fileStream.Length)];
                fileStream.Read(buffer, 0, (int)fileStream.Length);
                entry.DateTime = fileInfo.LastWriteTime;
                entry.Size = fileStream.Length;
                fileStream.Close();

                zipOut.PutNextEntry(entry);
                zipOut.Write(buffer, 0, buffer.Length);
            }

            zipOut.Finish();
            zipOut.Close();
            zipOut.Dispose();

            if (Directory.Exists(url + FileName))
                Directory.Delete(url +  FileName,true);
        }
        catch (Exception ex)
        {

        }
    }
    public bool IsReusable
    {
        get { return true; }
    }
}