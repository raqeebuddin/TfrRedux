using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TfrRedo.Controllers;
using TfrRedo.ViewModels;

namespace TfrRedo.Tests
{
    [TestFixture]
    public class HomControllerTests
    {
        [Test]
        [Category("HomeControllerIndexMethodGet")]
        public void ShoudReturnIndexPageViewModel()
        {
            var fakeTest = new Mock<IIndexPageViewModel>();
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
