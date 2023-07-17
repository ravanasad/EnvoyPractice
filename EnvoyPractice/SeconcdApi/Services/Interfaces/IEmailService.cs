using SeconcdApi.Dtos;

namespace SeconcdApi.Services.Interfaces
{
    public interface IEmailService
    {
        public Task<ResponseDto> SendEmail(RequestDto request);
    }
}
