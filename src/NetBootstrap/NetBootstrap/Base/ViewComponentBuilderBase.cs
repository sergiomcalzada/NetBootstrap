using System;
using System.Web;

namespace NetBootstrap.Base
{
    public interface IComponentBuilder<TViewComponent>
   where TViewComponent : ViewComponentBase
    {
        TViewComponent Component { get; set; }
    }

    public abstract class ViewComponentBuilderBase<TViewComponent, TBuilder> : IComponentBuilder<TViewComponent>, IHtmlString
        where TViewComponent : ViewComponentBase
        where TBuilder : ViewComponentBuilderBase<TViewComponent, TBuilder>
    {

        public static TBuilder Create(TViewComponent component)
        {
            var builder = (TBuilder)Activator.CreateInstance(typeof(TBuilder));
            builder.Component = component;
            return builder;
        }

        #region Implementation of IComponentBuilder<TViewComponent>

        public TViewComponent Component { get; set; }

        #endregion

        #region Implementation of IHtmlString

        public virtual string ToHtmlString()
        {
            var html = Component.ToHtmlString();
            return html.ToHtmlString();
        }

        #endregion
    }

    public abstract class HtmlViewComponentBuilderBase<TViewComponent, TBuilder> : ViewComponentBuilderBase<TViewComponent, TBuilder>
        where TViewComponent : HtmlComponentBase
        where TBuilder : HtmlViewComponentBuilderBase<TViewComponent, TBuilder>
    {
        public virtual TBuilder Name(string name)
        {
            this.Component.Name = name;
            return (TBuilder)this;
        }

    }

    public abstract class ScriptViewComponentBuilderBase<TViewComponent, TBuilder> : ViewComponentBuilderBase<TViewComponent, TBuilder>
        where TViewComponent : ScriptComponentBase
        where TBuilder : ScriptViewComponentBuilderBase<TViewComponent, TBuilder>
    {
        public virtual TBuilder Type(string type)
        {
            this.Component.Type = type;
            return (TBuilder)this;
        }
    }
}
