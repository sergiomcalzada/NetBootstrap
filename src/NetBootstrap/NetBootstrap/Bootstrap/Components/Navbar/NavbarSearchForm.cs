using System;
using System.Web.Mvc;

namespace NetBootstrap.Bootstrap.Components.Navbar
{
    public class NavbarSearchForm : NavbarItem
    {
        public string Placeholder { get; set; }
    }

    public class NavbarSearchFormBuilder : NavbarItemBuilder<NavbarSearchFormBuilder, NavbarSearchForm>
    {
        public NavbarSearchFormBuilder(NavbarSearchForm item)
            : base(item)
        {
        }

        #region Overrides of NavbarItemBuilder<NavbarFormBuilder,NavbarSearchForm>

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

        public NavbarSearchFormBuilder Placeholder(string placeholder)
        {
            this.Item.Placeholder = placeholder;
            return this;
        }
    }

}