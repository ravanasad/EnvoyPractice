using MassTransit;
using SeconcdApi.Dtos;
using SeconcdApi.Services.Interfaces;
using Shared.Entities;

namespace SeconcdApi.Services
{
    public sealed class ReservationCreateConsumer : IConsumer<ReservationEvent>
    {
        private readonly ILogger<ReservationCreateConsumer> _logger;
        private readonly IEmailService _emailService;
        public ReservationCreateConsumer(ILogger<ReservationCreateConsumer> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public Task Consume(ConsumeContext<ReservationEvent> context)
        {
            RequestDto request = new RequestDto()
            {
                Email = context.Message.Email,
                Fullname = context.Message.Fullname,
                Message = context.Message.Message
            };
            _emailService.SendEmail(request);
            return Task.CompletedTask;
        }
    }
}
