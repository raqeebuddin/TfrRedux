using Domain.Stations;

namespace TfrRedo.ViewModels
{
    public class IndexPageViewModel : IIndexPageViewModel
    {
        public IndexLandingPageModel Arrival { get; set; }
        public IndexLandingPageModel Departure { get; set; }
    }
}