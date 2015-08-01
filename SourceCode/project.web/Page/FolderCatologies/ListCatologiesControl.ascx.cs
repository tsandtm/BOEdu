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
using System.Data;
using project.config.library.Utilities;
namespace project.web.Controls
{
    public partial class ListCatologieControl : System.Web.UI.UserControl, IListCatologiesView
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

        #region MEMBER VARIABLES
        public int _PageSize;
        private int _TotalPages = 1;
        int _CountItemSuccess;//su dung de phat hien thao ta trong he thong co thanh cong hay khong
        #endregion

        #region init
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                OnFristLoadEventHandler();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.InitView();

            ButtonAdd.Click += new EventHandler(ButtonAdd_Click);
            ButtonDelete.Click += new EventHandler(ButtonDelete_Click);
            mojoCutePager1.Command += new CommandEventHandler(mojoCutePager1_Command);
            DropDownListPageNumber.SelectedIndexChanged += new EventHandler(DropDownListPageNumber_SelectedIndexChanged);
            RepeaterCatologie.ItemCommand += new RepeaterCommandEventHandler(RepeaterCatologie_ItemCommand);

            DropDownListIsActive.SelectedIndexChanged += new EventHandler(DropDownListIsActive_SelectedIndexChanged);
        }
        #endregion

        #region Cac phuong thuc load
        private void KhoiTaoGiaTriBanDau()
        {
        }
        public void LoadData(string TacVu, object Value)
        {
            if (TacVu.Equals(ConstantVariable.TACVU_REFRESH))
            {
                OnLoadListData_Event();
            }

            UpdatePanelShowCatologie_on.Update();
        }
        #endregion

        #region All event
        void ButtonDelete_Click(object sender, EventArgs e)
        {
            int count = RepeaterCatologie.Items.Count;
            for (int i = 0; i < count; i++)
            {
                RepeaterItem item = (RepeaterItem)RepeaterCatologie.Items[i];
                CheckBox CheckBoxSelect = (CheckBox)item.FindControl("CheckBoxSelect");
                Literal LiteralCatologyGuid = (Literal)item.FindControl("LiteralCatologyGuid");
                if (CheckBoxSelect.Checked)
                    OnDelete_Event(new Guid(LiteralCatologyGuid.Text));
            }
            SuccessMessage = "Thao tác thành công!";
            OnLoadListData_Event();
        }
        void ButtonAdd_Click(object sender, EventArgs e)
        {
            OnCallHandler(ConstantVariable.TACVU_ADD, Guid.Empty);
        }
        void mojoCutePager1_Command(object sender, CommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument);
            mojoCutePager1.CurrentIndex = PageNumber;
            OnLoadListData_Event();
        }
        void DropDownListPageNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mojoCutePager1.CurrentIndex = 1;
                PageNumber = 1;
                _PageSize = Convert.ToInt32(DropDownListPageNumber.SelectedValue.ToString());
                OnLoadListData_Event();
            }
            catch (Exception)
            {
                Response.Redirect(Request.RawUrl);
            }
        }
        void RepeaterCatologie_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals(ConstantVariable.TACVU_EDIT))
            {
                try
                {
                    OnCallHandler(ConstantVariable.TACVU_EDIT, new Guid(e.CommandArgument.ToString()));
                    return;
                }
                catch (Exception ex)
                {
                    ErrorMessage = "Lỗii chuyển đổi dữ liệu. Vui lòng liên hệ với quản trị để khắc phục!";
                }
            }
        }
        void DropDownListIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnLoadListData_Event();
            UpdatePanelShowCatologie_on.Update();
        }
        #endregion

        #region Phan trang
        public int PageNumber
        {
            get
            {
                if (ViewState["pageNumber"] != null)
                {
                    try { return Convert.ToInt32(ViewState["pageNumber"].ToString()); }
                    catch { return 1; } // add
                }
                return 1;
            }
            set
            {
                ViewState["pageNumber"] = value;
            }
        }
        public int PageSize
        {
            get
            {
                try
                {
                    return Convert.ToInt32(DropDownListPageNumber.SelectedValue);
                }
                catch { return 15; } // add
            }
            set
            {
                this._PageSize = value;
            }
        }
        public int TotalPages
        {
            set { this._TotalPages = value; }
        }
        #endregion

        #region Emplement
        public Guid catologyRoot
        {
            get { return new Guid("0c7874c2-5221-4753-a533-ba5069b1d37a"); }
        }
        public int DropdownListIsActive
        {
            get
            {
                try
                {
                    return Convert.ToInt32(DropDownListIsActive.SelectedValue);
                }
                catch (Exception)
                {
                    return -1;
                }

            }
        }
        public int countItemSuccess
        {
            set
            {
                _CountItemSuccess += value;
            }
        }
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
        public List<Catologie> listCatologie
        {
            set
            {
                RepeaterCatologie.DataSource = value;
                RepeaterCatologie.DataBind();
                if (this._TotalPages > 1)
                {
                    mojoCutePager1.Visible = true;
                    mojoCutePager1.ShowFirstLast = true;
                    mojoCutePager1.PageSize = this._PageSize;
                    mojoCutePager1.PageCount = this._TotalPages;
                }
                else
                    mojoCutePager1.Visible = false;
            }
        }
        public List<TowTypeParameters<string, string>> PapeNumbers
        {
            set
            {
                DropDownListPageNumber.Items.Clear();
                DropDownListPageNumber.DataSource = value;
                DropDownListPageNumber.DataTextField = "T";
                DropDownListPageNumber.DataValueField = "V";
                DropDownListPageNumber.DataBind();
            }
        }

        public event EventHandler<EventArgs> LoadListData_Event;
        private void OnLoadListData_Event()
        {
            if (LoadListData_Event != null)
                LoadListData_Event(this, new EventArgs());
        }

        public event EventHandler<OneParameterEventAgrs<Guid>> Delete_Event;
        private void OnDelete_Event(Guid parameterValue)
        {
            if (Delete_Event != null)
                Delete_Event(this, new OneParameterEventAgrs<Guid>(parameterValue));
        }

        public event EventHandler<OneParameterEventAgrs<int>> SelectedIndexChanged_EventArgs;

        public event EventHandler<EventArgs> FristLoadEventHandler;
        private void OnFristLoadEventHandler()
        {
            if (FristLoadEventHandler != null)
                FristLoadEventHandler(this, new EventArgs());
        }
        #endregion

        #region Other
        public string BuildSymbol(object item)
        {
            int count = 1;
            try
            {
                count = Convert.ToInt32(item);
            }
            catch (Exception)
            {
            }

            string temp = string.Empty;

            if (count > 1)
                temp = "|";
            for (int i = 1; i < count; i++)
                temp = temp + "___";
            return temp = temp + " ";
        }
        #endregion
    }
}


