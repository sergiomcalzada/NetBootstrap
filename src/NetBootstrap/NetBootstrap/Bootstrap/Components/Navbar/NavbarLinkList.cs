using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NetBootstrap.Bootstrap.Components.Navbar
{
    public class NavbarLinkList : NavbarItem
    {
        public List<INavbarLink> Items { get; set; }
        public NavbarLinkList ()
        {
            this.Items = new List<INavbarLink>();
        }
    }

    public class NavbarLinkListBuilder : NavbarItemBuilder<NavbarLinkListBuilder, NavbarLinkList>
    {
        public UrlHelper UrlHelper { get; set; }

        public NavbarLinkListBuilder(NavbarLinkList item, UrlHelper urlHelper)
            : base(item)
        {
            UrlHelper = urlHelper;
        }

        #region Overrides of NavbarItemBuilder<NavbarLinkListBuilder,NavbarLinkList>

        public override string ToHtmlString()
        {
            var htmlString = new StringBuilder();
            foreach (var item in this.Item.Items)
            {
                htmlString.AppendLine(item.ToHtmlString());
            }


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

            nav.InnerHtml = htmlString.ToString();
            return nav.ToString();
        }

        #endregion

        public NavbarLinkBuilder AddLink()
        {
            var item = new NavbarLink();
            var builder = new NavbarLinkBuilder(item, UrlHelper);
            this.Item.Items.Add(item);
            return builder;
        }

        public void AddDivider()
        {
            var item = new NavbarDivider();
            this.Item.Items.Add(item);
        }
    }

    public interface INavbarLink : IHtmlString { }
   
    public class NavbarLink : INavbarLink
    {
        public NavbarLink ()
        {
            this.Link = "#";
        }
        public bool Active { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }

        #region Implementation of IHtmlString

        public string ToHtmlString()
        {

            var navItem = new TagBuilder("li");

            if (this.Active)
                navItem.AddCssClass("active");

            var navLink = new TagBuilder("a");

            navLink.MergeAttribute("href", Link);

            navLink.InnerHtml = this.Text;
            navItem.InnerHtml = navLink.ToString();

            return navItem.ToString();
        }

        #endregion
    }
    public class NavbarLinkBuilder
    {
        public NavbarLink Item { get; set; }
        public UrlHelper UrlHelper { get; set; }

        public NavbarLinkBuilder(NavbarLink item, UrlHelper urlHelper)
        {
            this.Item = item;
            UrlHelper = urlHelper;
        }

        public NavbarLinkBuilder Text(string text)
        {
            this.Item.Text = text;
            return this;
        }

        public NavbarLinkBuilder Active(bool active)
        {
            this.Item.Active = active;
            return this;
        }

        public NavbarLinkBuilder Action(string actionName, string controllerName, object routeValues)
        {

            var generatedUrl = UrlHelper.Action(actionName, controllerName, routeValues);

            this.Item.Link = generatedUrl;
            return this;
        }

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
}