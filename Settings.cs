using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6OP.HamCockpitPlugins.SpaceWeather
{
    class Settings
    {
        [DisplayName("Background Color")]
        [Description("The background color of the panel.")]
        [DefaultValue(typeof(Color), "Control")]
        public Color BackColor { get; set; } = SystemColors.GradientInactiveCaption;
    } // end class
}
