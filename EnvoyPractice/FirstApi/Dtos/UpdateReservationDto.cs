﻿namespace FirstApi.Dtos
{
    public record UpdateReservationDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

    }

}
