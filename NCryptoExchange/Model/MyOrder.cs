using System;

namespace Lostics.NCryptoExchange.Model
{
    public class MyOrder<M, O> : Order
        where M : MarketId
        where O : OrderId
    {
        private readonly O orderId;
        private readonly M marketId;
        private readonly DateTime created;
        private readonly decimal originalQuantity;

        public MyOrder(O orderId, OrderType orderType,
            DateTime created, decimal price, decimal quantity, decimal originalQuantity,
            M marketId) : base(orderType, price, quantity)
        {
            this.orderId = orderId;
            this.created = created;
            this.originalQuantity = originalQuantity;
            this.marketId = marketId;
        }

        public O OrderId { get { return this.orderId; } }
        public DateTime Created { get { return this.created; } }
        public decimal OriginalQuantity { get { return this.originalQuantity; } }
        public M MarketId { get { return this.marketId; } }
    }
}
