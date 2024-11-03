using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class innit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "apartments",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    address_country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address_state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address_zip_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address_street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price_amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    price_currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cleaning_fee_amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    cleaning_fee_currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_booked_on_utc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    amenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_apartments", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    apartment_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    duration_start = table.Column<DateOnly>(type: "date", nullable: false),
                    duration_end = table.Column<DateOnly>(type: "date", nullable: false),
                    price_for_period_amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    price_for_period_currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cleaning_fee_amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    cleaning_fee_currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amenities_up_charge_amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    amenities_up_charge_currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total_price_amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    total_price_currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    confirmed_on_utc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rejected_on_utc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    completed_on_utc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    cancelled_on_utc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bookings", x => x.guid);
                    table.ForeignKey(
                        name: "fk_bookings_apartments_apartment_guid",
                        column: x => x.apartment_guid,
                        principalTable: "apartments",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bookings_users_user_guid",
                        column: x => x.user_guid,
                        principalTable: "users",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    apartment_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    booking_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    created_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reviews", x => x.guid);
                    table.ForeignKey(
                        name: "fk_reviews_apartments_apartment_guid",
                        column: x => x.apartment_guid,
                        principalTable: "apartments",
                        principalColumn: "guid");
                    table.ForeignKey(
                        name: "fk_reviews_bookings_booking_guid",
                        column: x => x.booking_guid,
                        principalTable: "bookings",
                        principalColumn: "guid");
                    table.ForeignKey(
                        name: "fk_reviews_users_user_guid",
                        column: x => x.user_guid,
                        principalTable: "users",
                        principalColumn: "guid");
                });

            migrationBuilder.CreateIndex(
                name: "ix_bookings_apartment_guid",
                table: "bookings",
                column: "apartment_guid");

            migrationBuilder.CreateIndex(
                name: "ix_bookings_user_guid",
                table: "bookings",
                column: "user_guid");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_apartment_guid",
                table: "reviews",
                column: "apartment_guid");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_booking_guid",
                table: "reviews",
                column: "booking_guid");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_user_guid",
                table: "reviews",
                column: "user_guid");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "apartments");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
