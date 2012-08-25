using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NetBootstrap.Bootstrap.Components.Button
{
    public class ButtonToolbar : BootstrapComponent
    {
        public ButtonToolbar(ViewContext context) : base(context)
        {
            this.Groups = new List<ButtonGroup>();
        }

        public List<ButtonGroup> Groups { get; set; }

        #region Overrides of ViewComponentBase

        public override IHtmlString ToHtmlString()
        {
            var builder = new StringBuilder();
            foreach (var group in Groups)
            {
                builder.AppendLine(group.ToHtmlString().ToString());
            }

            var rootTag = new TagBuilder("div");
            rootTag.AddCssClass("btn-toolbar");
            rootTag.InnerHtml = builder.ToString();

            return new HtmlString(rootTag.ToString());
        }

        #endregion
    }
}
