using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Features.PackageFeatures.Queries;

public class GetAllPackagesQuery : IRequest<IEnumerable<PackageDto>>
{
}

public class GetAllPackagesQueryHandler : IRequestHandler<GetAllPackagesQuery, IEnumerable<PackageDto>>
{
    private readonly AssignmentDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllPackagesQueryHandler(AssignmentDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PackageDto>> Handle(GetAllPackagesQuery request, CancellationToken cancellationToken)
        => await _dbContext.Packages.OrderBy(x => x.Id).ProjectTo<PackageDto>(_mapper.ConfigurationProvider).ToListAsync();
}

public class PackageDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }
}