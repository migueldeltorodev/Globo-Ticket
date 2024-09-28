using GloboTicket.TicketManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandResponse : BaseResponse
    {
        public UpdateEventCommandResponse() : base()
        {

        }
        public UpdateEventDto EventDto { get; set; }
    }
}
