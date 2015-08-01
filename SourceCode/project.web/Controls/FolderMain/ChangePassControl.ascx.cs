using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Globalization;

using project.web.Components.Security;
using thanhdai18htquanlyphanquyen.Library.Framework;
using thanhdai18htquanlyphanquyen.Library.Models;
using System.Drawing;

namespace project.web.Controls
{
    public partial class ChangePassControl : System.Web.UI.UserControl
    {
        private Guid userId = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                SiteUtils.RedirectToLoginPage(this);
                return;
            }
            if (!IsPostBack)
            {
               // PopularControls();
                BindData();
            }
        }

        
        private void BindData()
        {
    
            IUserBAL itemBAL = new UserBAL();
            User user = itemBAL.GetUserByLoginName(HttpContext.Current.User.Identity.Name.Trim());

            if (user == null || user.UserGuid == Guid.Empty)
                return;

            this.TextBoxUserID.Text = user.UserID;
            this.TextBoxUerName.Text = user.UserName;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.ButtonSave.Click += new EventHandler(btnSave_Click);
            this.ButtonExit.Click += new EventHandler(btnCancel_Click);
        }


        void btnCancel_Click(object sender, EventArgs e)
        {
            if (Session["ActivePage"]!=null)
            WebUtils.SetupRedirect(this, SiteUtils.GetNavigationSiteRoot() + "/" + Session["ActivePage"].ToString());
            else
                WebUtils.SetupRedirect(this, SiteUtils.GetNavigationSiteRoot() + "/Default.aspx");
        }

        void btnSave_Click(object sender, EventArgs e)
        {

            IUserBAL ItemBAL = new UserBAL();
            if (TextBoxPassWord.Text == TextBoxRePassWord.Text)
            {
                if (ItemBAL.UpdatePassWord(TextBoxUserID.Text, TextBoxPassWord.Text))
                {
                    LabelThongbao.BackColor = Color.Blue;
                    LabelThongbao.Text = "Đổi mật khẩu thành công!";
                    //sau khi luuw mật khẩu thành công thì bắt đăng nhập lại
                    WebUtils.SetupRedirect(this, SiteUtils.GetNavigationSiteRoot() + "/Secure/Logoff.aspx");
                }
                else
                    LabelThongbao.Text = "Đổi mật khẩu không thành công!";
            }
           
        }

        
    }
}
