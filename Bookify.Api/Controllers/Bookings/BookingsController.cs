﻿using Bookify.Application.Bookings.GetBooking;
using Bookify.Application.ReserveBookings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Controllers.Bookings
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly ISender _sender;

        public BookingsController(ISender sender)
        {
            _sender = sender;
        }



        [HttpPost]

        public async Task<IActionResult> AddBooking(AddBookingRequest request,
            CancellationToken cancellationToken)
        {
            var command = new ReserveBookingCommand(request.UserGuid,
                request.ApartmentGuid,
                request.StartDate,
                request.EndDate);

            var result = await _sender.Send(command,cancellationToken);
            
            if(result.IsFailure)
                return BadRequest(result.Error);

            return CreatedAtAction(nameof(AddBooking), new { id = result.Value }, result.Value);
        }


        [HttpGet("{Guid}")]
        public async Task<IActionResult> GetBooking([FromRoute] Guid Guid,
            CancellationToken cancellationToken)
        {
            var query = new GetBookingByIdQuery(Guid);

            var result = await _sender.Send(query, cancellationToken);

           return result.IsSuccess ? Ok(result.Value) : NotFound();
        }
    }
}
