using Microsoft.AspNetCore.Mvc;
using Moq;
using P1.Interview.API.Controllers;
using P1.Interview.Domain;
using PI.Interview.Services;
using Xunit;

namespace P1.Interview.UnitTests
{
    public class ControllerTests
    {
        [Fact]
        public async void Test_That_Portfolio_Controller_Returns_List()
        {
            var serviceMock = new Mock<IPortfolioService>();
            serviceMock
                .Setup(s => s.GetNRandomPortfolios(It.IsAny<int>()))
                .ReturnsAsync(new PortfolioAggregate());

            var sut = new PortfolioController(serviceMock.Object);

            var result = await sut.GetRandomPortfoliosAsync(10);

            Assert.NotNull(result);
            Assert.IsType<ActionResult<PortfolioAggregate>>(result);

            serviceMock
                .Verify(s => s.GetNRandomPortfolios(It.IsAny<int>()),
                Times.Once);
        }
    }
}
