using Moq;
using P1.Interview.Domain;
using P1.Interview.Infrastructure.Services;
using PI.Interview.Repository;
using System;
using Xunit;

namespace P1.Interview.UnitTests
{
    public class RepositoryTests
    {
        [Fact]
        public async void Test_That_Portfolio_Repository_Returns_List()
        {
            var secclClientMock = new Mock<ISecclHttpClient>();
            secclClientMock
                .Setup(s => s.GetEntityData<Portfolio[]>("Portfolio"))
                .ReturnsAsync(Array.Empty<Portfolio>());

            var sut = new PortfolioRepository(secclClientMock.Object);

            var result = await sut.GetPortfoliosForFirm();

            Assert.NotNull(result);

            secclClientMock
                .Verify(s => s.GetEntityData<Portfolio[]>("Portfolio"), 
                Times.Once);
        }
    }
}
