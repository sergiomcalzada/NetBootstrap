using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NetBootstrap.Bootstrap.Components.Button
{
    public class Button : BootstrapComponent
    {
        public Button(ViewContext context) : base(context)
        {
        }

        #region Overrides of ViewComponentBase

        public override IHtmlString ToHtmlString()
        {
            var builder = new TagBuilder("button");
            builder = setClass(builder);
            builder = setSize(builder);
            var htmlString = new HtmlString( builder.ToString());
            return htmlString;
        }

        private TagBuilder setSize(TagBuilder builder)
        {
            switch (this.Class)
            {
                case ButtonClass.Defatul:
                    builder.AddCssClass("btn");
                    break;
                case ButtonClass.Primary:
                    builder.AddCssClass("btn btn-primary");
                    break;
                case ButtonClass.Info:
                    builder.AddCssClass("btn btn-info");
                    break;
                case ButtonClass.Success:
                    builder.AddCssClass("btn btn-success");
                    break;
                case ButtonClass.Warning:
                    builder.AddCssClass("btn btn-warning");
                    break;
                case ButtonClass.Danger:
                    builder.AddCssClass("btn btn-danger");
                    break;
                case ButtonClass.Inverse:
                    builder.AddCssClass("btn btn-inverse");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return builder;
        }

        private TagBuilder setClass(TagBuilder builder)
        {
            switch (Size)
            {
                case ButtonSize.Standar:
                    break;
                case ButtonSize.Large:
                    builder.AddCssClass("btn-large");
                    break;
                case ButtonSize.Small:
                    builder.AddCssClass("btn-small");
                    break;
                case ButtonSize.Mini:
                    builder.AddCssClass("btn-mini");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return builder;
        }

        #endregion

        public ButtonClass Class { get; set; }
        public ButtonSize Size { get; set; }

    }
}
