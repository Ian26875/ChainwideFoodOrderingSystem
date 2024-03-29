﻿using ChainwideFoodOrderingSystem.SeedWork.Entity;

namespace ChainwideFoodOrderingSystem.Orders.Entity.DomainEvents;

public class OrderMarkedAsPendingEvent : DomainEvent
{
    public Guid OrderId { get; }

    public OrderMarkedAsPendingEvent(OrderId orderId)
    {
        this.OrderId = orderId;
    }
}