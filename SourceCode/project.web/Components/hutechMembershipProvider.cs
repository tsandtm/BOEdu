using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Security;

using System.Web;
using System.Data.SqlClient;
using thanhdai18htquanlyphanquyen.Library.Models;
using thanhdai18htquanlyphanquyen.Library;
using thanhdai18htquanlyphanquyen.Library.WebHelpers.UserRegisteredHandlers;


namespace project.web.Components.Security
{
    /// <summary>
    ///
    /// </summary>
    public class hutechMembershipProvider : MembershipProvider
    {
        #region Private Properties
        private String description = String.Empty;
        private String name = String.Empty;
        private String applicationName = String.Empty;
        private const int LoginnameMaxlength = 50;
        private const int EmailMaxlength = 100;
        private const int PasswordquestionMaxlength = 255;
        private const int PasswordanswerMaxlength = 255;
        private const int PasswordSize = 14;
        //private MachineKeySection machineKey;


        #endregion

        #region Public Properties

        public override string ApplicationName
        {
            get
            {
                this.applicationName = "REM";
                return applicationName;
            }
            set
            {
                applicationName = value;
            }
        }

        public override string Description
        {
            get
            {
                return description;
            }
        }

        public override bool EnablePasswordReset
        {
            get
            {
                return false;
            }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                return false;
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                return 5;
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                return 0;
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                return 4;
            }
        }

        public override string Name
        {
            get
            {
                return name;
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                return 5;
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                //return MembershipPasswordFormat.Clear; 
                return MembershipPasswordFormat.Hashed;
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                return string.Empty;
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                return false;
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                return false;
            }
        }


        #endregion

        #region Private Methods


        private MembershipUser CreateMembershipUserFromSiteUser(SiteUser siteUser)
        {
            if ((siteUser == null) || (siteUser.UserId == Guid.Empty))
                return null;

            return new MembershipUser(
            this.name,
            siteUser.LoginName,
            siteUser.UserId,
            siteUser.Email,
            "",
            siteUser.Comment,
            true,
            siteUser.IsLockedOut,
            siteUser.DateCreated,
            siteUser.LastLoginDate,
            siteUser.LastActivityDate,
            siteUser.LastPasswordChangedDate,
            siteUser.LastLockoutDate);
        }


        #endregion

