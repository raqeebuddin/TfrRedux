using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFR.ViewModels;

namespace TFR.Controllers
{
    public class HomeController : Controller
    {
        private ILandingPageViewModel _landingPageViewModel;

        public HomeController(ILandingPageViewModel landingPageViewModel)
        {
            _landingPageViewModel = landingPageViewModel;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}