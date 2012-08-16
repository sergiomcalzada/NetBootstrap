using System.Web;

namespace NetBootstrap.Bootstrap.Components.Navbar
{
    public interface INavbarItemBuilder : IHtmlString
    {
    }


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
            return (TBuilder) this;
        }

        #region Implementation of IHtmlString

        public abstract string ToHtmlString();

        #endregion
    }

}