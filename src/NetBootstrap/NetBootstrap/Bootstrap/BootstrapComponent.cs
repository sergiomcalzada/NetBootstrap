using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using NetBootstrap.Base;

namespace NetBootstrap.Bootstrap
{
    public abstract class BootstrapComponent : ViewComponentBase
    {
        protected BootstrapComponent(ViewContext context) : base(context)
        {
            this.Enabled = true;
            this.Active = false;
        }


        protected TagBuilder HtmlBuilder;

        public string Name { get; set; }

        public string Id
        {
            get { return TagBuilder.CreateSanitizedId(Name); }
        }

        public bool Enabled { get; set; }

        public bool Active { get; set; }


        protected virtual void SetEnabled()
        {
            if (!this.Enabled )
                HtmlBuilder.AddCssClass("disabled");
        }
        protected virtual void SetActive()
        {
            if (this.Active)
                HtmlBuilder.AddCssClass("active");
        }
    }
}
