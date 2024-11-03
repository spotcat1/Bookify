﻿//using Bogus;
//using Bookify.Application.Abstractions.Data;
//using Bookify.Domain.Apartments;
//using Dapper;
//using Newtonsoft.Json;

//public static class SeedDataExtensions
//{
//    public static void SeedData(this IApplicationBuilder app)
//    {
//        using var scope = app.ApplicationServices.CreateScope();

//        var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
//        using var connection = sqlConnectionFactory.CreateConnection();

//        var faker = new Faker();

//        List<object> apartments = new();
//        for (var i = 0; i < 100; i++)
//        {
//            apartments.Add(new
//            {
//                Id = Guid.NewGuid(),
//                Name = faker.Company.CompanyName(),
//                Description = "Amazing view",
//                Country = faker.Address.Country(),
//                State = faker.Address.State(),
//                ZipCode = faker.Address.ZipCode(),
//                City = faker.Address.City(),
//                Street = faker.Address.StreetAddress(),
//                PriceAmount = faker.Random.Decimal(50, 1000),
//                PriceCurrency = "USD",
//                CleaningFeeAmount = faker.Random.Decimal(25, 200),
//                CleaningFeeCurrency = "USD",
//                Amenities = JsonConvert.SerializeObject(new List<string> { "Parking", "MountainView" }),
//                LastBookedOn = faker.Date.Between(new DateTime(1753, 1, 1), DateTime.Now)
//            });
//        }

//        const string sql = """
//            INSERT INTO dbo.apartments
//            (guid, name, description, address_country, address_state, address_zip_code, address_city, address_street, price_amount, price_currency, cleaning_fee_amount, cleaning_fee_currency, amenities, last_booked_on_utc)
//            VALUES(@Id, @Name, @Description, @Country, @State, @ZipCode, @City, @Street, @PriceAmount, @PriceCurrency, @CleaningFeeAmount, @CleaningFeeCurrency, @Amenities, @LastBookedOn);
//            """;

//        foreach (var apartment in apartments)
//        {
//            connection.Execute(sql, apartment);
//        }
//    }
//}
