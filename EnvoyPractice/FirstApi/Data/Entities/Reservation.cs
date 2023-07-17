using Shared.Entities;

namespace FirstApi.Data.Entities
{
    public record Reservation(int id, string Fullname, string Email, string Message) : BaseEntity(id);
}
