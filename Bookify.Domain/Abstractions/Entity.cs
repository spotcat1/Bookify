﻿namespace Bookify.Domain.Abstractions
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        protected Entity(Guid Guid)
        {
            GUID = Guid;
        }
        public Guid GUID { get; init; }

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _domainEvents.ToList();
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }


        protected void RaiseDomainEvents(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}