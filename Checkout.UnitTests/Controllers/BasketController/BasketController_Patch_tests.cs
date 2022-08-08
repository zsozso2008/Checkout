using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Checkout.Api.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Checkout.UnitTests.Controllers.BasketController
{
    public class BasketController_Patch_tests
    {
        protected Mock<IMediator> mediatrMock;
        protected PatchBasketCommand patchBasketCommand;

        [SetUp]
        public void SetUp()
        {
            mediatrMock = new Mock<IMediator>();
            mediatrMock.Setup(x => x.Send(It.IsAny<PatchBasketCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((PatchBasketCommand patchBasketCommand, CancellationToken cancellationToken) =>
                    Guid.NewGuid());
            patchBasketCommand = new PatchBasketCommand();
        }

        [Test]
        public async Task CreatBasketSucceedAsync()
        {
            var controller = new Api.Controllers.BasketController(Mock.Of<ILogger<Api.Controllers.BasketController>>(),
                mediatrMock.Object);
            var result = await controller.PayBasket(patchBasketCommand, Guid.NewGuid());
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
