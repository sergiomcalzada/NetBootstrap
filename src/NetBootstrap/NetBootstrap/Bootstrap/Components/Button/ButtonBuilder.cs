using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetBootstrap.Bootstrap.Components.Button
{
    public class ButtonBuilder : BootstrapBuilder<Button, ButtonBuilder>
    {
        public virtual ButtonBuilder ButtonType(ButtonClass buttonClass)
        {
            Component.Class = buttonClass;
            return this;
        }

        public virtual ButtonBuilder Size(ButtonSize size)
        {
            Component.Size = size;
            return this;
        }
    }
}
