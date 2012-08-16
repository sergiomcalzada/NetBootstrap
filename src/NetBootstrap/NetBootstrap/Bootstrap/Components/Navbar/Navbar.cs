using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NetBootstrap.Bootstrap.Components.Navbar
{
    public class Navbar : BootstrapComponent
    {
        private readonly TagBuilder _navInner;
        private readonly TagBuilder _navContainer;


        public Navbar(ViewContext context)
            : base(context)
        {
            HtmlBuilder = new TagBuilder("div");
            HtmlBuilder.AddCssClass("navbar");

            _navInner = new TagBuilder("div");
            _navInner.AddCssClass("navbar-inner");

            _navContainer = new TagBuilder("div");
            _navContainer.AddCssClass("container");

            this.Fixed = NavbarFix.None;
            this.Items = new List<INavbarItemBuilder>();
        }

        #region Overrides of ViewComponentBase

        public override IHtmlString ToHtmlString()
        {
            SetFixed();
            SetContainerContent();

            _navInner.InnerHtml = _navContainer.ToString();
            HtmlBuilder.InnerHtml = _navInner.ToString();
            var htmlString = new HtmlString(HtmlBuilder.ToString());
            return htmlString;
        }

        #endregion

        public NavbarFix Fixed { get; set; }
        public List<INavbarItemBuilder> Items { get; set; }

        private void SetFixed()
        {
            switch (this.Fixed)
            {
                case NavbarFix.None:
                    break;
                case NavbarFix.Top:
                    HtmlBuilder.AddCssClass("navbar-fixed-top");
                    break;
                case NavbarFix.Down:
                    HtmlBuilder.AddCssClass("navbar-fixed-bottom");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetContainerContent()
        {

            var content = new StringBuilder();
            foreach (var item in Items)
            {
                content.AppendLine(item.ToHtmlString());
            }

            _navContainer.InnerHtml = content.ToString();
        }

      
    }

    public class NavbarItemFactory
    {
        private readonly Navbar _component;

        public NavbarItemFactory(Navbar component)
        {
            _component = component;
        }

        public NavbarBrandBuilder AddBrand()
        {
            var builder = new NavbarBrandBuilder(new NavbarBrand());
            _component.Items.Add(builder);
            return builder;
        }

        public NavbarLinkListBuilder AddLinks(Action<NavbarLinkListBuilder> links )
        {
            var builder = new NavbarLinkListBuilder(new NavbarLinkList(), new UrlHelper(this._component.ViewContext.RequestContext));
            _component.Items.Add(builder);
            links(builder);
            return builder;
        }

        public NavbarSearchFormBuilder AddSearchForm()
        {
            var builder = new NavbarSearchFormBuilder(new NavbarSearchForm());
            _component.Items.Add(builder);
            return builder;
        }

        public NavbarFormBuilder AddForm()
        {
            var builder = new NavbarFormBuilder(new NavbarForm());
            _component.Items.Add(builder);
            return builder;
        }

    }

}
