using System.Web.Mvc;
using NetBootstrap.Base;
using NetBootstrap.Bootstrap.Components.Button;
using NetBootstrap.Bootstrap.Components.Navbar;

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

        public NavbarBuilder Navbar ()
        {
            return NavbarBuilder.Create(new Navbar(this.HtmlHelper.ViewContext));
        }

        public ButtonGroupBuilder ButtonGroup()
        {
            return ButtonGroupBuilder.Create(new ButtonGroup(this.HtmlHelper.ViewContext));
        }

        public ButtonToolbarBuilder ButtonToolbar()
        {
            return ButtonToolbarBuilder.Create(new ButtonToolbar(this.HtmlHelper.ViewContext));
        }
    }
}
