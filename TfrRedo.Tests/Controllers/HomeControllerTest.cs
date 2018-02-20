
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Web.Mvc;
using Domain.Instructions;
using Domain.Legs;
using Domain.Stations;
using Moq;
using NUnit.Framework;

using TfrRedo.Controllers;
using TfrRedo.Services.SearchStations.Queries.JourneyFinder;
using TfrRedo.Services.SearchStations.Queries.stationFinder;
using TfrRedo.ViewModels;
using TFR.Data.Models.Journey;

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


        [Test]
        public void ShouldCallStationfinderResultPage()
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

            _mockJourneyFinder.Setup(x => x.Get(It.IsAny<string>(), It.IsAny<string>())).Returns(new Journey()
            {
                Legs = new List<Leg>()
                    {
                        new Leg()
                        {
                            Instruction = new Instruction(){Summary = "Legs Summary", Detailed = "Detailed"},
                            Id = 2,
                            Duration = 1,
                            Distance = 1,
                            DurationHours = 1,
                            DurationMinutes = 20
                        }

                    },

                LegsTrain = new List<Leg>()
                    {
                    new Leg()
                    {
                        Instruction = new Instruction(){Summary = "Train Leg Summary", Detailed = "Detailed"},
                        Id = 2,
                        Duration = 1,
                        Distance = 1,
                        DurationHours = 1,
                        DurationMinutes = 20
                    }
                    }
            });


            _mockJourneyDetailsPageViewModel.Setup(x => x.Journey).Returns(new Journey());

            var fakeStationFinderResultPageModel = new StationFinderResultPageViewModel();

            sut.StationFinderResultPage(fakeStationFinderResultPageModel);


            _mockJourneyFinder.Verify(x => x.Get(It.IsAny<string>(), It.IsAny<string>()),
                Times.Exactly(1));

        }
    }

}

