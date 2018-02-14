using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Stations;
using Moq;
using NUnit.Framework;
using TfrRedo.Controllers;
using TfrRedo.Services.Interfaces;
using TfrRedo.Services.SearchStations.Queries.stationFinder;
using TfrRedo.ViewModels;
using TfrRedo.WebApi.Queries;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TfrRedo.Tests
{
    [TestFixture]
    public class HomControllerTests
    {
        //[SetUp]
        //static void SetUp()
        //{
        //    Mock<HomeController> homeController = new Mock<HomeController>();
        //}

        //[TearDown]
       
        //static void TearDown()
        //{

        //}

        

        [Test]
        [Category("HomeControllerIndexMethodGet")]
        public void ShoudReturnIndexPageViewModel()
        {
            var mockIndexPageViewModel = new Mock<IIndexPageViewModel>();
            IIndexPageViewModel indexPageViewModel, IStationFinder stationFinder,
            IStationFinderResultPageViewModel stationFinderResultPageViewModel, IJourneyfinder journeyFinder,
            IJourneyDetailsPageViewModel journeyDetailsPageViewModel, IPreviousJourneysViewModel p
            var homeController = new HomeController(mockIndexPageViewModel);
            var stat = new StationFinder();
            int one = 1;

            Assert.AreEqual(one, 1);
        }
    }
}
