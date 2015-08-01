using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project.web.UI
{
    public class SiteLogo : WebControl
    {
        private bool useH1 = false;

        public bool UseH1
        {
            get
            {
                return useH1;
            }
            set
            {
                useH1 = value;
            }
        }

        private string overrideUrl = string.Empty;
        public string OverrideUrl
        {
            get
            {
                return overrideUrl;
            }
            set
            {
                overrideUrl = value;
            }
        }

        private string overrideTitle = string.Empty;
        public string OverrideTitle
        {
            get
            {
                return overrideTitle;
            }
            set
            {
                overrideTitle = value;
            }
        }

        private string overrideImageUrl = string.Empty;
        public string OverrideImageUrl
        {
            get
            {
                return overrideImageUrl;
            }
            set
            {
                overrideImageUrl = value;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (HttpContext.Current == null)
            {
                // TODO: show a bmp or some other design time thing?
                writer.Write("[" + this.ID + "]");
            }
            else
            {
                string urlToUse = "~/";
                string titleToUse = "HUTECH";
                string imageUrlToUse = Page.ResolveUrl("~/App_Themes/Default/Images/app_logo.png");

                //urlToUse = siteSettings.SiteRoot + "/Default.aspx";

                if (useH1)
                {
                    writer.Write("<h1 class='sitelogo'>");
                }

                if (overrideUrl.Length > 0)
                {
                    //if (siteSettings.SiteFolderName.Length > 0)
                    //{
                    //    overrideUrl = SiteUtils.GetNavigationSiteRoot()
                    //        + overrideUrl.Replace("~/", "/");
                    //}
                    urlToUse = overrideUrl;
                }

                if (overrideImageUrl.Length > 0)
                {
                    imageUrlToUse = Page.ResolveUrl(overrideImageUrl);
                }

                if (overrideTitle.Length > 0)
                    titleToUse = overrideTitle;

                writer.Write("<a href='{0}' title='{1}'><img class='sitelogo' alt='{1}' src='{2}' /></a>",
                Page.ResolveUrl(urlToUse),
                titleToUse,
                imageUrlToUse);

                if (useH1)
                {
                    writer.Write("</h1>");
                }
            }
        }
    }
}
