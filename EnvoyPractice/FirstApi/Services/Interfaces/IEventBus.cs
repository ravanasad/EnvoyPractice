using Shared.Entities;

namespace FirstApi.Services.Interfaces
{
    public interface IEventBus
    {
        Task PublisAsync(ReservationEvent message, CancellationToken cancellationToken);
    }
}
