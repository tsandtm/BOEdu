using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using log4net;
using System.Globalization;
using project.web.Components.Security;
using Resources;
using thanhdai18htquanlyphanquyen.Library.Framework;
using thanhdai18htquanlyphanquyen.Library.Models;


namespace project.web.Secure
{
    public partial class Register : hutechBasePage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            ImageButtonAddNew.Click += new EventHandler(ImageButtonAddNew_Click);

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!WebUser.IsAdminOrRoleAdmin)
            //{
            //    SiteUtils.RedirectToAccessDeniedPage(this);
            //    return;
            //}
            SecurityHelper.DisableBrowserCache();
            PopulateLabels();
        }

        #region Load all
        private void PopulateLabels()
        {
            Title = Resource.AdminMenuRoleAdminLink;

        }
        #endregion

        #region All event
        void ImageButtonAddNew_Click(object sender, EventArgs e)
        {
            hutechMembershipProvider newUser = (hutechMembershipProvider)Membership.Provider;

            string userName = txtUserName.Text;
            string pass = txtPassword.Text;
            string email = txtEmail.Text;
            MembershipCreateStatus createStatus;

            //neu ket qua tra ve null la` khong tao duoc acc
            MembershipUser u = newUser.CreateUser(userName, pass, email, null, null, true, null, out createStatus);//tao tai khoan
            switch (createStatus)
            {
                case MembershipCreateStatus.Success:
                    //try
                    //{
                    //    //Update User
                    //    SiteUser item = new SiteUser(userName);
                    //    item.Name = txtName.Text;
                    //    item.Save();

                    //    //Add role UnAuthenticated
                    //    Role.AddUserToDefaultRoles(item);

                    //    //Reset data
                    //    txtEmail.Text = string.Empty;
                    //    txtPassword.Text = string.Empty;
                    //    txtUserName.Text = string.Empty;

                    //    CreateAccountResults.Text = "The user account was successfully created!";
                    //}
                    //catch (Exception ex)
                    //{
                    //    CreateAccountResults.Text = ex.ToString();
                    //}
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    CreateAccountResults.Text = "There already exists a user with this username.";
                    break;

                case MembershipCreateStatus.DuplicateEmail:
                    CreateAccountResults.Text = "There already exists a user with this email address.";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    CreateAccountResults.Text = "There email address you provided in invalid.";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    CreateAccountResults.Text = "There security answer was invalid.";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    CreateAccountResults.Text = "Mật khẩu không hợp lệ. Độ dài it nhất là 7 và chứa chữ cái và số";

                    break;
                default:
                    CreateAccountResults.Text = "There was an unknown error; the user account was NOT created.";
                    break;
            }
        }
        #endregion

    }
}