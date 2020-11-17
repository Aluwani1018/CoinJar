using Moq;
using Xunit;
using System.Linq;
using CoinJar.Core.Uow;
using CoinJar.Service.Services;
using CoinJar.Service.Services.Implementation;
using System.Collections.Generic;
using CoinJar.Core.Domain;


namespace CoinJar.Tests.Services
{
    public class CoinServiceTests
    {

        private Mock<IUnitOfWork> _unitOfWorkMock;
        
        private ICoinService _coinService;

        public CoinServiceTests()
        {
            SetupMocks();
            _coinService = new CoinService(_unitOfWorkMock.Object);
        }
        private void SetupMocks()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _unitOfWorkMock.Setup(r => r.Coins.Add(It.IsAny<Coin>())).Verifiable();
            _unitOfWorkMock.Setup(r => r.Coins.RemoveRange(It.IsAny<List<Coin>>())).Verifiable();
        }


        [Fact]
        public void Should_Add_Coin()
        {
            _coinService.AddCoin(DataUtilities.GetCoin());

            _unitOfWorkMock.Verify(r => r.Coins.Add(It.IsAny<Coin>()));
        }

        [Fact]
        public void Should_Reset_Coins()
        {
            _coinService.Reset();

            _unitOfWorkMock.Verify(r => r.Coins.RemoveRange(It.IsAny<List<Coin>>()));
        }

        [Fact]
        public void Should_Get_Total_Amount_When_No_Coin_Captured()
        {
            _unitOfWorkMock.Setup(r => r.Coins.GetAll()).Returns(new List<Coin>());
            
            decimal expectedTotalAmount = 0;
            decimal totalAmount = _coinService.GetTotalAmount();

            Assert.Equal(expectedTotalAmount, totalAmount);
        }

        [Fact]
        public void Should_Get_Total_Amount_For_Existing_Coins()
        {
            _unitOfWorkMock.Setup(r => r.Coins.GetAll()).Returns(DataUtilities.GetCoinsList());

            decimal expectedTotalAmount = DataUtilities.GetCoinsList().Sum(x => x.Amount);
            decimal totalAmount = _coinService.GetTotalAmount();

            Assert.Equal(expectedTotalAmount, totalAmount);
        }

    }
}
