using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQueryHandler : IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListVm>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesListWithEventsQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryEventListVm>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetCategoriesWithEventsAsync(request.IncludeHistory);
            return _mapper.Map<List<CategoryEventListVm>>(categories);
        }
    }
}
