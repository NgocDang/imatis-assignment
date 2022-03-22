using Features.CustomerFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly IMediator _mediator;

    public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<CustomerDto>> Get()
        => await _mediator.Send(new GetAllCustomersQuery());
}
