using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VE3NEA.HamCockpit.PluginAPI;

namespace W6OP.HamCockpitPlugins.SpaceWeather
{
    [Export(typeof(IPlugin))]
    [Export(typeof(IVisualPlugin))]
    class SpaceWeatherPlugin : IPlugin, IVisualPlugin
    {
        private Settings settings = new Settings();
        private SpaceWeatherPanel panel;

        /// <summary>
        /// Constructor
        /// </summary>
        public void SpaceWeather()
        {

        }

        #region IPlugin Implmentation

        public string Name => "Space Weather";

        public string Author => "W6OP";

        public bool Enabled { get; set; }

        public object Settings { get => settings; set => ApplySettings(value); }

        public ToolStrip ToolStrip => null;

        public ToolStripItem StatusItem => null;

        #endregion

        #region IVisual Implmentation

        public bool CanCreatePanel => panel == null;

        public UserControl CreatePanel()
        {
            panel = new SpaceWeatherPanel
            {
                Name = GetTitleAndVersion()
            };
            return panel;
        }

        public void DestroyPanel(UserControl panel)
        {
            this.panel = null;
        }

        #endregion


        private void ApplySettings(object value)
        {
            settings = value as Settings;
            if (panel != null)
            {
                panel.BackColor = settings.BackColor;
            }
        }

        private string GetTitleAndVersion()
        {
            // get the version number
            Assembly asm = Assembly.GetExecutingAssembly();
            AssemblyName an = asm.GetName();
            string version = an.Version.Major + "." + an.Version.Minor + "." + an.Version.Build + "." + an.Version.Revision;
            return "Space Weather (" + version + ")";
        }

    } // end class
}
