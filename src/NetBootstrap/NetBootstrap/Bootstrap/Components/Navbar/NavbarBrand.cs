using System;
using System.Web.Mvc;

namespace NetBootstrap.Bootstrap.Components.Navbar
{
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
}