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

namespace TfrRedo.Tests
{
    [TestFixture]
    public class HomControllerTests
    {
        [Test]
        [Category("HomeControllerIndexMethodGet")]
        public void ShoudReturnIndexPageViewModel()
        {
            var _webApiStationFinder = new Mock<IWebApiStationFinder>();

            var sut = new StationFinder(_webApiStationFinder.Object);

            var departure = new IndexLandingPageModel
            {
                Name = "start"
            };

            var arrival = new IndexLandingPageModel
            {
                Name = "kings"
            };

            var test = sut.Get(departure, arrival);

            _webApiStationFinder.Verify(x => x.StationFinder(It.IsAny<IndexLandingPageModel>()));
        }

        [Test]
        [Category("HomeControllerIndexMethodGet")]
        public void ShouldReturnEmptyIndexPageVieWModel()
        {

        }

        [Test]
        [Category("HomeControllerIndexMethodGet")]
        public void ShouldDirectToIndexView()
        {

        }
    }
}
