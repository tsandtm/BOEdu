using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Collections;
using project.web;
using thanhdai18htquanlyphanquyen.Library.Models;
using thanhdai18htquanlyphanquyen.Library.Framework;


namespace project.web.Components.Security
{
    /// <summary>
    ///
    /// </summary>
    public class hutechRoleProvider : RoleProvider
    {
        private string applicationName = "unknown";


        public hutechRoleProvider()
        {
        }


        public override string ApplicationName
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    return "ThuLao.Hutech";
                }

                return applicationName;
            }
            set
            {
                applicationName = value;
            }
        }

        /// <summary>
        /// Get any needed parameters from config section
        /// </summary>
        /// <param name="name">name of the provider</param>
        /// <param name="config">configuration collection</param>
        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            //if (config["blah"] != null)
            //{
            //  String blah = config["blah"];
            //}

            base.Initialize(name, config);
        }

        /// <summary>
        /// required implementation
        /// </summary>
        /// <param name="userNames">a list of usernames</param>
        /// <param name="roleNames">a list of roles</param>
        public override void AddUsersToRoles(string[] userNames, string[] roleNames)
        {
            //if ((userNames != null) && (roleNames != null))
            //{
            //    foreach (String userName in userNames)
            //    {
            //        SiteUser siteUser = new SiteUser(userName);
            //        if (siteUser.UserId != Guid.Empty)
            //        {
            //            foreach (String roleName in roleNames)
            //            {
            //                Role role = new Role(roleName);
            //                if (role.RoleId != Guid.Empty)
            //                {
            //                    Role.AddUser(role.RoleId, siteUser.UserId);
            //                }
            //            }
            //        }
            //    }
            //}
        }

        /// <summary>
        /// required implementation
        /// </summary>
        /// <param name="roleName">a role name</param>
        public override void CreateRole(string roleName)
        {
            if ((roleName != null) && (roleName.Length > 0))
            {
                //if (!Role.Exists(roleName))
                //{
                //    Role role = new Role();
                //    role.RoleName = roleName;
                //    role.Save();
                //}
            }
        }

        /// <summary>
        /// required implementation
        /// </summary>
        /// <param name="roleName">a role</param>
        /// <param name="throwOnPopulatedRole">get upset of users are in a role</param>
        /// <returns></returns>
        //public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        //{
        //    bool result = false;

        //    if ((roleName != null) && (roleName.Length > 0))
        //    {
        //        Role role = new Role(roleName);
        //        if (role.RoleId != Guid.Empty)
        //        {
        //            if ((throwOnPopulatedRole) && (role.HasUsers()))
        //            {
        //                throw new Exception("This role cannot be deleted because it has users.");
        //            }

        //            Role.DeleteRole(role.RoleId);
        //            result = true;
        //        }
        //    }

        //    return result;
        //}

        /// <summary>
        /// required implemention
        /// </summary>
        /// <param name="roleName">a role</param>
        /// <param name="usernameToMatch">a username to look for in the role</param>
        /// <returns></returns>
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            //return service.FindUsersInRole(_RemoteProviderName, _ApplicationName, roleName, usernameToMatch);


            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// required implementation
        /// this should not be used to get data for a dropdown list
        /// because it doesn't have role id or display name
        /// </summary>
        /// <returns></returns>
        public override string[] GetAllRoles()
        {
            string[] roleList = null;// new string[Role.CountOfRoles()];
            //int i = 0;
            //using (IDataReader reader = Role.GetSiteRoles())
            //{
            //    while (reader.Read())
            //    {
            //        roleList[i] = reader["RoleName"].ToString();
            //        i += 1;
            //    }
            //}
            return roleList;
        }

        /// <summary>
        /// required implementation
        /// </summary>
        /// <param name="username">a username</param>
        /// <returns>a list of roles</returns>
        public override string[] GetRolesForUser(string userName)
        {
            if (HttpContext.Current != null)
            {
                string roleCookieName = SiteUtils.GetRoleCookieName();

                if ((HttpContext.Current.Request.IsAuthenticated)
                && (HttpContext.Current.User.Identity.Name == userName)
                )
                {
                    if (
                    (CookieHelper.CookieExists(roleCookieName))
                    && (CookieHelper.GetCookieValue(roleCookieName).Length > 0)
                    )
                    {
                        return GetRolesFromCookie();
                    }
                    else
                    {
                        return GetRolesAndSetCookie();
                    }
                }
                else
                {
                    // not current user or not authenticated


                    //if ((userName != null) && (userName.Length > 0))
                    //{
                    //    return SiteUser.GetRoles(userName);
                    //}
                }
            }

            return new string[0];
        }

        public static void ResetCurrentUserRolesCookie()
        {
            if (HttpContext.Current == null)
            {
                return;
            }
            if (HttpContext.Current.Request == null)
            {
                return;
            }
            if (!HttpContext.Current.Request.IsAuthenticated)
            {
                return;
            }

            GetRolesAndSetCookieInternal();
        }

        private static string[] GetRolesAndSetCookieInternal()
        {
            string[] currentUserRoles = new string[0];
            String hostName =  WebUtils.GetHostName();


            string roleCookieName = SiteUtils.GetRoleCookieName();
            //currentUserRoles = SiteUser.GetRoles(HttpContext.Current.User.Identity.Name);
            string roleStr = "";
            //foreach (string role in currentUserRoles)
            //{
            //    roleStr += role;
            //    roleStr += ";";
            //}

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
            1, // version
            HttpContext.Current.User.Identity.Name, // user name
            DateTime.Now, // issue time
            DateTime.Now.AddHours(1), // expires every hour
            false, // don't persist cookie
            roleStr // roles
            );

            string cookieStr = FormsAuthentication.Encrypt(ticket);

            HttpCookie roleCookie = new HttpCookie(roleCookieName, cookieStr);
            //roleCookie.Expires = DateTime.Now.AddMinutes(20);
            roleCookie.HttpOnly = true;
            roleCookie.Path = "/";
            HttpContext.Current.Response.Cookies.Add(roleCookie);

            return currentUserRoles;
        }

        private string[] GetRolesAndSetCookie()
        {
            return GetRolesAndSetCookieInternal();
        }

        private string[] GetRolesFromCookie()
        {
            string[] currentUserRoles = new string[0];
            String hostName =  WebUtils.GetHostName();

            string roleCookieName = SiteUtils.GetRoleCookieName();
            ArrayList userRoles = new ArrayList();
            HttpCookie roleCookie = HttpContext.Current.Request.Cookies[roleCookieName];
            if (roleCookie != null)
            {
                FormsAuthenticationTicket ticket
                = FormsAuthentication.Decrypt(roleCookie.Value);

                foreach (string role in ticket.UserData.Split(new char[] { ';' }))
                {
                    userRoles.Add(role);
                }
            }

            currentUserRoles = (string[])userRoles.ToArray(typeof(string));

            return currentUserRoles;
        }




        /// <summary>
        /// required implementation
        /// </summary>
        /// <param name="roleName">a role</param>
        /// <returns>a list of users</returns>
        //public override string[] GetUsersInRole(string roleName)
        //{
        //    Role role = new Role(roleName);
        //    if (role.RoleId != Guid.Empty)
        //    {
        //        string[] userList = new string[role.CountOfUsers()];
        //        int i = 0;
        //        using (IDataReader reader = Role.GetRoleMembers(role.RoleId))
        //        {
        //            while (reader.Read())
        //            {
        //                userList[i] = reader["LoginName"].ToString();
        //                i += 1;
        //            }
        //        }

        //        return userList;
        //    }


        //    return new string[0];
        //}

        /// <summary>
        /// required implementation
        /// </summary>
        /// <param name="userName">a username</param>
        /// <param name="roleName">a role</param>
        /// <returns>true or false</returns>
        public override bool IsUserInRole(string userName, string roleName)
        {
            bool result = false;
            string[] userRoles = GetRolesForUser(userName);
            foreach (String role in userRoles)
            {
                if (role == roleName)
                    result = true;
            }

            return result;
        }

        /// <summary>
        /// required implementation
        /// </summary>
        /// <param name="userNames">a list of usernames</param>
        /// <param name="roleNames">a list of roles</param>
        public override void RemoveUsersFromRoles(string[] userNames, string[] roleNames)
        {
            if ((userNames != null) && (roleNames != null))
            {
                foreach (String userName in userNames)
                {
                    SiteUser siteUser = new SiteUser(userName);
                    if (siteUser.UserId != Guid.Empty)
                    {
                        //foreach (String roleName in roleNames)
                        //{
                        //    Role role = new Role(roleName);
                        //    if (role.RoleId != Guid.Empty)
                        //    {
                        //        Role.RemoveUser(role.RoleId, siteUser.UserId);
                        //    }
                        //}
                    }
                }
            }
        }

        /// <summary>
        /// required implementation
        /// </summary>
        /// <param name="roleName">a role</param>
        /// <returns>true or false</returns>
        //public override bool RoleExists(string roleName)
        //{
        //    bool result = false;

        //    if ((roleName != null) && (roleName.Length > 0))
        //    {
        //        result = Role.Exists(roleName);
        //    }

        //    return result;
        //}

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}

