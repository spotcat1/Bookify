﻿namespace Bookify.Domain
{
    public record DateRange
    {
        private DateRange()
        {

        }

        public DateOnly Start { get; init; }
        public DateOnly End { get; init; }

        public int LengthInDays => End.DayNumber - Start.DayNumber;

        public static DateRange Create(DateOnly start, DateOnly end)
        {
            if (start > end)
            {
                throw new InvalidOperationException("invalid date");
            }

            return new DateRange
            {
                Start = start,
                End = end
            };
        }
    }

}