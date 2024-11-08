﻿// <auto-generated />
using System;
using Bookify.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookify.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241103102937_innit")]
    partial class innit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bookify.Domain.Apartments.Apartment", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<string>("Amenities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("amenities");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasColumnName("description");

                    b.Property<DateTime?>("LastBookedOnUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_booked_on_utc");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("name");

                    b.Property<long>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bigint")
                        .HasColumnName("version");

                    b.HasKey("GUID")
                        .HasName("pk_apartments");

                    b.ToTable("apartments", (string)null);
                });

            modelBuilder.Entity("Bookify.Domain.Bookings.Booking", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<Guid>("ApartmentGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("apartment_guid");

                    b.Property<DateTime?>("CancelledOnUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("cancelled_on_utc");

                    b.Property<DateTime?>("CompletedOnUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("completed_on_utc");

                    b.Property<DateTime?>("ConfirmedOnUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("confirmed_on_utc");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_on_utc");

                    b.Property<DateTime?>("RejectedOnUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("rejected_on_utc");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<Guid>("UserGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_guid");

                    b.HasKey("GUID")
                        .HasName("pk_bookings");

                    b.HasIndex("ApartmentGuid")
                        .HasDatabaseName("ix_bookings_apartment_guid");

                    b.HasIndex("UserGuid")
                        .HasDatabaseName("ix_bookings_user_guid");

                    b.ToTable("bookings", (string)null);
                });

            modelBuilder.Entity("Bookify.Domain.Review.Review", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<Guid>("ApartmentGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("apartment_guid");

                    b.Property<Guid>("BookingGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("booking_guid");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("comment");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_on_utc");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<Guid>("UserGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_guid");

                    b.HasKey("GUID")
                        .HasName("pk_reviews");

                    b.HasIndex("ApartmentGuid")
                        .HasDatabaseName("ix_reviews_apartment_guid");

                    b.HasIndex("BookingGuid")
                        .HasDatabaseName("ix_reviews_booking_guid");

                    b.HasIndex("UserGuid")
                        .HasDatabaseName("ix_reviews_user_guid");

                    b.ToTable("reviews", (string)null);
                });

            modelBuilder.Entity("Bookify.Domain.Users.User", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("last_name");

                    b.HasKey("GUID")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Bookify.Domain.Apartments.Apartment", b =>
                {
                    b.OwnsOne("Bookify.Domain.Apartments.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("ApartmentGUID")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("guid");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("address_city");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("address_country");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("address_state");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("address_street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("address_zip_code");

                            b1.HasKey("ApartmentGUID");

                            b1.ToTable("apartments");

                            b1.WithOwner()
                                .HasForeignKey("ApartmentGUID")
                                .HasConstraintName("fk_apartments_apartments_guid");
                        });

                    b.OwnsOne("Bookify.Domain.Apartments.Money", "CleaningFee", b1 =>
                        {
                            b1.Property<Guid>("ApartmentGUID")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("guid");

                            b1.Property<decimal>("Amount")
                                .HasPrecision(18, 2)
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("cleaning_fee_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("cleaning_fee_currency");

                            b1.HasKey("ApartmentGUID");

                            b1.ToTable("apartments");

                            b1.WithOwner()
                                .HasForeignKey("ApartmentGUID")
                                .HasConstraintName("fk_apartments_apartments_guid");
                        });

                    b.OwnsOne("Bookify.Domain.Apartments.Money", "Price", b1 =>
                        {
                            b1.Property<Guid>("ApartmentGUID")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("guid");

                            b1.Property<decimal>("Amount")
                                .HasPrecision(18, 2)
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("price_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("price_currency");

                            b1.HasKey("ApartmentGUID");

                            b1.ToTable("apartments");

                            b1.WithOwner()
                                .HasForeignKey("ApartmentGUID")
                                .HasConstraintName("fk_apartments_apartments_guid");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("CleaningFee")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("Bookify.Domain.Bookings.Booking", b =>
                {
                    b.HasOne("Bookify.Domain.Apartments.Apartment", null)
                        .WithMany()
                        .HasForeignKey("ApartmentGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bookings_apartments_apartment_guid");

                    b.HasOne("Bookify.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bookings_users_user_guid");

                    b.OwnsOne("Bookify.Domain.Apartments.Money", "AmenitiesUpCharge", b1 =>
                        {
                            b1.Property<Guid>("BookingGUID")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("guid");

                            b1.Property<decimal>("Amount")
                                .HasPrecision(18, 2)
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("amenities_up_charge_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("amenities_up_charge_currency");

                            b1.HasKey("BookingGUID");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingGUID")
                                .HasConstraintName("fk_bookings_bookings_guid");
                        });

                    b.OwnsOne("Bookify.Domain.Apartments.Money", "CleaningFee", b1 =>
                        {
                            b1.Property<Guid>("BookingGUID")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("guid");

                            b1.Property<decimal>("Amount")
                                .HasPrecision(18, 2)
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("cleaning_fee_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("cleaning_fee_currency");

                            b1.HasKey("BookingGUID");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingGUID")
                                .HasConstraintName("fk_bookings_bookings_guid");
                        });

                    b.OwnsOne("Bookify.Domain.Apartments.Money", "PriceForPeriod", b1 =>
                        {
                            b1.Property<Guid>("BookingGUID")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("guid");

                            b1.Property<decimal>("Amount")
                                .HasPrecision(18, 2)
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("price_for_period_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("price_for_period_currency");

                            b1.HasKey("BookingGUID");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingGUID")
                                .HasConstraintName("fk_bookings_bookings_guid");
                        });

                    b.OwnsOne("Bookify.Domain.Apartments.Money", "TotalPrice", b1 =>
                        {
                            b1.Property<Guid>("BookingGUID")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("guid");

                            b1.Property<decimal>("Amount")
                                .HasPrecision(18, 2)
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("total_price_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("total_price_currency");

                            b1.HasKey("BookingGUID");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingGUID")
                                .HasConstraintName("fk_bookings_bookings_guid");
                        });

                    b.OwnsOne("Bookify.Domain.DateRange", "Duration", b1 =>
                        {
                            b1.Property<Guid>("BookingGUID")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("guid");

                            b1.Property<DateOnly>("End")
                                .HasColumnType("date")
                                .HasColumnName("duration_end");

                            b1.Property<DateOnly>("Start")
                                .HasColumnType("date")
                                .HasColumnName("duration_start");

                            b1.HasKey("BookingGUID");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingGUID")
                                .HasConstraintName("fk_bookings_bookings_guid");
                        });

                    b.Navigation("AmenitiesUpCharge")
                        .IsRequired();

                    b.Navigation("CleaningFee")
                        .IsRequired();

                    b.Navigation("Duration")
                        .IsRequired();

                    b.Navigation("PriceForPeriod")
                        .IsRequired();

                    b.Navigation("TotalPrice")
                        .IsRequired();
                });

            modelBuilder.Entity("Bookify.Domain.Review.Review", b =>
                {
                    b.HasOne("Bookify.Domain.Apartments.Apartment", null)
                        .WithMany()
                        .HasForeignKey("ApartmentGuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_apartments_apartment_guid");

                    b.HasOne("Bookify.Domain.Bookings.Booking", null)
                        .WithMany()
                        .HasForeignKey("BookingGuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_bookings_booking_guid");

                    b.HasOne("Bookify.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserGuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_users_user_guid");
                });
#pragma warning restore 612, 618
        }
    }
}
