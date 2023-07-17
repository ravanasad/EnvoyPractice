using Microsoft.EntityFrameworkCore;

namespace FirstApi.Data.DbContexts
{
    public class PrepDb
    {
        public static async Task PrepPopulationAsync(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            await SeedDataAsync(serviceScope.ServiceProvider.GetRequiredService<ReservationDbContext>());
        }
        private static async Task SeedDataAsync(ReservationDbContext context)
        {
            await context.Database.MigrateAsync();
        }
    }
}
