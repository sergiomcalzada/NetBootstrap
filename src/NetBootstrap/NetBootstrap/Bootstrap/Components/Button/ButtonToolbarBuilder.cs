using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetBootstrap.Bootstrap.Components.Button
{
    public class ButtonToolbarBuilder : BootstrapBuilder<ButtonToolbar, ButtonToolbarBuilder>
    {
        public ButtonToolbarBuilder AddGruops(Action<ButtonToolbarFactory> groups)
        {
            var builder = new ButtonToolbarFactory(this.Component);

            groups(builder);
            return this;

        }
    }

    public class ButtonToolbarFactory
    {
        protected ButtonToolbar Component { get; set; }

        public ButtonToolbarFactory(ButtonToolbar component)
        {
            Component = component;
        }

        public ButtonGroupBuilder AddGroup()
        {
            var group = new ButtonGroup(this.Component.ViewContext);
            Component.Groups.Add(group);
            var builder = ButtonGroupBuilder.Create(group);
            return builder;
        }


    }
}
