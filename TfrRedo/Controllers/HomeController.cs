using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TfrRedo.Services.SearchStations.Queries.stationFinder;
using TfrRedo.ViewModels;

namespace TfrRedo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIndexPageViewModel _indexPageViewModel;
        private readonly IStationFinder _stationFinder;
        private  IStationFinderResultPageViewModel _stationFinderResultPageViewModel;
        public HomeController(
            IIndexPageViewModel indexPageViewModel, 
            IStationFinder stationFinder,
            IStationFinderResultPageViewModel stationFinderResultPageViewModel
            )
        {
            _indexPageViewModel = indexPageViewModel;
            _stationFinder = stationFinder;
            _stationFinderResultPageViewModel = stationFinderResultPageViewModel;
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

           return View(_stationFinderResultPageViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}