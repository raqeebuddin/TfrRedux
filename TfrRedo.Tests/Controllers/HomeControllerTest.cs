
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Web.Mvc;
using Domain.Stations;
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

        [Test]
        public void ShouldReturnViewResultFromIndexMethod()
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

        [Test]
        public void ShouldCallStationFinderGetOnce()
        {
            var _mockIndexViewPageModel = new Mock<IIndexPageViewModel>();
            var _mockStationFinder = new Mock<IStationFinder>();
            var _mockStationFinderResultPageModel = new Mock<IStationFinderResultPageViewModel>();
            var _mockJourneyFinder = new Mock<IJourneyfinder>();
            var _mockJourneyDetailsPageViewModel = new Mock<IJourneyDetailsPageViewModel>();
            var _mockPreviousJourneyViewModel = new Mock<IPreviousJourneysViewModel>();

            var sut = new HomeController(_mockIndexViewPageModel.Object, _mockStationFinder.Object,
                _mockStationFinderResultPageModel.Object, _mockJourneyFinder.Object,
                _mockJourneyDetailsPageViewModel.Object, _mockPreviousJourneyViewModel.Object);

            _mockStationFinder.Setup(x => x.Get(It.IsAny<Station>(), It.IsAny<Station>())).Returns(
               new List<StationFinderResponseModel>()
               {
                   new StationFinderResponseModel(){Matches = new List<Station>(){new Station(){Name = "Station One"}}},
                   new StationFinderResponseModel(){Matches = new List<Station>(){new Station(){Name = "Station Two"}}}
               }
            );

            var FakeIndexLandingPageModel = new IndexPageViewModel()
            {
                Arrival = new Station() { Name = "Kings" },
                Departure = new Station() { Name = "Tott" }
            };

            sut.Index(FakeIndexLandingPageModel);


            _mockStationFinder.Verify(x => x.Get(It.IsAny<Station>(), It.IsAny<Station>()),
                Times.Exactly(1));

        }

        //[Test]
        //public void test()
        //{
        //    var _mockIndexViewPageModel = new Mock<IIndexPageViewModel>();
        //    var _mockStationFinder = new Mock<IStationFinder>();
        //    var _mockStationFinderResultPageModel = new Mock<IStationFinderResultPageViewModel>();
        //    var _mockJourneyFinder = new Mock<IJourneyfinder>();
        //    var _mockJourneyDetailsPageViewModel = new Mock<IJourneyDetailsPageViewModel>();
        //    var _mockPreviousJourneyViewModel = new Mock<IPreviousJourneysViewModel>();

        //    var sut = new HomeController(_mockIndexViewPageModel.Object, _mockStationFinder.Object,
        //        _mockStationFinderResultPageModel.Object, _mockJourneyFinder.Object,
        //        _mockJourneyDetailsPageViewModel.Object, _mockPreviousJourneyViewModel.Object);

        //    _mockStationFinder.Setup(x => x.Get(It.IsAny<Station>(), It.IsAny<Station>()));

        //    sut.Index(new IndexPageViewModel());

        //    _mockStationFinder.VerifyAll();

        //}
    }

}

