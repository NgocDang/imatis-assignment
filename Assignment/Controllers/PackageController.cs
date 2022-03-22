using Features.PackageFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers;

[ApiController]
[Route("[controller]")]
public class PackageController : ControllerBase
{
    private readonly ILogger<PackageController> _logger;
    private readonly IMediator _mediator;

    public PackageController(ILogger<PackageController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<PackageDto>> GetAll()
        => await _mediator.Send(new GetAllPackagesQuery());
}
