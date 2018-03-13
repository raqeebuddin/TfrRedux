using log4net;
using System.Web.Mvc;
using TfrRedo.Services.SearchStations.Queries.JourneyFinder;
using TfrRedo.Services.SearchStations.Queries.stationFinder;
using TfrRedo.ViewModels;

namespace TfrRedo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIndexPageViewModel _indexPageViewModel;
        private readonly IJourneyDetailsPageViewModel _journeyDetailsPageViewModel;
        private readonly IJourneyfinder _journeyFinder;
        private readonly IStationFinder _stationFinder;
        private readonly IStationFinderResultPageViewModel _stationFinderResultPageViewModel;
        private readonly IPreviousJourneysViewModel _previousJourneys;

        public HomeController(IIndexPageViewModel indexPageViewModel, IStationFinder stationFinder,
            IStationFinderResultPageViewModel stationFinderResultPageViewModel, IJourneyfinder journeyFinder,
            IJourneyDetailsPageViewModel journeyDetailsPageViewModel, IPreviousJourneysViewModel previousJourneys)
        {
            _indexPageViewModel = indexPageViewModel;
            _journeyFinder = journeyFinder;
            _stationFinder = stationFinder;
            _stationFinderResultPageViewModel = stationFinderResultPageViewModel;
            _journeyDetailsPageViewModel = journeyDetailsPageViewModel;
            _previousJourneys = previousJourneys;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ILog log = log4net.LogManager.GetLogger(typeof(HomeController));
            
                log.Debug("Debug message");
                log.Warn("Warn message");
                log.Error("Error message");
                log.Fatal("Fatal message");
                ViewBag.Title = "Home Page";
         
            return View(_indexPageViewModel);
        }

        [HttpPost]
        public ActionResult Index(IndexPageViewModel indexPageViewModel)
        {
            var stationFinder = _stationFinder.Get(indexPageViewModel.Departure, indexPageViewModel.Arrival);
            _stationFinderResultPageViewModel.DepartureStations = stationFinder[0].Matches;
            _stationFinderResultPageViewModel.ArrivalStations = stationFinder[1].Matches;
            return View("StationFinderResultPage" , _stationFinderResultPageViewModel);
        }

        [HttpPost]
        public ActionResult StationFinderResultPage(StationFinderResultPageViewModel stations)
        {
            var journeyDetails  = _journeyFinder.Get(stations.SelectedDepartureStationIcsId,
                stations.SelectedArrivalStationIcsId);
            _journeyDetailsPageViewModel.Journey = journeyDetails;
            _journeyDetailsPageViewModel.Journey.LegsTrain = journeyDetails.Legs;
            return View("JourneyPlanner", _journeyDetailsPageViewModel);
        }

        [HttpGet]
        public ActionResult PreviousJourneys()
        {
            _previousJourneys.Journeys = _journeyFinder.GetAllJourneys();
            return View(_previousJourneys);
        }
    }
}