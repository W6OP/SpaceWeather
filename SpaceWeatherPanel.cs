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
using Newtonsoft.Json;

namespace W6OP.HamCockpitPlugins.SpaceWeather
{
    public partial class SpaceWeatherPanel : UserControl
    {
        private readonly WebManager webManager = new WebManager();
        private readonly JSONManager jsonManager = new JSONManager();
        private const string NASA_Url = "https://services.swpc.noaa.gov/images/";
        private const string NOAA_Sunspot_Url = "https://services.swpc.noaa.gov/json/solar-cycle/predicted-solar-cycle.json";

        private DataTable SunSpotTable = new DataTable();
        private BindingSource SunSpotBinder = new BindingSource();

        private bool SunSpotsHaveBeenLoaded;

        /// <summary>
        /// Initialize the control.
        /// </summary>
        public SpaceWeatherPanel()
        {
            InitializeComponent();

            SunSpotBinder.DataSource = SunSpotTable;
            DataGridViewSunSpots.DataSource = SunSpotBinder;

        }

        /// <summary>
        /// Load the space weather image for the initial display.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpaceWeatherPanel_Load(object sender, EventArgs e)
        {
            GetImage("swx-overview-small.gif");
        }

        /// <summary>
        /// Cosolidate button clicks to one event.
        /// Use the tag of the button as the image name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            GetImage((string)button.Tag);
        }

        /// <summary>
        /// Display the retrieved image in the control.
        /// </summary>
        /// <param name="imageName"></param>
        private void GetImage(string imageName)
        {
            string imageUrl = NASA_Url + imageName;

            ImagePictureBox.Image = webManager.DownloadImageFromUrl(imageUrl);

            TabControlSpaceWeather.SelectedTab = TabPageSpaceWeather;
        }

        /// <summary>
        /// Button click event for the SunSpot button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPredictedSunSpots_Click(object sender, EventArgs e)
        {
            _ = GetDataAsync();
        }

        /// <summary>
        /// retrieve predicted SunSpot data from NOAA and display in a datagridview.
        /// https://www.swpc.noaa.gov/products/predicted-sunspot-number-and-radio-flux
        /// https://services.swpc.noaa.gov/json/solar-cycle/predicted-solar-cycle.json
        /// Date - predicted - high - low - 10.7 cm Radio Flux predicted - 10.7 cm Radio Flux high - 10.7 cm Radio Flux - low
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async Task GetDataAsync()
        {
            string url = NOAA_Sunspot_Url;

            string json = await webManager.GetJsonAsync(url);

            SunSpotTable = jsonManager.GetSunspotTable(json);

            TabControlSpaceWeather.SelectedTab = TabPageSunSpots; 

            DataGridViewSunSpots.Columns.Clear();
            SunSpotBinder.DataSource = SunSpotTable;
            DataGridViewSunSpots.DataSource = SunSpotBinder;
        }

        /// <summary>
        /// The first time the SunSpot tab is selected, query for SunSpot data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControlSpaceWeather_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SunSpotsHaveBeenLoaded == false)
            {
                SunSpotsHaveBeenLoaded = true;
                _ = GetDataAsync();
            }
        }
    } // end class
}

/*
 Sources

S.I.D.C. Brussels International Sunspot Number, Data Files (link is external).​
Penticton, B.C., Canada: 10.7cm radio flux values (sfu), Data Files (link is external).
Predicted values are based on the consensus of the Solar Cycle 25 Prediction Panel​

Fields (JSON)
time-tag: yyyy-mm
predicted_ssn: predicted sunspot number
high_ssn: predicted sunspot number high range
low_ssn: predicted sunspot number low range
predicted_f10.7: predicted f10.7cm value
high_f10.7: predicted f10.7cm high range
low_f10.7: predicted f10.7cm low range
 */