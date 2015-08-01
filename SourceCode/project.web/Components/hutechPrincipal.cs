using System.Security.Principal;

namespace project.web.Components.Security
{
    /// <summary>
    ///
    /// </summary>
    public class hutechPrincipal : IPrincipal
    {
        private IPrincipal innerPrincipal;
        private hutechIdentity identity = new hutechIdentity();
        //private string userRoles = string.Empty;

        public hutechPrincipal(IPrincipal innerPricipal)
        {
            this.innerPrincipal = innerPricipal;
            identity = new hutechIdentity(this.innerPrincipal.Identity);
        }

        public bool IsInRole(string role)
        {
            bool result = false;
            if (this.innerPrincipal != null)
            {
                result = this.innerPrincipal.IsInRole(role);
            }

            return result;
        }

        public IIdentity Identity
        {
            get
            {
                return identity;
            }
        }
    }
}
