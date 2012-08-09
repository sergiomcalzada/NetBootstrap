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

        private TagBuilder HtmlBuilder;

        public Button(ViewContext context)
            : base(context)
        {
            HtmlBuilder = new TagBuilder("Button");
        }

        #region Overrides of ViewComponentBase

        public override IHtmlString ToHtmlString()
        {
            SetClass();
            SetSize();
            SetText();
            var htmlString = new HtmlString(HtmlBuilder.ToString());
            return htmlString;
        }

        private void SetSize()
        {
            switch (this.Class)
            {
                case ButtonClass.Defatul:
                    HtmlBuilder.AddCssClass("btn");
                    break;
                case ButtonClass.Primary:
                    HtmlBuilder.AddCssClass("btn btn-primary");
                    break;
                case ButtonClass.Info:
                    HtmlBuilder.AddCssClass("btn btn-info");
                    break;
                case ButtonClass.Success:
                    HtmlBuilder.AddCssClass("btn btn-success");
                    break;
                case ButtonClass.Warning:
                    HtmlBuilder.AddCssClass("btn btn-warning");
                    break;
                case ButtonClass.Danger:
                    HtmlBuilder.AddCssClass("btn btn-danger");
                    break;
                case ButtonClass.Inverse:
                    HtmlBuilder.AddCssClass("btn btn-inverse");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetClass()
        {
            switch (Size)
            {
                case ButtonSize.Standar:
                    break;
                case ButtonSize.Large:
                    HtmlBuilder.AddCssClass("btn-large");
                    break;
                case ButtonSize.Small:
                    HtmlBuilder.AddCssClass("btn-small");
                    break;
                case ButtonSize.Mini:
                    HtmlBuilder.AddCssClass("btn-mini");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetText()
        {
            HtmlBuilder.InnerHtml = this.Text;
        }

        #endregion

        public ButtonClass Class { get; set; }
        public ButtonSize Size { get; set; }
        public string Text { get; set; }

    }
}
