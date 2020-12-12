using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6OP.HamCockpitPlugins.SpaceWeather
{
    /// <summary>
    /// Containor for button properties at run time.
    /// </summary>
    public class Endpoint
    {
        public Endpoint()
        {

        }

        public string button1Address = "https://services.swpc.noaa.gov/images/swx-overview-small.gif";
        public string button1Caption = "Space Weather";
        public string button1Comment = "";
        public string button1Text = "Space Weather";

        public string button2Address = "https://services.swpc.noaa.gov/images/station-k-index.png";
        public string button2Caption = "Station K Index";
        public string button2Comment = "";
        public string button2Text = "Station K Index";

        public string button3Address = "https://services.swpc.noaa.gov/images/station-a-index.png";
        public string button3Caption = "Station A Index";
        public string button3Comment = "";
        public string button3Text = "Station A Index";

        public string button4Address = "https://services.swpc.noaa.gov/images/planetary-k-index.gif";
        public string button4Caption = "Planetary K Index";
        public string button4Comment = "";
        public string button4Text = "Planetary K Index";

        public string button5Address = "https://services.swpc.noaa.gov/images/animations/enlil/latest.jpg";
        public string button5Caption = "(CME) Solar Wind Prediction Model";
        public string button5Comment = "";
        public string button5Text = "CME Prediction";

        public string button6Address = "https://www.sws.bom.gov.au/Images/HF%20Systems/Global%20HF/Ionospheric%20Map/WorldIMap.gif";
        public string button6Caption = "Ionospheric World Map";
        public string button6Comment = "";
        public string button6Text = "Ionospheric Map";

        public string button7Address = "https://sohowww.nascom.nasa.gov/data/synoptic/sunspots_earth/mdi_sunspots.jpg";
        public string button7Caption = "Sun Spots";
        public string button7Comment = "";
        public string button7Text = "Sun Spots";

        public string button8Address = "https://sohowww.nascom.nasa.gov/data/realtime/hmi_igr/512/latest.jpg";
        public string button8Caption = "SDO/HMI Continuum";
        public string button8Comment = "";
        public string button8Text = "SDO/HMI Continuum";

        public string button9Address = "https://sohowww.nascom.nasa.gov/data/realtime/hmi_mag/512/latest.jpg";
        public string button9Caption = "SDO HMI Magnetogram";
        public string button9Comment = "";
        public string button9Text = "SDO/HMI Magnetogram";

    } // end class

}
/*

  static let button7Address = "https://sohowww.nascom.nasa.gov/data/LATEST/current_eit_195.gif"
  static let button7Caption = "other"
  static let button7Comment = ""
  static let button7Text = "Other"
 
  static let button10Address = "https://sohowww.nascom.nasa.gov/data/realtime/hmi_mag/512/latest.jpg"
  static let button10Caption = "SDO HMI Magnetogram Image"
  static let button10Comment = ""
  static let button10Text = "SDO/HMI Magnetogram"
 */