        #region Public Methods

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);
            this.name = "hutechMembershipProvider";
            this.description = "tsandtm Membership Provider";//HongHoang.ThamDinhGia

            //System.Configuration.Configuration cfg = WebConfigurationManager.OpenWebConfiguration(HostingEnvironment.ApplicationVirtualPath);
            //machineKey = (MachineKeySection)cfg.GetSection("system.web/machineKey");

            //if (machineKey.ValidationKey.Contains("AutoGenerate"))
            //    if (PasswordFormat != MembershipPasswordFormat.Clear) throw new ProviderException("Hashed or Encrypted passwords are not supported with auto-generated keys.");

        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            /*
                                     * Takes, as input, a user name, a password (the user's current password), and a 
                                     * new password and updates the password in the membership data source. 
                                     * ChangePassword returns true if the password was updated successfully. Otherwise, 
                                     * it returns false. Before changing a password, ChangePassword calls the provider's 
                                     * virtual OnValidatingPassword method to validate the new password. It then 
                                     * changes the password or cancels the action based on the outcome of the call. If the 
                                     * user name, password, new password, or password answer is not valid, 
                                     * ChangePassword does not throw an exception; it simply returns false. Following a 
                                     * successful password change, ChangePassword updates the user's 
                                     * LastPasswordChangedDate.
                                     */

            bool result = false;

            if (
            (username == null) || (username == String.Empty)
            || (oldPassword == null) || (oldPassword == String.Empty)
            || (newPassword == null) || (newPassword == String.Empty)
            )
            {
                return result;
            }

            if (newPassword.Length < this.MinRequiredPasswordLength)
            {
                throw new ArgumentException("Mật mã không đủ độ dài");
            }

            int countNonAlphanumericCharacters = 0;
            for (int i = 0; i < newPassword.Length; i++)
            {
                if (!char.IsLetterOrDigit(newPassword, i))
                {
                    countNonAlphanumericCharacters++;
                }
            }

            if (countNonAlphanumericCharacters < MinRequiredNonAlphanumericCharacters)
            {
                throw new ArgumentException("Mật Mã Yêu Cầu Phải Có Ký Tự Đặc Biệt");
            }

            if (PasswordStrengthRegularExpression.Length > 0)
            {
                if (!Regex.IsMatch(newPassword, PasswordStrengthRegularExpression))
                {
                    throw new ArgumentException(
                    "Mật Mã Không Giống \"Regular Expression\"");
                }
            }

            ValidatePasswordEventArgs e = new ValidatePasswordEventArgs(username, newPassword, false);
            OnValidatingPassword(e);

            if (e.Cancel)
            {
                if (e.FailureInformation != null)
                {
                    throw e.FailureInformation;
                }
                else
                {
                    throw new ArgumentException("Việc đánh giá mật mã tùy ý thất bại.");
                }
            }

            SiteUser siteUser = new SiteUser(username);
            if (siteUser.UserId == Guid.Empty)
            {
                return result;
            }

            if (
            ((MembershipPasswordFormat)PasswordFormat == MembershipPasswordFormat.Hashed)
            )
            {
                if (siteUser.Password == EncodePassword(oldPassword, MembershipPasswordFormat.Hashed))
                {
                    siteUser.Password = EncodePassword(newPassword, MembershipPasswordFormat.Hashed);
                    //result = siteUser.Save();
                }
            }
            else
                if ((MembershipPasswordFormat)PasswordFormat == MembershipPasswordFormat.Encrypted)
                {
                    if (siteUser.Password == EncodePassword(oldPassword, MembershipPasswordFormat.Encrypted))
                    {
                        siteUser.Password = EncodePassword(newPassword, MembershipPasswordFormat.Encrypted);
                       // result = siteUser.Save();
                    }
                }
                else
                    if ((MembershipPasswordFormat)PasswordFormat == MembershipPasswordFormat.Clear)
                    {
                        if (siteUser.Password == oldPassword)
                        {
                            siteUser.Password = newPassword;
                           // result = siteUser.Save();
                        }
                    }

            if (result)
            {
                //siteUser.UpdateLastPasswordChangeTime();
            }

            return result;
        }

        public override bool ChangePasswordQuestionAndAnswer(
        string userName,
        string password,
        string newPasswordQuestion,
        string newPasswordAnswer)
        {
            /*
                                     * 	Takes, as input, a user name, password, password question, and password answer and 
                                     * updates 
                                     * the password question and answer in the data source if the user name and password are valid. 
                                     * This method 
                                     * returns true if the password question and answer are successfully updated. Otherwise, 
                                     * it returns false. 
                                     * ChangePasswordQuestionAndAnswer returns false if either the user name or password is invalid.
                                     */
            // not use now

            //if (
            //    String.IsNullOrEmpty(userName)
            //    || (password == null)
            //    || String.IsNullOrEmpty(newPasswordQuestion)
            //    || String.IsNullOrEmpty(newPasswordAnswer)
            //    || (newPasswordQuestion.Length > PasswordquestionMaxlength)
            //    || (newPasswordAnswer.Length > PasswordanswerMaxlength)
            //    )
            //{
            //    return false;
            //}

            //SiteUser siteUser = new SiteUser(siteSettings, userName);
            //if (siteUser.UserId > -1 && ValidateUser(userName, password))
            //{
            //    return siteUser.UpdatePasswordQuestionAndAnswer(newPasswordQuestion, newPasswordAnswer);
            //}
            return false;
        }


        public override MembershipUser CreateUser(
        string userName,
        string password,
        string email,
        string passwordQuestion,
        string passwordAnswer,
        bool isApproved,
        object providerUserKey,
        out MembershipCreateStatus status)
        {
            /*
            * Takes, as input, a user name, password, e-mail address, and other information and adds 
            * a new 
            * user to the membership data source. CreateUser returns a MembershipUser object 
            * representing the 
            * newly created user. It also accepts an out parameter  that returns a 
            * MembershipCreateStatus value indicating whether the user was successfully created or, 
            * if the user 
            * was not created, the reason why. If the user was not created, CreateUser returns null. 
            * Before creating a new user, 
            * CreateUser calls the provider's virtual OnValidatingPassword method to validate the 
            * supplied password. 
            * It then creates the user or cancels the action based on the outcome of the call.
            */
            if (String.IsNullOrEmpty(userName) || userName.Length > LoginnameMaxlength)
            {
                status = MembershipCreateStatus.InvalidUserName;
                return null;
            }

            //if (String.IsNullOrEmpty(email) || email.Length > EmailMaxlength)
            //{
            //    status = MembershipCreateStatus.InvalidEmail;
            //    return null;
            //}

            if (String.IsNullOrEmpty(password))
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            //if (SiteUser.EmailExistsInDB(email))
            //{
            //    status = MembershipCreateStatus.DuplicateEmail;
            //    return null;
            //}

            //if (SiteUser.LoginExistsInDB(userName))
            //{
            //    status = MembershipCreateStatus.DuplicateUserName;
            //    return null;
            //}

            if (password.Length < MinRequiredPasswordLength)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }


            int nonAlphaNumericCharactersUsedCount = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password, i))
                {
                    nonAlphaNumericCharactersUsedCount++;
                }
            }

            if (nonAlphaNumericCharactersUsedCount < MinRequiredNonAlphanumericCharacters)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }


            if (PasswordStrengthRegularExpression.Length > 0)
            {
                if (!Regex.IsMatch(password, PasswordStrengthRegularExpression))
                {
                    status = MembershipCreateStatus.InvalidPassword;
                    return null;
                }
            }


            ValidatePasswordEventArgs e = new ValidatePasswordEventArgs(userName, password, true);
            this.OnValidatingPassword(e);

            if (e.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            password = EncodePassword(password, PasswordFormat);

            SiteUser siteUser = new SiteUser();
            siteUser.SiteId = Guid.Parse("cd348ff8-00c2-496b-8a65-5e78201f7780");
            siteUser.LoginName = userName;
            siteUser.Password = password;
            siteUser.Name = name;
            siteUser.Email = email;
            bool created = false;// siteUser.Save(); //Tao tai khoan moi cho nay


            if (created)
            {
                //Role.AddUserToDefaultRoles(siteUser);
                status = MembershipCreateStatus.Success;
                return CreateMembershipUserFromSiteUser(siteUser);
            }
            else
            {
                status = MembershipCreateStatus.UserRejected;
                return null;
            }
        }

        public override bool DeleteUser(string userName, bool deleteAllRelatedData)
        {
            /*
                                     * 	Takes, as input, a user name and deletes that user from the membership data source. DeleteUser returns 
                                     * true if the user was successfully deleted. Otherwise, it returns false. DeleteUser takes a third parameter-a Boolean 
                                     * named deleteAllRelatedData-that specifies whether related data for that user should be deleted also. 
                                     * If deleteAllRelatedData is true, DeleteUser should delete role data, profile data, and all other data associated 
                                     * with that user.
                                     */
            bool result = false;
            // we are ignoring deleteAllRelatedData
            // on purpose because whether to really delete or just flag as deleted
            // is determined by the siteSettings.ReallyDeleteUsers setting

            if (userName != null)
            {
                SiteUser siteUser = new SiteUser(userName);
                if (siteUser.UserId != Guid.Empty)
                {
                    // just check IsDeleted = true
                    //result = SiteUser.Delete(siteUser.UserId);
                }
            }

            return result;
        }

        public override MembershipUserCollection FindUsersByEmail(
        string emailToMatch,
        int pageIndex,
        int pageSize,
        out int totalRecords)
        {
            /*
                                     * Returns a MembershipUserCollection containing MembershipUser objects representing 
                                     * users whose e-mail addresses match the emailToMatch input parameter. Wildcard syntax 
                                     * is data source-dependent. MembershipUser objects in the MembershipUserCollection are 
                                     * sorted by e-mail address. If FindUsersByEmail finds no matching users, it returns an empty 
                                     * MembershipUserCollection.
                                     */

            MembershipUserCollection users = new MembershipUserCollection();
            totalRecords = 0;

            //if (
            //    (siteSettings != null)
            //    && (emailToMatch != null)
            //    && (emailToMatch.Length > 5)
            //    )
            //{

            //}

            //using(IDataReader reader = SiteUser.GetUserByEmail(siteSettings.SiteId, emailToMatch))
            //{
            //    while (reader.Read())
            //    {
            //        MembershipUser user = new MembershipUser(
            //            this.name,
            //            reader["LoginName"].ToString(),
            //            reader["UserGuid"],
            //            reader["Email"].ToString(),
            //            reader["PasswordQuestion"].ToString(),
            //            reader["Comment"].ToString(),
            //            Convert.ToBoolean(reader["ProfileApproved"], CultureInfo.InvariantCulture),
            //            Convert.ToBoolean(reader["IsLockedOut"], CultureInfo.InvariantCulture),
            //            Convert.ToDateTime(reader["DateCreated"], CultureInfo.InvariantCulture),
            //            Convert.ToDateTime(reader["LastLoginDate"], CultureInfo.InvariantCulture),
            //            Convert.ToDateTime(reader["LastActivityDate"], CultureInfo.InvariantCulture),
            //            Convert.ToDateTime(reader["LastPasswordChangedDate"], CultureInfo.InvariantCulture),
            //            Convert.ToDateTime(reader["LastLockoutDate"], CultureInfo.InvariantCulture));

            //        users.Add(user);
            //        totalRecords += 1;

            //    }
            //}
            return users;
        }

        public override MembershipUserCollection FindUsersByName(
        string usernameToMatch,
        int pageIndex,
        int pageSize,
        out int totalRecords)
        {
            MembershipUserCollection users = new MembershipUserCollection();
            totalRecords = 0;

            if (
            (usernameToMatch != null)
            && (usernameToMatch.Length > 0)
            )
            {
            }

            //using (IDataReader reader = SiteUser.GetUserByLoginName(usernameToMatch))
            //{
            //    while (reader.Read())
            //    {
            //        MembershipUser user = new MembershipUser(
            //        this.name,
            //        reader["LoginName"].ToString(),
            //        reader["UserId"],
            //        reader["Email"].ToString(),
            //        "", //reader["PasswordQuestion"].ToString(),
            //        reader["Comment"].ToString(),
            //        true, //Convert.ToBoolean(reader["ProfileApproved"], CultureInfo.InvariantCulture),
            //        Convert.ToBoolean(reader["IsLockedOut"], CultureInfo.InvariantCulture),
            //        Convert.ToDateTime(reader["DateCreated"], CultureInfo.InvariantCulture),
            //        Convert.ToDateTime(reader["LastLoginDate"], CultureInfo.InvariantCulture),
            //        Convert.ToDateTime(reader["LastActivityDate"], CultureInfo.InvariantCulture),
            //        Convert.ToDateTime(reader["LastPasswordChangedDate"], CultureInfo.InvariantCulture),
            //        Convert.ToDateTime(reader["LastLockoutDate"], CultureInfo.InvariantCulture));

            //        users.Add(user);
            //        totalRecords += 1;
            //    }
            //}

            return users;
        }

        public override MembershipUserCollection GetAllUsers(
        int pageIndex,
        int pageSize,
        out int totalRecords)
        {
            /*
                                     Returns a MembershipUserCollection containing MembershipUser objects representing all registered users. 
                                     * If there are no registered users, GetAllUsers returns an empty MembershipUserCollection. The results returned 
                                     * by GetAllUsers are constrained by the pageIndex and pageSize input parameters. pageSize specifies the 
                                     * maximum number of MembershipUser objects to return. pageIndex identifies which page of results to return. 
                                     * Page indexes are 0-based. GetAllUsers also takes an out parameter (in Visual Basic, ByRef) named totalRecords 
                                     * that, on return, holds a count of all registered users.
                                     */

            MembershipUserCollection users = new MembershipUserCollection();
            totalRecords = 0;

            //int totalPages = 1;

            List<SiteUser> siteUserPage = new List<SiteUser>();// SiteUser.GetUserList();

            foreach (SiteUser siteUser in siteUserPage)
            {
                MembershipUser user = new MembershipUser(
                this.name,
                siteUser.LoginName,
                siteUser.UserId,
                siteUser.Email,
                "", //siteUser.PasswordQuestion,
                siteUser.Comment,
                true, //siteUser.ProfileApproved,
                siteUser.IsLockedOut,
                siteUser.DateCreated,
                siteUser.LastLoginDate,
                siteUser.LastActivityDate,
                siteUser.LastPasswordChangedDate,
                siteUser.LastLockoutDate);

                users.Add(user);
                totalRecords++;
            }


            //totalRecords = User.UserCount();

            return users;
        }

        public override int GetNumberOfUsersOnline()
        {
            int result = 0;

            /*
                                     Returns a count of users that are currently online-that is, whose LastActivityDate is greater 
                                     * than the current date and time minus the value of the membership service's UserIsOnlineTimeWindow 
                                     * property, which can be read from Membership.UserIsOnlineTimeWindow. UserIsOnlineTimeWindow 
                                     * specifies a time in minutes and is set using the <membership> element's 
                                     * userIsOnlineTimeWindow attribute.
                                     */
            //if (siteSettings != null)
            //{
            //    DateTime sinceTime = DateTime.UtcNow.AddMinutes(-Membership.UserIsOnlineTimeWindow);
            //    result = SiteUser.UsersOnlineSinceCount(siteSettings.SiteId, sinceTime);
            //}

            return result;
        }

        public override string GetPassword(string userName, string passwordAnswer)
        {
            /*
                                     * Takes, as input, a user name and a password answer and returns that user's password. 
                                     * If the user name is not valid, GetPassword throws a ProviderException. Before retrieving 
                                     * a password, GetPassword verifies that EnablePasswordRetrieval is true. 
                                     * If EnablePasswordRetrieval is false, GetPassword throws a NotSupportedException. 
                                     * If EnablePasswordRetrieval is true but the password format is hashed, GetPassword 
                                     * throws a ProviderException since hashed passwords cannot, by definition, be retrieved. 
                                     * A membership provider should also throw a ProviderException from Initialize if 
                                     * EnablePasswordRetrieval is true but the password format is hashed. GetPassword also 
                                     * checks the value of the RequiresQuestionAndAnswer property before retrieving a password. 
                                     * If RequiresQuestionAndAnswer is true, GetPassword compares the supplied password 
                                     * answer to the stored password answer and throws a MembershipPasswordException if 
                                     * the two don't match. GetPassword also throws a MembershipPasswordException if the 
                                     * user whose password is being retrieved is currently locked out.
                                     */

            return null;

            //SiteSettings siteSettings = GetSiteSettings();

            //if (!siteSettings.AllowPasswordRetrieval)
            //{
            //    throw new MojoMembershipException(
            //        ResourceHelper.GetMessageTemplate("PasswordRetrievalNotEnabledMessage.config")
            //        );
            //}

            ////if (PasswordFormat == MembershipPasswordFormat.Hashed)
            ////{
            ////    throw new ProviderException(
            ////            ResourceHelper.GetMessageTemplate("CannotRetrieveHashedPasswordMessage.config")
            ////            );
            ////}

            //if ((userName != null) && (siteSettings != null))
            //{
            //    SiteUser siteUser = new SiteUser(siteSettings, userName);
            //    if (siteUser.UserId > -1)
            //    {
            //        if (siteUser.IsLockedOut)
            //        {
            //            throw new MembershipPasswordException(
            //                ResourceHelper.GetMessageTemplate("UserAccountLockedMessage.config"));
            //        }

            //        bool okToGetPassword = false;
            //        if (siteSettings.RequiresQuestionAndAnswer)
            //        {
            //            if ((passwordAnswer != null) && (passwordAnswer == siteUser.PasswordAnswer))
            //            {
            //                okToGetPassword = true;
            //            }
            //            else
            //            {
            //                if (siteSettings.MaxInvalidPasswordAttempts > 0)
            //                {
            //                    siteUser.IncrementPasswordAnswerAttempts(siteSettings);
            //                }
            //            }

            //        }
            //        else
            //        {
            //            okToGetPassword = true;
            //        }

            //        if(okToGetPassword)
            //        {
            //            switch(PasswordFormat)
            //            {
            //                case MembershipPasswordFormat.Clear:
            //                    return siteUser.Password;
            //                case MembershipPasswordFormat.Encrypted:

            //                    return UnencodePassword(siteUser.Password, MembershipPasswordFormat.Encrypted);

            //                case MembershipPasswordFormat.Hashed:
            //                    string newPassword = GeneratePassword();
            //                    siteUser.Password = EncodePassword(newPassword, MembershipPasswordFormat.Hashed);
            //                    siteUser.Save();
            //                    //siteUser.UnlockAccount();
            //                    return newPassword;

            //            }

            //        }
            //        else
            //        {
            //            return null;
            //        }
            //    }
            //    else
            //    {
            //        throw new ProviderException(ResourceHelper.GetMessageTemplate("UserNotFoundMessage.config"));

            //    }

            //}

            //return null;


        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            /*
                                     * Takes, as input, a user name or user ID (the method is overloaded) and a Boolean value 
                                     * indicating whether to update the user's LastActivityDate to show that the user is currently online. 
                                     * GetUser returns a MembershipUser object representing the specified user. If the user name or 
                                     * user ID is invalid (that is, if it doesn't represent a registered user) GetUser returns null (Nothing in Visual Basic).
                                     */
            if (providerUserKey != null)
            {
                SiteUser siteUser = null;
                if (providerUserKey is Guid)
                {
                    siteUser = new SiteUser((Guid)providerUserKey);
                    if (siteUser.UserId != Guid.Empty)
                    {
                        if (userIsOnline)
                        {
                            //siteUser.UpdateLastActivityTime();
                        }
                        return this.CreateMembershipUserFromSiteUser(siteUser);
                    }
                }
            }



            return null;
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            /*
                                     * 	Takes, as input, a user name or user ID (the method is overloaded) and a 
                                     * Boolean value indicating whether to update the user's LastActivityDate to 
                                     * show that the user is currently online. GetUser returns a MembershipUser object 
                                     * representing the specified user. If the user name or user ID is invalid (that is, if 
                                     * it doesn't represent a registered user) GetUser returns null (Nothing in Visual Basic).
                                     */

            if ((username != null) && (username.Length > 0))
            {
                SiteUser siteUser = null;
                siteUser = new SiteUser(username);
                if (siteUser.UserId != Guid.Empty)
                {
                    if (userIsOnline)
                    {
                        //siteUser.UpdateLastActivityTime();
                    }
                    return this.CreateMembershipUserFromSiteUser(siteUser);
                }
            }

            return null;
        }

        /// <summary>
        /// không dùng
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public override string GetUserNameByEmail(string email)
        {
            //if ((email != null)&&(email.Length >  5))
            //{
            //    return SiteUser.GetUserNameFromEmail(siteSettings.SiteId, email);
            //}
            return String.Empty;
        }

        public override string ResetPassword(string userName, string passwordAnswer)
        {
            /*
                                    Takes, as input, a user name and a password answer and replaces the user's current password 
                                     * with a new, random password. ResetPassword then returns the new password. A 
                                     * convenient mechanism for generating a random password is the 
                                     * Membership.GeneratePassword method. If the user name is not valid, ResetPassword 
                                     * throws a ProviderException. ResetPassword also checks the value of the 
                                     * RequiresQuestionAndAnswer property before resetting a password. If 
                                     * RequiresQuestionAndAnswer is true, ResetPassword compares the supplied password 
                                     * answer to the stored password answer and throws a MembershipPasswordException if 
                                     * the two don't match. Before resetting a password, ResetPassword verifies that 
                                     * EnablePasswordReset is true. If EnablePasswordReset is false, ResetPassword throws 
                                     * a NotSupportedException. If the user whose password is being changed is currently 
                                     * locked out, ResetPassword throws a MembershipPasswordException. Before resetting a 
                                     * password, ResetPassword calls the provider's virtual OnValidatingPassword method to 
                                     * validate the new password. It then resets the password or cancels the action based on 
                                     * the outcome of the call. If the new password is invalid, ResetPassword throws a 
                                     * ProviderException. Following a successful password reset, ResetPassword updates the 
                                     * user's LastPasswordChangedDate.
                                    */
            throw new Exception("Phiên bản này không cho phép reset Password.");
        }

        public virtual string GeneratePassword()
        {
            return Membership.GeneratePassword(
            MinRequiredPasswordLength < PasswordSize ? PasswordSize : MinRequiredPasswordLength,
            MinRequiredNonAlphanumericCharacters);
        }

        public override bool UnlockUser(string userName)
        {
            /*
                                     Unlocks (that is, restores login privileges for) the specified user. UnlockUser returns true if the 
                                     * user is successfully unlocked. Otherwise, it returns false. If the user is already unlocked, 
                                     * UnlockUser simply returns true.
                                     */

            bool result = false;
            if ((userName != null) && (userName.Length > 0))
            {
                //SiteUser siteUser = new SiteUser(userName);
                //if (siteUser.UserId != Guid.Empty)
                //{
                //    if (!siteUser.IsLockedOut)
                //    {
                //        result = true;
                //    }
                //    else
                //    {
                //        result = siteUser.UnlockAccount();
                //    }
                //}
            }

            return result;
        }

        public override void UpdateUser(MembershipUser user)
        {
            /*
                                    Takes, as input, a MembershipUser object representing a registered user and updates the 
                                     * information stored for 
                                     that user in the membership data source. If any of the input submitted in the MembershipUser 
                                     * object is not valid, 
                                     UpdateUser throws a ProviderException. Note that UpdateUser is not obligated to allow all 
                                     * the data that 
                                     can be encapsulated in a MembershipUser object to be updated in the data source.
                                     
                                     */

            if (user != null)
            {
                SiteUser siteUser;
                siteUser = new SiteUser(user.UserName);
                if (siteUser.UserId != Guid.Empty)
                {
                    //siteUser.Comment = user.Comment;
                    siteUser.Email = user.Email;
                    siteUser.LoginName = user.UserName;
                    //siteUser.ProfileApproved = user.IsApproved;
                    //if (
                    //    (user.PasswordQuestion != null)
                    //    &&(user.PasswordQuestion.Length > 0)
                    //    &&(user.PasswordQuestion != siteUser.PasswordQuestion)
                    //    )
                    //{
                    //    siteUser.PasswordQuestion = user.PasswordQuestion;
                    //}
                   // siteUser.Save();
                    if (user.LastActivityDate > siteUser.LastActivityDate)
                    {
                        //siteUser.UpdateLastActivityTime(); //cập nhật sau
                    }
                }
            }
        }

        public override bool ValidateUser(string userName, string password)
        {
            string urlApp = SiteUtils.GetSiteId();
            bool result = false;
            IUserBAL itemBAL = new UserBAL();
            User user = itemBAL.GetUserByLogin(userName, password, urlApp);
            //login trang thái,
            //get value phân quyền
            if (user.UserGuid != Guid.Empty)
            {
                HttpContext.Current.Session["permissionvalue"] = user.ValuePermission;
                result = true;
            }

            return result;
        }
        #region Xu ly cap nhat user... xong roi se bo
        // true neu database cu dang nhap thanh cong. false dang nhap that bai trong databse cu
        //private void insertProcess(string userName, string password)
        //{
        //    //Kiem tra user trong databse moi. Neu co user. luu lai userid.
        //    SiteUser siteUser = new SiteUser(userName);
        //    //Dang nhap trong database cu. Lay cac thong tin trong database cu
        //    ts_admin ts = ts_admin.GetAccAdmin(userName, GetMD5UFT8Hash(password));
        //    if (ts != null)
        //    {
        //        password = EncodePassword(password, PasswordFormat);
        //        siteUser.Password = password;
        //        siteUser.Save(); //Tao tai khoan moi cho nay

        //        return;//Thoat
        //    }
        //}
        //Ham ma hoa
        private string GetMD5UFT8Hash(string pas_)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedBytes;
            UTF8Encoding encoder = new UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(pas_));
            pas_ = "";
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                pas_ += hashedBytes.GetValue(i).ToString();
            }

            return pas_;
        }
        #endregion



        private void OnUserRegistered(UserRegisteredEventArgs e)
        {
            foreach (UserRegisteredHandlerProvider handler in UserRegisteredHandlerProviderManager.Providers)
            {
                handler.UserRegisteredHandler(null, e);
            }
        }


        public string EncodePassword(string pass)
        {
            return EncodePassword(pass, (MembershipPasswordFormat)PasswordFormat);
        }

        public string EncodePassword(string pass, MembershipPasswordFormat passwordFormat)
        {
            if (passwordFormat == MembershipPasswordFormat.Clear)
            {
                return pass;
            }

            if (passwordFormat == MembershipPasswordFormat.Hashed)
            {
                return Hash(pass);
            }

            byte[] bIn = Encoding.Unicode.GetBytes(pass);
            byte[] bRet = EncryptPassword(bIn);

            return Convert.ToBase64String(bRet);
        }


        public string UnencodePassword(string pass, MembershipPasswordFormat passwordFormat)
        {
            switch (passwordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    return pass;
                case MembershipPasswordFormat.Hashed:
                    throw new ProviderException("Can't decrypt hashed password");
                default:
                    byte[] bIn = Convert.FromBase64String(pass);
                    byte[] bRet = DecryptPassword(bIn);
                    if (bRet == null)
                        return null;

                    return Encoding.Unicode.GetString(bRet);
            }
        }


        public string Hash(string cleanText)
        {
            if (string.IsNullOrEmpty(cleanText))
            {
                return string.Empty;
            }

            //TODO: we can't currently use SHA256 or SHA512
            //because the password field in the db is not big enough to store the hash

            //switch (WebConfigSettings.HashedPasswordCryptoType)
            //{
            //    case "SHA512":
            //        return GetSHA512Hash(cleanText);

            //    case "SHA256":
            //        return GetSHA256Hash(cleanText);

            //    case "MD5":
            //    default:
            //        return GetMD5Hash(cleanText);
            //}

            return GetMD5Hash(cleanText);
        }


        private string GetMD5Hash(string cleanText)
        {
            if (string.IsNullOrEmpty(cleanText))
            {
                return string.Empty;
            }

            using (MD5CryptoServiceProvider hasher = new MD5CryptoServiceProvider())
            {
                Byte[] clearBytes = new UnicodeEncoding().GetBytes(cleanText);
                Byte[] hashedBytes = hasher.ComputeHash(clearBytes);

                return BitConverter.ToString(hashedBytes);
            }
        }

        private string GetSHA512Hash(string cleanText)
        {
            if (string.IsNullOrEmpty(cleanText))
            {
                return string.Empty;
            }

            using (SHA512CryptoServiceProvider hasher = new SHA512CryptoServiceProvider())
            {
                Byte[] clearBytes = new UnicodeEncoding().GetBytes(cleanText);
                Byte[] hashedBytes = hasher.ComputeHash(clearBytes);

                return BitConverter.ToString(hashedBytes);
            }
        }

        private string GetSHA256Hash(string cleanText)
        {
            if (string.IsNullOrEmpty(cleanText))
            {
                return string.Empty;
            }

            using (SHA256CryptoServiceProvider hasher = new SHA256CryptoServiceProvider())
            {
                Byte[] clearBytes = new UnicodeEncoding().GetBytes(cleanText);
                Byte[] hashedBytes = hasher.ComputeHash(clearBytes);

                return BitConverter.ToString(hashedBytes);
            }
        }

        #endregion

        #region Protected Methods

        protected override void OnValidatingPassword(ValidatePasswordEventArgs e)
        {
            /*
                                     * Virtual method called when a password is created. The default implementation in MembershipProvider 
                                     * fires a ValidatingPassword event, so be sure to call the base class's OnValidatingPassword method if 
                                     * you override this method. The ValidatingPassword event allows applications to apply additional tests to 
                                     * passwords by registering event handlers. A custom provider's CreateUser, ChangePassword, and ResetPassword 
                                     * methods (in short, all methods that record new passwords) should call this method.
                                     */

            base.OnValidatingPassword(e);
        }



        #endregion


        public void ChangeUserPasswordFormat(int oldPasswordFormat)
        {
            /*
                                     * 
                                     Cleartext change to encrypted - encrypt plain passwords for exisitng
                                     Cleartext change to hashed - hash passwords for exisiting users
                                     Encrypted changed to cleartext - decrypt passwords
                                     Encrypted change to hashed - decrypt then hash passwords
                                     Hashed to cleartext - replace password with random password
                                     Hashed to encrypted - replace passwords with random passwords then encrypt them
                                     */
            switch (oldPasswordFormat)
            {
                case (int)MembershipPasswordFormat.Clear:

                    switch (PasswordFormat)
                    {
                        case MembershipPasswordFormat.Encrypted:
                            ThreadPool.QueueUserWorkItem(new WaitCallback(ChangeFromClearTextPasswordsToEncrypted));

                            break;

                        case MembershipPasswordFormat.Hashed:
                            ThreadPool.QueueUserWorkItem(new WaitCallback(ChangeFromClearTextPasswordsToHashed));

                            break;
                    }

                    break;

                case (int)MembershipPasswordFormat.Encrypted:

                    switch (PasswordFormat)
                    {
                        case MembershipPasswordFormat.Clear:
                            ThreadPool.QueueUserWorkItem(new WaitCallback(ChangeFromEncryptedPasswordsToClearText));

                            break;

                        case MembershipPasswordFormat.Hashed:
                            ThreadPool.QueueUserWorkItem(new WaitCallback(ChangeFromEncryptedPasswordsToHashed));

                            break;
                    }

                    break;


                case (int)MembershipPasswordFormat.Hashed:

                    switch (PasswordFormat)
                    {
                        case MembershipPasswordFormat.Encrypted:
                            ThreadPool.QueueUserWorkItem(new WaitCallback(ChangeFromHashedPasswordsToEncrypted));

                            break;

                        case MembershipPasswordFormat.Clear:
                            ThreadPool.QueueUserWorkItem(new WaitCallback(ChangeFromHashedPasswordsToClearText));

                            break;
                    }

                    break;
            }
        }


        private void ChangeFromClearTextPasswordsToEncrypted(Object objSiteSettings)
        {
            //not use now

            //DataTable dtUsers = SiteUser.GetUserListForPasswordFormatChange(site.SiteId);
            //foreach (DataRow row in dtUsers.Rows)
            //{
            //    try
            //    {
            //        DatabaseHelper.UpdateTableField(
            //            "mp_Users",
            //            "UserID",
            //            Convert.ToInt32(row["UserID"]).ToString(CultureInfo.InvariantCulture),
            //            "Pwd",
            //            EncodePassword(row["Pwd"].ToString(), MembershipPasswordFormat.Encrypted),
            //            String.Empty);
            //    }
            //    catch (Exception ex)
            //    {
            //        // I don't like catching a general exception here but since this gets queued 
            //        //on a different thread best to log anything that goes wrong
            //        log.Error("ChangeFromClearTextPasswordsToEncrypted", ex);
            //    }
            //}
        }


        private void ChangeFromClearTextPasswordsToHashed(Object objSiteSettings)
        {
            // not use now

            //SiteSettings site = objSiteSettings as SiteSettings;
            //if (site == null) return;

            //DataTable dtUsers = SiteUser.GetUserListForPasswordFormatChange(site.SiteId);
            //foreach (DataRow row in dtUsers.Rows)
            //{
            //    try
            //    {
            //    DatabaseHelper.UpdateTableField(
            //        "mp_Users",
            //        "UserID",
            //        Convert.ToInt32(row["UserID"]).ToString(CultureInfo.InvariantCulture),
            //        "Pwd",
            //        Hash(row["Pwd"].ToString()),
            //        String.Empty);
            //    }
            //    catch (Exception ex)
            //    {
            //        // I don't like catching a general exception here but since this gets queued 
            //        //on a different thread best to log anything that goes wrong
            //        log.Error("ChangeFromClearTextPasswordsToEncrypted", ex);
            //    }
            //}
        }


        private void ChangeFromEncryptedPasswordsToClearText(Object objSiteSettings)
        {
            // not use now

            //SiteSettings site = objSiteSettings as SiteSettings;
            //if (site == null) return;

            //DataTable dtUsers = SiteUser.GetUserListForPasswordFormatChange(site.SiteId);
            //foreach (DataRow row in dtUsers.Rows)
            //{
            //    try
            //    {
            //        DatabaseHelper.UpdateTableField(
            //            "mp_Users",
            //            "UserID",
            //            Convert.ToInt32(row["UserID"]).ToString(CultureInfo.InvariantCulture),
            //            "Pwd",
            //            UnencodePassword(row["Pwd"].ToString(), MembershipPasswordFormat.Encrypted),
            //            String.Empty);
            //    }
            //    catch (Exception ex)
            //    {
            //        // I don't like catching a general exception here but since this gets queued 
            //        //on a different thread best to log anything that goes wrong
            //        log.Error("ChangeFromClearTextPasswordsToEncrypted", ex);
            //    }
            //}
        }


        private void ChangeFromEncryptedPasswordsToHashed(Object objSiteSettings)
        {
            // not use now

            //SiteSettings site = objSiteSettings as SiteSettings;
            //if (site == null) return;

            //DataTable dtUsers = SiteUser.GetUserListForPasswordFormatChange(site.SiteId);
            //foreach (DataRow row in dtUsers.Rows)
            //{
            //    try
            //    {
            //    DatabaseHelper.UpdateTableField(
            //        "mp_Users",
            //        "UserID",
            //        Convert.ToInt32(row["UserID"]).ToString(CultureInfo.InvariantCulture),
            //        "Pwd",
            //        Hash(UnencodePassword(row["Pwd"].ToString(), MembershipPasswordFormat.Encrypted)),
            //        String.Empty);
            //    }
            //    catch (Exception ex)
            //    {
            //        // I don't like catching a general exception here but since this gets queued 
            //        //on a different thread best to log anything that goes wrong
            //        log.Error("ChangeFromClearTextPasswordsToEncrypted", ex);
            //    }
            //}
        }


        private void ChangeFromHashedPasswordsToClearText(Object objSiteSettings)
        {
            // not use now

            //SiteSettings site = objSiteSettings as SiteSettings;
            //if (site == null) return;

            ////Hashed to cleartext - replace password with random password
            //DataTable dtUsers = SiteUser.GetUserListForPasswordFormatChange(site.SiteId);
            //foreach (DataRow row in dtUsers.Rows)
            //{
            //    try
            //    {
            //    DatabaseHelper.UpdateTableField(
            //        "mp_Users",
            //        "UserID",
            //        Convert.ToInt32(row["UserID"]).ToString(CultureInfo.InvariantCulture),
            //        "Pwd",
            //        SiteUser.CreateRandomPassword(site.MinRequiredPasswordLength + 2),
            //        String.Empty);
            //    }
            //    catch (Exception ex)
            //    {
            //        // I don't like catching a general exception here but since this gets queued 
            //        //on a different thread best to log anything that goes wrong
            //        log.Error("ChangeFromClearTextPasswordsToEncrypted", ex);
            //    }
            //}

        }


        private void ChangeFromHashedPasswordsToEncrypted(Object objSiteSettings)
        {
            // not use now

            //SiteSettings site = objSiteSettings as SiteSettings;
            //if (site == null) return;

            ////Hashed to encrypted - replace passwords with random passwords then encrypt them
            //DataTable dtUsers = SiteUser.GetUserListForPasswordFormatChange(site.SiteId);

            //foreach (DataRow row in dtUsers.Rows)
            //{
            //    try
            //    {
            //    DatabaseHelper.UpdateTableField(
            //        "mp_Users",
            //        "UserID",
            //        Convert.ToInt32(row["UserID"]).ToString(CultureInfo.InvariantCulture),
            //        "Pwd",
            //        EncodePassword(SiteUser.CreateRandomPassword(site.MinRequiredPasswordLength + 2), 
            //        MembershipPasswordFormat.Encrypted),
            //        String.Empty);
            //    }
            //    catch (Exception ex)
            //    {
            //        // I don't like catching a general exception here but since this gets queued 
            //        //on a different thread best to log anything that goes wrong
            //        log.Error("ChangeFromClearTextPasswordsToEncrypted", ex);
            //    }

            //}
        }


        //public override MembershipUser CreateUser(
        //    string userName,
        //    string password,
        //    string email,
        //    string passwordQuestion,
        //    string passwordAnswer,
        //    bool isApproved,
        //    object providerUserKey,
        //    out MembershipCreateStatus status)
        //{
        //    /*
        //     * Takes, as input, a user name, password, e-mail address, and other information and adds 
        //     * a new 
        //     * user to the membership data source. CreateUser returns a MembershipUser object 
        //     * representing the 
        //     * newly created user. It also accepts an out parameter  that returns a 
        //     * MembershipCreateStatus value indicating whether the user was successfully created or, 
        //     * if the user 
        //     * was not created, the reason why. If the user was not created, CreateUser returns null. 
        //     * Before creating a new user, 
        //     * CreateUser calls the provider's virtual OnValidatingPassword method to validate the 
        //     * supplied password. 
        //     * It then creates the user or cancels the action based on the outcome of the call.
        //     */

        //    if (String.IsNullOrEmpty(userName) || userName.Length > LoginnameMaxlength)
        //    {
        //        status = MembershipCreateStatus.InvalidUserName;
        //        return null;
        //    }

        //    if (String.IsNullOrEmpty(email) || email.Length > EmailMaxlength)
        //    {
        //        status = MembershipCreateStatus.InvalidEmail;
        //        return null;
        //    }

        //    if (String.IsNullOrEmpty(password))
        //    {
        //        status = MembershipCreateStatus.InvalidPassword;
        //        return null;
        //    }

        //    //if (RequiresQuestionAndAnswer)
        //    //{
        //    //    if (String.IsNullOrEmpty(passwordQuestion)
        //    //        || passwordQuestion.Length > PasswordquestionMaxlength)
        //    //    {
        //    //        status = MembershipCreateStatus.InvalidQuestion;
        //    //        return null;
        //    //    }

        //    //    if (String.IsNullOrEmpty(passwordAnswer)
        //    //        || passwordAnswer.Length > PasswordanswerMaxlength)
        //    //    {
        //    //        status = MembershipCreateStatus.InvalidAnswer;
        //    //        return null;
        //    //    }
        //    //}

        //    //if (User.EmailExistsInDB(email))
        //    //{
        //    //    status = MembershipCreateStatus.DuplicateEmail;
        //    //    return null;
        //    //}

        //    if (SiteUser.LoginExistsInDB(userName))
        //    {
        //        status = MembershipCreateStatus.DuplicateUserName;
        //        return null;
        //    }

        //    if (password.Length < MinRequiredPasswordLength)
        //    {
        //        status = MembershipCreateStatus.InvalidPassword;
        //        return null;
        //    }


        //    int nonAlphaNumericCharactersUsedCount = 0;

        //    for (int i = 0; i < password.Length; i++)
        //    {
        //        if (!char.IsLetterOrDigit(password, i))
        //        {
        //            nonAlphaNumericCharactersUsedCount++;
        //        }
        //    }

        //    if (nonAlphaNumericCharactersUsedCount < MinRequiredNonAlphanumericCharacters)
        //    {
        //        status = MembershipCreateStatus.InvalidPassword;
        //        return null;
        //    }


        //    if (PasswordStrengthRegularExpression.Length > 0)
        //    {
        //        if (!Regex.IsMatch(password, PasswordStrengthRegularExpression))
        //        {
        //            status = MembershipCreateStatus.InvalidPassword;
        //            return null;
        //        }
        //    }


        //    ValidatePasswordEventArgs e = new ValidatePasswordEventArgs(userName, password, true);
        //    this.OnValidatingPassword(e);

        //    if (e.Cancel)
        //    {
        //        status = MembershipCreateStatus.InvalidPassword;
        //        return null;
        //    }

        //    password = EncodePassword(password, PasswordFormat);

        //    SiteUser siteUser = new SiteUser();
        //    siteUser.Name = userName;
        //    siteUser.LoginName = userName;
        //    siteUser.Email = email;
        //    siteUser.SiteId = Guid.Empty; //...
        //    //siteUser.PasswordQuestion = passwordQuestion;
        //    //siteUser.PasswordAnswer = passwordAnswer;
        //    //siteUser.ProfileApproved = isApproved;
        //    siteUser.Password = password;
        //    bool created = siteUser.Save(); //Tao tai khoan moi cho nay


        //    if (created)
        //    {
        //        //Role.AddUserToDefaultRoles(siteUser);


        //        status = MembershipCreateStatus.Success;
        //        return CreateMembershipUserFromSiteUser(siteUser);
        //    }
        //    else
        //    {
        //        status = MembershipCreateStatus.UserRejected;
        //        return null;
        //    }
        //}
    }
}
