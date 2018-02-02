using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TfrRedo.Services.SearchStations.Queries.GetStationDetails;
using TfrRedo.ViewModels;

namespace TfrRedo.Controllers
{
    public class HomeController : Controller
    {
        IIndexPageViewModel _indexPageViewModel;
        IStationFinder _getStationDetails;
        public HomeController(IIndexPageViewModel indexPageViewModel, IStationFinder getStationDetails)
        {
            _indexPageViewModel = indexPageViewModel;
            _getStationDetails = getStationDetails;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View(_indexPageViewModel);
        }
        [HttpPost]
        public ActionResult Index(IndexPageViewModel indexPageViewModel)
        {
           var stationDetails = _getStationDetails.Get(indexPageViewModel.Arrival);
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