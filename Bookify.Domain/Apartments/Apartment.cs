﻿using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Apartments
{
    public sealed class Apartment : Entity
    {
        public Apartment(
            Guid Guid,
            Name name,
            Description description,
            Address address,
            Money price,
            Money cleaningFee,
            DateTime? lastBookedOnUtc,
            List<Amenity> amenities) : base(Guid)
        {
            Name = name;
            Description = description;
            Address = address; 
            Price = price;
            CleaningFee = cleaningFee;
            LastBookedOnUtc = lastBookedOnUtc;
            Amenities = amenities;
        }
        public Name Name { get; private set; }
        public Description Description { get; private set; }
        public Address Address { get; private set; }
        public Money Price { get; private set; }
        public Money CleaningFee { get; private set;   }
        public DateTime? LastBookedOnUtc { get; private set; }
        public List<Amenity> Amenities { get; private set; } = new();
    }
}
