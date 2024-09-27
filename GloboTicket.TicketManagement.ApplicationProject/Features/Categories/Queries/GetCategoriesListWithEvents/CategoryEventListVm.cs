namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class CategoryEventListVm
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<CategoryEventDto> Events { get; set; }
    }
}
