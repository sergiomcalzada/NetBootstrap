using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NetBootstrap.Bootstrap.Components.Button
{
    public class ButtonGroup : BootstrapComponent
    {
        public ButtonGroup(ViewContext context) : base(context)
        {
            this.Buttons = new List<Button>();
        }

        public IList<Button> Buttons { get; set; }

        #region Overrides of ViewComponentBase

        public override IHtmlString ToHtmlString()
        {
            var builder = new StringBuilder();
            foreach (var button in Buttons)
            {
               builder.AppendLine( button.ToHtmlString().ToString());
            }

            var rootTag = new TagBuilder("div");
            rootTag.AddCssClass("btn-group");
            rootTag.InnerHtml = builder.ToString();

            return new HtmlString(rootTag.ToString());
        }

        #endregion
    }
}
