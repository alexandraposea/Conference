using Conference.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Conference.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly MediatR.IMediator _mediator;

        public SuggestionsController(MediatR.IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetSuggestions")]
        public async Task<List<GetSuggestions.Model>> GetSuggestedConferences(CancellationToken cancellationToken)
        {
            var query = new GetSuggestions.Query();
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }

    }
}
