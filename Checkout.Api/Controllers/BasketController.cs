using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MediatR;
using Checkout.Api.Commands;

namespace Checkout.Api.Controllers
{
    [Route("api/v1/baskets")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _loggingService;
        private readonly IMediator _mediator;

        public BasketController(ILogger<BasketController> loggingService, IMediator mediator)
        {
            _loggingService = loggingService;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatBasket([FromBody] CreateBaschetCommand createBaschetCommand)
        {
            var result = await _mediator.Send(createBaschetCommand).ConfigureAwait(false);
            return this.Ok(new {baschetId = result});

        }

        [HttpPut("{basketId}/article-line")]
        public async Task<IActionResult> AddArticle([FromBody] AddArticleCommand addArticleCommand,
            [FromRoute] Guid basketId)
        {
            addArticleCommand.BasketId = basketId;
            var result = await _mediator.Send(addArticleCommand).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet("{basketId}")]
        public async Task<IActionResult> GetBasket([FromRoute] GetBasketCommand getBasketCommand)
        {
            var result = await _mediator.Send(getBasketCommand).ConfigureAwait(false);

            return this.Ok(result);
        }

        [HttpPatch("{basketId}")]
        public async Task<IActionResult> PayBasket([FromBody] PatchBasketCommand patchBasketCommand, [FromRoute] Guid basketId )
        {
            patchBasketCommand.BasketId = basketId;
            var result = await _mediator.Send(patchBasketCommand).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
