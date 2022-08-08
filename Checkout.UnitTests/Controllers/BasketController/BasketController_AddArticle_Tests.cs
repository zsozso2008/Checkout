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
    public class BasketController_AddArticle_Tests
    {
        protected Mock<IMediator> mediatrMock;
        protected AddArticleCommand addArticleCommand;

        [SetUp]
        public void SetUp()
        {
            mediatrMock = new Mock<IMediator>();
            mediatrMock.Setup(x => x.Send(It.IsAny<AddArticleCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((AddArticleCommand addArticleCommand, CancellationToken cancellationToken) =>
                    Guid.NewGuid());
            addArticleCommand = new AddArticleCommand();
        }

        [Test]
        public async Task CreatBasketSucceedAsync()
        {
            var controller = new Api.Controllers.BasketController(Mock.Of<ILogger<Api.Controllers.BasketController>>(),
                mediatrMock.Object);
            var result = await controller.AddArticle(addArticleCommand, Guid.NewGuid());
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
