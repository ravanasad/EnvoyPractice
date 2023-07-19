using FirstApi.Services.Interfaces;
using MassTransit;
using Shared.Entities;

namespace FirstApi.Services
{
    public sealed class EventBust : IEventBus
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public EventBust(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublisAsync(ReservationEvent message, CancellationToken cancellationToken)
        => await _publishEndpoint.Publish<ReservationEvent>(message, cancellationToken);
    }
}
