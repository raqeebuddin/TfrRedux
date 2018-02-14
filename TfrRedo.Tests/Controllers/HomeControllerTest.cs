
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
        public void ShoudldRenderStationFinderResultPage()
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

            var mockIndexPageViewModel =
                new Mock<IndexPageViewModel>().Object;



            var mock = new Mock<IndexPageViewModel>();

            mock.SetupSet(m => m.Arrival = It.Is<IndexLandingPageModel>(station => station.Name == "Kings")).Verifiable();


            var result = sut.Index(mock.Object) as ViewResult;


            mock.Verify();

            Assert.That(result.ViewName, Is.EqualTo("StationFinderResultPage"));
        }


        //public void TestMethod()
        //{
        //    var serviceMock = new Mock<IMyService>();
        //    var objectUnderTest = new MyViewModel(serviceMock.Object);

        //    serviceMock.Setup(x => x.GetData()).Returns(42);

        //    var result = objectUnderTest.ShowSomething();

        //    Assert.AreEqual("Just a test 42", result);
        //    serviceMock.Verify(c => c.GetData(), Times.Once());
        //}


    }

}

