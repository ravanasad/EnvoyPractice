using AutoMapper;
using FirstApi.Data.Entities;
using FirstApi.Dtos;
using FirstApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
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
        public async Task<IActionResult> CreateReservation(CreateReservationDto request)
        {
            var mappedRequest = _mapper.Map<Reservation>(request);
            var response = _reservationService.AddAsync(mappedRequest);
            var mappedRespone = _mapper.Map<ReservationDto>(response);
            return Ok(mappedRespone);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReservation(UpdateReservationDto request)
        {
            var mappedRequest = _mapper.Map<Reservation>(request);
            var response = _reservationService.UpdateAsync(mappedRequest);
            var mappedRespone = _mapper.Map<ReservationDto>(response);
            return Ok(mappedRespone);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            Reservation reservation = await _reservationService.GetByIdAsync(id);
            var response = _reservationService.DeleteAsync(reservation);
            var mappedRespone = _mapper.Map<ReservationDto>(response);
            return Ok(mappedRespone);
        }
    }
}
