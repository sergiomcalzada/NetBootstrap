using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBootstrap.Base;

namespace NetBootstrap.Bootstrap
{
    public class BootstrapBuilder<TBootstrapComponent, TBuilder> : ViewComponentBuilderBase<TBootstrapComponent, TBuilder>
        where TBuilder : BootstrapBuilder<TBootstrapComponent, TBuilder>
        where TBootstrapComponent : BootstrapComponent
    {
    }
}
