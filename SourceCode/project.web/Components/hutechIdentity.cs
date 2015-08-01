using System;
using System.Security.Principal;

namespace project.web.Components.Security
{
    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public class hutechIdentity : MarshalByRefObject, IIdentity
    {
        public hutechIdentity()
        {
        }

        public hutechIdentity(IIdentity innerIdentity)
        {
            this.innerIdentity = innerIdentity;
            name = this.innerIdentity.Name;
            isAuthenticated = this.innerIdentity.IsAuthenticated;
        }

        private IIdentity innerIdentity;
        private string name = string.Empty;
        private bool isAuthenticated = false;
        private bool alreadyChecked = false;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string AuthenticationType
        {
            get
            {
                return innerIdentity.AuthenticationType;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return isAuthenticated;
            }
        }
    }
}
