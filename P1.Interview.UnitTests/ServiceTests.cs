using Moq;
using P1.Interview.Domain;
using PI.Interview.Repository;
using PI.Interview.Services;
using Xunit;

namespace P1.Interview.UnitTests
{
    public class ServiceTests
    {
        [Fact]
        public async void Test_That_Portfolio_Service_Returns_List_Of_Three()
        {
            var repoMock = new Mock<IPortfolioRepository>();
            repoMock
                .Setup(s => s.GetPortfoliosForFirm())
                .ReturnsAsync(new Portfolio[] { new Portfolio(),
            new Portfolio(), new Portfolio(), new Portfolio(), new Portfolio() });

            var sut = new PortfolioService(repoMock.Object);

            var result = await sut.GetNRandomPortfolios(3);

            Assert.NotNull(result);
            Assert.IsType<PortfolioAggregate>(result);
            Assert.Equal(3, result.Portfolios.Count);

            repoMock
                .Verify(s => s.GetPortfoliosForFirm(),
                Times.Once);
        }
    }
}
