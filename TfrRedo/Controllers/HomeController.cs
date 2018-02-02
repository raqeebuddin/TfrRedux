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
        IIndexPageViewModel _indexPageViewModel;
        IStationFinder _stationFinder;
        public HomeController(IIndexPageViewModel indexPageViewModel, IStationFinder stationFinder)
        {
            _indexPageViewModel = indexPageViewModel;
            _stationFinder = stationFinder;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View(_indexPageViewModel);
        }
        [HttpPost]
        public ActionResult Index(IndexPageViewModel indexPageViewModel)
        {
           var stationDetails = _stationFinder.Get(indexPageViewModel.Arrival);
           return View();
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