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

        //private string GetItems()
        //{
        //    var nav = new TagBuilder("ul");
        //    nav.AddCssClass("nav");

        //    var navContent = new StringBuilder();
        //    foreach (var item in this.Items)
        //    {
        //        var navItem = new TagBuilder("li");

        //        if (item is NavbarLink)
        //        {
        //            if (item.Active)
        //                navItem.AddCssClass("active");

        //            var navLink = new TagBuilder("a");
        //            navLink.MergeAttribute("href", "#");

        //            navLink.InnerHtml = item.Text;
        //            navItem.InnerHtml = navLink.ToString();

        //        }
        //        else if (item is NavbarDivider )
        //        {
        //            navItem.AddCssClass("divider-vertical");
        //        }



        //        navContent.AppendLine(navItem.ToString());
        //    }

        //    nav.InnerHtml = navContent.ToString();

        //    var navCollapsed = new TagBuilder("div");
        //    navCollapsed.AddCssClass("nav-collapse");
        //    navCollapsed.InnerHtml = nav.ToString();

        //    return navCollapsed.ToString();
        //}
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

        public NavbarLinkListBuilder AddLinks()
        {
            var builder = new NavbarLinkListBuilder(new NavbarLinkList());
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



    public class NavbarItem
    {
        public NavbarItemPull Pull { get; set; }
    }

    public interface INavbarItemBuilder : IHtmlString { }
    public abstract class NavbarItemBuilder<TBuilder, TItem> : INavbarItemBuilder
        where TBuilder : NavbarItemBuilder<TBuilder, TItem>
        where TItem : NavbarItem
    {
        protected NavbarItemBuilder(TItem item)
        {
            this.Item = item;
        }

        public TItem Item { get; set; }

        public virtual TBuilder Pull(NavbarItemPull pull)
        {
            Item.Pull = pull;
            return (TBuilder)this;
        }

        #region Implementation of IHtmlString

        public abstract string ToHtmlString();

        #endregion
    }


    public class NavbarBrand : NavbarItem
    {
        public string Text { get; set; }
    }
    public class NavbarBrandBuilder : NavbarItemBuilder<NavbarBrandBuilder, NavbarBrand>
    {
        public NavbarBrandBuilder(NavbarBrand item)
            : base(item)
        {
        }

        public virtual NavbarBrandBuilder Text(string text)
        {
            Item.Text = text;
            return this;
        }

        #region Overrides of NavbarItemBuilder<NavbarBrandBuilder,NavbarBrand>

        public override string ToHtmlString()
        {

            var brand = new TagBuilder("a");
            brand.AddCssClass("brand");
            brand.MergeAttribute("href", "#");
            brand.InnerHtml = this.Item.Text;

            var nav = new TagBuilder("ul");
            nav.AddCssClass("nav");
            switch (this.Item.Pull)
            {
                case NavbarItemPull.None:
                    break;
                case NavbarItemPull.Left:
                    nav.AddCssClass("pull-left");
                    break;
                case NavbarItemPull.Right:
                    nav.AddCssClass("pull-right");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            nav.InnerHtml = brand.ToString();
            return nav.ToString();
        }

        #endregion
    }

    public class NavbarForm : NavbarItem
    {
        public string Placeholder { get; set; }
    }
    public class NavbarFormBuilder : NavbarItemBuilder<NavbarFormBuilder, NavbarForm>
    {
        public NavbarFormBuilder(NavbarForm item)
            : base(item)
        {
        }

        #region Overrides of NavbarItemBuilder<NavbarFormBuilder,NavbarForm>

        public override string ToHtmlString()
        {
            var form = new TagBuilder("form");
            form.AddCssClass("navbar-search");

            var search = new TagBuilder("input");
            search.AddCssClass("search-query");
            search.MergeAttribute("type", "text");
            search.MergeAttribute("placeholder", this.Item.Placeholder);

            form.InnerHtml = search.ToString();


            var nav = new TagBuilder("ul");
            nav.AddCssClass("nav");
            switch (this.Item.Pull)
            {
                case NavbarItemPull.None:
                    break;
                case NavbarItemPull.Left:
                    nav.AddCssClass("pull-left");
                    break;
                case NavbarItemPull.Right:
                    nav.AddCssClass("pull-right");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            nav.InnerHtml = form.ToString();
            return nav.ToString();
        }

        #endregion

        public NavbarFormBuilder Placeholder(string placeholder)
        {
            this.Item.Placeholder = placeholder;
            return this;
        }
    }

    public class NavbarLinkList : NavbarItem { }
    public class NavbarLinkListBuilder : NavbarItemBuilder<NavbarLinkListBuilder, NavbarLinkList>
    {
        public NavbarLinkListBuilder(NavbarLinkList item)
            : base(item)
        {
            Items = new List<ILinkItem>();
        }

        #region Overrides of NavbarItemBuilder<NavbarLinkListBuilder,NavbarLinkList>

        public override string ToHtmlString()
        {
            throw new NotImplementedException();
        }

        #endregion

        public List<ILinkItem> Items { get; set; }
    }

    public interface INavbarLink : IHtmlString { }
    public class NavbarLink : INavbarLink
    {
        public bool Active { get; set; }
        public string Text { get; set; }

        #region Implementation of IHtmlString

        public string ToHtmlString()
        {

            var navItem = new TagBuilder("li");

            if (this.Active)
                navItem.AddCssClass("active");

            var navLink = new TagBuilder("a");
            navLink.MergeAttribute("href", "#");

            navLink.InnerHtml = this.Text;
            navItem.InnerHtml = navLink.ToString();

            return navItem.ToString();
        }

        #endregion
    }

    public class NavbarDivider : INavbarLink
    {
        #region Implementation of IHtmlString

        public string ToHtmlString()
        {
            var navItem = new TagBuilder("li");
            navItem.AddCssClass("divider-vertical");
            return navItem.ToString();
        }

        #endregion
    }

    public class NavbarLinkBuilder
    {



    }
}
