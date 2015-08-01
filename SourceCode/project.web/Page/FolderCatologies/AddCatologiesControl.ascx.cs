//Author:					Nguyen Van Ngoc
//Created:				    2014-3-11
//Last Modified:			2014-3-11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ngocnv10052014.catology.library.Models;
using ngocnv10052014.catology.library.Views;
using nvn.Library.Patterns;
using nvn.Library.Utility;
using AjaxControlToolkit;
using System.IO;
using project.config.library.Utilities;

namespace project.web.Controls
{
    public partial class AddCatologieControl : System.Web.UI.UserControl, IAddCatologiesView
    {
        #region Su kien dung de goi qua control khac
        public event EventHandler<TowParameterEventAgrs<string, Guid>> CallHandler;
        protected void OnCallHandler(string TacVu, Guid ValueGuid)
        {
            if (CallHandler != null)
            {
                CallHandler(this, new TowParameterEventAgrs<string, Guid>(TacVu, ValueGuid));
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //    OnFristLoadEventHandler();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.InitView();
            ButtonSave.Click += new EventHandler(ButtonSave_Click);
            ButtonExit.Click += new EventHandler(ButtonExit_Click);

            AsyncFileUpload1.UploadedComplete += new EventHandler<AsyncFileUploadEventArgs>(AsyncFileUpload1_UploadedComplete);
            AsyncFileUpload1.UploadedFileError += new EventHandler<AsyncFileUploadEventArgs>(AsyncFileUpload1_UploadedFileError);
        }

        #region Load du lieu lan dau tien
        private void KhoiTaoGiaTriBanDau()
        {
        }
        public void LoadData(string TacVu, object Value)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Show", Popup.OpenPopup("ts-popup"), false);

            if (TacVu.Equals(ConstantVariable.TACVU_EDIT))
            {
                PanelFileUpload.Visible = true;

                OnLoadData_Event(ConstantVariable.TACVU_EDIT, new Guid(Value.ToString()));
                UpdatePanelPopupAddCatologie_on.Update();
                return;
            }

            if (TacVu.Equals(ConstantVariable.TACVU_ADD))
            {
                PanelFileUpload.Visible = false;


                OnLoadData_Event(ConstantVariable.TACVU_ADD, Guid.Empty);
                UpdatePanelPopupAddCatologie_on.Update();
                return;
            }
        }
        #endregion

        #region All event
        void ButtonExit_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Show", Popup.ExitPopup("ts-popup"), false);
            UpdatePanelPopupAddCatologie_on.Update();
            OnCallHandler(ConstantVariable.TACVU_REFRESH, Guid.Empty);
        }

        void ButtonSave_Click(object sender, EventArgs e)
        {
            Catologie item = new Catologie();

            //Truyen du lieu vao
            try
            {
                item.CatologyGuid = new Guid(LiteralCatologyGuid.Text);
            }
            catch (Exception)
            {
                item.CatologyGuid = Guid.Empty;
            }

            item.CatologyName = TextBoxCatologyName.Text.Trim();
            item.Description = TextBoxDescription.Text;
            item.KindCatologyGuid = new Guid(DropDownListCatologies.SelectedValue);
            item.KindCatologyName = DropDownListCatologies.SelectedItem.ToString();
            item.IsActive = CheckBoxIsActive.Checked;
            try
            {
                item.Position = Convert.ToInt16(TextBoxPosition.Text);
            }
            catch (Exception)
            {
                ErrorMessage = "Thứ tự hiển thị không được nhập chữ.";
            }


            //control hien thi trang chu
            //item.SaveSetting = false;
            //item.SaveSetting = true;
            //item.SettingGroup = "SHOW";//ten cua nhom setting
            //item.SettingValue = "";//guid cua item can luu setting

            //Check loi
            //Kiem tra  loi trung danh muc 
            if (item.KindCatologyGuid == item.CatologyGuid)
            {
                ErrorMessage = "Vui lòng lựa chọn nhóm danh mục khác!";
                UpdatePanelPopupAddCatologie_on.Update();
                return;
            }

            //Kiem tra null ten danh muc
            if (item.CatologyName == string.Empty)
            {
                ErrorMessage = "Vui lòng nhận tên danh mục!";
                UpdatePanelPopupAddCatologie_on.Update();
                return;
            }

            OnSave_Event(item);
            UpdatePanelPopupAddCatologie_on.Update();
        }
        #endregion

        #region Emplement
        public Guid guidRootCatology
        {
            get { return new Guid("0c7874c2-5221-4753-a533-ba5069b1d37a"); }
        }

        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>property<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        public string ErrorMessage
        {
            set
            {
                if (value != null)
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Error", ShowMessage.Error(value), false);
            }
        }
        public string SuccessMessage
        {
            set
            {
                if (value != null)
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Success", ShowMessage.Success(value), false);
            }
        }

