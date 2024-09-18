﻿using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.ApplicationProject.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}
