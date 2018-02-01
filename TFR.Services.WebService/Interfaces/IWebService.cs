using TFR.Data.Models;
using TFR.Data.Models.Stations;
using TFR.WebServices.Models.Responses;

namespace TFR.Services.WebService.Interfaces
{
    public interface IWebService
    {
        WebServiceResponseModel GetStation(IStation station);
        void GetJourneyList(IStation departure, IStation arrival);
    }
}
