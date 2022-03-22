using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Enums;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Features.CustomerFeatures.Queries;

public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerDto>>
{
}

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
{
    private readonly AssignmentDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllCustomersQueryHandler(AssignmentDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        => await _dbContext.Customers.Include(x => x.PromotionPrograms)
        .ThenInclude(x => x.Promotion)
        .OrderBy(x => x.Id)
        .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
        .ToListAsync();

}

public class CustomerDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public IEnumerable<CustomerPromotionDto> Promotions { get; set; }
}

public class CustomerPromotionDto
{
    public int Id { get; set; }

    public int PackageId { get; set; }

    public string Description { get; set; }

    public PromotionType PromotionType { get; set; }

    public int? BuyingXQuantity { get; set; }
    public int? PayingYQuantity { get; set; }

    public decimal? DiscountedPrice { get; set; }
}


