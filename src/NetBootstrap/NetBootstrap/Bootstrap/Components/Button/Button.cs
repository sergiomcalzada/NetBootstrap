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
            throw new NotImplementedException();
        }

        #endregion

        public ButtonClass Class { get; set; }
        public ButtonSize Size { get; set; }

    }
}
