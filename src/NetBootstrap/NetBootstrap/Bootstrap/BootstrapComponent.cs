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
        }

        public string Name { get; set; }

        public string Id
        {
            get { return TagBuilder.CreateSanitizedId(Name); }
        }
    }
}
