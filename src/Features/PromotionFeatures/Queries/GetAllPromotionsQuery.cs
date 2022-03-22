using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Enums;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Features.PromotionFeatures.Queries;

public class GetAllPromotionsQuery : IRequest<IEnumerable<PromotionDto>>
{
}

public class GetAllPromotionsQueryHandler : IRequestHandler<GetAllPromotionsQuery, IEnumerable<PromotionDto>>
{
    private readonly AssignmentDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllPromotionsQueryHandler(AssignmentDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PromotionDto>> Handle(GetAllPromotionsQuery request, CancellationToken cancellationToken)
        => await _dbContext.Promotions.ProjectTo<PromotionDto>(_mapper.ConfigurationProvider).ToListAsync();
}

public class PromotionDto
{
    public int Id { get; set; }

    public int PackageId { get; set; }

    public string Description { get; set; }

    public PromotionType PromotionType { get; set; }

    public int? BuyingXQuantity { get; set; }
    public int? PayingYQuantity { get; set; }

    public decimal? DiscountedPrice { get; set; }
}