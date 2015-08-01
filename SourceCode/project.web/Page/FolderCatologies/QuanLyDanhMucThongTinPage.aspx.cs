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
using project.config.library.Utilities;

namespace project.web.Admin
{
    public partial class QuanLyDanhMucThongTinPage : System.Web.UI.Page// hutechBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            ListCatologiesControl1.CallHandler += new EventHandler<TowParameterEventAgrs<string, Guid>>(ListCatologiesControl1_CallHandler);
            AddCatologiesControl1.CallHandler += new EventHandler<TowParameterEventAgrs<string, Guid>>(AddCatologiesControl1_CallHandler);
        }

        void AddCatologiesControl1_CallHandler(object sender, TowParameterEventAgrs<string, Guid> e)
        {
            if (e.T.Equals(ConstantVariable.TACVU_REFRESH))
            {
                ListCatologiesControl1.LoadData(ConstantVariable.TACVU_REFRESH, Guid.Empty);
                return;
            }
        }

        void ListCatologiesControl1_CallHandler(object sender, TowParameterEventAgrs<string, Guid> e)
        {
            if (e.T.Equals(ConstantVariable.TACVU_ADD))
            {
                AddCatologiesControl1.LoadData(ConstantVariable.TACVU_ADD, Guid.Empty);
                return;
            }

            if (e.T.Equals(ConstantVariable.TACVU_EDIT))
            {
                AddCatologiesControl1.LoadData(ConstantVariable.TACVU_EDIT, e.V);
                return;
            }
        }
    }
}