using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetBootstrap.Bootstrap.Abstract
{
    public abstract class ViewComponentFactoryBase
    {
        public ViewComponentFactoryBase(HtmlHelper helper)
        {
            HtmlHelper = helper;
        }

        protected HtmlHelper HtmlHelper { get; set; }

    }

    public abstract class ViewComponentFactoryBase<TModel> : ViewComponentFactoryBase
    {
        public ViewComponentFactory(HtmlHelper helper)
            : base(helper)
        {
        }


    }
}
