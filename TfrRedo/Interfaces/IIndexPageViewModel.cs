using Domain.Stations;

namespace TfrRedo.ViewModels
{
    public interface IIndexPageViewModel
    {
        Station Departure { get; set; }
        Station Arrival { get; set; }
    }
}