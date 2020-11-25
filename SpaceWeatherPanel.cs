using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VE3NEA.HamCockpit.PluginAPI;
using System.ComponentModel.Composition;

namespace W6OP.HamCockpitPlugins.SpaceWeather
{
    public partial class SpaceWeatherPanel: UserControl
    {
        private WebManager webManager = new WebManager();
        private const string NASA_Url = "https://services.swpc.noaa.gov/images/";

        /// <summary>
        /// 
        /// </summary>
        public SpaceWeatherPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            GetImage((string)button.Tag);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageName"></param>
        private void GetImage(string imageName)
        {
            string imageUrl = NASA_Url + imageName;

            ImagePictureBox.Image = webManager.DownloadImageFromUrl(imageUrl);
        }
    } // end class
}
