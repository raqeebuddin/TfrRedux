﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using TFR.ViewModels;
using TFR.WebServices.Models.Interfaces;
using TFR.WebServices.Models.Responses;

namespace TFR.Controllers
{
    public class HomeController : Controller
    {
        private ILandingPageViewModel _landingPageViewModel;
        public IWebService _webService;
        public HomeController(
            ILandingPageViewModel landingPageViewModel,
            IWebService webService)
        {
            _landingPageViewModel = landingPageViewModel;
            _webService = webService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_landingPageViewModel);
        }

        [HttpPost]
        public ActionResult Index(LandingPageViewModel landingPageViewModel)
        {
            //var station = landingPageViewModel.ArrivalStation; 
            var model  = _webService.GetStation(landingPageViewModel.ArrivalStation);
            //_webService.GetStation(landingPageViewModel.DepartureStation);
            return RedirectToAction("Test", model);
        }

        [HttpGet]
        public ActionResult Test(WebServiceResponseModel model)
        {
            return View(model);
        }

    }
}