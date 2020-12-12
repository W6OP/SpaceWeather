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
   
        private const string NOAA_Sunspot_Url = "https://services.swpc.noaa.gov/json/solar-cycle/predicted-solar-cycle.json";
     

        private DataTable SunSpotTable = new DataTable();
        private readonly BindingSource SunSpotBinder = new BindingSource();

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
            Endpoint endpoint = new Endpoint();
            string url = endpoint.button1Address;
            string caption = endpoint.button1Caption;
            string comments = endpoint.button1Comment;

            SetButtonLabels();

            GetImage(url, caption, comments);
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
           
            var endpointInfo = GetEndpoint((string)button.Tag);

            GetImage(endpointInfo.Item1, endpointInfo.Item2, endpointInfo.Item3);
        }

        /// <summary>
        /// Display the retrieved image in the control.
        /// </summary>
        /// <param name="imageName"></param>
        private void GetImage(string imageURL, string caption, string comment)
        {
            ImagePictureBox.Image = webManager.DownloadImageFromUrl(imageURL);

            LabelCaption.Text = caption;
            LabelComments.Text = comment;

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

        /// <summary>
        /// get the URL etc. for the specific button.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        private Tuple<string, string, string> GetEndpoint(string tag)
        {
            Endpoint endpoint = new Endpoint();
            Tuple<string, string, string> endpointInfo = Tuple.Create("", "", "");

            switch (tag)
            {
                case "1":
                    endpointInfo = Tuple.Create(endpoint.button1Address, endpoint.button1Caption, endpoint.button1Comment);
                    break;
                case "2":
                    endpointInfo = Tuple.Create(endpoint.button2Address, endpoint.button2Caption, endpoint.button2Comment);
                    break;
                case "3":
                    endpointInfo = Tuple.Create(endpoint.button3Address, endpoint.button3Caption, endpoint.button3Comment);
                    break;
                case "4":
                    endpointInfo = Tuple.Create(endpoint.button4Address, endpoint.button4Caption, endpoint.button4Comment);
                    break;
                case "5":
                    endpointInfo = Tuple.Create(endpoint.button5Address, endpoint.button5Caption, endpoint.button5Comment);
                    break;
                case "6":
                    endpointInfo = Tuple.Create(endpoint.button6Address, endpoint.button6Caption, endpoint.button6Comment);
                    break;
                case "7":
                    endpointInfo = Tuple.Create(endpoint.button7Address, endpoint.button7Caption, endpoint.button7Comment);
                    break;
                case "8":
                    endpointInfo = Tuple.Create(endpoint.button8Address, endpoint.button8Caption, endpoint.button8Comment);
                    break;
                case "9":
                    endpointInfo = Tuple.Create(endpoint.button9Address, endpoint.button9Caption, endpoint.button9Comment);
                    break;
                case "10":
                    //endpointInfo = Tuple.Create(endpoint.button10Address, endpoint.button10Caption, endpoint.button10Comment);
                    break;
            }

            return endpointInfo;
        }

        /// <summary>
        /// Set the button labels.
        /// </summary>
        private void SetButtonLabels()
        {
            Endpoint endpoint = new Endpoint();

            foreach (var button in panel4.Controls.OfType<Button>())
            {
                switch (button.Tag)
                {
                    case "1":
                        button.Text = endpoint.button1Text;
                        break;
                    case "2":
                        button.Text = endpoint.button2Text;
                        break;
                    case "3":
                        button.Text = endpoint.button3Text;
                        break;
                    case "4":
                        button.Text = endpoint.button4Text;
                        break;
                    case "5":
                        button.Text = endpoint.button5Text;
                        break;
                    case "6":
                        button.Text = endpoint.button6Text;
                        break;
                    case "7":
                        button.Text = endpoint.button7Text;
                        break;
                    case "8":
                        button.Text = endpoint.button8Text;
                        break;
                    case "9":
                        button.Text = endpoint.button9Text;
                        break;
                    case "80":
                        button.Text = "Predicted Sun Spots";
                        break;
                    default:
                        button.Text = "";
                        break;
                }
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