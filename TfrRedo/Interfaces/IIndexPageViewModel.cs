using Domain.Stations;

namespace TfrRedo.ViewModels
{
    public interface IIndexPageViewModel
    {
        IndexLandingPageModel Departure { get; set; }
        IndexLandingPageModel Arrival { get; set; }
    }
}