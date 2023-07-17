namespace SeconcdApi.Dtos
{
    public class ResponseDto
    {
        public string Fullname { get; }
        public string Email { get; }
        public string Message { get; }

        public ResponseDto(string fullname, string email, string message)
        {
            Fullname = fullname;
            Email = email;
            Message = message;
        }
    }
}
