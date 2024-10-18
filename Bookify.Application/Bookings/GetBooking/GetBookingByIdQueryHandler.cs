using Bookify.Application.Abstractions.Data;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Dapper;
using System.Data;

namespace Bookify.Application.Bookings.GetBooking
{
    internal sealed class GetBookingByIdQueryHandler :
        IQueryHandler<GetBookingByIdQuery, BookingResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetBookingByIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<BookingResponse>> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """

                SELECT
                     Guid AS GUID
                     Apartment_Guid AS ApartmentGuid
                     User_Guid AS UserGuid
                     status AS Status
                     price_for_period_amount AS PriceAmount
                     price_for_period_currency AS PriceCurrency
                     price_for_cleaning_amount AS CleaningFeeAmount
                     price_for_cleaning_currency AS CleaningFeeCurrency
                     price_for_amenities_amount AS AmenitiesUpChargeAmount
                     price_for_amenities_currency AS AmenitiesUpChargeCurrency
                     price_for_total_amount AS TotalPriceAmount
                     price_for_total_currency AS TotalPriceAmountCurrency
                     created_on_utc AS CreatedOnUtc
                     start_date AS DurationStart
                     end_date AS DurationEnd
                FROM bookings
                WHERE GUID = @bookingGuid 

                """;


            var booking = await connection.QueryFirstOrDefaultAsync<BookingResponse>(sql, new
            {
                request.BookingGuid
            });


            return booking;
        }
    }
}
