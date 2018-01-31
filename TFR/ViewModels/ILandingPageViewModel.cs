using TFR.Data.Models.Stations;

namespace TFR.ViewModels
{
    public interface ILandingPageViewModel
    {
        Station DepartureStation { get; set; }
        Station ArrivalStation { get; set; }
    }
}
