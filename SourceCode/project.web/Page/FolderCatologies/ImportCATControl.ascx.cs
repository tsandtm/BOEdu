using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Resources;

using System.Web.Security;
using System.Configuration;
using nvn.Library.Utility;

using System.Globalization;
using ngocnv10052014.catology.library.Models;
using project.config.library.Utilities;
using thanhdai18htquanlyphanquyen.Library.Presenters;
using project.web;
using WebMatrix.WebData;


namespace DA.Web.Controls.ImportData
{
    public partial class ImportCATControl : System.Web.UI.UserControl
    {
        #region Variable
        private bool IsError = false; // dont alow insert data if true
        #endregion

        #region Cac su kien uy thac
        public event EventHandler ReloadData;
        protected void onReloadData()
        {
            if (ReloadData != null)
            {
                ReloadData(this, new EventArgs());
            }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Show();
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            ImageButtonUpload.Click += new EventHandler(ImageButtonUpload_Click);
            ImageButtonSave.Click += new EventHandler(ImageButtonSave_Click);
            ImageButtonBack.Click += new EventHandler(ImageButtonBack_Click);
            ImageButtonExit.Click += new EventHandler(ImageButtonExit_Click);
        }


        #region Load All data

        public void Show()
        {
            PopulateControls(Step.Step1);
        }
        #endregion

        #region All Event

        void ImageButtonExit_Click(object sender, EventArgs e)
        {
            PopulateControls(Step.Step1);
        }
        void ImageButtonBack_Click(object sender, EventArgs e)
        {
            PopulateControls(Step.Step1);
        }
        void ImageButtonSave_Click(object sender, EventArgs e)
        {
            PopulateControls(Step.Step3);
            if (!IsError)
            {

ICatologieBAL itemBAL = new CatologieBAL();

                using (DataSet ds = TempXMLHelper.ReadTemporayDataFromXml(Server.MapPath(ConfigurationManager.AppSettings["VALUE_PATH_XML_INFOTEACHING"] + "/" + SiteUtils.GetCurrentUserId().ToString() + ".xml")))
                {
                    if (ds.Tables.Count > 0)
                    {
                        DataTable dataTable = ds.Tables[0];
                        int count = 0;
                        //Save data
                        DateTime _dateUpdate = DateTime.Now;
                        int maxPosition = itemBAL.GetMaxPositionByKindGuid(ConstantVariable.Catologys_Root_Value);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            try
                            {
                                

                                //nếu có đã có tài khoản thì bỏ qua
                                Catologie sv = new Catologie();
                                sv.CatologyName = row["hovaten"].ToString();
                                sv.Khoa = row["khoa"].ToString();
                                sv.Lop = row["lop"].ToString();
                                sv.Massv = row["Massv"].ToString();

                                sv.Role = "SinhVien";
                                sv.PassWord = "AGyJb4cD1KcNsuxyrPPpk+W1fO2MsHVd+MAC7F1XC+ATZ0hViF7xwoUDNWBKadg4Mw==";
                                //WebSecurity.CreateUserAndAccount(sv.Massv, "123");
                                //Roles.AddUserToRole(sv.Massv, "SinhVien");
                                //int userID= WebSecurity.GetUserId(sv.Massv);
                               // Membership.GeneratePassword(
                                sv.KindCatologyGuid = ConstantVariable.Catologys_Root_Value;
                                sv.IsActive = true;
                                //sv.UserID = userID;
                                sv.Position = ++maxPosition;
                                sv.ListStringToSort = ConstantVariable.ToBinary(sv.Position);
                                Guid catGuid=Guid.Empty;
                                Guid catRootGuid = Guid.Empty;

                                catRootGuid = itemBAL.CreateImport(sv);//lưu gốc
                                if (catRootGuid != Guid.Empty)
                                {
                                    sv = new Catologie();
                                    sv.IsNotDelete = true;
                                    sv.Massv = row["Massv"].ToString();
                                    sv.CatologyName = "Danh mục chưa phân loại";
                                    sv.ListStringToSort = ConstantVariable.ToBinary(sv.Position);
                                    sv.KindCatologyGuid = catRootGuid;
                                    sv.IsActive = true;
                                    catGuid = itemBAL.Save(sv);//lưu thư mục mặc định

                                }
                                

                                if (catGuid != Guid.Empty)
                                {
                                    count++;
                                    row["ErrorContent"] = "save successful!";
                                    row["IsDongLoi"] = false;

                                }
                                else
                                {
                                    row["ErrorContent"] = "không tạo được thư mục mặc định!";
                                    row["IsDongLoi"] = true;
                                    continue;
                                }
                            }
                            catch (Exception ex)
                            {
                                row["ErrorContent"] = ex;
                                row["IsDongLoi"] = true;
                            }
                        }

                        ErrorMessage(false, "Lưu thành công " + count.ToString() + " record!");
                        GridViewSaveOK.DataSource = dataTable;
                        GridViewSaveOK.DataBind();
                    }
                }
            }
        }
        void ImageButtonUpload_Click(object sender, EventArgs e)
        {
            //Check file exist
            if (FileUploadLevelTraining.HasFile && FileUploadLevelTraining.FileName.Trim().Length > 0)
            {
                string extension = Path.GetExtension(FileUploadLevelTraining.FileName); // excel file extension               
                string excelPath = Server.MapPath("~/Resources/" + "excelUploadFile" + extension);
                FileUploadLevelTraining.SaveAs(excelPath);
                FileUploadLevelTraining.Dispose();
                ProcessPreviewExcelFile(excelPath, extension);
            }
        }
        #endregion

