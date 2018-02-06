using System.Web.Mvc;
using TfrRedo.Services.SearchStations.Queries.JourneyFinder;
using TfrRedo.Services.SearchStations.Queries.stationFinder;
using TfrRedo.ViewModels;

namespace TfrRedo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIndexPageViewModel _indexPageViewModel;
        private readonly IStationFinder _stationFinder;
        private  IStationFinderResultPageViewModel _stationFinderResultPageViewModel;
        private IJourneyfinder _journeyFinder;
        private IJourneyDetailsPageViewModel _journeyDetailsPageViewModel;
        public HomeController(
            IIndexPageViewModel indexPageViewModel, 
            IStationFinder stationFinder,
            IStationFinderResultPageViewModel stationFinderResultPageViewModel,
            IJourneyfinder journeyFinder,
            IJourneyDetailsPageViewModel journeyDetailsPageViewModel
            )
        {
            _indexPageViewModel = indexPageViewModel;
            _journeyFinder = journeyFinder;
            _stationFinder = stationFinder;
            _stationFinderResultPageViewModel = stationFinderResultPageViewModel;
            _journeyDetailsPageViewModel = journeyDetailsPageViewModel;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View(_indexPageViewModel);
        }
        [HttpPost]
        public ActionResult Index(IndexPageViewModel indexPageViewModel)
        {
            var stationFinder = _stationFinder.Get(indexPageViewModel.Arrival);
            _stationFinderResultPageViewModel.Stations = stationFinder.Matches;

           return View("StationFinderResultPage", _stationFinderResultPageViewModel);
        }

        [HttpPost]
        public ActionResult StationFinderResultPage(StationFinderResultPageViewModel stations)
        {
            var journeyDetails = _journeyFinder.Get(stations.SelectedStationIcsId);
            _journeyDetailsPageViewModel.Journey = journeyDetails;
            _journeyDetailsPageViewModel.Journey.LegsTrain = journeyDetails.Legs;

            return View("JourneyPlanner", _journeyDetailsPageViewModel);
        }

        [HttpPost]
        public ActionResult JourneyPlanner (StationFinderResultPageViewModel stationFinderviewModel)
        {
            var journeyDetails =  _journeyFinder.Get(stationFinderviewModel.SelectedStationIcsId);
            _journeyDetailsPageViewModel.Journey = journeyDetails;

            return View(_journeyDetailsPageViewModel);
        }

    }
}