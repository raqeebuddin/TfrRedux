using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFR.Data.Models;
using TFR.WebServices.Models.Interfaces;

namespace TFR.WebServices.Models.Requests
{
    class WebService : IWebService
    {

        public void GetJourneyList(IStation departure, IStation arrival)
        {
            //var journey = String.Format(
            //   $"https://api.tfl.gov.uk/journey/journeyresults/{departure.Name}/to/{arrStation}?&mode=tube");

            //using (WebClient client = new WebClient())
            //{
            //    var json = client.DownloadString(JourneyCall);
            //    ItineraryResult data = JsonConvert.DeserializeObject<TrainFoldRide.Models.ItineraryResult>(json);

            //    Debug.WriteLine("The duration of this journey is: " + data.Journeys[0].Duration + " minutes");
            //    return data.Journeys[0];
            //}
        }

        public void GetStation(IStation station)
        {
           
        }
    }
}
