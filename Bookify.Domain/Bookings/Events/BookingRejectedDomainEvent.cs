﻿using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events
{
    public sealed record BookingRejectedDomainEvent(Guid BookingGuid) : IDomainEvent;
}
