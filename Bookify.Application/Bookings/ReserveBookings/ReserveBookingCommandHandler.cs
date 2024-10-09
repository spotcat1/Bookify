using Bookify.Application.Abstractions.Clocks;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Domain.Users;
using System.IO.Pipes;

namespace Bookify.Application.ReserveBookings
{
    internal sealed class ReserveBookingCommandHandler :
        ICommandHandler<ReserveBookingCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IBookingRepository _bokkingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PricingServices _pricingServices;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ReserveBookingCommandHandler(
            IUserRepository userRepository,
            IApartmentRepository apartmentRepository,
            IUnitOfWork unitOfWork,
            PricingServices pricingServices,
            IBookingRepository bokkingRepository,
            IDateTimeProvider dateTimeProvider)
        {
            _userRepository = userRepository;
            _apartmentRepository = apartmentRepository;
            _unitOfWork = unitOfWork;
            _pricingServices = pricingServices;
            _bokkingRepository = bokkingRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserGuid, cancellationToken);

            if (user is null)
            {
                return Result.Failure<Guid>(UserErrors.NotFound);
            }

            var apartment = await _apartmentRepository.GetByIdAsync(request.ApartmentGuid, cancellationToken);

            if (apartment is null)
            {
                return Result.Failure<Guid>(ApartmentErrors.NotFound);
            }

            var duration = DateRange.Create(request.StartDate, request.EndDate);

            if (await _bokkingRepository.IsOverlappingAsync(apartment,duration, cancellationToken))
            {
                return Result.Failure<Guid>(BookingErrors.Overlap);
            }

            var booking = Booking.Reserver(
                apartment,
                user.GUID,
                duration,
                _dateTimeProvider.utcNow,
                _pricingServices
                );

             _bokkingRepository.Add(booking);

            await _unitOfWork.SaveChangesAsync();

            return booking.GUID;
        }
    }
}
