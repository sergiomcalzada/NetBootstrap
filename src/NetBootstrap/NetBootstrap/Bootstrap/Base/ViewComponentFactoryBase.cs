using System.Web.Mvc;

namespace NetBootstrap.Bootstrap.Base
{
    public abstract class ViewComponentFactoryBase
    {
        protected ViewComponentFactoryBase(HtmlHelper helper)
        {
            HtmlHelper = helper;
        }

        protected HtmlHelper HtmlHelper { get; set; }

    }

    public abstract class ViewComponentFactoryBase<TModel> : ViewComponentFactoryBase
    {
        protected ViewComponentFactoryBase(HtmlHelper helper)
            : base(helper)
        {
        }


    }
}
