using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFR.ViewModels;
using TFR.WebServices.Models.Interfaces;

namespace TFR.Controllers
{
    public class HomeController : Controller
    {
        private ILandingPageViewModel _landingPageViewModel;
        private IWebServicRequestModele  _webService;
        public HomeController(ILandingPageViewModel landingPageViewModel)
        {
            _landingPageViewModel = landingPageViewModel;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_landingPageViewModel);
        }

        [HttpPost]
        public ActionResult Index(ILandingPageViewModel landingPageViewModel)
        {
            return View(_landingPageViewModel);
        }
    }
}