using System.Web.Mvc;
using NetBootstrap.Base;

namespace NetBootstrap.Bootstrap
{
    public class BootstrapFactory : ViewComponentFactoryBase
    {
        public BootstrapFactory(HtmlHelper helper) : base(helper)
        {
        }
    }

    public class BootstrapFactory<TModel> : ViewComponentFactoryBase<TModel>
    {
        public BootstrapFactory(HtmlHelper helper)
            : base(helper)
        {
        }
    }
}
