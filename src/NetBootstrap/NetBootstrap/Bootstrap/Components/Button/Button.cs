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

       

        public Button(ViewContext context)
            : base(context)
        {
            HtmlBuilder = new TagBuilder("Button");
            HtmlBuilder.AddCssClass("btn");
            this.Class = ButtonClass.Defatul;
            this.Size = ButtonSize.Standar;
            this.Text = string.Empty;
            
        }

        #region Overrides of ViewComponentBase

        public override IHtmlString ToHtmlString()
        {
            SetEnabled();

            SetClass();
            SetSize();
            SetText();
            
            var htmlString = new HtmlString(HtmlBuilder.ToString());
            return htmlString;
        }


        #endregion

        public ButtonClass Class { get; set; }
        public ButtonSize Size { get; set; }
        public string Text { get; set; }


        private void SetClass()
        {
            switch (this.Class)
            {
                case ButtonClass.Defatul:
                    break;
                case ButtonClass.Primary:
                    HtmlBuilder.AddCssClass("btn-primary");
                    break;
                case ButtonClass.Info:
                    HtmlBuilder.AddCssClass("btn-info");
                    break;
                case ButtonClass.Success:
                    HtmlBuilder.AddCssClass("btn-success");
                    break;
                case ButtonClass.Warning:
                    HtmlBuilder.AddCssClass("btn-warning");
                    break;
                case ButtonClass.Danger:
                    HtmlBuilder.AddCssClass("btn-danger");
                    break;
                case ButtonClass.Inverse:
                    HtmlBuilder.AddCssClass("btn-inverse");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetSize()
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
    }
}
