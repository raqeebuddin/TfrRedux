using TFR.Data.Models;

namespace TFR.WebServices.Models.Interfaces
{
    public interface IWebService
    {
        IWebServiceResponseModel GetStation(IStation station);
        void GetJourneyList(IStation departure, IStation arrival);
    }
}
