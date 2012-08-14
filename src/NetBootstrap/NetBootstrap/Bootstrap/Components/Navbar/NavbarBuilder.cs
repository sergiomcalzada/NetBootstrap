using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetBootstrap.Bootstrap.Components.Navbar
{
    public class NavbarBuilder : BootstrapBuilder<Navbar, NavbarBuilder>
    {
        public virtual NavbarBuilder Fixed(NavbarFix @fixed)
        {
            Component.Fixed = @fixed;
            return this;
        }



        public virtual NavbarBuilder Items(Action<NavbarItemFactory> addAction)
        {
            var factory = new NavbarItemFactory(Component);
            addAction(factory);

            return this;
        }
    }
}
