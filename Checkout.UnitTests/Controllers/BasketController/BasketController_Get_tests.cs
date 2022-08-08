using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Checkout.Api.Commands;
using Checkout.DataAccess.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Checkout.UnitTests.Controllers.BasketController
{
    public class BasketController_Get_tests
    {
        protected Mock<IMediator> mediatrMock;
        protected GetBasketCommand getBasketCommand;

        [SetUp]
        public void SetUp()
        {
            mediatrMock = new Mock<IMediator>();
            mediatrMock.Setup(x => x.Send(It.IsAny<GetBasketCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((GetBasketCommand createBasketCommand, CancellationToken cancellationToken) => new Basket());
        }

        [Test]
        public async Task GetBasketSucceedAsync()
        {
            var controller = new Api.Controllers.BasketController(Mock.Of<ILogger<Api.Controllers.BasketController>>(),
                mediatrMock.Object);
            var result = await controller.GetBasket(getBasketCommand);

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
