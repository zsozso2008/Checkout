using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework.Internal;
using Checkout.Api.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ILogger = NUnit.Framework.Internal.ILogger;
using System.Threading.Tasks;

namespace Checkout.UnitTests.Controllers.BasketController
{
    public class BasketController_Create_tests
    {
        protected Mock<IMediator> mediatrMock;
        protected CreateBaschetCommand createBasketCommand;

        [SetUp]
        public void SetUp()
        {
            mediatrMock = new Mock<IMediator>();
            mediatrMock.Setup(x => x.Send(It.IsAny<CreateBaschetCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((CreateBaschetCommand createBasketCommand, CancellationToken cancellationToken) =>
                    Guid.NewGuid());
        }

        [Test]
        public async Task CreatBasketSucceedAsync()
        {
            var controller = new Api.Controllers.BasketController(Mock.Of<ILogger<Api.Controllers.BasketController>>(),
                mediatrMock.Object);
            var result = await controller.CreatBasket(createBasketCommand);
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
