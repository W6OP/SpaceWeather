using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6OP.HamCockpitPlugins.SpaceWeather
{
   public class JSONManager
    {
        //private readonly WebManager webManager = new WebManager();

        /// <summary>
        /// 
        /// </summary>
        public JSONManager()
        {

        }

        /// <summary>
        /// Fields (JSON)
        /// time-tag: yyyy-mm
        /// predicted_ssn: predicted sunspot number
        /// high_ssn: predicted sunspot number high range
        /// low_ssn: predicted sunspot number low range
        /// predicted_f10.7: predicted f10.7cm value
        /// high_f10.7: predicted f10.7cm high range
        /// low_f10.7: predicted f10.7cm low range
        /// </summary>
        /// <returns></returns>
        internal DataTable GetSunspotTable(string json)
        {
            return (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
        }
    } // end class
}

/*
 Sources

S.I.D.C. Brussels International Sunspot Number, Data Files (link is external).​
Penticton, B.C., Canada: 10.7cm radio flux values (sfu), Data Files (link is external).
Predicted values are based on the consensus of the Solar Cycle 25 Prediction Panel​

 */