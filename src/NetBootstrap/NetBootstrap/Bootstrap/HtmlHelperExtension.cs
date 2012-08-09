using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace NetBootstrap.Bootstrap
{
    public static class HtmlHelperExtension
    {

        public static BootstrapFactory<TModel> Bootstrap<TModel>(this HtmlHelper<TModel> helper)
        {
            return new BootstrapFactory<TModel>(helper);
        }
    }
}
