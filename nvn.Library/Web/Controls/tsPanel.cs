using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nvn.Library.Web.Controls
{
    [ToolboxData("<{0}:Panel runat=server></{0}:Panel>")]
    public class tsPanel : System.Web.UI.WebControls.Panel, System.Web.UI.IPostBackEventHandler
    {
        [Category("Behavior")]
        [DefaultValue("")]
        public string CommandName
        {
            get
            {
                String s = (String)ViewState["CommandName"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["CommandName"] = value;
            }
        }

        [Category("Behavior")]
        [DefaultValue("")]
        public string CommandArgument
        {
            get
            {
                String s = (String)ViewState["CommandArgument"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["CommandArgument"] = value;
            }
        }


        [Category("Behavior")]
        [DefaultValue("")]
        public string OnClientClick
        {
            get
            {
                String s = (String)ViewState["OnClientClick"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["OnClientClick"] = value;
            }
        }

        [Category("Behavior")]
        [DefaultValue("")]
        public string OnClientMouseOver
        {
            get
            {
                String s = (String)ViewState["OnClientMouseOver"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["OnClientMouseOver"] = value;
            }
        }

        [Category("Behavior")]
        [DefaultValue("")]
        public string OnClientMouseOut
        {
            get
            {
                String s = (String)ViewState["OnClientMouseOut"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["OnClientMouseOut"] = value;
            }
        }

        public tsPanel()
            : base()
        {
        }

        [Category("Action")]
        public event CommandEventHandler Command;
        [Category("Action")]
        public event EventHandler Click;
        [Category("Action")]
        public event EventHandler MouseOver;
        [Category("Action")]
        public event EventHandler MouseOut;


        protected virtual void OnCommand(CommandEventArgs e)
        {
            if (Command != null)
            {
                Command(this, e);
            }
        }

        protected virtual void OnClick(EventArgs e)
        {
            if (Click != null)
            {
                Click(this, e);
            }
        }

        protected virtual void OnMouseOver(EventArgs e)
        {
            if (MouseOver != null)
            {
                MouseOver(this, e);
            }
        }

        protected virtual void OnMouseOut(EventArgs e)
        {
            if (MouseOut != null)
            {
                MouseOut(this, e);
            }
        }

        public void RaisePostBackEvent(string eventArgument)
        {
            OnCommand(new CommandEventArgs(this.CommandName, this.CommandArgument));
            OnClick(new EventArgs());
            OnMouseOver(new EventArgs());
            OnMouseOut(new EventArgs());
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if (Click != null || Command != null)
            {
                this.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(this, String.Empty));
            }
            if (MouseOver != null)
            {
                this.Attributes.Add("onmouseover", Page.ClientScript.GetPostBackEventReference(this, String.Empty));
            }
            if (MouseOut != null)
            {
                this.Attributes.Add("onmouseout", Page.ClientScript.GetPostBackEventReference(this, String.Empty));
            }

            if (OnClientClick != "")
            {
                this.Attributes.Add("onclick", OnClientClick);
            }
            if (OnClientMouseOver != "")
            {
                this.Attributes.Add("onmouseover", OnClientMouseOver);
            }
            if (OnClientMouseOut != "")
            {
                this.Attributes.Add("onmouseout", OnClientMouseOut);
            }
            base.Render(writer);
        }
    }
}
