
using System.Web.Mvc;
using Moq;
using NUnit.Framework;

using TfrRedo.Controllers;
using TfrRedo.Services.SearchStations.Queries.JourneyFinder;
using TfrRedo.Services.SearchStations.Queries.stationFinder;
using TfrRedo.ViewModels;

namespace TfrRedo.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private IIndexPageViewModel _mockIndexViewPageModel;
        private IStationFinder _mockStationFinder;
        private IStationFinderResultPageViewModel _mockStationFinderResultPageModel;
        private IJourneyfinder _mockJourneyFinder;
        private IJourneyDetailsPageViewModel _mockJourneyDetailsPageViewModel;
        private IPreviousJourneysViewModel _mockPreviousJourneyViewModel;

        //[SetUp]
        //private void SetUp()
        //{
        //    _mockIndexViewPageModel = new Mock<IIndexPageViewModel>().Object;
        //    _mockStationFinder = new Mock<IStationFinder>().Object;
        //    _mockStationFinderResultPageModel = new Mock<IStationFinderResultPageViewModel>().Object;
        //    _mockJourneyFinder = new Mock<IJourneyfinder>().Object;
        //    _mockJourneyDetailsPageViewModel = new Mock<IJourneyDetailsPageViewModel>().Object;
        //    _mockPreviousJourneyViewModel = new Mock<IPreviousJourneysViewModel>().Object;

        //}

        [Test]
        public void ShouldReturnIndexViewPageViewModel()
        {
            _mockIndexViewPageModel = new Mock<IIndexPageViewModel>().Object;
            _mockStationFinder = new Mock<IStationFinder>().Object;
            _mockStationFinderResultPageModel = new Mock<IStationFinderResultPageViewModel>().Object;
            _mockJourneyFinder = new Mock<IJourneyfinder>().Object;
            _mockJourneyDetailsPageViewModel = new Mock<IJourneyDetailsPageViewModel>().Object;
            _mockPreviousJourneyViewModel = new Mock<IPreviousJourneysViewModel>().Object;

            var sut = new HomeController(
                _mockIndexViewPageModel,
                _mockStationFinder, _mockStationFinderResultPageModel, _mockJourneyFinder,
                _mockJourneyDetailsPageViewModel, _mockPreviousJourneyViewModel);


            var result = sut.Index();

            Assert.That(result, Is.TypeOf<ViewResult>());

        }

    }

}

