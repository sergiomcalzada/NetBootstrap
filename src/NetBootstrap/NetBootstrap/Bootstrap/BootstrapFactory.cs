using System.Web.Mvc;
using NetBootstrap.Base;
using NetBootstrap.Bootstrap.Components.Button;

namespace NetBootstrap.Bootstrap
{

    public class BootstrapFactory<TModel> : ViewComponentFactoryBase<TModel>
    {
        public BootstrapFactory(HtmlHelper<TModel> helper)
            : base(helper)
        {
        }

        public ButtonBuilder Button()
        {
            return ButtonBuilder.Create(new Button(this.HtmlHelper.ViewContext));
        }
    }
}