        #region Ultility
        private void VisableAllControl()
        {
            this.PanelUploadFile.Visible = false;
            this.PanelSaveData.Visible = false;
            this.PanelMessage.Visible = false;
            this.ImageButtonSave.Visible = false;
            this.ImageButtonSave.Visible = false;
            lblMessError.Text = string.Empty;
        }
        protected enum Step
        {
            Step1 = 1, // steps upload
            Step2 = 2, // steps check data
            Step3 = 3, // step insert into database
            Error = -1
        }
        private bool ValidateColumnName(DataRow row)
        {
            string strCheck = string.Empty;
            try
            {
                strCheck = row["hovaten"].ToString();
                strCheck = row["Massv"].ToString();
                strCheck = row["lop"].ToString();
                strCheck = row["khoa"].ToString();
            }
            catch { return false; }
            return true;
        }
        private void PopulateControls(Step step)
        {
            switch (step)
            {
                case ImportCATControl.Step.Step1:
                    VisableAllControl();
                    this.PanelUploadFile.Visible = true;
                    break;
                case ImportCATControl.Step.Step2:
                    VisableAllControl();
                    this.PanelSaveData.Visible = true;
                    ImageButtonSave.Visible = true;
                    BindDataOnGridView();
                    break;
                case ImportCATControl.Step.Step3:
                    VisableAllControl();
                    this.PanelMessage.Visible = true;
                    break;
                case ImportCATControl.Step.Error:
                    VisableAllControl();
                    this.PanelSaveData.Visible = true;
                    BindDataOnGridView();
                    break;
            }
        }
        private void BindDataOnGridView()
        {
            try
            {
                using (DataSet ds = TempXMLHelper.ReadTemporayDataFromXml(Server.MapPath(ConfigurationManager.AppSettings["VALUE_PATH_XML_INFOTEACHING"] + "/" + SiteUtils.GetCurrentUserId().ToString() + ".xml")))
                {
                    if (ds.Tables.Count > 0)
                    {
                        GridViewPreview.DataSource = ds.Tables[0];
                        GridViewPreview.DataBind();
                    }
                }
            }
            catch { }
        }
        //xem trước các lỗi bắt bước 1
        private void ProcessPreviewExcelFile(string excelPath, string extension)
        {
            bool IsError = false;
            ExcelHelper excelHelper = new ExcelHelper();
            DataSet dataset = new DataSet();

            try { excelHelper.OpenExcelFile(excelPath, extension); }
            catch
            {
                ErrorMessage(true, "Lỗi không tìm thấy file import");
                return;
            }

            try { dataset = excelHelper.GetWorksheets(excelHelper.WorkSheetNames[0]); }
            catch
            {
                lblMessError.Text = Resource.ErrorD002;
                DeleteFileTemp(excelPath);
                return;
            }

            if (dataset.Tables[0].Rows.Count > 2000)
            {
                ErrorMessage(true, "Để đảm bảo đường truyền. Vui lòng chỉ import tối đa 2000 record trong một lần!");
                return;
            }

            if (dataset.Tables.Count > 0)
            {
                //kiem tra mau import
                int count = 0;
                int countError = 0;
                if (dataset.Tables[0].Rows.Count > 0 && !ValidateColumnName(dataset.Tables[0].Rows[0]))
                {
                    lblMessError.Text = Resource.ErrorD001;
                    return;
                }

                dataset.Tables[0].Columns.Add(new DataColumn("STT", typeof(int)));
                dataset.Tables[0].Columns.Add(new DataColumn("ErrorContent", typeof(string)));
                dataset.Tables[0].Columns.Add(new DataColumn("IsDongLoi", typeof(bool)));


                //Check data import
                string stringError;
                bool boolError;
                List<Catologie> listCatologie = new List<Catologie>();
                string itemInRow;
                string positionRecordError = string.Empty;
                try
                {
                    foreach (DataRow row in dataset.Tables[0].Rows)
                    {
                        itemInRow = string.Empty;
                        stringError = string.Empty;
                        boolError = false;
                        row["STT"] = ++count;

                        Catologie itemSP = new Catologie();


                        itemInRow = row["Massv"].ToString().Trim().ToUpper();
                        if (itemInRow.Equals(""))
                        {
                            stringError += ", Mã sinh viên " + Resource.ErrorD003;
                            IsError = true;
                        }
                        else
                            itemSP.Massv = itemInRow;


                        itemInRow = row["hovaten"].ToString().Trim();
                        if (itemInRow == "")
                        {
                            stringError += ", Tên sinh viên " + Resource.ErrorD003;
                            IsError = true;
                        }
                        else
                            itemSP.CatologyName = itemInRow;


                        itemInRow = row["lop"].ToString().Trim().ToUpper();
                        if (itemInRow == "")
                        {
                            stringError += ", Lớp " + Resource.ErrorD003;
                            IsError = true;
                        }
                        else
                            itemSP.Lop = itemInRow;

                        itemInRow = row["khoa"].ToString().Trim().ToUpper();
                        if (itemInRow == "")
                        {
                            stringError += ", Khoa " + Resource.ErrorD003;
                            IsError = true;
                        }
                        else
                            itemSP.Khoa = itemInRow;

                        //Check exist data
                        try
                        {
                            //Check row exist in data import
                            if (listCatologie.Contains(itemSP))
                            {
                                stringError += ", record " + Resource.ErrorD006;
                                IsError = true;
                            }
                            else
                                listCatologie.Add(itemSP);


                            //Check row exist in database
                            if (CheckItemCatologie(itemSP))
                            {
                                stringError += ", Trùng lắp thông tin CSDL";
                                IsError = true;
                            }
                        }
                        catch (Exception)
                        {
                            stringError = Resource.ErrorD007;
                            IsError = true;
                        }

                        //Check error; true: error - false: unError
                        boolError = stringError == string.Empty ? false : true;
                        if (boolError)
                        {
                            countError++;
                            positionRecordError = positionRecordError + ", " + count;
                        }
                        row["IsDongLoi"] = IsError;// boolError;
                        row["ErrorContent"] = stringError;

                    }
                }
                catch { }
                DeleteFileTemp(excelPath);

                //Save xml to preview and next step 2, then, save data into database
                lblMessageError.Text = "Lỗi " + countError.ToString() + " record! <b>Vị trí</b>: " + positionRecordError;
                if (TempXMLHelper.SaveTemporayDataAsXml(Server.MapPath(ConfigurationManager.AppSettings["VALUE_PATH_XML_INFOTEACHING"] + "/" + SiteUtils.GetCurrentUserId() + ".xml"), dataset))
                {
                    if (!IsError)
                        PopulateControls(Step.Step2);
                    else
                        PopulateControls(Step.Error);
                }
                else
                    PopulateControls(Step.Step1);
            }
        }


        #endregion

        //Kiểm tra trùng lắp dữ liệu
       


        #region cac hàm
        protected string GetDisplayDate(object o)
        {
            if ((o == null) || (o.ToString() == String.Empty))
            {
                return o.ToString();
            }
            return Convert.ToDateTime(o).ToString("dd/MM/yyyy");
        }
        protected string GetCssClass(object obj)
        {
            if (obj.ToString() == "True") { return "ErrorRow"; }
            return string.Empty;
        }
        private void DeleteFileTemp(string path)
        {
            if (File.Exists(path)) File.Delete(path);
        }

        //Kiểm tra trùng lắp dữ liệu
        private bool CheckItemCatologie(Catologie itemSP)
        {
            ICatologieBAL ItemBAL = new CatologieBAL();
            return ItemBAL.CheckExistUser(itemSP);
          //  return false;
        }
        public void ErrorMessage(bool erorr, string value)
        {
            if (value != null)
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Show", ShowMessage.Error(value), false);
        }
        #endregion


      


    }
}