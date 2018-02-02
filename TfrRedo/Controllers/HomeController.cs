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
        IGetStationDetails _getStationDetails;
        public HomeController(IIndexPageViewModel indexPageViewModel, IGetStationDetails getStationDetails)
        {
            _indexPageViewModel = indexPageViewModel;
            _getStationDetails = getStationDetails;
        }
        public ActionResult Index()
        {
            return View(_indexPageViewModel);
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