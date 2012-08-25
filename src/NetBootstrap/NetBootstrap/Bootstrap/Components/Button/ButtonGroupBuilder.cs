using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace NetBootstrap.Bootstrap.Components.Button
{
    public class ButtonGroupBuilder : BootstrapBuilder<ButtonGroup, ButtonGroupBuilder>
    {
        public ButtonGroupBuilder AddButtons(Action<ButtonGroupFactory> buttons)
        {
            var builder = new ButtonGroupFactory(this.Component);

            buttons(builder);
            return this;

        }
    }

    public class ButtonGroupFactory
    {
        protected ButtonGroup Component { get; set; }

        public ButtonGroupFactory(ButtonGroup component)
        {
            Component = component;
        }

        public ButtonBuilder AddButton()
        {
            var button = new Button(this.Component.ViewContext);
            Component.Buttons.Add(button);
            var builder = ButtonBuilder.Create(button);
            return builder;
        }

       
    }
}
