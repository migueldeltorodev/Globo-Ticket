namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class CategoryEventDto
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
    }
}
