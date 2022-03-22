using Features.PromotionFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers;

[ApiController]
[Route("[controller]")]
public class PromotionController : ControllerBase
{
    private readonly ILogger<PromotionController> _logger;
    private readonly IMediator _mediator;

    public PromotionController(ILogger<PromotionController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<PromotionDto>> GetAll()
        => await _mediator.Send(new GetAllPromotionsQuery());
}
