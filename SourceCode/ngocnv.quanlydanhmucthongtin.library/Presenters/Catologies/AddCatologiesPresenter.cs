

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nvn.Library.Patterns.MVP;
using nvn.Library.Patterns;
using ngocnv10052014.catology.library.Views;
using ngocnv10052014.catology.library.Models;
using System.IO;
using project.config.library.Utilities;
using nvn.Library.Helpers;

namespace ngocnv10052014.catology.library.Presenters
{
    public class AddCatologiesPresenter : BasePresenter<IAddCatologiesView>
    {
        public AddCatologiesPresenter(IAddCatologiesView view)
            : base(view)
        {
            this.view.LoadData_Event += new EventHandler<TowParameterEventAgrs<string, Guid>>(view_LoadData_Event);
            this.view.Save_Event += new EventHandler<OneParameterEventAgrs<Catologie>>(view_Save_Event);
            this.view.SaveFile_Event += new EventHandler<OneParameterEventAgrs<Catologie>>(view_SaveFile_Event);
        }



        #region Event

        void view_SaveFile_Event(object sender, OneParameterEventAgrs<Catologie> e)
        {
            Catologie item = e.myType;

            ICatologieBAL itemBAL = new CatologieBAL();
            if (itemBAL.SaveFileThumbnail(item.CatologyGuid, item.UrlHinhanh))//nếu chọn file mới tiến hành upload file
            {
                if (item.DataImage != null)
                {
                    if (!Directory.Exists(view.UrlServer))
                        try
                        {
                            Directory.CreateDirectory(view.UrlServer);
                        }
                        catch (Exception)
                        {
                            view.ErrorMessage = "Không thể tạo thư mục chứa file";
                        }
                    SaveFiles(item.DataImage, view.UrlServer + item.UrlHinhanh);
                    //Xu ly luu hinh anh cho bang detail
                    string[] E = view.ListUrl;
                    foreach (string itemurl in E)
                    {
                        //neu chua co thu luc thi tao moi
                        if (!Directory.Exists(itemurl))
                            Directory.CreateDirectory(itemurl);
                    }
                    ImageHandler ImageHandler = new ImageHandler();
                    ImageHandler.SaveImage(view.ListWith, view.ListHight, view.ListQuality, E, view.UrlServer, item.UrlHinhanh, item.DataImage);
                }
            }

        }

        void view_Save_Event(object sender, OneParameterEventAgrs<Catologie> e)
        {
            ICatologieBAL itemBAL = new CatologieBAL();
            Catologie item = e.myType;

            //bo sung du lieu cho doi tuong item
            item.ListStringToSort = ConstantVariable.ToBinary(item.Position);

            //Save data
            item.CatologyGuid = itemBAL.Save(item);
            if (item.CatologyGuid != Guid.Empty)
            {
                view.ErrorMessage = "Thao tác thành công!";
                BindingData(item.CatologyGuid);
            }
            else
                view.ErrorMessage = "Thao tác thất bại!";
        }
        void view_LoadData_Event(object sender, TowParameterEventAgrs<string, Guid> e)
        {
            BindingData(e.V);
        }
        #endregion

        #region private method

        private void SaveFiles(byte[] data, string url)
        {
            try
            {
                using (BinaryWriter Writer = new BinaryWriter(File.Open(url, FileMode.Create)))
                {
                    Writer.Write(data);
                    Writer.Flush();
                    Writer.Close();
                }
            }
            catch (Exception)
            {
                view.ErrorMessage = "Lưu file lên server thất bại";
            }
        }
        private void BindingData(Guid catologyGuid)
        {
            ICatologieBAL itemBAL = new CatologieBAL();
            //lay len danh sach danh muc
            view.listCatologies = itemBAL.GetAllCatologies(view.guidRootCatology, 1);

            //neu catology guid rong thi xem nhu tao moi. neu co guild thi load du lieu len
            if (catologyGuid != Guid.Empty)
                view.itemCatologie = itemBAL.GetCatologie(catologyGuid);
            else
                view.itemCatologie = new Catologie();

        }

        #endregion

    }
}