        public string WaningMessage
        {
            set
            {
                if (value != null)
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Waning", ShowMessage.Waning(value), false);
            }
        }
        public Catologie itemCatologie
        {
            set
            {
                if (value.KindCatologyGuid != Guid.Empty)
                    DropDownListCatologies.SelectedValue = value.KindCatologyGuid.ToString();

                LiteralCatologyGuid.Text = value.CatologyGuid.ToString();
                LableCatologyID.Text = value.CatologyID.ToString();
                TextBoxCatologyName.Text = value.CatologyName;
                TextBoxDescription.Text = value.Description;
                CheckBoxIsActive.Checked = value.IsActive;
                TextBoxPosition.Text = value.Position.ToString();
                string urlImage = ResolveUrl("~/Data/ImageCatology/") + value.UrlHinhanh.ToString();
                if (!string.IsNullOrEmpty(value.UrlHinhanh) && File.Exists(MapPath(urlImage)))
                    img_prev.Attributes.Add("src", urlImage);
                else
                    img_prev.Attributes.Add("src", ResolveUrl("~/") + ConstantVariable.URL_NOIMAGE);
            }
        }
        public List<Catologie> listCatologies
        {
            set
            {
                string temp;
                foreach (Catologie item in value)
                {
                    temp = string.Empty;
                    if (item.Levels > 1)
                        temp += "|";
                    for (int i = 1; i < item.Levels; i++)
                    {
                        temp = temp + "____";
                    }
                    item.CatologyName = temp + item.CatologyName;
                }

                DropDownListCatologies.Items.Clear();
                DropDownListCatologies.DataSource = value;
                DropDownListCatologies.DataTextField = "CatologyName";
                DropDownListCatologies.DataValueField = "CatologyGuid";
                DropDownListCatologies.DataBind();
            }
        }

        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Event<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        public event EventHandler<EventArgs> FristLoadEventHandler;
        private void OnFristLoadEventHandler()
        {
            if (FristLoadEventHandler != null)
                FristLoadEventHandler(this, new EventArgs());
        }

        public event EventHandler<TowParameterEventAgrs<string, Guid>> LoadData_Event;
        private void OnLoadData_Event(string valueString, Guid valueGuid)
        {
            if (LoadData_Event != null)
                LoadData_Event(this, new TowParameterEventAgrs<string, Guid>(valueString, valueGuid));
        }

        public event EventHandler<OneParameterEventAgrs<Catologie>> Save_Event;
        private void OnSave_Event(Catologie parameterValue)
        {
            if (Save_Event != null)
                Save_Event(this, new OneParameterEventAgrs<Catologie>(parameterValue));
        }
        #endregion

        #region Save file thumbnail
        void AsyncFileUpload1_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {
            // Uncomment to save to AsyncFileUpload\Uploads folder.
            // ASP.NET must have the necessary permissions to write to the file system.
            Catologie item = new Catologie();
            item.CatologyGuid = new Guid(LiteralCatologyGuid.Text);
            item.UrlHinhanh = AsyncFileUpload1.FileName;
            item.DataImage = AsyncFileUpload1.FileBytes;

            //co the xay ra loi cho nay
            OnSaveFile_Event(item);
        }

        void AsyncFileUpload1_UploadedFileError(object sender, AsyncFileUploadEventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "error", "top.$get(\"" + uploadResult.ClientID + "\").innerHTML = 'Error: " + e.StatusMessage + "';", true);
        }

        public event EventHandler<OneParameterEventAgrs<Catologie>> SaveFile_Event;
        private void OnSaveFile_Event(Catologie paraValue)
        {
            if (SaveFile_Event != null)
                SaveFile_Event(this, new OneParameterEventAgrs<Catologie>(paraValue));
        }

        public string UrlServer
        {
            get { return HttpContext.Current.Server.MapPath("~/Data/"); }
        }
        public string[] ListUrl
        {
            get
            {
                string[] ListUrl = { HttpContext.Current.Server.MapPath("~/Data/ImageCatology/") };
                return ListUrl;
            }
        }
        public int[] ListHight
        {
            get
            {
                int[] listHight = { 300 };
                return listHight;
            }
        }
        public int[] ListWith
        {
            get
            {
                int[] listWith = { 300 };
                return listWith;
            }
        }
        public int[] ListQuality
        {
            get
            {
                int[] listQuality = { 100 };
                return listQuality;
            }
        }
        #endregion
    }
}

