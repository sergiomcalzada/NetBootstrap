using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBootstrap.Base;

namespace NetBootstrap.Bootstrap
{
    public class BootstrapBuilder<TBootstrapComponent, TBootstrapBuilder> : ViewComponentBuilderBase<TBootstrapComponent, TBootstrapBuilder>
        where TBootstrapBuilder : BootstrapBuilder<TBootstrapComponent, TBootstrapBuilder>
        where TBootstrapComponent : BootstrapComponent
    {

        public virtual TBootstrapBuilder Name(string name)
        {
            Component.Name = name;
            return (TBootstrapBuilder)this;
        }

    }
}
