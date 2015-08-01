using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using nvn.Library.Web.Controls;
using Resources;

namespace project.web.UI
{
    /// <summary>
    /// This control inherits form Paginate and applies localization from Resource.resx
    /// Useing to set up the page number for data
    /// </summary>
    public class mojoCutePager :Paginate
    {

        protected override void OnInit(EventArgs e)
        {
            
            if (HttpContext.Current == null) { return; }
            base.OnInit(e);
            DoInit();
            
        }

        private void DoInit()
        {
            //this.NavigateToPageText = Resource.CutePagerNavigateToPageText;
            //this.GoClause = Resource.CutePagerGoClause;
            //this.OfClause = Resource.CutePagerOfClause;
            //this.FromClause = Resource.CutePagerFromClause;
            //this.PageClause = Resource.CutePagerPageClause;
            //this.ToClause = Resource.CutePagerToClause;
            //this.ShowingResultClause = Resource.CutePagerShowingResultClause;
            //this.ShowResultClause = Resource.CutePagerShowResultClause;
            //this.BackToFirstClause = Resource.CutePagerBackToFirstClause;
            //this.GoToLastClause = Resource.CutePagerGoToLastClause;
            //this.BackToPageClause = Resource.CutePagerBackToPageClause;
            //this.NextToPageClause = Resource.CutePagerNextToPageClause;
            this.NavigateToPageText = Resource.CutePagerNavigateToPageText;
            this.GoClause = Resource.CutePagerGoClause;
            this.OfClause = Resource.CutePagerOfClause;
            this.FromClause = Resource.CutePagerFromClause;
            this.PageClause = Resource.CutePagerPageClause;
            this.ToClause = Resource.CutePagerToClause;
            this.ShowingResultClause = Resource.CutePagerShowingResultClause;
            this.ShowResultClause = Resource.CutePagerShowResultClause;
            this.BackToFirstClause = Resource.CutePagerBackToFirstClause;
            this.GoToLastClause = Resource.CutePagerGoToLastClause;
            this.BackToPageClause = Resource.CutePagerBackToPageClause;
            this.NextToPageClause = Resource.CutePagerNextToPageClause;

            try
            {
                if (System.Threading.Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                {
                    this.RTL = true;
                }
            }
            catch { }

        }

        //protected override void Render(HtmlTextWriter writer)
        //{
        //    if (HttpContext.Current == null)
        //    {
        //        writer.Write("[" + this.ID + "]");
        //        return;
        //    }

        //    base.Render(writer);


        //}

    }
}
