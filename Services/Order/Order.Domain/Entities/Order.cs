using Order.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Entities
{
    public class Order : EntityBase
    {
        public Order()
        {

        }
        public Order(Guid UserId, decimal amount)
        {
            Id = Guid.NewGuid();
            UserId = UserId;
            Balance = amount;
        }

        public Guid UserId { get; set; }
        public decimal Balance { get; set; }
    }
}
