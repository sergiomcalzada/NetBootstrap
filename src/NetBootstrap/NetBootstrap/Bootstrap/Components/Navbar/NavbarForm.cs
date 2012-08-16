using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NetBootstrap.Bootstrap.Components.Navbar
{
    public class NavbarForm : NavbarItem
    {
        public IHtmlString Content { get; set; }
    }

    public class NavbarFormBuilder : NavbarItemBuilder<NavbarFormBuilder, NavbarForm>
    {
        public NavbarFormBuilder(NavbarForm item)
            : base(item)
        {
        }

        #region Overrides of NavbarItemBuilder<NavbarFormBuilder,NavbarSearchForm>

        public override string ToHtmlString()
        {
            var form = new TagBuilder("form");
            form.AddCssClass("navbar-form");

            

            form.InnerHtml = Item.Content.ToHtmlString();


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

        public NavbarFormBuilder Content(string content)
        {

            this.Item.Content = new HtmlString(content);
            return this;
        }

        

        public NavbarFormBuilder Content(Func<object, object> content)
        {
            this.Item.Content = new HtmlString(content(null).ToString().Trim());
            return this;
        }
    }

}