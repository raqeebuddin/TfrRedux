using TFR.Data.Models;
using TFR.Data.Models.Stations;
using TFR.WebServices.Models.Responses;

namespace TFR.WebServices.Models.Interfaces
{
    public interface IWebService
    {
        WebServiceResponseModel GetStation(Station station);
        void GetJourneyList(IStation departure, IStation arrival);
    }
}
