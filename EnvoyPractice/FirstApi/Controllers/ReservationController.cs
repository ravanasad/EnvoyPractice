using AutoMapper;
using FirstApi.Data.Entities;
using FirstApi.Dtos;
using FirstApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities;

namespace FirstApi.Controllers
{
    [Route("reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;
        public ReservationController(IReservationService reservationService, IMapper mapper, IEventBus eventBus)
        {
            _reservationService = reservationService;
            _mapper = mapper;
            _eventBus = eventBus;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservatoin(int id)
        {
            var response = await _reservationService.GetByIdAsync(id);
            var mappedRespone = _mapper.Map<ReservationDto>(response);
            return Ok(mappedRespone);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservatoins()
        {
            var response = await _reservationService.GetWhereAsync();
            var mappedRespone = _mapper.Map<List<ReservationDto>>(response);
            return Ok(mappedRespone);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDto request, CancellationToken token)
        {
            var mappedRequest = _mapper.Map<Reservation>(request);
            var response = await _reservationService.AddAsync(mappedRequest);

            await _eventBus.PublisAsync(new ReservationEvent()
            {
                Email = request.Email,
                Fullname = request.Fullname,
                Message = request.Message
            }, token);

            var mappedRespone = _mapper.Map<ReservationDto>(response);
            return Ok(mappedRespone);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReservation(UpdateReservationDto request)
        {
            var mappedRequest = _mapper.Map<Reservation>(request);
            var response = await _reservationService.UpdateAsync(mappedRequest);
            var mappedRespone = _mapper.Map<ReservationDto>(response);
            return Ok(mappedRespone);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            Reservation reservation = await _reservationService.GetByIdAsync(id);
            var response = await _reservationService.DeleteAsync(reservation);
            var mappedRespone = _mapper.Map<ReservationDto>(response);
            return Ok(mappedRespone);
        }
    }
}
