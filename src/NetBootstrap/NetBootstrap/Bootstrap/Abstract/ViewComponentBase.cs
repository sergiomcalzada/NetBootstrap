using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetBootstrap.Bootstrap.Abstract
{
    public abstract class ViewComponentBase
    {
        public ViewContext ViewContext { get; private set; }

        protected ViewComponentBase(ViewContext context)
        {
            this.ViewContext = context;
        }

        public abstract IHtmlString ToHtmlString();
    }

    public abstract class HtmlComponentBase : ViewComponentBase
    {
        protected HtmlComponentBase(ViewContext context)
            : base(context)
        {
        }

        public string Name { get; set; }

        public string Id
        {
            get { return TagBuilder.CreateSanitizedId(Name); }
        }
    }

    public abstract class ScriptComponentBase : ViewComponentBase
    {
        protected ScriptComponentBase(ViewContext context)
            : base(context)
        {
        }

        public string Type { get; set; }
    }
}
