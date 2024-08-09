using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Constants.Messages
{
    public static class OrderMessages
    {
        public const string UserRequired = "User is required.";
        public const string OrderRequired = "Order is required.";
        public const string AmountRequired = "Amount is required.";
        public const string AmountGreaterThanZero = "Amount must be greater than 0.";
        public const string UserNotFound = "User not found.";
        public const string OrderNotFound = "Order not found.";
    }
}
