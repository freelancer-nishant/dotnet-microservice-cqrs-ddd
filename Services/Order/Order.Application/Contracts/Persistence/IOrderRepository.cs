﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contracts.Persistence
{
    public interface IOrderRepository : IRepositoryBase<Domain.Entities.Order>
    {
    }
}
