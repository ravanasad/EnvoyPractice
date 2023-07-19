namespace FirstApi.Dtos
{
    public record UpdateReservationDto
    {
        public int Id { get; set; }
        string Fullname { get; set; }
        string Email { get; set; }
        string Message { get; set; }

    }
    
}
