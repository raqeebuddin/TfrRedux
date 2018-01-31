using TFR.Data.Models.Stations;

namespace TFR.ViewModels
{
    public class LandingPageViewModel : ILandingPageViewModel
    {
        public Station DepartureStation { get; set; }
        public Station ArrivalStation { get; set; }
    }
}