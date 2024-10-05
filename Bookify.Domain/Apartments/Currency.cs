namespace Bookify.Domain.Apartments
{
    public sealed record Currency
    {
        internal static readonly Currency None = new("");
        public static readonly Currency Usd = new("USD");
        public static readonly Currency EUR = new("EUR");
        private Currency(string code) => Code = code;

        public string Code { get; init; }

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(c => c.Code == code)??
                throw new ApplicationException("The Currency Code Was Not Found");
        }

        public static readonly IReadOnlyCollection<Currency> All = new[]
        {
            Usd,
            EUR
        };
    }
}
