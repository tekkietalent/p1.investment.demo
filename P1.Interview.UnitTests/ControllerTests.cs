using Moq;
using P1.Interview.API.Controllers;
using PI.Interview.Services;
using Xunit;

namespace P1.Interview.UnitTests
{
    public class ControllerTests
    {
        public async void Test_That_Portfolio_Controller_Returns_List()
        {
            var serviceMock = new Mock<IPortfolioService>();
            serviceMock
                .Setup(s => s.GetThreeRandomPortfolios())
                .ReturnsAsync(new Domain.PortfolioAggregate());

            var sut = new PortfolioController(serviceMock.Object);

            var result = sut.GetSample();

            Assert.NotNull(result);

            serviceMock
                .Verify(s => s.GetThreeRandomPortfolios(),
                Times.Once);
        }
    }
}
